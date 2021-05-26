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
            // TODO: This line of code loads data into the 'airlineDataSet1.flight' table. You can move, or remove it, as needed.
            this.flightTableAdapter.Fill(this.airlineDataSet1.flight);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                string query = "UPDATE " +
                    "           flight set fCode='" + txtFlight.Text +
                                "',fSource='" + cbSource.SelectedItem.ToString() + "',fDestination='" + cbDestination.SelectedItem.ToString() + "',fDate='" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "',fCapacity='" + txtNumofSeats.Text + ";";

               
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Flight Information has been Updated");
                con.Close();
                this.flightTableAdapter.Fill(this.airlineDataSet1.flight);
            }
        }
        Class2 cl2 = new Class2();
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
                this.flightTableAdapter.Fill(this.airlineDataSet1.flight);
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
    }
}
