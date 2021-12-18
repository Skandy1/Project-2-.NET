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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\Second.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        public Form3()
        {
            InitializeComponent();
            dataGridView1.Visible = dataGridView2.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Select One");
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Select One");
            cmd = new SqlCommand("SELECT BloodGroup from tbl_blood",con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox1.Items.Add(dataReader[0]);
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT d.DonorId, d.DonorName, d.Address, d.Number, d.Gender, d.Age, b.BloodGroup from tbl_blood b, tbl_donor d where d.BloodId IN (SELECT BloodId from tbl_blood where BloodGroup='" + comboBox1.Text + "')", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select d.DonorId, d.DonorName, d.Address, d.Number, d.Gender, d.Age, b.BloodGroup from tbl_blood b, tbl_donor d where d.Age >='" + textBox1.Text + "' AND b.BloodId=d.BloodId", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            dataGridView2.Visible = true;
        }
    }
}
