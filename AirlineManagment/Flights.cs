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
    public partial class Flights : Form
    {
        public Flights()
        {
            InitializeComponent();
        }

       

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
            this.Hide();
        }

        private void Flights_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'airlineDataSet2.flight' table. You can move, or remove it, as needed.
            //this.flightTableAdapter.Fill(this.airlineDataSet2.flight);

        }




        private void btnViewFlights_Click(object sender, EventArgs e)
        {
            ViewFlights viewFlights = new ViewFlights();
            viewFlights.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Class2 cl2 = new Class2();

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (txtFlight.Text == "" || cbDestination.SelectedItem.ToString() == "" || cbSource.SelectedItem.ToString() == "" || txtNumofSeats.Text == "")
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                SqlConnection con = new SqlConnection(cl2.konekcioni());
                con.Open();

                string query = "INSERT " +
                                "INTO flight(fCode, fSource, fDestination, fDate, fCapacity) " +
                                "VALUES ('" + txtFlight.Text + "','" + cbSource.SelectedItem.ToString() + "','" + cbDestination.SelectedItem.ToString() + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "','" + txtNumofSeats.Text + "')";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("Flight Recorded Successfully");
                con.Close();
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
