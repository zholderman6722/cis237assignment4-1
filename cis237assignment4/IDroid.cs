﻿//Zachery Holderman
//CIS237
//Instructor: David Barnes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    interface IDroid
    {
        //Method to calculate the total cost of a droid
        void CalculateTotalCost();

        //property to get the total cost of a droid
        decimal TotalCost { get; set; }
    }
}
