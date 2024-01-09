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
    public partial class add_product : Form
    {
        public add_product()
        {
            InitializeComponent();
        }

        private void add_product_Load(object sender, EventArgs e)
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
        }

        private void combotype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combotype.SelectedItem.ToString() == "یخچال فریزر")
            {
                combosize.Items.Add("175*92*86");
                combosize.Items.Add("170*90*80");
            }
            else
            {
                if (combotype.SelectedItem.ToString() == "اسپلیت")
                {
                    combosize.Items.Add("30000");
                    combosize.Items.Add("36000");
                }
                else
                {
                    if (combotype.SelectedItem.ToString() == " تصفیه هوا")
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
            if (c == false)
            {
                if (string.IsNullOrEmpty(combotype.Text))
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
                MessageBox.Show("کالا موجود است");
                return false;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Repository repository = new Repository();
            if (isvalid() == true)
            {
                bool a = repository.Insert_Product( combotype.Text , (int)txtid.Value, txtname.Text, (int)txtnumber.Value, Convert.ToInt32(txtprice.Text), combocolor.Text, txtpower.Text, combosize.Text, txtdes.Text);
                if (a == true)
                {
                    MessageBox.Show("ثبت شد");
                    txtid.Value = 0;
                    txtname.Text = null;
                    txtpower.Text = null;
                    txtnumber.Value = 0;
                    txtprice.Text = null;
                }
                else
                {
                    MessageBox.Show("شکست");
                }
            }
        }
    }
}
