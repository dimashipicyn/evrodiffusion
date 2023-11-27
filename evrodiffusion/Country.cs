using System;
using System.Collections.Generic;

namespace evrodiffusion
{
    class Country
    {
        Map map;
        int xl = 0; // bottom left
        int yl = 0; // bottom left
        int xh = 0; // top right
        int yh = 0; // top right
        public string name { get; }

        public Country(Map map, string name, int xl, int yl, int xh, int yh)
        {
            this.map = map;
            this.name = name;
            this.xl = xl;
            this.yl = yl;
            this.xh = xh;
            this.yh = yh;

            CreateCities(map);
        }

        public string Motif()
        {
            return name;
        }

        public void Distribute(DistributeTransaction transaction)
        {
            map.ForEach(xl, yl, xh, yh, city =>
            {
                city.Distribute(transaction, map.GetCity(city.x - 1, city.y));
                city.Distribute(transaction, map.GetCity(city.x + 1, city.y));
                city.Distribute(transaction, map.GetCity(city.x, city.y - 1));
                city.Distribute(transaction, map.GetCity(city.x, city.y + 1));
            });
        }

        public bool CountryComplete(int motifsCount)
        {
            bool complete = true;
            map.ForEach(xl, yl, xh, yh, city =>
            {
                complete &= city.CityComplete(motifsCount);
            });

            return complete;
        }

        void CreateCities(Map map)
        {
            for (int x = xl; x <= xh; x++)
            {
                for (int y = yl; y <= yh; y++)
                {
                    map.AddCity(new City(this, x, y, Constants.INITIAL_BALANCE));
                }
            }
        }
    }
}
