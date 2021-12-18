using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proj_2
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\Second.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
            /*comboBox1.Items.Add("Select One");
            comboBox2.Items.Add("Select One");
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;
            /*cmd = new SqlCommand("SELECT BloodGroup from tbl_blood",con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox2.Items.Add(dataReader[0]);
            }
            con.Close();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("SELECT BloodId from tbl_blood where BloodGroup='" + comboBox2.Text+"'", con);
            int s=0;
            con.Open();
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                s = (int)rd[0];
            }
            con.Close();
            cmd = new SqlCommand("INSERT into tbl_donor values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + s +"','"+textBox5.Text+ "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Donor Details Added!!");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Select One");
            comboBox2.Items.Add("Select One");
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Select One");
            comboBox2.SelectedIndex = comboBox1.FindStringExact("Select One");
            cmd = new SqlCommand("SELECT BloodGroup from tbl_blood",con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox2.Items.Add(dataReader[0]);
            }
            con.Close();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
        }
    }
}
