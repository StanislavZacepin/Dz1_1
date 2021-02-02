using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Dz4
{
    class Program
    {
        static void Main(string[] args)
        {
          var Text2 = new Dictionary<string, int>();

           
            List<int> Text = new List<int>(10);
            var g=0;
            Random rnd = new Random();
           
            for(int b=0 ;b<10;b++)
            {
                g = rnd.Next(0,11);
                Text.Add(g);
            }
            using (StreamWriter stream = new StreamWriter("Dz4.txt"))
                for(int i = 0; i < Text.Count; i++)
                {
                    stream.Write(Text[i]+","); 
                }

           


            using (var file_reader = File.OpenText("Dz4.txt"))
                while (!file_reader.EndOfStream)
                {
                    var str = file_reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(str)) continue;

                    var components = str.Split(',');
                    foreach (var item in components)
                    {
                        if (Text2.ContainsKey(item))
                            Text2[item]++;
                        else Text2.Add(item, 1);

                    }
              
                  
                    }






        }
    }
}
