using System;
using System.Collections.Generic;

namespace SimpleRAMKiller
{
    class Program
    {
        static List<byte[]> buffer = new List<byte[]>();
        static void Main(string[] args)
        {
            while (true)
            {
                var buf = new byte[1048576];
                for(int i = 0; i < buf.Length; i++)
                {
                    buf[i] = 1;
                }
                buffer.Add(buf);
                Console.WriteLine($"RAM +  {buffer.Count}");
            }
        }
    }
}
