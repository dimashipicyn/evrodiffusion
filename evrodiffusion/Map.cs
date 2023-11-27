using System;
using System.Collections.Generic;

namespace evrodiffusion
{
    class Map
    {
        private Dictionary<string, City> map;

        public Map()
        {
            map = new Dictionary<string, City>();
        }

        public void Clear()
        {
            map.Clear();
        }

        public void AddCity(City city)
        {
            map.Add(Key(city.x, city.y), city);
        }

        public City GetCity(int x, int y)
        {
            if (map.ContainsKey(Key(x, y)))
            {
                return map[Key(x, y)];
            }

            return null;
        }

        public void ForEach(int xl, int yl, int xh, int yh, Action<City> action)
        {
            for (int x = xl; x <= xh; x++)
            {
                for (int y = yl; y <= yh; y++)
                {
                    action(GetCity(x, y));
                }
            }
        }

        private string Key(int x, int y)
        {
            return x.ToString() + ":" + y.ToString();
        }
    }
}
