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
    public partial class Cancellation : Form
    {
        public Cancellation()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Class2 cl2 = new Class2();

        private void Cancellation_Load(object sender, EventArgs e)
        {
            fillTicketId();
            populate();
        }
        private void fetchfcode()
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            con.Open();
            string query = "select * from ticket where Tid=" + cbTicketID.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtFlightCode.Text = dr["Fcode"].ToString();
                con.Close();
            }
        }
            private void fillTicketId()
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Tid FROM ticket", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tid", typeof(string));
            dt.Load(rdr);
            cbTicketID.ValueMember = "Tid";
            cbTicketID.DataSource = dt;
            con.Close();
        }
        private void populate()
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            con.Open();
            string query = "select * from cancel";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            if (txtCancelID.Text == "" || txtFlightCode.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into cancel values(" + txtCancelID.Text + "," + cbTicketID.SelectedValue.ToString() + ",'" + txtFlightCode.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket Cancelled Successfully");
                    con.Close();
                    populate();
                    // deleteTicket;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void cbTicketID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchfcode();
        }
    }
}
