using System;
using System.IO;
using System.Collections.Generic;

namespace evrodiffusion
{
    struct CountryInfo
    {
        public CountryInfo(string name, int xl, int yl, int xh, int yh)
        {
            this.name = name;
            this.xl = xl;
            this.yl = yl;
            this.xh = xh;
            this.yh = yh;
        }
        public string name { get; }
        public int xl { get; }
        public int yl { get; }
        public int xh { get; }
        public int yh { get; }
    }

    class Input
    {
        public List<List<CountryInfo>> countries { get; }

        public Input()
        {
            countries = new List<List<CountryInfo>>();
        }
        public void Load(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                while (!r.EndOfStream)
                {
                    int countryCount = int.Parse(r.ReadLine());
                    if (countryCount > 0)
                    {
                        ParseCountries(r, countryCount);
                    }
                }
            }
        }
        void ParseCountries(StreamReader r, int countryCount)
        {
            List<CountryInfo> items = new List<CountryInfo>();
            for (int i = 0; i < countryCount; ++i)
            {
                string[] lineWords = r.ReadLine().Split(' ');

                var info = new CountryInfo(
                    lineWords[0],
                    int.Parse(lineWords[1]),
                    int.Parse(lineWords[2]),
                    int.Parse(lineWords[3]),
                    int.Parse(lineWords[4])
                );
                items.Add(info);
            }

            countries.Add(items);
        }
    }
}
