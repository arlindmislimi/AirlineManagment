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
    public partial class ViewFlights : Form
    {
        public ViewFlights()
        {
            InitializeComponent();
        }

        private void ViewFlights_Load(object sender, EventArgs e)
        {
            shfaqjanegrid();

        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            Flights flights = new Flights();
            flights.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Class2 cl2 = new Class2();
        private void shfaqjanegrid()
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            con.Open();
            string query = "SELECT * FROM flight";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            if (txtFlight.Text == "" || cbDestination.SelectedItem.ToString() == "" || cbSource.SelectedItem.ToString() == "" || txtNumofSeats.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                con.Open();
                string query = "UPDATE flight set fSource='" + cbSource.SelectedItem.ToString() + "',fDestination='" + cbDestination.SelectedItem.ToString() + "',fDate='" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "',fCapacity='" + txtNumofSeats.Text + "';";


                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Flight Information has been Updated");
                con.Close();
                shfaqjanegrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            if (txtFlight.Text == "")
            {
                MessageBox.Show("Please Enter Flight Code");
            }
            else
            {
                con.Open();
                string query = "DELETE FROM flight WHERE fCode=" + txtFlight.Text + ";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Flight Has Been Removed from The Schedule");
                con.Close();
                shfaqjanegrid();
                ViewFlights viewFlights = new ViewFlights();
                viewFlights.Show();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFlight.Clear();
            cbDestination.ResetText();
            cbSource.ResetText();
            dateTimePicker1.ResetText();
            txtNumofSeats.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string flightcode = row.Cells[0].Value.ToString();
                string source = row.Cells[1].Value.ToString();
                string destination = row.Cells[2].Value.ToString();
                //string takeofdate = row.Cells[3].Value.ToString();
                string numofseats = row.Cells[4].Value.ToString();

                txtFlight.Text = flightcode;
                cbSource.SelectedItem = source;
                cbDestination.SelectedItem = destination;
                
                txtNumofSeats.Text = numofseats;

            }
        }
    }
}
