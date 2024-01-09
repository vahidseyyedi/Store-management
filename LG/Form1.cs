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
    public partial class Form1 : Form
    {
        Repository repository = new Repository();
        Hash hash = new Hash();
        MainPage mainPage = new MainPage();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    lblWarning.Text = "لطفا مقادیر را پر کنید!";
                }
                else
                {
                    if (repository.verify(txtUserName.Text, Hash.creat(txtPassword.Text)) == true)
                    {
                        mainPage.Show();
                        repository.set_data(txtUserName.Text);
                        mainPage.access(Employee.side);
                        this.Hide();
                        
                    }
                    else
                    {
                        lblWarning.Text = "نام کاربری و رمز عبور صحیح نمی  باشد.";
                    }
                }
            }
            catch
            {
                lblWarning.Text = "اتصال به دیتابیس امکان ندارد";
            }
        }
    }
}
