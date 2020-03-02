using System;
using System.Collections.Generic;
using ToolWatchCache;

namespace ToolWatchCode
{
    public class ToolWatchInfo
    {
        public static void Main()
        {
            //Setup cache
            MyTWCache twc = new MyTWCache();

            //Add basic items to cache for later reference
            twc.Set("Products", "AAAA, AAAB, AAAC");
            twc.Set("AAAA_Desc", "Barcode to keep track of select item's checkout and return");
            twc.Set("AAAB_Desc", "Tracker & Barcode to keep track of select item's checkout and return as well as GPS tracking");
            twc.Set("AAAC_Desc", "Scanner for station to check in and check out tools for work");
            twc.Set("AAAA_Price", 1);
            twc.Set("AAAB_Price", 5);
            twc.Set("AAAC_Price", 4);

            //Someone wants to enter something, but not sure if it already exists and doesn't want to destroy any info in case there is
            //They can
            if (!twc.Contains("AAAC_Desc"))
            {
                twc.Set("AAAC_Desc", "More info coming soon!");
            }

            //Or simply
            twc.SetNX("AAAC_Desc", "New info coming soon!");

            //To remove items from the cache
            twc.Delete("AAAC_Price");
            twc.Delete("AAAC_Desc");

            //if it cannot find the key you're looking for, it will return an exception
            try
            {
                twc.Delete("AAAD_Desc");
            }
            catch (KeyNotFoundException e)
            {
                //Which you can handle gracefully
                Console.WriteLine("Key not found! Nothing deleted");
            }

            //it will also return an exception should it fail to get the key
            try
            {
                object obj = twc.Get("AAAD_Desc");
                Console.WriteLine("The desc is: " + (string)obj);
            }
            catch (KeyNotFoundException e)
            {
                //Which you can handle gracefully
                Console.WriteLine("Key not found! Nothing returned");
            }

            //You can always list the keys if you forget what is there
            string[] keys = twc.ListKeys();
            Console.WriteLine("\nKeys in the cache...");
            foreach (string k in keys)
            {
                Console.WriteLine(k);
            }


            //Hold console
            Console.ReadKey();
        }
    }
}
