﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BukaExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Extractor.setFilePath(Directory.GetCurrentDirectory());
            else
                Extractor.setFilePath(args[0]);

            Extractor et;
            if (Extractor.isBukaFormat())
            {
                Console.WriteLine("BukaFormat");
                et = new BukaExtractor();
            }
            else
            if (Extractor.isHBupViewFormat())
            {
                Console.WriteLine("HBupViewFormat");
                et = new HBupViewExtractor();
            }
            else
            {
                et = null;
                Console.WriteLine("No Buka files is found");
            }

            if (et != null)
                et.extract();            
        }
    }
}
