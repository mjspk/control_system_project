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
   

    public partial class Form3 : Form
    {

        SqlConnection cn = new SqlConnection(@"Server = .\; DataBase= my_DB ; Integrated Security=true; ");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form3()
        {
            InitializeComponent();
            password_tb.PasswordChar = '*';

            username_tb.Focus();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            Application.Exit();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            cn.Open();
            cmd = new SqlCommand("Select * From Table_1 where usernames ='" + username_tb.Text+ "' and pasword ='" + password_tb.Text+"' ", cn);
            
            dr = cmd.ExecuteReader();
            int count = 0;

            while( dr.Read())
            {
                count += 1;
            }
            
            if (count == 1)
            {
                label4.Text = "Access ia Allow";

                
                Form1 frm = new Form1();
                frm.ShowDialog();
                this.Close();
            }
             else if (count > 0)
            {
                label4.Text = "username and password uncorrect";
            }
            else
            {
                label4.Text = "username or password uncorrect";
                
            }
            cn.Close();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)

        {
            
            
           


        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form3_Enter(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form3_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void Form3_MouseLeave(object sender, EventArgs e)
        {
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {


           
            login_bt.Visible = true;
            login_bt.Visible = true;
            password_tb.Visible = true;
            username_tb.Visible = true;
            label4.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            username_tb.Focus();
            button3.Visible = false;
            timer1.Enabled = false;
            close_bt.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.AcceptButton = login_bt;
            
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void password_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
