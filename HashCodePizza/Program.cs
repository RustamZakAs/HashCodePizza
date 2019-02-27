using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HashCodePizza
{
    class Program
    {
        static void Main(string[] args)
        {
            string   thisAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string   file = Path.Combine(thisAppPath, "a_example.in");
            string[] textLines;
            string   FirstLine;

            int x = 0;
            int y = 0;
            int min = 0;
            int max = 0;
            int TCount = 0;
            int MCount = 0;
            int element = 0;
            int no_element = 0;
            int minCount = 0;

            int[,] input;

            if (File.Exists(file))
            {
                textLines = File.ReadAllLines(file, Encoding.UTF8);
                FirstLine = textLines[0];

                Regex regex = new Regex(@"[0-9]+");
                MatchCollection matches = regex.Matches(FirstLine);
                if (matches.Count > 0)
                {
                    x = int.Parse(matches[0].ToString());
                    y = int.Parse(matches[1].ToString());
                    min = int.Parse(matches[2].ToString());
                    max = int.Parse(matches[3].ToString());
                }
                else
                {
                    Console.WriteLine("Совпадений не найдено");
                }

                input = new int[x, y];
                for (int i = 0, k = 1; i < x; i++, k++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (textLines[k][j] == 'T')
                        {
                            TCount++;
                            input[i, j] = 1;
                        }
                        else
                        {
                            MCount++;
                            input[i, j] = 0;
                        }
                    }
                }

                element = TCount <= MCount ? 1 : 0;
                no_element = TCount > MCount ? 1 : 0;
                minCount = TCount <= MCount ? TCount : MCount;
                //input = new int[,] 
                //{
                //    { 1, 1, 1, 1, 1 },
                //    { 1, 0, 0, 0, 1 },
                //    { 1, 1, 1, 1, 1 },
                //};

                List<int[,]> masList = new List<int[,]>();

                masList.Add(findMiniPizza(input, minCount, no_element));
            }
            else
            {
                Console.WriteLine("File not faund!");
            }
            Console.ReadKey();
        }

        public static int[,] findMiniPizza(int[,] input, int elementCount, int element)
        {
            List<string> outList = new List<string>();

            int _up = 0;
            int _left = 0;
            int _down = 0;
            int _right = 0;

            for (int i = 0; i < elementCount; i++)
            {
                int[] point = Point(input, i + 1);

                //_up    = point[0];
                //_down  = point[0];
                //_left  = point[1];
                //_right = point[1];
                bool Wflag = true;
                for (int w = 0; w <= point[1]; w++)
                {
                    if (Wflag)
                    {
                        for (int a = 0; a <= point[0]; a++)
                        {
                            if (w == 0 && a == 0)
                            {
                                _up = point[0];
                                _left = point[1];
                            }
                            int val = input[point[0] - a, point[1] - w];
                            if (val == element)
                            {
                                _up = point[0] - a;
                                _left = point[1] - w;
                            }
                            else
                            {
                                if (w != 0 && a != 0)
                                {
                                    _left = _left == point[0] ? point[0] : _left - 1;
                                    Wflag = false;
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int a = 0; a <= point[1]; a++)
                {
                    int zz = input.GetLength(0) - point[1] - 1;
                    for (int z = 0; z <= zz; z++)
                    {
                        if (a == 0 && z == 0)
                        {
                            _left = point[0];
                            _down = point[1];
                        }
                        int val = input[point[1] - a, point[0] + z];
                        if (val == element)
                        {
                            _left = point[0] - a;
                            _down = point[1] + z;
                        }
                        else
                        {
                            if (a != 0 && z != 0)
                            {
                                _down = _down == point[0] ? point[0] : _down - 1;
                                Wflag = false;
                                break;
                            }
                        }
                    }
                }

                bool Zflag = true;
                int zzz = input.GetLength(0) - point[1] - 1;
                for (int z = 0; z <= zzz; z++)
                {
                    if (Zflag)
                    {
                        int sss = input.GetLength(1) - point[0] - 1;
                        for (int s = 0; s <= sss; s++)
                        {
                            int val = input[point[1] + z, point[0] + s];
                            if (val == element)
                            {
                                _down = point[0] - z;
                                _right = point[1] + s;
                            }
                            else
                            {
                                _right = point[0];
                                Zflag = false;
                                break;
                            }
                        }
                    }
                }

                outList.Add(_up.ToString() + " " + _left.ToString() + " " + _down.ToString() + " " + _right.ToString() );
            }
            
            foreach (var item in outList)
            {
                Console.WriteLine(item);
            }

            return new int[,] { };
        }

        private static int[] Point (int[,] input, int Item)
        {
            int _Item = 0;
            int x = input.GetLength(0);
            int y = input.GetLength(1);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if ((input[i, j] == 0) && (Item > _Item))
                    {
                        _Item++;
                    }
                    if ((input[i, j] == 0) && (Item == _Item))
                    {
                        return new int[] { i , j };
                    }
                }
            }
            return new int[] { -1, -1 };
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
