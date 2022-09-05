using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Craigslist_Emailer
{
    public partial class OnlineLeadFinder_Main : Form
    {
        frmBackpage frmBackpage;
        frmCL frmCL;
        frmKijiji frmKijiji;

        public OnlineLeadFinder_Main()
        {
            InitializeComponent();
            frmBackpage = new frmBackpage();
            frmBackpage.MdiParent = this;
            frmBackpage.Visible = false;

            frmCL = new frmCL();
            frmCL.MdiParent = this;
            frmCL.Visible = false;

            frmKijiji = new frmKijiji();
            frmKijiji.MdiParent = this;
            frmKijiji.Visible = false;
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void mnuCL_Click(object sender, EventArgs e)
        {
            frmBackpage.Visible = false;
            frmKijiji.Visible = false;
            frmCL.Visible = true;
        }

        private void mnuBackpage_Click(object sender, EventArgs e)
        {
            frmCL.Visible = false;
            frmKijiji.Visible = false;
            frmBackpage.Visible = true;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kijijiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCL.Visible = false;
            frmBackpage.Visible = false;
            frmKijiji.Visible = true;
        }
    }
}
