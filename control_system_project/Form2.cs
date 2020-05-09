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
    public partial class Form2 : Form
    {

        SqlConnection cn = new SqlConnection(@"Server = .\; DataBase= my_DB ; Integrated Security=true; ");
        SqlCommand cmd;
        SqlDataReader dr;
        private Form1 frm;
        
        public Form2()
        {
            InitializeComponent();

            frm = new Form1();

        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            

            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '"+temprang_tb1.Text+ "' ,value2 = '" + low_temprang_tb1.Text + "' where val='1' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + temprang_tb1.Text + "' ,value2 = '" + low_temprang_tb1.Text + "' where val='1' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + pressrang_tb1.Text + "', value2 ='" + low_pressrang_tb1.Text + "' where val='2'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 ='" + pressrang_tb1.Text + "', value2 ='" + low_pressrang_tb1.Text + "' where val='2'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + levelrang_tb1.Text + "', value2 = '" + low_levelrang_tb1.Text + "' where val='3' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + levelrang_tb1.Text + "', value2 = '" + low_levelrang_tb1.Text + "' where val='3' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();



            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + temprang_tb2.Text + "' , value2 = '" + low_temprang_tb2.Text + "' where val='8' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + temprang_tb2.Text + "' , value2 = '" + low_temprang_tb2.Text + "' where val='8' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();   

            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + pressrang_tb2.Text + "', value2 ='" + low_pressrang_tb2.Text + "' where val='9'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 ='" + pressrang_tb2.Text + "', value2 ='" + low_pressrang_tb2.Text + "' where val='9'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + levelrang_tb2.Text + "' , value2 = '" + low_levelrang_tb2.Text + "' where val='7' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3 set value1 = '" + levelrang_tb2.Text + "' , value2 = '" + low_levelrang_tb2.Text + "' where val='7' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();


            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + temprang_heat_tb.Text + "' , value2 = '" + low_temprang_heat_tb.Text + "' where val='5' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + temprang_heat_tb.Text + "' , value2 = '" + low_temprang_heat_tb.Text + "' where val='5' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + pressrang_heat_tb.Text + "' , value2 = '" + low_pressrang_heat_tb.Text + "' where val='6'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + pressrang_heat_tb.Text + "' , value2 = '" + low_pressrang_heat_tb.Text + "' where val='6'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();


            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + levelrang_heat_tb.Text + "' , value2 = '" + low_levelrang_heat_tb.Text + "' where val='11'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + levelrang_heat_tb.Text + "' , value2 = '" + low_levelrang_heat_tb.Text + "' where val='11'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();


            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + flowrang_tb.Text + "', value2 = '" + low_flowrang_tb.Text + "' where val='4' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + flowrang_tb.Text + "', value2 = '" + low_flowrang_tb.Text + "' where val='4' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();     
           
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + gas_temprang_tb.Text + "' ,value2 = '" + low_gas_temprang_tb.Text + "' where val='10' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();           
            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + gas_temprang_tb.Text + "' ,value2 = '" + low_gas_temprang_tb.Text + "' where val='10' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();



            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value1 = '" + water_volume.Text + "'  where val='12' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_3  set value2 = '" +( Convert.ToInt32( comboBox1.Text)* 1000) + "'  where val='12' ", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            this.Close();



        }

        private void Form2_Load(object sender, EventArgs e)
        {



            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '1' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            temprang_tb1.Text = dr["value1"].ToString();
            low_temprang_tb1.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '2' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_tb1.Text = dr["value1"].ToString();
            low_pressrang_tb1.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_tb1.Text = dr["value1"].ToString();
            low_levelrang_tb1.Text = dr["value2"].ToString();
            cn.Close();

       


            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '8' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            temprang_tb2.Text = dr["value1"].ToString();
            low_temprang_tb2.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '9' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_tb2.Text = dr["value1"].ToString();
            low_pressrang_tb2.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_tb2.Text = dr["value1"].ToString();
            low_levelrang_tb2.Text = dr["value2"].ToString();
            cn.Close();




            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '5' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            temprang_heat_tb.Text = dr["value1"].ToString();
            low_temprang_heat_tb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '6' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_heat_tb.Text = dr["value1"].ToString();
            low_pressrang_heat_tb.Text = dr["value2"].ToString();
            cn.Close();


            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '11' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_heat_tb.Text = dr["value1"].ToString();
            low_levelrang_heat_tb.Text = dr["value2"].ToString();
            cn.Close();



            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '4' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            flowrang_tb.Text = dr["value1"].ToString();
            low_flowrang_tb.Text = dr["value2"].ToString();
            cn.Close();           

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '10' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            gas_temprang_tb.Text = dr["value1"].ToString();
            low_gas_temprang_tb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '12' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            water_volume.Text = dr["value1"].ToString();
           
            cn.Close();

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '12' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            comboBox1.Text =Convert.ToString ( Convert.ToInt32( dr["value2"].ToString()) /1000 );

            cn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pressrang_tb2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
