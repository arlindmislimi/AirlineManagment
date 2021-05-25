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
        
        private void btnRecord_Click(object sender, EventArgs e)
        {
            
        }
    }
}
