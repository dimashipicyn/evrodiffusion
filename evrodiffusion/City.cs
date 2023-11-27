using System;

namespace evrodiffusion
{
    class City
    {
        Country country;
        Wallet wallet;
        public int x { get; }
        public int y { get; }

        public City(Country country, int x, int y, int initialBalance)
        {
            this.country = country;
            this.x = x;
            this.y = y;

            wallet = new Wallet();
            wallet.AddMoney(country.Motif(), initialBalance);
        }

        public void Distribute(DistributeTransaction transaction, City other)
        {
            if (other is null)
            {
                return;
            }

            foreach (string motif in wallet.AvailableMotifs())
            {
                int representative = GetRepresentativePortion(motif);

                transaction.AddOperation(() =>
                {
                    TakeMoney(motif, representative);
                    other.GiveMoney(motif, representative);
                });
            }
        }

        public bool CityComplete(int motifsCount)
        {
            return wallet.AvailableMotifs().Count == motifsCount;
        }

        void GiveMoney(string countryMotif, int count)
        {
            wallet.AddMoney(countryMotif, count);
        }

        void TakeMoney(string countryMotif, int count)
        {
            wallet.SubMoney(countryMotif, count);
        }

        int GetRepresentativePortion(string countryMotif)
        {
            return wallet.Count(countryMotif) / Constants.REPRESENTATIVE_PORTION_DIVIDER;
        }
    }
}
