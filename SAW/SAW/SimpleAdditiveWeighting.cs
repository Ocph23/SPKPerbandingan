﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commmon;
using System.Collections.ObjectModel;

namespace SAW
{
    public class SimpleAdditiveWeighting
    {
        public int colls = 7;
        public int rows = 6;
        double[,] NilaiAlternatif = {
                { 1, 3, 2, 1, 5, 3, 2 },
                { 1, 2, 3, 2, 4, 2, 1 },
                { 1, 1, 4, 3, 3, 1, 2 },
                { 1, 2, 5, 4, 2, 3, 1 },
                { 1, 3, 1, 5, 3, 2, 2 },
                { 1, 1, 3, 3, 2, 1, 1 }
        };

        double[] bobot = { 0.25, 0.25, 0.10, 0.10, 0.10, 0.10, 0.10 };

        public ObservableCollection<Criteria> _NilaiAlternatif()
        {
            var Datas = CriteriasCollection.Get();
            return Datas;
        }
        public List<double> MatriksKeputusan()
        {
            double[,] MatriksNormal = new double[rows, colls];
            List<double> normals = new List<double>();
            ObservableCollection<Criteria> Datas = _NilaiAlternatif();
            foreach(var Data in Datas)
            {
                foreach(var Att in Data.Alternatives)
                {
                    var a = Att.Rank;
                    
                    normals.Add(a);
                    
                }
            }
            for (int coll = 0; coll <= colls - 1; coll++)
            {
                double[] data = new double[rows];
                for (int row = 0; row <= rows - 1; row++)
                {
                    data[row] = NilaiAlternatif[row, coll];
                }
                double max = MaxOfArray(data);
                for (int row = 0; row <= rows - 1; row++)
                {
                    MatriksNormal[row, coll] = NilaiAlternatif[row, coll] / max;
                }
            }
            return normals;
        }

        public double[] Hasil()
        {
            double[] hasil = new double[2];
            /*double[,] MatriksN = MatriksKeputusan();
            double[] hasil = new double[colls];
            for (int i = 0; i <= rows - 1; i++)
            {

                for (int j = 0; j <= colls - 1; j++)
                {

                    hasil[i] += bobot[i] * MatriksN[i, j];
                }
            }*/
            return hasil;
        }

        public double MaxOfArray(double[] data)
        {
            var awal = data[0];
            foreach (var item in data)
            {
                if (awal < item)
                {
                    awal = item;
                }
            }
            return awal;
        }


        public double MinOfArray(double[] data)
        {
            var awal = data[0];
            foreach (var item in data)
            {
                if (awal > item)
                {
                    awal = item;
                }
            }
            return awal;
        }
    }


}