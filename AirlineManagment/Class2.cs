﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AirlineManagment
{
    class Class2
    {
        public string konekcioni()
        {
            string con = "Data Source=ARLIND\\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";
            return con;
        }
    }
}