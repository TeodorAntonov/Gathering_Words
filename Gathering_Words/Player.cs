using System;
using System.Collections.Generic;
using System.Text;

namespace Gathering_Words
{
    public class Player
    {
        private string _symbol;
        public Player(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol    
        {
            get 
            {
                return _symbol;
            }
            set 
            {
                _symbol = value;              
                
            }   
        }
    }
}
