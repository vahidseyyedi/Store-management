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
    public partial class edit_employee : Form
    {
        Repository repository = new Repository();
        public edit_employee()
        {
            InitializeComponent();

        }
        public int index_employee = 0;

        private void edit_employee_Load(object sender, EventArgs e)
        {
            comboside.Items.Add("مدیریت");
            comboside.Items.Add("صندوقدار");
            Repository repository = new Repository();
            DataTable dt = repository.SelcetRow_user(index_employee);
            txtname.Text = dt.Rows[0][1].ToString();
            txtfamily.Text = dt.Rows[0][2].ToString();
            txtbirth.Text = dt.Rows[0][3].ToString();
            lblregistor.Text = dt.Rows[0][4].ToString();
            txtnationalcode.Text = dt.Rows[0][5].ToString();
            txtmobile.Text = dt.Rows[0][6].ToString();
            txthomephone.Text = dt.Rows[0][7].ToString();
            txtadress.Text = dt.Rows[0][8].ToString();
            comboside.Text = dt.Rows[0][9].ToString();
            txtuser.Text = dt.Rows[0][10].ToString();
        }
        private bool isvalid()
        {
            if (repository.search_user_code(txtnationalcode.Text))
            {


                if (!repository.search_user(txtuser.Text))
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
            else
            {
                MessageBox.Show("کد ملی موجود نیست");
                return false;
            }

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (isvalid() == true)
            {
                bool i = repository.Update_user(index_employee, txtname.Text, txtfamily.Text, txtbirth.Text, now, txtnationalcode.Text, txtmobile.Text, txthomephone.Text, txtadress.Text, comboside.SelectedItem.ToString(), txtuser.Text, Hash.creat(txtpass.Text));
                if (i == true)
                {
                    MessageBox.Show("ویرایش شد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("شکست");
                }
            }

        }
    }
}
