using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace control_system_project
{
    public partial class Form4 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server = .\; DataBase= my_DB ; Integrated Security=true; ");
        SqlCommand cmd;
        SqlDataReader dr;
        
        public Form4()
           
        {
            InitializeComponent();
            old_password_tb.PasswordChar = '*';
            password_tb.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            cn.Open();
            cmd = new SqlCommand("Select * From Table_1 where usernames ='" + old_username.Text + "' and pasword ='" + old_password_tb.Text + "' ", cn);

            dr = cmd.ExecuteReader();
            int count = 0;

            while (dr.Read())
            {
                count += 1;
            }
            cn.Close();
            if (count == 1)
            {
                if (ed_username_tb.TextLength >= 2 && password_tb.TextLength >= 4)
                {
                    cmd = new SqlCommand(" Update  my_DB.dbo.Table_1 set usernames='" + ed_username_tb.Text + "' , pasword = '" + password_tb.Text + " ' ", cn);
                   cn.Open();
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You should Enter  New Password and New Username more than 3 char");
                }
            }
            else if (count > 0)
            {
                MessageBox.Show(" old username and password uncorrect");
            }
            else
            {
                MessageBox.Show(" old username or password uncorrect");
            }
            cn.Close();

           
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select  usernames , pasword From my_DB.dbo.Table_1",cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            old_username.Text = dr["usernames"].ToString();
          
            cn.Close();
            old_password_tb.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
