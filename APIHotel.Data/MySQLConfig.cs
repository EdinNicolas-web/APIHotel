﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHotel.Data
{
    public class MySQLConfig
    {
        public MySQLConfig(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }
    }
}
