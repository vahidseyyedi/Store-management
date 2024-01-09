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
    public partial class MainPage : Form
    {
        Repository repository = new Repository();
        Class.Product product = new Class.Product();
        List<Class.Product> products = new List<Class.Product>();
        List<int> list = new List<int>();
        public MainPage()
        {
            InitializeComponent();
            BindGrid();


        }


        public int idaddfactor = 0;
        public void BindGrid()
        {
            dg_product.DataSource = repository.SelectAll_Product();
            dg_product_factor.DataSource = repository.SelectAll_Product();
            dg_customer.DataSource = repository.SelectAll_customer();
            dg_user.DataSource = repository.SelectAll_user();
        }




        private void MainPage_Load(object sender, EventArgs e)
        {

        }
        //set access
        public void access(string side)
        {
            switch (side)
            {
                case "مدیریت": 

                    break;
                case "صندوقدار":
                    tabPage5.Enabled = false;
                    dg_user.DataSource = null;
                    break;
                  



            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            user user = new user();
            user.set(Employee.user, Employee.first_name, Employee.last_name , Employee.side);
            user.ShowDialog();
        }

        private void delete_product_Click(object sender, EventArgs e)
        {
            if (dg_product.CurrentRow != null)
            {
                string id = dg_product.CurrentRow.Cells[1].Value.ToString();
                string name = dg_product.CurrentRow.Cells[3].Value.ToString();
                string full = name + " " + id;
                if (MessageBox.Show($"آیا از حذف {full} مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int Id = int.Parse(dg_product.CurrentRow.Cells[1].Value.ToString());
                    repository.Delete_Product(Id);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک ردیف را از لیست انتخاب کنید");
            }
        }

        private void new_product_Click(object sender, EventArgs e)
        {
            Pages.add_product add = new Pages.add_product();
            add.ShowDialog();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            BindGrid();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (dg_product.CurrentRow != null)
            {
                int Id = int.Parse(dg_product.CurrentRow.Cells[1].Value.ToString());
                Pages.edit_product edit = new Pages.edit_product();
                edit.index = Id;
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dg_product.DataSource = repository.Search(txtsearch.Text);

        }




        private void button3_Click(object sender, EventArgs e)
        {
            if (txtdiscount.Value > 100)
            {
                MessageBox.Show("مقادیر وارد شده نا درست است");
            }
            else
            {


                if (txtnumber.Value > Convert.ToInt32(dg_product_factor.CurrentRow.Cells[4].Value))
                {
                    MessageBox.Show("موجودی کالا کافی نمیباشد" + "\n" + Convert.ToInt32(dg_product_factor.CurrentRow.Cells[4].Value.ToString()));
                }
                else
                {
                    if (txtnumber.Value == 0)
                    {
                        MessageBox.Show("تعداد را وارد کنید");
                    }
                    else
                    {
                        if (list.Contains(int.Parse(dg_product_factor.CurrentRow.Cells[1].Value.ToString())))
                        {
                            MessageBox.Show("تکراری است.");
                        }
                        else
                        {
                            Class.Product product = new Class.Product();
                            product.id = int.Parse(dg_product_factor.CurrentRow.Cells[1].Value.ToString());
                            product.type = dg_product_factor.CurrentRow.Cells[2].Value.ToString();
                            product.name = dg_product_factor.CurrentRow.Cells[3].Value.ToString();
                            product.number = (int)txtnumber.Value;
                            product.price = Convert.ToInt32(dg_product_factor.CurrentRow.Cells[5].Value.ToString());
                            product.color = dg_product_factor.CurrentRow.Cells[6].Value.ToString();
                            product.power = dg_product_factor.CurrentRow.Cells[7].Value.ToString();
                            product.size = dg_product_factor.CurrentRow.Cells[7].Value.ToString();
                            product.discount = (int)txtdiscount.Value;
                            product.Total_price = Class.Calculator.calc_discount((int)txtnumber.Value, product.price, (int)txtdiscount.Value);
                            products.Add(product);
                            BindGrid();
                            int a = 0;
                            for (int i = 0; i < products.Count; i++)
                            {
                                a = a + (int)products[i].Total_price;
                            }
                            
                            lbltotal.Text = Class.Calculator.calc_tax(a , (int)txttax.Value).ToString();
                            txtnumber.Value = 0;
                            txtdiscount.Value = 0;
                            lblcolor.Text = "--------------";
                            lblid.Text = "--------------";
                            lblname.Text = "--------------";
                            lblnumber.Text = "----";
                            lblpower.Text = "--------------";
                            lblprice.Text = "--------------";
                            lblsize.Text = "--------------";
                            lbltype.Text = "--------------";
                            list.Add(int.Parse(dg_product_factor.CurrentRow.Cells[1].Value.ToString()));
                            MessageBox.Show("اضافه شد");
                            dg_factor.DataSource = null;
                            dg_factor.DataSource = products;
                            dg_factor.Refresh();
                        }


                    }
                }
            }
        }





        private void button6_Click(object sender, EventArgs e)
        {
            dg_factor.DataSource = products;
            dg_factor.Refresh();

        }



        private void dg_product_factor_MouseClick(object sender, MouseEventArgs e)
        {
            if (dg_product_factor.CurrentRow != null)
            {
                int Id = int.Parse(dg_product_factor.CurrentRow.Cells[1].Value.ToString());
                lblid.Text = Id.ToString();
                lbltype.Text = dg_product_factor.CurrentRow.Cells[2].Value.ToString();
                lblname.Text = dg_product_factor.CurrentRow.Cells[3].Value.ToString();
                lblnumber.Text = dg_product_factor.CurrentRow.Cells[4].Value.ToString();
                lblprice.Text = dg_product_factor.CurrentRow.Cells[5].Value.ToString();
                lblcolor.Text = dg_product_factor.CurrentRow.Cells[6].Value.ToString();
                lblpower.Text = dg_product_factor.CurrentRow.Cells[7].Value.ToString();
                lblsize.Text = dg_product_factor.CurrentRow.Cells[8].Value.ToString();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dg_product_factor.DataSource = repository.Search(textBox3.Text);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dg_factor.SelectedRows.Count > 0)
            {
                int rowIndex = dg_factor.SelectedRows[0].Index;
                int productId = int.Parse(dg_factor.Rows[rowIndex].Cells[0].Value.ToString());
                products.RemoveAll(p => p.id == productId);
                dg_factor.DataSource = null;
                dg_factor.DataSource = products;
            }
            else
            {
                MessageBox.Show("لطفاً یک سطر را جهت حذف انتخاب کنید.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dg_factor.RowCount == 0)
            {
                MessageBox.Show("جدول خالی است");
            }
            else
            {
                if (string.IsNullOrEmpty(txtphone.Text))
                {
                    MessageBox.Show("لطفا شماره تلفن را وارد کنید");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtfullname.Text))
                    {
                        MessageBox.Show("لطفا نام و نام خانوادگی را وارد کنید");
                    }
                    else
                    {
                        try
                        {
                            DateTime now = DateTime.Now;

                            for (int i = 0; i < products.Count; i++)
                            {
                                DataTable dt = repository.SelcetRow_Product(products[i].id);
                                int b = int.Parse(dt.Rows[0][4].ToString()) - products[i].number;
                                repository.Edit_Product(products[i].id, products[i].type, products[i].name, b, products[i].price, products[i].color, products[i].power, products[i].size, "");
                                b = 0;
                            }
                            repository.insert_factor(txtphone.Text, txtfullname.Text, txtadress.Text, now, products, (int)txttax.Value, Convert.ToInt32(lbltotal.Text));
                            MessageBox.Show("ثبت شد");
                            products.Clear();
                            list.Clear();
                            dg_factor.DataSource = null;
                            dg_factor.DataSource = products;
                            BindGrid();

                        }
                        catch
                        {
                            MessageBox.Show("شکست خورد");
                        }
                    }

                }
            }

        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = repository.Search_customer(txtphone.Text);

            if (dataTable.Rows.Count > 0)
            {
                string fullName = dataTable.Rows[0]["FullName"].ToString();
                string phoneNumber = dataTable.Rows[0]["IdCustomers"].ToString();
                string address = dataTable.Rows[0]["Adress"].ToString();
                txtfullname.Text = fullName;
                txtadress.Text = address;
            }

        }

        private void txtsearchcustomer_TextChanged(object sender, EventArgs e)
        {
            dg_customer.DataSource = repository.Search_customer(txtsearchcustomer.Text);

        }



        private void dg_customer_MouseClick(object sender, MouseEventArgs e)
        {
            dg_customer_factor.DataSource = repository.SelectAll_factor_customer(int.Parse(dg_customer.CurrentRow.Cells[0].Value.ToString()));

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Pages.add_employee employee = new Pages.add_employee();
            employee.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dg_user.CurrentRow != null)
            {
                int Id = int.Parse(dg_user.CurrentRow.Cells[0].Value.ToString());
                Pages.edit_employee edit = new Pages.edit_employee();
                edit.index_employee = Id;
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            BindGrid();
            dg_user.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dg_user.CurrentRow != null)
            {
                string fname = dg_user.CurrentRow.Cells[1].Value.ToString();
                string lname = dg_user.CurrentRow.Cells[3].Value.ToString();
                string full = fname + " " + lname;
                if (MessageBox.Show($"آیا از حذف {full} مطمئن هستید ؟", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int Id = int.Parse(dg_user.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete_user(Id);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک ردیف را از لیست انتخاب کنید");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            dg_product.Refresh();
            dg_product_factor.Refresh();
            dg_customer.Refresh();
            dg_customer_factor.Refresh();
            dg_factor.Refresh();
            dg_user.Refresh();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            dg_product.Refresh();
            dg_product_factor.Refresh();
            dg_customer.Refresh();
            dg_customer_factor.Refresh();
            dg_factor.Refresh();
            dg_user.Refresh();

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            dg_product.Refresh();
            dg_product_factor.Refresh();
            dg_customer.Refresh();
            dg_customer_factor.Refresh();
            dg_factor.Refresh();
            dg_user.Refresh();

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            dg_product.Refresh();
            dg_product_factor.Refresh();
            dg_customer.Refresh();
            dg_customer_factor.Refresh();
            dg_factor.Refresh();
            dg_user.Refresh();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            dg_customer.DataSource = repository.SelectAll_customer();
        }


    }
}
