﻿using System;

namespace Fynance.Result
{
    public class FyQuote
    {
        public DateTime Period { get; set; }

        public double Low { get; set; }
        
        public double Close { get; set; }
        
        public double Open { get; set; }

        public double High { get; set; }
        
        public double AdjClose { get; set; }

        public double Volume { get; set; }        
    }
}