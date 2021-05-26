using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AirlineManagment
{
    public partial class ViewPassengers : Form
    {
        public ViewPassengers()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Passengers passengers = new Passengers();
            passengers.Show();
            this.Hide();
        }
        Class2 cl2 = new Class2();
        private void shfaqjanegrid()
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            con.Open();
            string query = "SELECT * FROM passenger";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void ViewPassengers_Load(object sender, EventArgs e)
        {
            shfaqjanegrid();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            if(txtID.Text == "")
            {
                MessageBox.Show("Enter the Passenger to delete");
            }
            else
            {
                con.Open();
                string query = "DELETE FROM passenger WHERE pId=" + txtID.Text + ";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Passenger Deleted Successfully");                
                con.Close();
                shfaqjanegrid();
                ViewPassengers viewPassengers = new ViewPassengers();
                viewPassengers.Show();
            }
        }

       
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtPassport.Clear();
            txtAddress.Clear();
            cbNationality.ResetText();
            cbGender.ResetText();
            txtPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            if (txtName.Text == "" || txtPassport.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                con.Open();
                string query = "UPDATE passenger set pName='" + txtName.Text + "',pPassport='" + txtPassport.Text + "',pAddress='" + txtAddress.Text + "',pNationality='" + cbNationality.SelectedItem.ToString() + "',pGender='" + cbGender.SelectedItem.ToString() + "',pPhone='" + txtPhone.Text + "' WHERE pId=" + txtID.Text + ";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Passenger Updated Successfully");
                con.Close();
                shfaqjanegrid();
            }
        }



       

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                string name = row.Cells[1].Value.ToString();
                string passport = row.Cells[2].Value.ToString();
                string address = row.Cells[3].Value.ToString();
                string nationality = row.Cells[4].Value.ToString();
                string gender = row.Cells[5].Value.ToString();
                string phone = row.Cells[6].Value.ToString();
                txtID.Text = id;
                txtName.Text = name;
                txtPassport.Text = passport;
                txtAddress.Text = address;
                cbNationality.SelectedItem = nationality;
                cbGender.SelectedItem = gender;
                txtPhone.Text = phone;
            }

        }
    }
}
