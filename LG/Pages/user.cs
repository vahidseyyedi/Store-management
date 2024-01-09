using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LG
{
    public partial class user : Form
    {
        Repository repository = new Repository();
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {

        }
        public void set(string user, string lname,string fname , string side )
        {
            lbluser.Text = user;
            lblfullname.Text = lname + " " + fname;
            lblside.Text = side;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnewpassword.Text == txtrenewpassword.Text)
            {

                if (repository.ChangePassword(Hash.creat(txtnewpassword.Text), Hash.creat(txtpassword.Text)) == true)
                {
                    MessageBox.Show("رمز با موفقعیت تغییر کرد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("رمز تغییر نکرد!");
                }
            }
            else
            {
                MessageBox.Show("مقادیر رمز عبور جدید با تکرار ان یکی نمی باشد");
                txtpassword.Clear();
                txtnewpassword.Clear();
                txtrenewpassword.Clear();
            }
        }
    }
}
