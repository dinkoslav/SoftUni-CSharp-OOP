namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using System;
    using System.Text;

    public class Instrument : Article, IInstrument
    {
        private string color;
        private bool isElectronic;

        public Instrument(string make, string model, decimal price, string color, bool isElectronic) 
            : base(make, model, price)
        {
            if (IsValidColor(color))
            {
                this.color = color;
            }

            this.isElectronic = isElectronic;
        }

        public string Color
        {
            get { return this.color; }
        }

        public bool IsElectronic
        {
            get { return this.isElectronic; }
        }

        private bool IsValidColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                throw new ArgumentException("The color is required.");
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder instrument = new StringBuilder();

            instrument.AppendLine(base.ToString())
                .AppendFormat("Color: {0}", this.Color).AppendLine()
                .AppendFormat("Electronic: {0}", this.IsElectronic ? "yes" : "no");

            return instrument.ToString();
        }
    }
}
