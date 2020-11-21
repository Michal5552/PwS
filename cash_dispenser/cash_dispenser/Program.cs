using System;
using System.Collections.Generic;
using System.Linq;
using Cash_dispenser.Data.PinVAL;
using Cash_dispenser.Data.PinVAL.Exceptions;

namespace Cash_dispenser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                PinVAL pinVAL = new PinVAL("19");
            }
            catch (PinVAL_Exception p_e)
            {
                Console.WriteLine(p_e.What());
            }
        }
    }
}