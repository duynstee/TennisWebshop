﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    public class Section
    {
        public string SectionLetter;
        public List<Row> Rows = new List<Row>();
        public Section(string sectionCode, int totalRows, int totalSeats)
        {
            for (int i = 0; i < totalRows; i++)
            {
                int rowNumber = i + 1;
                Row row = new Row(sectionCode, rowNumber , totalSeats);
                 
                Rows.Add(row);
            }
        }
    }
}
