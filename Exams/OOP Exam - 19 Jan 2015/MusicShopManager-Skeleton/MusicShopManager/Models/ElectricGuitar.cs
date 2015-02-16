namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using System;
    using System.Text;

    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private const int ElectricGuitarNumberOfStrings = 6;
        private const bool ElectricGuitarIsElectric = true;

        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, 
            int numberOfAdapters, int numberOfFrets)
            : base(make, model, price, color, ElectricGuitarIsElectric, bodyWood, fingerboardWood, ElectricGuitarNumberOfStrings)
        {
            if (IsValidNumberOfAdapters(numberOfAdapters))
            {
                this.numberOfAdapters = numberOfAdapters;
            }

            if (IsValidNumberOfFrets(numberOfFrets))
            {
                this.numberOfFrets = numberOfFrets;
            }
        }

        private bool IsValidNumberOfFrets(int numberOfFrets)
        {
            if (numberOfFrets <= 0)
            {
                throw new ArgumentException("The number of frets must be positive.");
            }

            return true;
        }

        private bool IsValidNumberOfAdapters(int numberOfAdapters)
        {
            if (numberOfAdapters < 0)
            {
                throw new ArgumentException("The number of adapters must be positive.");
            }

            return true;
        }

        public int NumberOfAdapters
        {
            get { return this.numberOfAdapters; }
        }

        public int NumberOfFrets
        {
            get { return this.numberOfFrets; }
        }

        public override string ToString()
        {
            StringBuilder electricGuitar = new StringBuilder();

            electricGuitar.AppendLine(base.ToString())
                .AppendFormat("Adapters: {0}", this.NumberOfAdapters).AppendLine()
                .AppendFormat("Frets: {0}", this.NumberOfFrets);

            return electricGuitar.ToString();
        }
    }
}
