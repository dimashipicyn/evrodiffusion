using System;
using System.Collections.Generic;

namespace evrodiffusion
{
    class Wallet
    {
        private Dictionary<string, int> balance;

        public Wallet()
        {
            balance = new Dictionary<string, int>();
        }

        public void AddMoney(string countryMotif, int count)
        {
            if (balance.ContainsKey(countryMotif))
            {
                balance[countryMotif] += count;
            }
            else
            {
                balance.Add(countryMotif, count);
            }
        }

        public void SubMoney(string countryMotif, int count)
        {
            if (balance[countryMotif] < count)
            {
                throw new Exception($"Not enough funds for this motif: {countryMotif}");
            }

            balance[countryMotif] -= count;
        }

        public int Count(string countryMotif)
        {
            return balance[countryMotif];
        }

        public List<string> AvailableMotifs()
        {
            return new List<string>(balance.Keys).FindAll(key => Count(key) > 0);
        }
    }
}
