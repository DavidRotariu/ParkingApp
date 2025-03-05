﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ParkingApp
{
    public class Parcare
    {
        public string Nume { get; set; }
        public List<LocDeParcare> Locuri { get; set; }

        public Parcare(string nume, int totalSpots)
        {
            Nume = nume;
            Locuri = new List<LocDeParcare>();

            for (int i = 1; i <= totalSpots; i++)
            {
                Locuri.Add(new LocDeParcare(i));
            }
        }

        public string GetStatusParcare()
        {
            string status = $"Parcarea: {Nume}\n";

            foreach (var spot in Locuri)
            {
                status += spot.GetInfo() + "\n";
            }

            return status;
        }
    }
}
