using System;
using System.Collections.Generic;

namespace evrodiffusion
{
    class DiffusionSimulator
    {
        List<Country> countries;
        Map map;
        int daysPassed = 0;
        public Dictionary<string, int> stats { get; }

        public DiffusionSimulator(List<CountryInfo> items)
        {
            countries = new List<Country>();
            map = new Map();
            stats = new Dictionary<string, int>();

            AddCountries(items);
        }

        public void Simulate()
        {
            while (!countries.TrueForAll(c => c.CountryComplete(countries.Count)))
            {
                daysPassed++;

                DistributeTransaction transaction = new DistributeTransaction();
                foreach (Country c in countries)
                {
                    c.Distribute(transaction);
                }

                transaction.Commit();
                UpdateStats();

            }
            UpdateStats();
        }
        void AddCountries(List<CountryInfo> items)
        {
            foreach (CountryInfo countryInfo in items)
            {
                Country country = new Country(
                    map,
                    countryInfo.name,
                    countryInfo.xl,
                    countryInfo.yl,
                    countryInfo.xh,
                    countryInfo.yh
                );
                countries.Add(country);
            }
        }

        void UpdateCountryStats(Country c)
        {
            if (!stats.ContainsKey(c.name))
            {
                stats.Add(c.name, daysPassed);
            }
        }

        void UpdateStats()
        {
            foreach (Country c in countries)
            {
                if (c.CountryComplete(countries.Count))
                {
                    UpdateCountryStats(c);
                }
            }
        }
    }
}
