using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;


namespace control_system_project
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server = .\; DataBase= my_DB ; Integrated Security=true; ");
        SqlCommand cmd;
        SqlDataReader dr;
        private SerialPort myport;
        public SerialPort myport1;

       
        private string in_data;
        private double tempreading1C;
        private double tempreading_heat_C;
        private double tempreading2C;
        private double gas_tempreadingC;


        private double flowreadingL_m ;
        private double levelreading1CM ;
        private double levelreading2CM ;
        private double levelreading_heatCM;
        private double pressreading1PSI = 14.7;
        private double pressreading_heatPSI;
        private double pressreading2PSI = 14.7;

        


        public Form1()
        {
            InitializeComponent();
            
        }



        private void start_btn_Click(object sender, EventArgs e)
        {


            

            try
            {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = sensor_port_tb.Text;
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += Myport_DataReceived1;
            myport.Open();
            start_btn.BackColor = Color.Green;
            stop_btn.BackColor = Color.Silver;




            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"error");

            }

        }

        private void Myport_DataReceived1(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myport.ReadLine();
           
            this.Invoke(new EventHandler(displaydata_event));

        }

        private void displaydata_event(object sender, EventArgs e)
        {

            
            try
            {
                serial_tb.Text = in_data;
                
                string datafromarduino = myport.ReadLine().ToString();
                string[] datamulti = datafromarduino.Split(',');
                tempreading1C = (double)(Math.Round(Convert.ToDouble(datamulti[0]), 2));
                tempreading_heat_C = (double)(Math.Round(Convert.ToDouble(datamulti[1]), 2));
                tempreading2C = (double)(Math.Round(Convert.ToDouble(datamulti[2]), 2));
                gas_tempreadingC = (double)(Math.Round(Convert.ToDouble(datamulti[3]), 2));
                flowreadingL_m = (double)(Math.Round(Convert.ToDouble(datamulti[4]), 2));
                levelreading1CM = (double)(Math.Round(Convert.ToDouble(datamulti[5]), 2));
                levelreading2CM = (double)(Math.Round(Convert.ToDouble(datamulti[6]), 2));
                pressreading_heatPSI = (double)(Math.Round(Convert.ToDouble(datamulti[7]), 2));

                levelreading_heatCM = ( (Convert.ToDouble(water_volume.Text)*1000)  - (   (121 * 3.141592 * levelreading1CM) + (121 * 3.141592 * levelreading2CM))  ) /( 400 * 3.141592);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }






            ////////////////////////////////////// temp1

            if (tank1_temp_cb.SelectedIndex == 0)
            {
                cn.Close();
                temp_tb1.Text = tempreading1C.ToString();
                             
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '1' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string  temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + temprang + "' ,value2 = '" + low_temprang + "' where val='1' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();




            }

            else if (tank1_temp_cb.SelectedIndex ==1)
            {
                double tempreading1F = (tempreading1C * 1.8) + 32;
                temp_tb1.Text = Convert.ToString(tempreading1F);
                
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '1' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + ((Convert.ToDouble(temprang) *1.8)+32 )+ "' ,value2 = '" + ((Convert.ToDouble( low_temprang) *1.8)+32) + "' where val='1' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank1_temp_cb.SelectedIndex ==2)
            {

                double tempreading1K = tempreading1C + 273;
                temp_tb1.Text = Convert.ToString(tempreading1K);
                
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '1' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + (Convert.ToDouble(temprang) +273) + "' ,value2 = '" +(Convert.ToDouble( low_temprang) +273) + "' where val='1' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();
            }

            ///////////////// temp in heat tank

            if (tank_heat_temp_cb.SelectedIndex ==0)
            {
                temp_heat_tb.Text = tempreading_heat_C.ToString();
                
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '5' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + temprang + "' ,value2 = '" + low_temprang + "' where val='5' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();

            }

            else if (tank_heat_temp_cb.SelectedIndex ==1)
            {
                double tempreading2F = (tempreading_heat_C * 1.8) + 32;
                temp_heat_tb.Text = Convert.ToString(tempreading2F);
                
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '5' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + ((Convert.ToDouble(temprang) * 1.8) + 32) + "' ,value2 = '" + ((Convert.ToDouble(low_temprang) * 1.8) + 32) + "' where val='5' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank_heat_temp_cb.SelectedIndex ==2)
            {

                double tempreading2K = tempreading_heat_C + 273;
                temp_heat_tb.Text = Convert.ToString(tempreading2K);
                
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '5' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + (Convert.ToDouble(temprang) + 273) + "' ,value2 = '" + (Convert.ToDouble(low_temprang) + 273) + "' where val='5' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();
            }

            //////////////// temp 2
            if (tank2_temp_cb.SelectedIndex ==0)
            {
                temp_tb2.Text = tempreading2C.ToString();
              

                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '8' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + temprang + "' ,value2 = '" + low_temprang + "' where val='8' ", cn);
                cmd.ExecuteNonQuery();
                cn.Close();




            }

            else if (tank2_temp_cb.SelectedIndex ==1)
            {
                double tempreading3F = (tempreading2C * 1.8) + 32;
                temp_tb2.Text = Convert.ToString(tempreading3F);
                
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '8' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + ((Convert.ToDouble(temprang) * 1.8) + 32) + "' ,value2 = '" + ((Convert.ToDouble(low_temprang) * 1.8) + 32) + "' where val='8' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank2_temp_cb.SelectedIndex ==2)
            {

                double tempreading3K = tempreading2C + 273;
                temp_tb2.Text = Convert.ToString(tempreading3K);
               
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '8' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + (Convert.ToDouble(temprang) + 273) + "' ,value2 = '" + (Convert.ToDouble(low_temprang) + 273) + "' where val='8' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();
            }

            //////////////////// gas temp
            if (gas_temp_cb.SelectedIndex == 0)
            {
                gas_temp_tb.Text = gas_tempreadingC.ToString();
                

                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '10' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + temprang + "' ,value2 = '" + low_temprang + "' where val='10' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();




            }

            else if (gas_temp_cb.SelectedIndex == 1)
            {
                double gas_tempreadingF = (gas_tempreadingC * 1.8) + 32;
                gas_temp_tb.Text = Convert.ToString(gas_tempreadingF);
                
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '10' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + ((Convert.ToDouble(temprang) * 1.8) + 32) + "' ,value2 = '" + ((Convert.ToDouble(low_temprang) * 1.8) + 32) + "' where val='10' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (gas_temp_cb.SelectedIndex == 2)
            {

                double gas_tempreadingK = gas_tempreadingC + 273;
                gas_temp_tb.Text = Convert.ToString(gas_tempreadingK);
                
                cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '10' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string temprang = dr["value1"].ToString();
                string low_temprang = dr["value2"].ToString();
                cn.Close();

                cn.Open();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + (Convert.ToDouble(temprang) + 273) + "' ,value2 = '" + (Convert.ToDouble(low_temprang) + 273) + "' where val='10' ", cn);

                cmd.ExecuteNonQuery();
                cn.Close();
            }
           

            ////////////////////////////////////////////press1

            if (tank1_press_cb.SelectedIndex ==0)
            {
                press_tb1.Text = pressreading1PSI.ToString();
               
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '2' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
               string pressrang = dr["value1"].ToString();
               string low_pressrang= dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + pressrang + "', value2 ='" + low_pressrang + "' where val='2'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            else if (tank1_press_cb.SelectedIndex==1)
            {
                double pressreading1bar = pressreading1PSI * 0.0689475729;
                press_tb1.Text = Convert.ToString(pressreading1bar);
               
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '2' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string pressrang = dr["value1"].ToString();
                string low_pressrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" +( Convert.ToDouble( pressrang)* 0.0689475729) + "', value2 ='" +(Convert.ToDouble( low_pressrang )* 0.0689475729 )+ "' where val='2'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            else if (tank1_press_cb.SelectedIndex==2)
            {

                double pressreading1kpa = pressreading1PSI * 6.89475729;
                press_tb1.Text = Convert.ToString(pressreading1kpa);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '2' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string pressrang = dr["value1"].ToString();
                string low_pressrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + (Convert.ToDouble(pressrang) * 6.89475729) + "', value2 ='" + (Convert.ToDouble(low_pressrang) * 6.89475729) + "' where val='2'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            ///////////////// press in heat tank

            if (tank_heat_press_cb.SelectedIndex == 0)
            {
                press_heat_tb.Text = pressreading_heatPSI.ToString();
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '6' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string pressrang = dr["value1"].ToString();
                string low_pressrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + pressrang + "', value2 ='" + low_pressrang + "' where val='6'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank_heat_press_cb.SelectedIndex==1)
            {
                double pressreading2bar = pressreading_heatPSI * 0.0689475729;
                press_heat_tb.Text = Convert.ToString(pressreading2bar);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '6' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string pressrang = dr["value1"].ToString();
                string low_pressrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + (Convert.ToDouble(pressrang) * 0.0689475729) + "', value2 ='" + (Convert.ToDouble(low_pressrang) * 0.0689475729) + "' where val='6'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank_heat_press_cb.SelectedIndex ==2)
            {

                double pressreading2kpa = pressreading_heatPSI * 6.89475729;
                press_heat_tb.Text = Convert.ToString(pressreading2kpa);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '6' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string pressrang = dr["value1"].ToString();
                string low_pressrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + (Convert.ToDouble(pressrang) * 6.89475729) + "', value2 ='" + (Convert.ToDouble(low_pressrang) * 6.89475729) + "' where val='6'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            ////////////////press2
            if (tank2_press_cb.SelectedIndex == 0)
            {
                press_tb2.Text = pressreading2PSI.ToString();
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '9' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string pressrang = dr["value1"].ToString();
                string low_pressrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + pressrang + "', value2 ='" + low_pressrang + "' where val='9'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            else if (tank2_press_cb.SelectedIndex==1)
            {
                double pressreading3bar = pressreading2PSI * 0.0689475729;
                press_tb2.Text = Convert.ToString(pressreading3bar);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '9' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string pressrang = dr["value1"].ToString();
                string low_pressrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + (Convert.ToDouble(pressrang) * 0.0689475729) + "', value2 ='" + (Convert.ToDouble(low_pressrang) * 0.0689475729) + "' where val='9'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            else if (tank2_press_cb.SelectedIndex==2)
            {

                double pressreading3kpa = pressreading2PSI * 6.89475729;
                press_tb2.Text = Convert.ToString(pressreading3kpa);
               
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '9' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string pressrang = dr["value1"].ToString();
                string low_pressrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 ='" + (Convert.ToDouble(pressrang) * 6.89475729) + "', value2 ='" + (Convert.ToDouble(low_pressrang) * 6.89475729) + "' where val='9'", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }


            //////////////////////////////////////////level1

            if (tank1_level_cb.SelectedIndex==1)
            {
                level_tb1.Text = levelreading1CM.ToString();
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
               string levelrang = dr["value1"].ToString();
               string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + levelrang + "', value2 = '" + low_levelrang + "' where val='3' ", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            else if (tank1_level_cb.SelectedIndex == 0)
            {
                double levelreading1m = levelreading1CM / 100;
                level_tb1.Text = Convert.ToString(levelreading1m);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" +(Convert.ToDouble( levelrang )/100)+ "', value2 = '" +(Convert.ToDouble( low_levelrang)/100) + "' where val='3' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank1_level_cb.SelectedIndex == 2)
            {

                double levelreading1mm = levelreading1CM * 10;
                level_tb1.Text = Convert.ToString(levelreading1mm);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" +(Convert.ToDouble (levelrang)*10) + "', value2 = '" + (Convert.ToDouble(low_levelrang) * 10) + "' where val='3' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank1_level_cb.SelectedIndex == 3)
            {

                double levelreading1ft = levelreading1CM * 0.032808399;
                level_tb1.Text = Convert.ToString(levelreading1ft);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" +(Convert.ToDouble( levelrang)* 0.032808399) + "', value2 = '" + (Convert.ToDouble(low_levelrang) * 0.032808399) + "' where val='3' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            //////////////////////////////level2
            if (tank2_level_cb.SelectedIndex==1)
            {
                level_tb2.Text = levelreading2CM.ToString();
               
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + levelrang + "', value2 = '" + low_levelrang + "' where val='7' ", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank2_level_cb.SelectedIndex ==0)
            {
                double levelreading2m = levelreading2CM / 100;
                level_tb2.Text = Convert.ToString(levelreading2m);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" +(Convert.ToDouble( levelrang)/100) + "', value2 = '" + (Convert.ToDouble(low_levelrang) / 100) + "' where val='7' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank2_level_cb.SelectedIndex==2)
            {

                double levelreading2mm = levelreading2CM * 10;
                level_tb2.Text = Convert.ToString(levelreading2mm);
             
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" +(Convert.ToDouble( levelrang)*10) + "', value2 = '" + (Convert.ToDouble(low_levelrang) * 10) + "' where val='7' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank2_level_cb.SelectedIndex==3)
            {

                double levelreading2ft = levelreading2CM * 0.032808399;
                level_tb2.Text = Convert.ToString(levelreading2ft);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" +(Convert.ToDouble( levelrang)* 0.032808399) + "', value2 = '" + (Convert.ToDouble(low_levelrang) * 0.032808399) + "' where val='7' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            //////////////////////////////////////////level heat tank


            if (tank_heat_level_cb.SelectedIndex == 1)
            {
                level_heat_tb.Text = levelreading_heatCM.ToString();
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '11' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + levelrang + "', value2 = '" + low_levelrang + "' where val='11' ", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            else if (tank_heat_level_cb.SelectedIndex == 0)
            {
                double levelreading1m = levelreading_heatCM / 100;
                level_heat_tb.Text = Convert.ToString(levelreading1m);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '11' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + (Convert.ToDouble(levelrang) / 100) + "', value2 = '" + (Convert.ToDouble(low_levelrang) / 100) + "' where val='11' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank_heat_level_cb.SelectedIndex == 2)
            {

                double levelreading1mm = levelreading_heatCM * 10;
                level_heat_tb.Text = Convert.ToString(levelreading1mm);
              
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '11' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + (Convert.ToDouble(levelrang) * 10) + "', value2 = '" + (Convert.ToDouble(low_levelrang) * 10) + "' where val='11' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            else if (tank_heat_level_cb.SelectedIndex == 3)
            {

                double levelreading1ft = levelreading_heatCM * 0.032808399;
                level_heat_tb.Text = Convert.ToString(levelreading1ft);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '11' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string levelrang = dr["value1"].ToString();
                string low_levelrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + (Convert.ToDouble(levelrang) * 0.032808399) + "', value2 = '" + (Convert.ToDouble(low_levelrang) * 0.032808399) + "' where val='11' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }


            ///////////////////////////////////// gas flow

            if (gas_flow_cb.SelectedIndex==0)
            {
                flow_tb.Text = flowreadingL_m.ToString();
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '4' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                

                string flowrang = dr["value1"].ToString();
               string low_flowrang = dr["value2"].ToString();
                cn.Close();
                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + flowrang + "', value2 = '" + low_flowrang + "' where val='4' ", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();



            }

            else if (gas_flow_cb.SelectedIndex==1)
            {
                double flowreadingL_h = flowreadingL_m * 60;
                flow_tb.Text = Convert.ToString(flowreadingL_h);
                
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '4' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                string flowrang = dr["value1"].ToString();
                string low_flowrang = dr["value2"].ToString();
                cn.Close();

                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" +(Convert.ToDouble( flowrang)*60) + "', value2 = '" +(Convert.ToDouble( low_flowrang)*60) + "' where val='4' ", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            else if (gas_flow_cb.SelectedIndex==2)
            {

                double flowreadingmL_sec = flowreadingL_m * 16.6666667;
                flow_tb.Text = Convert.ToString(flowreadingmL_sec);
               
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '4' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                cn.Close();

                string flowrang = dr["value1"].ToString();
                string low_flowrang = dr["value2"].ToString();
                cn.Close();

                cmd = new SqlCommand(" Update  my_DB.dbo.data_Table_2  set value1 = '" + (Convert.ToDouble(flowrang) * 16.6666667) + "', value2 = '" + (Convert.ToDouble(low_flowrang) * 16.6666667) + "' where val='4' ", cn);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            heat_tank_level_control.Enabled = true;
            tank1_level_control.Enabled = true;
            tank2_level_control.Enabled = true;
            start_btn.Enabled = false;
        }






       

       

        private void rangsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            


        }

        private void tepmrang_lb2_Click(object sender, EventArgs e)
        {

        }

        

        

        private void button2_Click_1(object sender, EventArgs e)
        {

            cn.Close();
            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_2 Where val= '1' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_lb1.Text = dr["value1"].ToString();
            low_tepmrang_lb1.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '2' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_lb1.Text = dr["value1"].ToString();
            low_pressrang_lb1.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '3' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_lb1.Text = dr["value1"].ToString();
            low_levelrang_lb1.Text = dr["value2"].ToString();
            cn.Close();

            

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_2 Where val= '8' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_lb2.Text = dr["value1"].ToString();
            low_tepmrang_lb2.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '9' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_lb2.Text = dr["value1"].ToString();
            low_pressrang_lb2.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '7' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_lb2.Text = dr["value1"].ToString();
            low_levelrang_lb2.Text = dr["value2"].ToString();
            cn.Close();
           

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '5' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_heat_lb.Text = dr["value1"].ToString();
            low_tepmrang_heat_lb.Text = dr["value2"].ToString();      
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '6' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_heat_lb.Text = dr["value1"].ToString();
            low_pressrang_heat_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '11' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_heat_lb.Text = dr["value1"].ToString();
            low_levelrang_heat_lb.Text = dr["value2"].ToString();
            cn.Close();



            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '4' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            flowrang_lb.Text = dr["value1"].ToString();
            low_flowrang_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_2 Where val= '10' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            gas_tepmrang_lb.Text = dr["value1"].ToString();
            low_gas_tepmrang_lb.Text = dr["value2"].ToString();
            cn.Close();



            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '12' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            water_volume.Text = dr["value1"].ToString();
            cn.Close();


            ///////////////////////////////////////////////
            temp_press_control.Enabled = true;

            if (radioButton1.Checked)
            {
                fill_of_tank1.Enabled = false;
                fill_of_tank2.Enabled = false;
                
            }
            else
            {
                fill_of_tank1.Enabled = true;
                fill_of_tank2.Enabled = true;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            tank1_temp_cb.SelectedItem = "C";
            tank2_temp_cb.SelectedItem = "C";
            tank_heat_temp_cb.SelectedItem = "C";
            gas_temp_cb.SelectedItem = "C";

            tank1_press_cb.SelectedIndex =0 ;
            tank2_press_cb.SelectedIndex = 0;
            tank_heat_press_cb.SelectedIndex = 0;

            tank_heat_level_cb.SelectedItem = "cm";
            tank1_level_cb.SelectedItem = "cm";
            tank2_level_cb.SelectedItem = "cm";
           gas_flow_cb.SelectedItem = "L/min";

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '1' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_lb1.Text = dr["value1"].ToString();
            low_tepmrang_lb1.Text = dr["value2"].ToString();
            cn.Close();


            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '2' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_lb1.Text = dr["value1"].ToString();
            low_pressrang_lb1.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_lb1.Text = dr["value1"].ToString();
            low_levelrang_lb1.Text = dr["value2"].ToString();
            cn.Close();


            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '8' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_lb2.Text = dr["value1"].ToString();
            low_tepmrang_lb2.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '9' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_lb2.Text = dr["value1"].ToString();
            low_pressrang_lb2.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_lb2.Text = dr["value1"].ToString();
            low_levelrang_lb2.Text = dr["value2"].ToString();
            cn.Close();
            

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '5' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_heat_lb.Text = dr["value1"].ToString();
            low_tepmrang_heat_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '6' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_heat_lb.Text = dr["value1"].ToString();
            low_pressrang_heat_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '11' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_heat_lb.Text = dr["value1"].ToString();
            low_levelrang_heat_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '4' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            flowrang_lb.Text = dr["value1"].ToString();
            low_flowrang_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '10' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            gas_tepmrang_lb.Text = dr["value1"].ToString();
            low_gas_tepmrang_lb.Text = dr["value2"].ToString();
            cn.Close();




            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '12' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            water_volume.Text = dr["value1"].ToString();
            cn.Close();



            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '14' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            sensor_port_tb.Text = dr["value1"].ToString();
            control_port_tb.Text = dr["value2"].ToString();
            cn.Close();

        }

        private void usernameAndPasswardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

       

        


       

        

        private void stop_btn_Click(object sender, EventArgs e)
        {

            fill_of_tank2.Enabled = false;
            try

            {
                stop_btn.BackColor = Color.Red;
                start_btn.BackColor = Color.Silver;
                myport.Close();
                start_btn.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }


            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("9");

                valveoff_btn1.BackColor = Color.Red;
                valveon_btn1.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }



            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("b");
                valveoff_btn2.BackColor = Color.Red;
                valveon_btn2.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }

            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("d");

                valveon_btn3.BackColor = Color.Silver;
                valveoff_btn3.BackColor = Color.Red;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }


            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("f");

                valveoff_btn4.BackColor = Color.Red;
                valveon_btn4.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }


            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("0");
                pumpoff_btn1.BackColor = Color.Red;
                pumpon_btn1.BackColor = Color.Silver;

                pictureBox2.Enabled = false;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }


            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("3");

                pumpoff_btn2.BackColor = Color.Red;
                pumpon_btn2.BackColor = Color.Silver;
                pictureBox3.Enabled = false;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }


            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("5");
                pumpoff_btn3.BackColor = Color.Red;
                pumpon_btn3.BackColor = Color.Silver;
                pictureBox4.Enabled = false;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }

            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("7");
                pumpoff_btn4.BackColor = Color.Red;
                pumpon_btn4.BackColor = Color.Silver;
                pictureBox5.Enabled = false;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This App programming to read & view data from contol system project and to control the output order of it. \n \n Programming By MJ.spk 2016 \n  all copyright received ." );
            
        }

        
        private void pumpon_btn1_Click_1(object sender, EventArgs e)
        {
           
           
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("1");
                pumpon_btn1.BackColor = Color.Green;
            pumpoff_btn1.BackColor = Color.Silver;
                myport1.Close();
                pictureBox2.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void pumpoff_btn1_Click_1(object sender, EventArgs e)
        {
            
           
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("0");
                pumpoff_btn1.BackColor = Color.Red;
                pumpon_btn1.BackColor = Color.Silver;

                pictureBox2.Enabled = false;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void pumpon_btn2_Click_1(object sender, EventArgs e)
        {
          
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("2");

                pumpon_btn2.BackColor = Color.Green;
                pumpoff_btn2.BackColor = Color.Silver;
                pictureBox3.Enabled = true;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }

        }

        private void pumpoff_btn2_Click_1(object sender, EventArgs e)
        {
           
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("3");

                pumpoff_btn2.BackColor = Color.Red;
                pumpon_btn2.BackColor = Color.Silver;
                pictureBox3.Enabled = false;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }

        }

        private void pumpon_btn3_Click_1(object sender, EventArgs e)
        {
            
           
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("4");
                pumpon_btn3.BackColor = Color.Green;
                pumpoff_btn3.BackColor = Color.Silver;
                pictureBox4.Enabled = true;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void pumpoff_btn3_Click_1(object sender, EventArgs e)
        {
           
            
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("5");
                pumpoff_btn3.BackColor = Color.Red;
                pumpon_btn3.BackColor = Color.Silver;
                pictureBox4.Enabled = false;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void pumpon_btn4_Click(object sender, EventArgs e)
        {
            
            
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("6");
                pumpon_btn4.BackColor = Color.Green;
                pumpoff_btn4.BackColor = Color.Silver;
                pictureBox5.Enabled = true;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void pumpoff_btn4_Click_1(object sender, EventArgs e)
        {
           
            
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("7");
                pumpoff_btn4.BackColor = Color.Red;
                pumpon_btn4.BackColor = Color.Silver;
                pictureBox5.Enabled = false;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void valveon_btn1_Click_1(object sender, EventArgs e)
        {
            
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("8");
                valveon_btn1.BackColor = Color.Green;
                valveoff_btn1.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void valveoff_btn1_Click_1(object sender, EventArgs e)
        {
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("9");

                valveoff_btn1.BackColor = Color.Red;
                valveon_btn1.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void valveon_btn2_Click_1(object sender, EventArgs e)
        {
            
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("a");
                valveon_btn2.BackColor = Color.Green;
                valveoff_btn2.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void valveoff_btn2_Click_1(object sender, EventArgs e)
        {
            
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("b");
                valveoff_btn2.BackColor = Color.Red;
                valveon_btn2.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void valveon_btn3_Click_1(object sender, EventArgs e)
        {
            
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("c");
                valveon_btn3.BackColor = Color.Green;
                valveoff_btn3.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }


        private void valveoff_btn3_Click_1(object sender, EventArgs e)
        {
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("d");

                valveon_btn3.BackColor = Color.Silver;
                valveoff_btn3.BackColor = Color.Red;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void valveon_btn4_Click_1(object sender, EventArgs e)
        {
            
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("e");
                valveon_btn4.BackColor = Color.Green;
                valveoff_btn4.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }

        private void valveoff_btn4_Click_1(object sender, EventArgs e)
        {
            myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = control_port_tb.Text;


            try
            {
                myport1.Open();
                myport1.WriteLine("f");

                valveoff_btn4.BackColor = Color.Red;
                valveon_btn4.BackColor = Color.Silver;
                myport1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");

            }
        }




        //////////////////////  Tanks fill procedure Tank1///////////////////////////////////////////////////
        private void timer1_Tick(object sender, EventArgs e)
        {
            cn.Close();
            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();


            if (Convert.ToDouble(dr["value1"].ToString()) > levelreading1CM &&  Convert.ToDouble(dr["value2"].ToString()) > levelreading1CM)
            {

                fill_of_tank1.Enabled = false;
                check_of_filled_of_Tank1.Enabled = true;





                /////// Input valve  on
                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("8");
                    valveon_btn1.BackColor = Color.Green;
                    valveoff_btn1.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

            }

            else if (Convert.ToDouble(dr["value1"].ToString()) < levelreading1CM && (Convert.ToDouble(dr["value1"].ToString()) + 1.4) <= levelreading1CM)
            {
                fill_of_tank1.Enabled = false;
                check_of_filled_of_Tank1.Enabled = true;


                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("1");
                    pumpon_btn1.BackColor = Color.Green;
                    pumpoff_btn1.BackColor = Color.Silver;
                    myport1.Close();
                    pictureBox2.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

            }

            else
            {
                safty_tank1.Enabled = true;
                fill_of_tank1.Enabled = false;
            }

            cn.Close();


        }

        ////////////////////////////// check of filled of Tank1/////////////////
        private void check_of_filled_of_Tank1_Tick(object sender, EventArgs e)
        {
            
            cn.Close();
            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();

            if (Convert.ToDouble(dr["value1"].ToString()) >= levelreading1CM && (Convert.ToDouble(dr["value2"].ToString()) ) <= levelreading1CM)
            {
               
                cn.Close();
                check_of_filled_of_Tank1.Enabled = false;
                safty_tank1.Enabled = true;

                /////// Input valve  off
                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("9");
                    valveoff_btn1.BackColor = Color.Red;
                    valveon_btn1.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

               

                 //pump1 off
                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("0");
                    pumpoff_btn1.BackColor = Color.Red;
                    pumpon_btn1.BackColor = Color.Silver;
                    pictureBox2.Enabled = false;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }


            }

        }




        //////////////////////  Tanks fill procedure  tank2///////////////////////////////////////////////////

        private void timer3_Tick(object sender, EventArgs e)
        {


            cn.Close();
            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();

            if (Convert.ToDouble(dr["value1"].ToString()) > levelreading2CM && Convert.ToDouble(dr["value2"].ToString()) > levelreading2CM)
            {
                
                
                check_of_filled_of_Tank2.Enabled = true;
                fill_of_tank2.Enabled = false;


                // valve on 
                
                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("a");
                    valveon_btn2.BackColor = Color.Green;
                    valveoff_btn2.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }
            }



            else if (Convert.ToDouble(dr["value1"].ToString()) < levelreading2CM && (Convert.ToDouble(dr["value1"].ToString()) + 1.4 ) < levelreading2CM)
            {

                check_of_filled_of_Tank2.Enabled = true;
                fill_of_tank2.Enabled = false;

                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("2");
                    pumpon_btn2.BackColor = Color.Green;
                    pumpoff_btn2.BackColor = Color.Silver;
                    pictureBox3.Enabled = true;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

            }

            else
            {
                safty_tank2.Enabled = true;
                fill_of_tank2.Enabled = false;
            }
            cn.Close();


        }


        ///////////////////////// check filled of Tank2//////////////////////////////////
        private void check_of_filled_of_Tank2_Tick(object sender, EventArgs e)
        {
            
            cn.Close();
            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();

            if (Convert.ToDouble(dr["value1"].ToString()) >= levelreading2CM && (Convert.ToDouble(dr["value2"].ToString()) ) <= levelreading2CM)
            {
                cn.Close();


                check_of_filled_of_Tank2.Enabled = false;
                safty_tank2.Enabled = true;
                
                

                /////// Input valve  off
               
                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("b");
                    valveoff_btn2.BackColor = Color.Red;
                    valveon_btn2.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }


                //pump2 off
                
                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("3");
                    pumpoff_btn2.BackColor = Color.Red;
                    pumpon_btn2.BackColor = Color.Silver;
                    pictureBox3.Enabled = false;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }
            }
        }

        /////////////////////////////safty procedure for Tank1//////////////////////////////////////////////////////////////////////////////////////


        private void timer2_Tick(object sender, EventArgs e)
        {

            cn.Close();
            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            
            
            if ( Convert.ToDouble(dr["value1"].ToString()) > levelreading1CM && (Convert.ToDouble(dr["value2"].ToString())-1) > levelreading1CM && levelreading1CM != 0 && pumpon_btn1.BackColor != Color.Green && pumpon_btn3.BackColor != Color.Green && valveoff_btn1.BackColor!=Color.Green)
            {
                cn.Close();


                           
                end_of_safty_tank1.Enabled = true;
                safty_tank1.Enabled = false;

              



                // تشغيل المخة الاوله 

                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("1");
                    pumpon_btn1.BackColor = Color.Green;
                    pumpoff_btn1.BackColor = Color.Silver;
                    pictureBox2.Enabled = true;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }


                // غلق صمام الدخول


                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("9");
                    valveoff_btn1.BackColor = Color.Red;
                    valveon_btn1.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

               


                // تشغيل المخة الاحتياطية 
               
               


                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("4");
                    pumpon_btn3.BackColor = Color.Green;
                    pumpoff_btn3.BackColor = Color.Silver;
                    pictureBox4.Enabled = true;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

                MessageBox.Show("There is a leak Found in Tank1 \n  Precautionary Procedures will Apply Now!");
            }
           
                                   

        }



        ////////////////// end of safty procedure in tank 1///////////////////
        private void end_of_timer2_Tick(object sender, EventArgs e)
        {

            if (levelreading1CM >= 0 && levelreading1CM <= 1)
            {



                end_of_safty_tank1.Enabled = false;


                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("0");
                    pumpoff_btn1.BackColor = Color.Red;
                    pumpon_btn1.BackColor = Color.Silver;

                    pictureBox2.Enabled = false;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

                myport1 = new SerialPort();
                myport1.BaudRate = 9600;
                myport1.PortName = control_port_tb.Text;


                try
                {
                    myport1.Open();
                    myport1.WriteLine("5");
                    pumpoff_btn3.BackColor = Color.Red;
                    pumpon_btn3.BackColor = Color.Silver;
                    pictureBox4.Enabled = false;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }
               

                MessageBox.Show("The Safty Procedure finishing Now! \n Make some Maintenance to your unit and Try to Fill it again");

            }
        }




        ///////////////////////////safty procedure for  Tank2/////////////////////////////////

        private void timer4_Tick(object sender, EventArgs e)
        {

            cn.Close();
            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            

            if (  Convert.ToDouble(dr["value1"].ToString()) > levelreading2CM && (Convert.ToDouble(dr["value2"].ToString()) - 1.8) > levelreading2CM && levelreading2CM!=0 && pumpon_btn2.BackColor != Color.Green && valveoff_btn2.BackColor!= Color.Green)
            {
               
                cn.Close();
                
                end_of_safty_tank2.Enabled = true;
                safty_tank2.Enabled = false;

                // غلق صمام الدخول 

                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("b");
                    valveoff_btn2.BackColor = Color.Red;
                    valveon_btn2.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

                // تشغل المضخة               
               

                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("2");
                    pumpon_btn2.BackColor = Color.Green;
                    pumpoff_btn2.BackColor = Color.Silver;
                    pictureBox3.Enabled = true;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

                MessageBox.Show("Thhre is leak Found in  Tank 2 \n Precautionary Procedures will Apply Now!");
               
            }
           

           
        }



        


        ///////////////end of safty procedure in  Tank2////////////
        private void end_of_timer4_Tick(object sender, EventArgs e)
        {

            if (levelreading2CM >= 0 && levelreading2CM <= 1)
            {
                end_of_safty_tank2.Enabled = false;


                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("3");
                    pumpoff_btn2.BackColor = Color.Red;
                    pumpon_btn2.BackColor = Color.Silver;
                    pictureBox3.Enabled = false;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }


                MessageBox.Show("The Safty Procedure finishing Now!\n Make some Maintenance to  your unit and Try to Fill it again");

               
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0 )
            {
                tank1_timer.Enabled = true;
                tank2_timer.Enabled = false;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                tank2_timer.Enabled = true;
                tank1_timer.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tank1_timer.Enabled = false;
            tank2_timer.Enabled = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

        }


        //////////// feedback system tank1///////////////
        private void tank1_timer_Tick(object sender, EventArgs e)
        {
            cn.Close();
            if (radioButton1.Checked)
            {
                safty_tank1.Enabled = false;
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '3' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                //////////////////check for high level tank1///////////////////////

                if (levelreading1CM > Convert.ToDouble(dr["value1"].ToString()))
                {


                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("1");
                        pumpon_btn1.BackColor = Color.Green;
                        pumpoff_btn1.BackColor = Color.Silver;
                        myport1.Close();
                        pictureBox2.Enabled = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }




                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("9");
                        valveoff_btn1.BackColor = Color.Red;
                        valveon_btn1.BackColor = Color.Silver;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }


                }


                //////////////////check for equal level tank1///////////////////////
                else if (levelreading1CM < (Convert.ToDouble(dr["value1"].ToString()) + 1) && levelreading1CM > (Convert.ToDouble(dr["value2"].ToString())))
                {



                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("8");
                        valveon_btn1.BackColor = Color.Green;
                        valveoff_btn1.BackColor = Color.Silver;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }




                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("1");
                        pumpon_btn1.BackColor = Color.Green;
                        pumpoff_btn1.BackColor = Color.Silver;
                        myport1.Close();
                        pictureBox2.Enabled = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }

                }

                //////////////check for low level tank1///////////////////////


                else if (Convert.ToDouble(dr["value2"].ToString()) > levelreading1CM)
                {


                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("0");
                        pumpoff_btn1.BackColor = Color.Red;
                        pumpon_btn1.BackColor = Color.Silver;
                        pictureBox2.Enabled = false;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }



                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("8");
                        valveon_btn1.BackColor = Color.Green;
                        valveoff_btn1.BackColor = Color.Silver;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }



                    cn.Close();
                }




                cn.Close();
            }

            else
            {
                tank1_timer.Enabled = false;
            }
        }


        //////////// feedback system tank2///////////////
        private void tank2_timer_Tick(object sender, EventArgs e)
        {
            cn.Close();
            if (radioButton1.Checked)
            {
                safty_tank2.Enabled = false;
                cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '7' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                dr["value1"].ToString();
                //////////////////check for high level tank2///////////////////////
                if (levelreading2CM > (Convert.ToDouble(dr["value1"].ToString()) +1))
                {
                    

                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("b");
                        valveoff_btn2.BackColor = Color.Red;
                        valveon_btn2.BackColor = Color.Silver;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }

                   

                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("2");
                        pumpon_btn2.BackColor = Color.Green;
                        pumpoff_btn2.BackColor = Color.Silver;                      
                        pictureBox3.Enabled = true;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }


                    


                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("5");
                        pumpoff_btn3.BackColor = Color.Red;
                        pumpon_btn3.BackColor = Color.Silver;
                        pictureBox4.Enabled = false;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }



                }

                //////////////////check for equal level tank2///////////////////////


                else if (levelreading2CM < (Convert.ToDouble(dr["value1"].ToString()) + 1)  && levelreading2CM > (Convert.ToDouble(dr["value2"].ToString()) ))
                {
                    


                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("a");
                        valveon_btn2.BackColor = Color.Green;
                        valveoff_btn2.BackColor = Color.Silver;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }


                    


                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("2");
                        pumpon_btn2.BackColor = Color.Green;
                        pumpoff_btn2.BackColor = Color.Silver;
                        pictureBox3.Enabled = true;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }


                    


                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("4");
                        pumpon_btn3.BackColor = Color.Green;
                        pumpoff_btn3.BackColor = Color.Silver;
                        pictureBox4.Enabled = true;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }


                }
                //////////////////check for low level tank2///////////////////////
                else if ( (Convert.ToDouble(dr["value2"].ToString()) ) > levelreading2CM)
                {



                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("3");
                        pumpoff_btn2.BackColor = Color.Red;
                        pumpon_btn2.BackColor = Color.Silver;                       
                        pictureBox3.Enabled = false;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }




                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("a");
                        valveon_btn2.BackColor = Color.Green;
                        valveoff_btn2.BackColor = Color.Silver;                       
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }


                    try
                    {
                        myport1 = new SerialPort();
                        myport1.BaudRate = 9600;
                        myport1.PortName = control_port_tb.Text;
                        myport1.Open();
                        myport1.WriteLine("4");
                        pumpon_btn3.BackColor = Color.Green;
                        pumpoff_btn3.BackColor = Color.Silver;
                        pictureBox4.Enabled = true;
                        myport1.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error");

                    }



                }
            }

            else
            {
                tank2_timer.Enabled = false;
            }
            cn.Close();
        }


        

        ///////////// temp and press safty system///////////////////
        private void temp_press_control_Tick(object sender, EventArgs e)
        {
            cn.Close();
            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '6' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            

            if (Convert.ToDouble(dr["value1"].ToString()) < pressreading_heatPSI )
            {

               


                //////////// safty valve open/////////////////

                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("e");
                    valveon_btn4.BackColor = Color.Green;
                    valveoff_btn4.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }



            }


            if (Convert.ToDouble(dr["value1"].ToString()) >= pressreading_heatPSI  )
            {




                //////////// safty valve close/////////////////
               

                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("f");
                    valveoff_btn4.BackColor = Color.Red;
                    valveon_btn4.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }



            }

            cn.Close();
            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_3 Where val= '5' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            

             if (Convert.ToDouble(dr["value1"].ToString()) <= tempreading_heat_C)
            {
                /////////////////// heater off////////////////
                cn.Close();
                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("7");
                    pumpoff_btn4.BackColor = Color.Red;
                    pumpon_btn4.BackColor = Color.Silver;
                    pictureBox5.Enabled = false;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }


               
            }

            if (Convert.ToDouble(dr["value1"].ToString()) > tempreading_heat_C  && Convert.ToDouble(dr["value2"].ToString()) > tempreading_heat_C)
            {
                /////////////////// heater on////////////////
               


                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("6");
                    pumpon_btn4.BackColor = Color.Green;
                    pumpoff_btn4.BackColor = Color.Silver;
                    pictureBox5.Enabled = true;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }


            }

            cn.Close();
            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '12' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            auto_refresh.Interval = Convert.ToInt32( dr["value2"].ToString());
            cn.Close();

           if( autoRefreshToolStripMenuItem.Checked)
            {
                auto_refresh.Enabled = true;

            }
           
            else
            {
                auto_refresh.Enabled = false;
            }
        }

        private void heat_tank_level_control_Tick(object sender, EventArgs e)
        {
           


            if ( levelreading_heatCM < 15 )
            {


                heat_tank_level_control.Enabled = false;


                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("9");
                    valveoff_btn1.BackColor = Color.Red;
                    valveon_btn1.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }




               


                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("b");
                    valveoff_btn2.BackColor = Color.Red;
                    valveon_btn2.BackColor = Color.Silver;
                    myport1.Close();
                    MessageBox.Show("The Level Of Liquid In heat Tank should Not be Less Than '" + levelrang_heat_lb.Text + "' \n Heater could Shut Down !!! ");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

                
               
            }


           

            }

       

        

       

       

        private void tank1_level_control_Tick(object sender, EventArgs e)
        {
            if (levelreading1CM > 30)
            {

                tank1_level_control.Enabled = false;

                try
                {
                    tank1_level_control.Enabled = false;
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("9");
                    valveoff_btn1.BackColor = Color.Red;
                    valveon_btn1.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }

                MessageBox.Show("The Level Of Liquid In  Tank 1 should Not be Higher  Than 30 cm ");
            }

        }

        private void tank2_level_control_Tick(object sender, EventArgs e)
        {

            if (levelreading2CM > 30)
            {

                tank2_level_control.Enabled = false;

                try
                {
                    tank2_level_control.Enabled = false;
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("b");
                    valveoff_btn2.BackColor = Color.Red;
                    valveon_btn2.BackColor = Color.Silver;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }




                try
                {
                    myport1 = new SerialPort();
                    myport1.BaudRate = 9600;
                    myport1.PortName = control_port_tb.Text;
                    myport1.Open();
                    myport1.WriteLine("5");
                    pumpoff_btn3.BackColor = Color.Red;
                    pumpon_btn3.BackColor = Color.Silver;
                    pictureBox4.Enabled = false;
                    myport1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");

                }


                MessageBox.Show("The Level Of Liquid In  Tank 2 should Not be Higher  Than 30 cm ");

            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            comboBox1.Visible = false;
            comboBox3.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox2.Visible = false;
            comboBox1.Visible = false;
        }

        private void auto_refresh_Tick(object sender, EventArgs e)
        {



            ///////////////////////////////////////////////


            if (radioButton1.Checked)
            {
                fill_of_tank1.Enabled = false;
                fill_of_tank2.Enabled = false;

            }
            else
            {
                fill_of_tank1.Enabled = true;
                fill_of_tank2.Enabled = true;
            }

            temp_press_control.Enabled = true;
        }

        private void dispay_refresh_Tick(object sender, EventArgs e)
        {
            cn.Close();

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '14' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            sensor_port_tb.Text = dr["value1"].ToString();
            control_port_tb.Text = dr["value2"].ToString();
            cn.Close();

            cn.Close();
            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_2 Where val= '1' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_lb1.Text = dr["value1"].ToString();
            low_tepmrang_lb1.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '2' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_lb1.Text = dr["value1"].ToString();
            low_pressrang_lb1.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '3' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_lb1.Text = dr["value1"].ToString();
            low_levelrang_lb1.Text = dr["value2"].ToString();
            cn.Close();



            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_2 Where val= '8' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_lb2.Text = dr["value1"].ToString();
            low_tepmrang_lb2.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '9' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_lb2.Text = dr["value1"].ToString();
            low_pressrang_lb2.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '7' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_lb2.Text = dr["value1"].ToString();
            low_levelrang_lb2.Text = dr["value2"].ToString();
            cn.Close();


            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '5' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            tepmrang_heat_lb.Text = dr["value1"].ToString();
            low_tepmrang_heat_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '6' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            pressrang_heat_lb.Text = dr["value1"].ToString();
            low_pressrang_heat_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '11' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            levelrang_heat_lb.Text = dr["value1"].ToString();
            low_levelrang_heat_lb.Text = dr["value2"].ToString();
            cn.Close();



            cmd = new SqlCommand(" Select  value1 , value2 From my_DB.dbo.data_Table_2 Where val= '4' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            flowrang_lb.Text = dr["value1"].ToString();
            low_flowrang_lb.Text = dr["value2"].ToString();
            cn.Close();

            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_2 Where val= '10' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            gas_tepmrang_lb.Text = dr["value1"].ToString();
            low_gas_tepmrang_lb.Text = dr["value2"].ToString();
            cn.Close();



            cmd = new SqlCommand(" Select  value1 ,value2  From my_DB.dbo.data_Table_3 Where val= '12' ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            water_volume.Text = dr["value1"].ToString();
            cn.Close();

            

        }

        private void controlPortsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.ShowDialog();
        }

        private void sensor_port_tb_Click(object sender, EventArgs e)
        {

        }

        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
