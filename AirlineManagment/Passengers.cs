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


namespace AirlineManagment
{
    public partial class Passengers : Form
    {
        public Passengers()
        {
            InitializeComponent();
        }
       
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
            this.Hide();
        }

        private void btnViewFlights_Click(object sender, EventArgs e)
        {
            ViewPassengers viewPassengers = new ViewPassengers();
            viewPassengers.Show();
            this.Hide();
        }  
        
        
        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Class2 cl2 = new Class2();
        
        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPassport.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                SqlConnection con = new SqlConnection(cl2.konekcioni());
                con.Open();
                
                string query = "insert into passenger(pName,pPassport,pAddress,pNationality,pGender,pPhone) values('"+ txtName.Text + "','" + txtPassport.Text + "','" + txtAddress.Text + "','" + cbNationality.SelectedItem.ToString() + "','" + cbGender.SelectedItem.ToString() + "','" + txtPhone.Text + "')";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("Passenger Recorded Successfully");
                con.Close();          
    
            }

        }

        private void Passengers_Load(object sender, EventArgs e)
        {
            
            string kon = cl2.konekcioni();
            SqlDataAdapter da = new SqlDataAdapter("SELECT pId FROM passenger ORDER BY pId DESC", kon);
            DataTable ds = new DataTable();
            da.Fill(ds);
            int count = int.Parse(ds.Rows[0][0].ToString());
            label11.Text = (count + 1).ToString();                          

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPassport.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cbNationality.ResetText();
            cbGender.ResetText();
        }
    }
}
