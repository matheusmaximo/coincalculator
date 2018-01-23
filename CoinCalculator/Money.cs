using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCalculator
{
    /// <summary>
    /// Auxiliar class to represent money
    /// </summary>
    public class Money
    {
        public string FaceValue { get; set; }
        public int Value { get; set; }
        public int AmountAvailable { get; set; }
        public int AmountUsed { get; set; }
        public bool ControlledAvailability { get; set; }
    }
}
