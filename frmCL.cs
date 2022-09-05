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
    public partial class frmCL : Form
    {
        bool Active;
        public frmCL()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ADODB.Connection conn = new ADODB.Connection();
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\Db_Craigslist.mdb;Persist Security Info=False";
            conn.Open(conn.ConnectionString, string.Empty, string.Empty, 0);
            TreeNode nd;
            ADODB.Recordset rs = new ADODB.Recordset();

            #region Read Categories
            rs.Open("Select distinct Category from Categories", conn,CursorTypeEnum.adOpenStatic,LockTypeEnum.adLockReadOnly,0);
            while(!rs.EOF)
            {
                trvCate.Nodes.Add(rs.Fields["Category"].Value.ToString(),rs.Fields["Category"].Value.ToString());
                rs.MoveNext();
            }
            rs.Close();
            rs.Open("Select * from Categories",conn,CursorTypeEnum.adOpenStatic,LockTypeEnum.adLockReadOnly,0);
            while(!rs.EOF)
            {
                nd = trvCate.Nodes.Find(rs.Fields["Category"].Value.ToString(),false)[0];
                TreeNode tmpNode = new TreeNode();
                tmpNode.Text = rs.Fields["SubCategory"].Value.ToString();
                tmpNode.Tag = rs.Fields["Link"].Value.ToString();
                nd.Nodes.Add(tmpNode);
                //trvCate.Nodes.Add
                rs.MoveNext();
            }
            rs.Close();
            #endregion

            #region Read Locations
            rs.Open("Select distinct Country from Cities", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
            while (!rs.EOF)
            {
                trvLocations.Nodes.Add(rs.Fields["Country"].Value.ToString(), rs.Fields["Country"].Value.ToString());
                rs.MoveNext();
            }
            rs.Close();
            rs.Open("Select * from Cities", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
            while (!rs.EOF)
            {
                nd = trvLocations.Nodes.Find(rs.Fields["Country"].Value.ToString(), false)[0];
                nd.Nodes.Add(rs.Fields["City"].Value.ToString(), rs.Fields["City"].Value.ToString());
                //trvCate.Nodes.Add
                rs.MoveNext();
            }
            rs.Close();
            #endregion

            #region Read Templates
            rs.Open("Select * from Templates", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
            while (!rs.EOF)
            {
                drpTemplate.Items.Add(rs.Fields["Email"].Value.ToString() + " - " + rs.Fields["Subject"].Value.ToString());
                rs.MoveNext();
            }
            rs.Close();
            #endregion
            conn.Close();
        }
        
        private void trvCate_AfterCheck(object sender, TreeViewEventArgs e)
        {
            for(int i=0;i<e.Node.Nodes.Count;i++)
	        {
                e.Node.Nodes[i].Checked = e.Node.Checked;
            }
        }

        private void trvLocations_AfterCheck(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                e.Node.Nodes[i].Checked = e.Node.Checked;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Active = false;
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ADODB.Connection conn = new ADODB.Connection();
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\Db_Craigslist.mdb;Persist Security Info=False";
            conn.Open(conn.ConnectionString, string.Empty, string.Empty, 0);
            
            // Check if email settings exists
            ADODB.Recordset rsCities = new Recordset();
            rsCities.Open("Select * from SMTP", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
            if (rsCities.RecordCount == 0)
            {
                MessageBox.Show("Email Settings does not exists, please goto Email Setting form and Save neccesary settings.");
                return;
            }
            while (!rsCities.EOF)
            {
                if (rsCities.Fields["SMTPUrl"].Value.ToString() == string.Empty)
                {
                    MessageBox.Show("Email Settings does not exists, please goto Email Setting form and Save neccesary settings.");
                    return;
                }
                rsCities.MoveNext();
            }
            rsCities.Close();

            //if (txtUrl.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtName.Text == "")
            //{
            //    MessageBox.Show("Please enter your POP3/SMTP Url, Username, Password, Email From");
            //    return;
            //}

            this.Text = "Wait .... - This may take some time";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            groupBox2.Enabled = false;
            btnEmailSettings.Enabled = false;
            lblStatus.Text = "Last Status Message:";

            Active = true;

            MSXML2.XMLHTTP xml = new XMLHTTP();
            //ADODB.Recordset rsCities = new Recordset();
            rsCities.Open("Select * from Cities", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly,0);

            string str1, str2, id, link, ems, LinkAbbr, LinkPrefix, tmp;
            int strt, nd, prevnd;
            int pages = 0;
            //FileSystemObject FSys = new FileSystemObject();
            //TextStream txt;
            //if(FSys.FileExists(Application.StartupPath + @"\Sent Emails Logcsv"))
            //    txt = FSys.OpenTextFile(Application.StartupPath + @"\Sent Emails Log.csv",IOMode.ForAppending,false,Tristate.TristateFalse);
            //else
            //{
            //    txt = FSys.CreateTextFile(Application.StartupPath + @"\Sent Emails Log.csv",true,false);
            //    txt.WriteLine("Post Url,Date & Time Email Sent");
            //}

            string[] arrKeywords;
            arrKeywords = txtKeywords.Text.Split(',');
            string[] arrSkipKeywords;
            arrSkipKeywords = txtSkipKeywords.Text.Split(',');
            int KeyIndex;

            string[] arrTmp;

            int Skipped = 0, EmailSent = 0;
            lblSkipped.Text = Skipped.ToString();
            lblEmailsSent.Text = EmailSent.ToString();

            // Removing all prev results
            while (trvResults.Nodes.Count != 0)
                trvResults.Nodes[0].Remove();
            
            // For Each selected category and location
            foreach (TreeNode ndMainCate in trvCate.Nodes)
            {
                foreach (TreeNode ndSubCate in ndMainCate.Nodes)
                {
                    if (ndSubCate.Checked == false)
                        continue;

                    lblCategory.Text = ndSubCate.Text;
                    LinkAbbr = ndSubCate.Tag.ToString();

                    foreach (TreeNode ndCountry in trvLocations.Nodes)
                    {
                        foreach (TreeNode ndCity in ndCountry.Nodes)
                        {
                            if (ndCity.Checked == false)
                                continue;

                            lblLocation.Text = ndCity.Text;

                            if (ndCountry.Text == "US")
                            {
                                rsCities.MoveFirst();
                                rsCities.Find("City='" + ndCity.Text + "'", 0, SearchDirectionEnum.adSearchForward, 1);
                                if (!rsCities.EOF && rsCities.Fields["Link"].Value.ToString() != null)
                                    LinkPrefix = rsCities.Fields["Link"].Value.ToString();
                                else
                                    LinkPrefix = @"http://" + ndCity.Text.Replace(" ", "") + @".craigslist.org/";
                            }
                            else
                                LinkPrefix = @"http://" + ndCity.Text.Replace(" ", "") + @".craigslist.org/";

                            nxtPg:
                            try
                            {
                                Application.DoEvents();
                                if (Active == false) goto ex;

                                if (txtKeywords.Text.Trim() == string.Empty)
                                {
                                    if (pages == 0)
                                        xml.open("GET", LinkPrefix + LinkAbbr + "/", false, "", "");
                                    else
                                        xml.open("GET", LinkPrefix + LinkAbbr + "/index" + pages + ".html", false, null, null);
                                }
                                else
                                {
                                    if (pages == 0)
                                        xml.open("GET", LinkPrefix + "search/" + LinkAbbr + "?query=" + txtKeywords.Text, false, null, null);
                                    else
                                        xml.open("GET", LinkPrefix + "search/" + LinkAbbr + "?query=" + txtKeywords.Text + "&s=" + pages, false, null, null);
                                }
                                xml.send("");
                                str1 = xml.responseText;
                                Application.DoEvents();
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }

                            try
                            {

                                strt = str1.IndexOf("<h4>");
                                if (strt < 1)
                                {
                                    strt = str1.IndexOf("<p>");
                                    if (strt < 1) continue;
                                }
                                strt = str1.IndexOf("<a href=", strt);
                                while (strt > 1)
                                {
                                    if (Active == false) goto ex;

                                    strt += 9;
                                    prevnd = str1.IndexOf("\"", strt);
                                    id = str1.Substring(strt, prevnd - strt);
                                    if (id == "index") goto nxt;
                                    if (id.IndexOf(".htm") == -1) goto nxt;
                                    Application.DoEvents();
                                    if (Active == false) goto ex;
                                    link = LinkPrefix + id;

                                    strt = str1.IndexOf(">", prevnd) + 1;
                                    prevnd = str1.IndexOf("<", strt);

                                    TreeNode nd1 = new TreeNode();
                                    nd1.Text = str1.Substring(strt, prevnd - strt);
                                    nd1.Tag = link;

                                    //Skip Keywords
                                    for (KeyIndex = 0; KeyIndex < arrSkipKeywords.Length; KeyIndex++)
                                    {
                                        if (nd1.Text.IndexOf(arrSkipKeywords[KeyIndex], 1, StringComparison.CurrentCultureIgnoreCase) > 0 && arrSkipKeywords[KeyIndex].Trim() != string.Empty)
                                        {
                                            goto nxt;
                                        }
                                    }

                                    trvResults.Nodes.Add(nd1);

                                    EmailSent += 1;

                                nxt:
                                    this.Text = EmailSent + " Results found";
                                    strt = str1.IndexOf("<a href=", prevnd);
                                }
                            }
                            catch (Exception ex) { }

                            //Next page
                            pages = pages + 100;
                            if (str1.IndexOf("index" + pages + ".htm") != 0)
                                goto nxtPg;

                            // Reset page
                            pages = 0;
                        }
                    }
                }
            }

            MessageBox.Show("Finished");
            goto ex1;
         ex:
            MessageBox.Show("Stopped");
         ex1:
            conn.Close();
            this.Text = "CL Emailer";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            groupBox2.Enabled = true;
            btnEmailSettings.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Active = false;
        }

        private void btnEmailSettings_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmailSettings_CL frm = new frmEmailSettings_CL();
                frm.ShowDialog();

                drpTemplate.Items.Clear();
                ADODB.Connection conn = new ADODB.Connection();
                ADODB.Recordset rs = new ADODB.Recordset();
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\Db_Craigslist.mdb;Persist Security Info=False";
                conn.Open(conn.ConnectionString, string.Empty, string.Empty, 0);
                rs.Open("Select * from Templates", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
                while (!rs.EOF)
                {
                    drpTemplate.Items.Add(rs.Fields["Email"].Value.ToString() + " - " + rs.Fields["Subject"].Value.ToString());
                    rs.MoveNext();
                }
                rs.Close();
                conn.Close();
            }
            catch (Exception ex)
            { }
        }

        private void trvResults_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                wb.Navigate(e.Node.Tag.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Last Status Message:";
            MSXML2.XMLHTTP xml = new XMLHTTP();
            string str2, ems, tmp;
            int strt, nd, prevnd;
            ADODB.Connection conn = new ADODB.Connection();
            string[] arrTmp;
            object RecsAffected;
            string[] arrSkipKeywords;
            int KeyIndex;
            int Skipped = 0, EmailSent = 0;
            string Url = "", Username = "", Password = "", From = "", Subject = "", Message = "";
            bool EnableSSL = false;
            try
            {
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\Db_Craigslist.mdb;Persist Security Info=False";
                conn.Open(conn.ConnectionString, string.Empty, string.Empty, 0);

                // Check if email settings exists
                ADODB.Recordset rsCities = new Recordset();
                rsCities.Open("Select * from SMTP", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
                if (rsCities.RecordCount == 0)
                {
                    MessageBox.Show("Email Settings does not exists, please goto Email Setting form and Save neccesary settings.");
                    return;
                }
                while (!rsCities.EOF)
                {
                    if (rsCities.Fields["SMTPUrl"].Value.ToString() == string.Empty)
                    {
                        MessageBox.Show("Email Settings does not exists, please goto Email Setting form and Save neccesary settings.");
                        return;
                    }
                    rsCities.MoveNext();
                }
                rsCities.Close();

                if (drpTemplate.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Email template to be used to send emails.");
                    return;
                }

                this.Text = "Please Wait ....";
                btnStart.Enabled = false;
                drpTemplate.Enabled = false;
                btnStop2.Enabled = true;

                Active = true;

                lblSkipped.Text = Skipped.ToString();
                lblEmailsSent.Text = EmailSent.ToString();
                lblCategory.Text = "";
                lblLocation.Text = "";

                arrSkipKeywords = txtSkipKeywords.Text.Split(',');

                #region "Load POP3 Settings"
                ADODB.Recordset rs = new ADODB.Recordset();
                //rs.Open("Select * from SMTP", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
                //while (!rs.EOF)
                //{
                //    Url = rs.Fields["SMTPUrl"].Value.ToString();
                //    Username = rs.Fields["SMTPUsername"].Value.ToString();
                //    Password = rs.Fields["SMTPPassword"].Value.ToString();
                //    //From = rs.Fields["From"].Value.ToString();
                //    break;
                //}
                //rs.Close();

                rs.Open("Select * from Templates where Subject='" + drpTemplate.SelectedItem.ToString().Split('-')[1].Trim() + "'", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockReadOnly, 0);
                while (!rs.EOF)
                {
                    Subject = rs.Fields["Subject"].Value.ToString();
                    Message = rs.Fields["Message"].Value.ToString();
                    From = rs.Fields["Email"].Value.ToString();
                    Url = rs.Fields["Url"].Value.ToString();
                    Username = rs.Fields["Username"].Value.ToString();
                    Password = rs.Fields["Password"].Value.ToString();
                    if (rs.Fields["EnableSSL"].Value.ToString() == "1")
                        EnableSSL = true;
                    else
                        EnableSSL = false;
                    break;
                }
                rs.Close();
                #endregion
            }
            catch (Exception ex)
            {
                //MessageBox.Show("There seems to be some problem with Database, please check.");
                lblStatus.Text = ex.Message;
                return;
            }

            foreach (TreeNode ResultNode in trvResults.Nodes)
            {
                if (ResultNode.Checked == false) continue;
                try 
                {
                    Application.DoEvents();
                    if (Active == false) goto ex;
                    xml.open("GET", ResultNode.Tag.ToString().Replace(".org//",".org/"), false, "", "");
                    xml.send("");
                    str2 = xml.responseText;
                    Application.DoEvents();

                    //Skip Keywords
                    for (KeyIndex = 0; KeyIndex < arrSkipKeywords.Length; KeyIndex++)
                    {
                        if (str2.IndexOf(arrSkipKeywords[KeyIndex], 1, StringComparison.CurrentCultureIgnoreCase) != 0 && arrSkipKeywords[KeyIndex].Trim() != string.Empty)
                        {
                            Skipped += 1;
                            lblSkipped.Text = Skipped.ToString();
                            this.Text = EmailSent + " Emails Sent";
                            lblStatus.Text = "Last Status Message: Ad skipped because of keywords violation";
                            continue;
                        }
                    }

                    ems = "";
                    strt = str2.IndexOf("mailto:");
                    if (strt > 1)
                    {
                        strt += 7;
                        nd = str2.IndexOf("?", strt);
                        tmp = str2.Substring(strt, nd - strt).Replace("\"", "");
                        arrTmp = tmp.Split(';');
                        tmp = "";
                        for (KeyIndex = 0; KeyIndex < arrTmp.Length; KeyIndex++)
                        {
                            if (arrTmp[KeyIndex] != "")
                                //tmp = tmp + (char)arrTmp[KeyIndex].Replace("&#","");
                                tmp = tmp + Convert.ToChar(Convert.ToInt32(arrTmp[KeyIndex].Replace("&#", "")));
                        }

                        if (chkEmail.Checked == false && tmp.ToLower().IndexOf("craigslist") > 0)
                        {
                            tmp = "";
                            Skipped += 1;
                            lblSkipped.Text = Skipped.ToString();
                            this.Text = EmailSent + " Emails Sent";
                            lblStatus.Text = "Last Status Message: Ad skipped because email was like something@craigslist.org";
                            continue;
                        }

                        //Check if this email has already been contacted
                        try
                        {
                            conn.Execute("insert into Listings values('" + tmp + "')", out RecsAffected, 1);
                        }
                        catch (Exception ex)
                        {
                            Skipped += 1;
                            lblSkipped.Text = Skipped.ToString();
                            this.Text = EmailSent + " Emails Sent";
                            lblStatus.Text = "Last Status Message: Ad skipped because some occured while entering details into database.";
                            continue;
                        }

                        // Send Email
                        try
                        {
                            MailMessage message = new MailMessage(From, tmp, Subject, Message);
                            SmtpClient emailClient = new SmtpClient(Url);
                            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(Username, Password);
                            emailClient.UseDefaultCredentials = false;
                            emailClient.Credentials = SMTPUserInfo;
                            if (EnableSSL == true)
                                emailClient.EnableSsl = true;
                            else
                                emailClient.EnableSsl = false;
                            emailClient.Send(message);
                        }
                        catch (Exception ex)
                        {
                            Skipped += 1;
                            lblSkipped.Text = Skipped.ToString();
                            this.Text = EmailSent + " Emails Sent";
                            lblStatus.Text = "Last Status Message: " + ex.Message;
                            continue;
                        }

                        EmailSent += 1;
                        lblEmailsSent.Text = EmailSent.ToString();
                        this.Text = EmailSent + " Emails Sent";
                        lblStatus.Text = "Last Status Message: Email Sent Successfully";
                    }
                    else
                    {
                        Skipped += 1;
                        lblSkipped.Text = Skipped.ToString();
                        this.Text = EmailSent + " Emails Sent";
                        lblStatus.Text = "Last Status Message: Ad skipped because no email was present";
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Skipped += 1;
                    lblSkipped.Text = Skipped.ToString();
                    continue;
                }
            }

            MessageBox.Show("Finished");
            goto ex1;
        ex:
            MessageBox.Show("Stopped");
        ex1:
            conn.Close();
            this.Text = "CL Emailer";
            btnStart.Enabled = true;
            drpTemplate.Enabled = true;
            btnStop2.Enabled = false;
        }

        private void btnStop2_Click(object sender, EventArgs e)
        {
            Active = false;
        }
    }
}