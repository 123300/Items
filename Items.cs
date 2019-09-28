using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Items_Project
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            if (!String.IsNullOrEmpty(priceTextBox.Text))
            {
                string commandString = @"INSERT INTO Items (Name, Price) Values ('" + nameTextBox.Text + "'," + priceTextBox.Text + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("add");

                }
                else
                {
                    MessageBox.Show("Price");
                }

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Please Enter Price");
                return;
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            string commandString = @"SELECT * FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                showDataGridView.DataSource = null;
                MessageBox.Show("Data not Found!");
            }



            sqlConnection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            if (!String.IsNullOrEmpty(idTextBox.Text))
            {
                string commandString = @"DELETE FROM Items WHERE ID = " + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Delete");
                }
                else
                {
                    MessageBox.Show("Not Delete");
                }

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Please Enter Id");
                return;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            if (!String.IsNullOrEmpty(priceTextBox.Text))
            {
                string commandString = @"UPDATE Items SET Name = '" + nameTextBox.Text + "' ,Price = " + priceTextBox.Text + " WHERE ID= " + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Update");
                }
                else
                {
                    MessageBox.Show("Not Update");
                }

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Inter Price");
                return;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            if (!String.IsNullOrEmpty(priceTextBox.Text))
            {
                string commandString = @"SELECT Name, Price FROM Items WHERE Price >= " +priceTextBox.Text+ "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    showDataGridView.DataSource = null;
                    MessageBox.Show("Data not Found!");
                }

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Inter Price");
                return ;
            }
        }
    }
}
