using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ADODB;
using System.Net.Mail;
using Microsoft.VisualBasic;
using MSXML2;
using Scripting;

namespace Craigslist_Emailer
{
    public partial class frmEmailSettings_Kijiji : Form
    {
        ADODB.Connection conn;
        ADODB.Recordset rsTemplates;

        public frmEmailSettings_Kijiji()
        {
            InitializeComponent();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                //ADODB.Connection conn = new ADODB.Connection();
                //conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\Db_Kijiji.mdb;Persist Security Info=False";
                //conn.Open(conn.ConnectionString, string.Empty, string.Empty, 0);
                string que = string.Empty;
                object retObj;
                que = "insert into SMTP values('" + txtUrl.Text.Replace("'", "''") + "'";
                que += ",'" + txtUsername.Text.Replace("'", "''") + "'";
                que += ",'" + txtPassword.Text.Replace("'", "''") + "'";
                que += ",''"; // Message
                que += ",'" + txtName.Text.Replace("'", "''") + "'";
                que += ",''"; //Subject
                if (chkSSLTop.Checked == true)
                    que += ",1)";
                else
                    que += ",0)";
                conn.Execute("delete * from SMTP", out retObj, 0);
                conn.Execute(que, out retObj, 0);
                //conn.Close();

                MessageBox.Show("Settings Saved Successfully", "Settings Saved", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Settings were not saved successfully due to some errors, please try again !", "Settings Saved", MessageBoxButtons.OK);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmailSettings_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new ADODB.Connection();
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\Db_Kijiji.mdb;Persist Security Info=False";
                conn.Open(conn.ConnectionString, string.Empty, string.Empty, 0);
                ADODB.Recordset rs = new ADODB.Recordset();

                #region "Load POP3 Settings"
                rs.Open("Select * from SMTP", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
                while (!rs.EOF)
                {
                    txtUrl.Text = rs.Fields["SMTPUrl"].Value.ToString();
                    txtUsername.Text = rs.Fields["SMTPUsername"].Value.ToString();
                    txtPassword.Text = rs.Fields["SMTPPassword"].Value.ToString();
                    txtName.Text = rs.Fields["From"].Value.ToString();
                    //txtSubject.Text = rs.Fields["Subject"].Value.ToString();
                    //txtMessage.Text = rs.Fields["Message"].Value.ToString();
                    rs.MoveNext();
                }
                rs.Close();
                #endregion

                rsTemplates = new ADODB.Recordset();
                rsTemplates.Open("Select * from Templates", conn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, 0);

                #region "Load POP3 Settings"
                //rs.Open("Select * from Templates", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
                //while (!rs.EOF)
                //{
                //    lstTemplates.Items.Add(rs.Fields["Subject"].Value.ToString());
                //    rs.MoveNext();
                //}
                //rs.Close();
                LoadTemplates();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendTestEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string ToEmail = Microsoft.VisualBasic.Interaction.InputBox("Please enter email address you want to send test email to?", "Send Test Email", "", 0, 0);
                MailMessage message = new MailMessage(txtName.Text, ToEmail, "This is Test Message from CL Emailer","This is Test Message from CL Emailer");
                SmtpClient emailClient = new SmtpClient(txtUrl.Text);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(txtUsername.Text, txtPassword.Text);
                emailClient.UseDefaultCredentials = false;
                emailClient.Credentials = SMTPUserInfo;
                if (chkSSLTop.Checked == true)
                    emailClient.EnableSsl = true;
                else
                    emailClient.EnableSsl = false;
                emailClient.Send(message);
                MessageBox.Show("Test Email Sent Successfully.", "Test Email Sent", MessageBoxButtons.OK);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rsTemplates.MoveFirst();
                rsTemplates.Find("Subject='" + lstTemplates.SelectedItem.ToString().Split('-')[1].Trim() + "'", 0, SearchDirectionEnum.adSearchForward, 1);
                if (!rsTemplates.EOF)
                {
                    txtEmail.Text = rsTemplates.Fields["Email"].Value.ToString();
                    txtSubject.Text = rsTemplates.Fields["Subject"].Value.ToString();
                    txtMessage.Text = rsTemplates.Fields["Message"].Value.ToString();
                    txtTUrl.Text = rsTemplates.Fields["Url"].Value.ToString();
                    txtTUsername.Text = rsTemplates.Fields["Username"].Value.ToString();
                    txtTPasswd.Text = rsTemplates.Fields["Password"].Value.ToString();
                }
            }
            catch (Exception ex)
            { }
            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";
            btnAdd.Enabled = false;
            txtTUrl.Text = "";
            txtTUsername.Text = "";
            txtTPasswd.Text = "";
        }

        private void LoadTemplates()
        {
            try
            {
                lstTemplates.Items.Clear();
                if(rsTemplates.State == 1) rsTemplates.Close();
                rsTemplates.Open("Select * from Templates", conn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, 0);
                while (!rsTemplates.EOF)
                {
                    lstTemplates.Items.Add(rsTemplates.Fields["Email"].Value.ToString() + " - " + rsTemplates.Fields["Subject"].Value.ToString());
                    rsTemplates.MoveNext();
                }
            }
            catch (Exception ex) { }
            txtSubject.Text = "";
            txtMessage.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Enabled == false) //Add new
                {
                    object recs;
                    rsTemplates.AddNew("Subject", "");
                    rsTemplates.Fields["Subject"].Value = txtSubject.Text;
                    rsTemplates.Fields["Message"].Value = txtMessage.Text;
                    rsTemplates.Fields["Email"].Value = txtEmail.Text;
                    rsTemplates.Fields["Url"].Value = txtTUrl.Text;
                    rsTemplates.Fields["Username"].Value = txtTUsername.Text;
                    rsTemplates.Fields["Password"].Value = txtTPasswd.Text;
                    if (chkSSLBelow.Checked == true)
                        rsTemplates.Fields["EnableSSL"].Value = 1;
                    else
                        rsTemplates.Fields["EnableSSL"].Value = 0;
                    rsTemplates.UpdateBatch(AffectEnum.adAffectAll);

                    btnAdd.Enabled = true;
                }
                else //Update existing
                {
                    object recs;
                    rsTemplates.MoveFirst();
                    rsTemplates.Find("Subject='" + lstTemplates.SelectedItem.ToString().Split('-')[1].Trim() + "'", 0, SearchDirectionEnum.adSearchForward, 1);
                    if (!rsTemplates.EOF)
                    {
                        rsTemplates.Fields["Subject"].Value = txtSubject.Text;
                        rsTemplates.Fields["Message"].Value = txtMessage.Text;
                        rsTemplates.Fields["Email"].Value = txtEmail.Text;
                        rsTemplates.Fields["Url"].Value = txtTUrl.Text;
                        rsTemplates.Fields["Username"].Value = txtTUsername.Text;
                        rsTemplates.Fields["Password"].Value = txtTPasswd.Text;
                        if (chkSSLBelow.Checked == true)
                            rsTemplates.Fields["EnableSSL"].Value = 1;
                        else
                            rsTemplates.Fields["EnableSSL"].Value = 0;
                        rsTemplates.UpdateBatch(AffectEnum.adAffectAll);
                    }
                }
                LoadTemplates();
            }
            catch (Exception ex) { }
            txtSubject.Text = "";
            txtMessage.Text = "";
            txtEmail.Text = "";
            txtTUrl.Text = "";
            txtTUsername.Text = "";
            txtTPasswd.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rsTemplates.MoveFirst();
                rsTemplates.Find("Subject='" + lstTemplates.SelectedItem.ToString().Split('-')[1].Trim() + "'", 0, SearchDirectionEnum.adSearchForward, 1);
                if (!rsTemplates.EOF)
                {
                    rsTemplates.Delete(AffectEnum.adAffectCurrent);
                }
                LoadTemplates();
            }
            catch (Exception ex) { }
        }

        private void frmEmailSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}