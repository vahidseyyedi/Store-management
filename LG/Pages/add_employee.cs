using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LG.Pages
{

    public partial class add_employee : Form
    {
        Repository repository = new Repository();
        public add_employee()
        {
            InitializeComponent();

            comboside.Items.Add("مدیریت");
            comboside.Items.Add("صندوقدار");
          

        }

        private bool isvalid()
        {
            if (repository.search_user_code(txtnationalcode.Text))
            {
                MessageBox.Show("کد ملی موجود است");
                return false;
            }
            else
            {
                if (repository.search_user(txtuser.Text))
                {
                    MessageBox.Show(" user موجود است");
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(txtbirth.Text))
                    {
                        MessageBox.Show("تاریخ تولد را مشخص کنید");
                        return false;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtname.Text))
                        {
                            MessageBox.Show("نام خالی است");
                            return false;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtfamily.Text))
                            {
                                MessageBox.Show("نام خانوادگی خالی است");
                                return false;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(txtmobile.Text))
                                {
                                    MessageBox.Show("شماره موبایل خالی است");
                                    return false;
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(txthomephone.Text))
                                    {
                                        MessageBox.Show("شماره تلفن خالی است");
                                        return false;
                                    }
                                    else
                                    {

                                        if (string.IsNullOrEmpty(comboside.Text))
                                        {
                                            MessageBox.Show("سمت خالی است");
                                            return false;
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(txtadress.Text))
                                            {
                                                MessageBox.Show("ادرس خالی است");
                                                return false;
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(txtpass.Text))
                                                {
                                                    MessageBox.Show("پسورد خالی است");
                                                    return false;
                                                }
                                                else
                                                {
                                                    return true;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnnew_Click(object sender, EventArgs e)
        {

        }

        private void combomonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (isvalid() == true)
            {
                bool s = repository.Insert_user(txtname.Text, txtfamily.Text, txtbirth.Text, now, txtnationalcode.Text, txtmobile.Text, txthomephone.Text, txtadress.Text, comboside.SelectedItem.ToString(), txtuser.Text, Hash.creat(txtpass.Text));
                if (s == true)
                {
                    MessageBox.Show("ذخیره شد");
                }
                else
                {
                    MessageBox.Show("شکست");
                }
            }
        }

        private void add_employee_Load(object sender, EventArgs e)
        {

        }
    }
}
