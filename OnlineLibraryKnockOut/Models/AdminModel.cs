﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityCore.Mappings;

namespace OnlineLibraryKnockOut.Models
{
    public class AdminModel : AdminMst
    {
        public string Type { get; set; }
        public string returnURL { get; set; }

        public bool isRemember { get; set; }
    }
}