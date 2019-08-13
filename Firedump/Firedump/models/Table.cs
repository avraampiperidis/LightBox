﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.pojos
{
    public class Table
    {
        public string TableName;
        public string ColumnName;
        public string DataType;
        public string IsNullable;
        public long length;
        public Table() { }

        public Table(string t,string c,string d,string n,long l):this()
        {
            this.TableName = t;
            this.ColumnName = c;
            this.DataType = d;
            this.IsNullable = n;
            this.length = l;
        }
    }
}