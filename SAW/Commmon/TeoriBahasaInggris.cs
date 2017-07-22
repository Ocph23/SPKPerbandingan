﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commmon
{
    public class TeoriBahasaInggris : Alternative
    {
        public Criteria criteria = new Criteria();
        public double _nilai;

        public TeoriBahasaInggris()
        {
            Ranks = new List<Range>
            {
                new Range("0-50", 0, 50, 0, 0),
                new Range("51-60", 51, 60, 1, 0),
                new Range("61-70", 61, 70, 2, 0),
                new Range("71-80", 71, 80, 3, 0),
                new Range("81-90", 81, 90, 4, 0),
                new Range("91-100", 91, 100, 5, 0)
            };
        }

        public double Nilai
        {
            set
            {
                _nilai = value;
                this.Bobot = Ranks.Where(O => O.Min <= value && O.Max >= value).FirstOrDefault().Bobot;

            }
        }

        public List<Range> Ranks { get; private set; }
    }
}