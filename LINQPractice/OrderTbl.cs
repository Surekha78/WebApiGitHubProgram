﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LINQPractice
{
    public partial class OrderTbl
    {
        // [PK]
        public int Oid { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public string Test { get; set; }
        public string Test2 { get; set; }
    }
}
