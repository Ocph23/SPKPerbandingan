﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commmon
{
   public  class Criteria
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Bobot { get; set; }
        public object UserValue { get; set; }

        public ObservableCollection<Alternative> Alternatives { get; set; }
    }
}