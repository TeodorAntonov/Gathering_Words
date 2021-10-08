using System;
using System.Collections.Generic;
using System.Text;

namespace Gathering_Words
{
    public class Falling_Words
    {
        private string symbol;

        Random rndChar = new Random();
        public Falling_Words(string symbol)
        {
            Char = symbol;
        }

        public List<char> listOfChar = new List<char>();
        public string Char
        {
            get
            {
                return symbol;
            }
            set
            {
                for (int i = 65; i <= 122; i++)
                {
                    if (i == 91 || i == 92 || i == 93 || i == 94 || i == 95 || i == 96)
                    {
                        continue;
                    }
                    char ch = Convert.ToChar(i);
                    listOfChar.Add(ch);
                }

                int randomChar = rndChar.Next(listOfChar.Count);
                symbol = listOfChar[randomChar].ToString();
            }
        }

    }
}
