using System;
using System.Text;

namespace Domain.Utils
{
    public static class Salt
    {
        private static readonly Random _random = new ();
        
        public static string Generate(uint size)
        {
            StringBuilder str_build = new ();
            
            for (int i = 0; i < size; i++)
            {
                bool isNumber = _random.Next() % 2 == 0;
                bool isUpperCase = _random.Next() % 2 != 0;
                double seed = _random.NextDouble();
                char value;
                
                if (isNumber)
                {
                    int shift = Convert.ToInt32(Math.Floor(10 * seed));
                    value = Convert.ToChar(shift + 48);
                }
                else
                {
                    if (isUpperCase)
                    {
                        int shift = Convert.ToInt32(Math.Floor(25 * seed));
                        value = Convert.ToChar(shift + 65);
                    }
                    else
                    {
                        int shift = Convert.ToInt32(Math.Floor(25 * seed));
                        value = Convert.ToChar(shift + 97);
                    }
                }
                str_build.Append(value);
            }

            return str_build.ToString();
        }
    }
}
