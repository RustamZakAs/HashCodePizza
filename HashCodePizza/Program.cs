using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HashCodePizza
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string[] text = File.ReadAllLines(path + @"\a_example.in", Encoding.UTF8);

            int x = (int)text.LongLength;
            int y = (int)text.Length;
        
            int[,] input;

            input = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    input[i, j] = text[i][j] == 'T' ? 1 : 0;
                }
            }

            input = new int[,] {
                { 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1 },
            };

            //List<int[,]> masList = new List<int[,]>();
            List<string[]> masListStr = new List<string[]>();

            masListStr.Add(findMiniPizza(text));
        }

        public static int[,] findMiniPizza(int[,] input)
        {
            for (int i = 0; i < input.LongLength; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i, j] == 1)
                    {

                        
                    }
                }
            }
            return new int[,] { };
        }

        public static string[] findMiniPizza(string[] input)
        {
            int T = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i][j] == 'T') T++;
                }
            }

            int M = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i][j] == 'M') M++;
                }
            }

            if (T > M) Console.WriteLine("T >"); else Console.WriteLine("M >");

            string[] vs = new string[] { };

            for (int i = 0; i < input.LongLength; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[i][j] == 'T')
                    {
                        

                    }
                }
            }
            return new string[] { };
        }
    }
}
