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
    public partial class Form5 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server = .\; DataBase= my_DB ; Integrated Security=true; ");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form5()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + sensor_port_tb.Text + "' ,value2 = '" + control_port_tb.Text + "' where val='14' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TANK_1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '14' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            sensor_port_tb.Text = dr["value1"].ToString();
            control_port_tb.Text = dr["value2"].ToString();
            cn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
