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
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }
        Class2 cl2 = new Class2();
        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void populate()
        {

            SqlConnection con = new SqlConnection(cl2.konekcioni());

            con.Open();
            string query = "select * from ticket";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void fillPassenger()
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT pId from passenger", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("pId", typeof(int));
            dt.Load(rdr);
            cbPassengerID.ValueMember = "pId";
            cbPassengerID.DataSource = dt;
            con.Close();
        }
        private void fillFlightCode()
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            con.Open();
            SqlCommand cmd = new SqlCommand("select fCode from flight", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("fCode", typeof(string));
            dt.Load(rdr);
            cbFlightCode.ValueMember = "fCode";
            cbFlightCode.DataSource = dt;
            con.Close();
        }
        string pname, ppass,pnat;
        
        private void fetchpassenger()
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            con.Open();
            string query = "select * from passenger where pId=" + cbPassengerID.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                pname = dr["pName"].ToString();
                ppass = dr["pPassport"].ToString();
                pnat = dr["pNationality"].ToString();
                txtName.Text = pname;
                txtPassport.Text = ppass;
                txtNationality.Text = pnat;
            }
            con.Close();
        }

                

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPassport.Text = "";
            txtNationality.Text = "";
            txtAmount.Text = "";
            txtTicketID.Text = "";
        }

        private void cbPassengerID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchpassenger();
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cl2.konekcioni());
            if (txtTicketID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                
                    con.Open();
                    string query = "insert into ticket values(" + txtTicketID.Text + ",'" + cbFlightCode.SelectedValue.ToString() + "','" + cbPassengerID.SelectedValue.ToString() + "','" + txtName.Text + "','" + txtPassport.Text + "','" + txtNationality + "','" + txtAmount.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket Booked Successfully");
                    con.Close();
                    populate();
                
            }
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            fillPassenger();
            
            fillFlightCode();
            populate();
        }

        
    }
}
