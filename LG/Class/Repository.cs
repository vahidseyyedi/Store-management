using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LG
{
    internal class Repository
    {
        //connecton string
        Class.Product Product = new Class.Product();
        private string connection_string = "Data Source=.;Initial Catalog=LG;Integrated Security=True;  ";

        // login page
        //verify
        public bool verify(string user, string pass)
        {
            using (SqlConnection con = new SqlConnection(connection_string))
            {
                string query = "SELECT count(*) from Users where UserName=@user and Password=@pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //end page one----------------------------

        //change password
        public bool ChangePassword(string npassword, string password)
        {
            using (SqlConnection conn = new SqlConnection(connection_string))
            {
                conn.Open();
                string sql = "UPDATE Users SET Password=@npassword WHERE Password=@password";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@npassword", npassword);
                    cmd.Parameters.AddWithValue("@password", password);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return (rowsAffected > 0);
                }
            }
        }

        //end page change password----------------------------

        //page add or edit
        //search id factor
        //search product id
        public bool search_product(int id)
        {
            bool codeExists = false;

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                string query = "SELECT COUNT(*) FROM Products WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", id);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    codeExists = true;
                }
                connection.Close();
            }

            if (codeExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //insert
        public bool Insert_Product(string type, int idproduct, string name, int number, int price, string color, string power, string size, string descreption)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            try
            {
                string query = "Insert Into Products (Type,ProductID,Name,Number,price,Color,Power,Size,Description) values (@Type,@ProductID,@Name,@Number,@Price,@Color,@Power,@Size,@Description)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ProductID", idproduct);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Color", color);
                command.Parameters.AddWithValue("@Power", power);
                command.Parameters.AddWithValue("@Size", size);
                command.Parameters.AddWithValue("@Description", descreption);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //end page add or edit----------------------------

        //main page
        //set data
        public void set_data(string user)
        {
            using (SqlConnection conn = new SqlConnection(connection_string))
            {
                string sql = "SELECT Id, FirstName, LastName, Side FROM Users WHERE UserName = @user";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", user);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Employee.Id = reader.GetInt32(0);
                    Employee.first_name = reader.GetString(1);
                    Employee.last_name = reader.GetString(2);
                    Employee.side = reader.GetString(3);
                    Employee.user = user;
                }
                reader.Close();
            }
        }

        public DataTable Search(string parameter)
        {
            string query = "Select * From Products where Name like @parameter or ProductID like @parameter";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Delete_Product(int Id)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            try
            {
                string query = "Delete From Products where ProductID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();

            }
        }

        

        public DataTable SelcetRow_Product(int Id)
        {
            string query = "SELECT * FROM Products WHERE ProductID = @ID";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", Id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll_Product()
        {
            string query = "Select * From Products";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Edit_Product(int productId, string type, string name, int number, int price, string color, string power, string size, string description)
        {
            string query = "UPDATE Products SET Type = @type , Name = @Name, Number = @Number, Price = @Price, Color = @Color, Power = @Power, Size = @Size, Description = @Description WHERE ProductID = @ProductID";
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Color", color);
                command.Parameters.AddWithValue("@Power", power);
                command.Parameters.AddWithValue("@Size", size);
                command.Parameters.AddWithValue("@Description", description);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return (rowsAffected > 0);
                }
                catch
                {
                    return false;
                }
            }
        }

        public void insert_factor(string customerId, string customerName, string customerAddress, DateTime date, List<Class.Product> products, int tax, int total)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            string query = @"INSERT INTO factor (IdCustomers, FullName, Adress, Date, Tax, total)
                     VALUES (@IdCustomers, @FullName, @Adress, @Date, @Tax, @total);
                     SELECT SCOPE_IDENTITY();";

            string detailsQuery = @"INSERT INTO detail_factor (InvoiceId, ProductID, Type, Name, Number, price, Color, Power, Size, discount, total_price)
                            VALUES (@InvoiceId, @ProductID, @ProductType, @Name, @Number, @price, @Color, @Power, @Size, @discount, @total_price);";

            try
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand command = new SqlCommand(query, connection, transaction);

                    command.Parameters.AddWithValue("@IdCustomers", customerId);
                    command.Parameters.AddWithValue("@FullName", customerName);
                    command.Parameters.AddWithValue("@Adress", customerAddress);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Tax", tax);
                    command.Parameters.AddWithValue("@total", total);

                    int invoiceId = Convert.ToInt32(command.ExecuteScalar());

                    foreach (Class.Product product in products)
                    {
                        SqlCommand detailsCommand = new SqlCommand(detailsQuery, connection, transaction);

                        detailsCommand.Parameters.AddWithValue("@InvoiceId", invoiceId);
                        detailsCommand.Parameters.AddWithValue("@ProductID", product.id);
                        detailsCommand.Parameters.AddWithValue("@ProductType", product.type);
                        detailsCommand.Parameters.AddWithValue("@Name", product.name);
                        detailsCommand.Parameters.AddWithValue("@Number", product.number);
                        detailsCommand.Parameters.AddWithValue("@price", product.price);
                        detailsCommand.Parameters.AddWithValue("@Color", product.color);
                        detailsCommand.Parameters.AddWithValue("@Power", product.power);
                        detailsCommand.Parameters.AddWithValue("@Size", product.size);
                        detailsCommand.Parameters.AddWithValue("@discount", product.discount);
                        detailsCommand.Parameters.AddWithValue("@total_price", product.Total_price);

                        detailsCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search_customer(string parameter)
        {

            string query = "Select * From factor where IdCustomers like @parameter or FullName like @parameter";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll_customer()
        {
            string query = "Select * From factor";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelcetRow_customer(int Id)
        {
            string query = "SELECT * FROM detail_factor WHERE InvoiceId = @ID";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", Id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll_factor_customer(int id)
        {
            string query = "Select * From detail_factor WHERE InvoiceId = @ID";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool search_user_code(string code)
        {
            bool codeExists = false;

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE NationalCode = @NationalCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NationalCode", code);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    codeExists = true;
                }
                connection.Close();
            }

            if (codeExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool search_user(string user)
        {
            bool codeExists = false;

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", user);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    codeExists = true;
                }
                connection.Close();
            }

            if (codeExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Insert_user(string fname, string lname, string datebirth, DateTime registor, string code , string phone, string homephone, string adress, string side , string user , string pass)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            try
            {
                string query = "Insert Into Users (FirstName,LastName,DateOfBirth,DateOfRegistratin,NationalCode,MobilePhone,HomePhone,Adress,Side,UserName,Password) values (@firstName,@lastName,@dateOfBirth,@dateOfRegistratin,@nationalCode,@mobilePhone,@homePhone,@adress,@side,@userName,@password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstName", fname);
                command.Parameters.AddWithValue("@lastName", lname);
                command.Parameters.AddWithValue("@dateOfBirth", datebirth);
                command.Parameters.AddWithValue("@dateOfRegistratin", registor);
                command.Parameters.AddWithValue("@nationalCode", code);
                command.Parameters.AddWithValue("@mobilePhone", phone);
                command.Parameters.AddWithValue("@homePhone", homephone);
                command.Parameters.AddWithValue("@adress", adress);
                command.Parameters.AddWithValue("@side", side);
                command.Parameters.AddWithValue("@userName", user);
                command.Parameters.AddWithValue("@password", pass);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Update_user(int id, string fname, string lname, string datebirth, DateTime registor, string code, string phone, string homephone, string adress, string side, string user, string pass)
        {
            SqlConnection connection = new SqlConnection(connection_string);
                try
                {
                    string query = "UPDATE Users SET FirstName = @firstName, LastName = @lastName, DateOfBirth = @dateOfBirth, DateOfRegistratin = @dateOfRegistratin, NationalCode = @nationalCode, MobilePhone = @mobilePhone, HomePhone = @homePhone, Adress = @adress, Side = @side, UserName = @userName, Password = @password WHERE Id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@firstName", fname);
                    command.Parameters.AddWithValue("@lastName", lname);
                    command.Parameters.AddWithValue("@dateOfBirth", datebirth);
                    command.Parameters.AddWithValue("@dateOfRegistratin", registor);
                    command.Parameters.AddWithValue("@nationalCode", code);
                    command.Parameters.AddWithValue("@mobilePhone", phone);
                    command.Parameters.AddWithValue("@homePhone", homephone);
                    command.Parameters.AddWithValue("@adress", adress);
                    command.Parameters.AddWithValue("@side", side);
                    command.Parameters.AddWithValue("@userName", user);
                    command.Parameters.AddWithValue("@password", pass);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
           
        }

        public DataTable SelcetRow_user(int id)
        {
            string query = "SELECT * FROM Users WHERE Id = @ID";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll_user()
        {
            string query = "Select * From Users";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Delete_user(int Id)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            try
            {
                string query = "Delete From Users where Id=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();

            }
        }

        public DataTable Search_user(string parameter)
        {
            string query = "Select * From Users where LastName like @parameter or FirstName like @parameter";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
