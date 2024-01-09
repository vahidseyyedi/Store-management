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
    public partial class edit_product : Form
    {
        public edit_product()
        {
            InitializeComponent();
        }
        public int index = 0;
        private void edit_product_Load(object sender, EventArgs e)
        {
            combotype.Items.Add("یخچال فریزر");
            combotype.Items.Add("اسپلیت");
            combotype.Items.Add(" تصفیه هوا");
            combotype.Items.Add("تلویزیون");
            combotype.Items.Add("سیستم های صوتی");
            combocolor.Items.Add("مشکی");
            combocolor.Items.Add("سفید");
            combocolor.Items.Add("طوسی");
            combocolor.Items.Add("نقره ای");
            Repository repository = new Repository();
            DataTable dt = repository.SelcetRow_Product(index);
            txtid.Value = Convert.ToInt32(dt.Rows[0][1]);
            combotype.SelectedItem = dt.Rows[0][2].ToString();
            txtname.Text = dt.Rows[0][3].ToString();
            txtnumber.Value = Convert.ToInt32(dt.Rows[0][4]);
            txtprice.Text = dt.Rows[0][5].ToString();
            combocolor.SelectedItem = dt.Rows[0][6].ToString();
            txtpower.Text = dt.Rows[0][7].ToString();
            combosize.SelectedItem = dt.Rows[0][8].ToString();
            txtdes.Text = dt.Rows[0][9].ToString();
        }

        private void combotype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combotype.SelectedItem.ToString() == "یخچال فریزر" )
            {
                combosize.Items.Add("175*92*86");
                combosize.Items.Add("170*90*80");
            }
            else
            {
                if(combotype.SelectedItem.ToString() == "اسپلیت" )
                {
                    combosize.Items.Add("30000");
                    combosize.Items.Add("36000");
                }
                else
                {
                    if(combotype.SelectedItem.ToString() == " تصفیه هوا")
                    {
                        combosize.Items.Add("20inch");
                        combosize.Items.Add("25inch");
                    }
                    else
                    {
                        if (combotype.SelectedItem.ToString() == "تلویزیون")
                        {
                            combosize.Items.Add("43inch");
                            combosize.Items.Add("50inch");
                        }
                        else
                        {
                            if (combotype.SelectedItem.ToString() == "سیستم های صوتی")
                            {
                                combosize.Items.Add("small");
                                combosize.Items.Add("large");
                            }
                        }
                    }
                }
            }
        }
        private bool isvalid()
        {
           
            Repository repository = new Repository();
            bool c = repository.search_product((int)txtid.Value);
            if(c == true)
            {
                if(string.IsNullOrEmpty(combotype.Text))
                {
                    MessageBox.Show("نوع کالا را وارد کنید");
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(txtname.Text))
                    {
                        MessageBox.Show("نام کالا را وارد کنید");
                        return false;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(combosize.Text))
                        {
                            MessageBox.Show("اندازه کالا را وارد کنید");
                            return false;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtpower.Text))
                            {
                                MessageBox.Show("قدرت کالا را وارد کنید");
                                return false;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(combocolor.Text))
                                {
                                    MessageBox.Show("رنگ کالا را وارد کنید");
                                    return false;
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(txtprice.Text))
                                    {
                                        MessageBox.Show("قیمت کالا را وارد کنید");
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
            else
            {
                MessageBox.Show("کالا یافت نشد");
                return false;
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            Repository repository = new Repository();
            if(isvalid() == true)
            {
                bool a = repository.Edit_Product((int)txtid.Value,combotype.Text , txtname.Text, (int)txtnumber.Value, Convert.ToInt32(txtprice.Text), combocolor.Text, txtpower.Text, combosize.Text, txtdes.Text);
                if (a == true)
                {
                    MessageBox.Show("ثبت شد");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("شکست");
                }
            }
        }

        private void txtid_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
