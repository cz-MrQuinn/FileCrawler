﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCrawler.viewmodels
{
   public class DirListingItem
    {
        public int id { get; set; }
        public string DirName { get; set; }
        public string FileName { get; set; }

        public long FileSize { get; set; }

        public DateTime FileCreated { get; set; }
        public DateTime FileLastAccess { get; set; }
        public DateTime FileLastWrite { get; set; }

        public string FileHash { get; set; }

    }
}

