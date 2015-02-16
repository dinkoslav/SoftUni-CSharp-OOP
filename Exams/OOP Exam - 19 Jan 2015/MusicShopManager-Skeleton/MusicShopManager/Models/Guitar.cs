namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using System;
    using System.Text;

    public class Guitar : Instrument, IGuitar
    {
        private string bodyWood;
        private string fingerboardWood;
        private int numberOfStrings;

        public Guitar(string make, string model, decimal price, string color, bool isElectrinic, 
            string bodyWood, string fingerboardWood, int numberOfStrings) 
            : base(make, model, price, color, isElectrinic)
        {
            if (IsValidBodyWood(bodyWood))
            {
                this.bodyWood = bodyWood;
            }

            if (IsValidFingerboardWood(fingerboardWood))
            {
                this.fingerboardWood = fingerboardWood;
            }

            this.numberOfStrings = numberOfStrings;
        }

        public string BodyWood
        {
            get { return this.bodyWood; }
        }

        public string FingerboardWood
        {
            get { return this.fingerboardWood; }
        }

        public int NumberOfStrings
        {
            get { return this.numberOfStrings; }
        }

        private bool IsValidFingerboardWood(string fingerboardWood)
        {
            if (string.IsNullOrEmpty(fingerboardWood))
            {
                throw new ArgumentException("The fingerboard wood is required.");
            }

            return true;
        }

        private bool IsValidBodyWood(string bodyWood)
        {
            if (string.IsNullOrEmpty(bodyWood))
            {
                throw new ArgumentException("The body wood is required.");
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder guitar = new StringBuilder();

            guitar.AppendLine(base.ToString())
                .AppendFormat("Strings: {0}", this.NumberOfStrings).AppendLine()
                .AppendFormat("Body wood: {0}", this.BodyWood).AppendLine()
                .AppendFormat("Fingerboard wood: {0}", this.FingerboardWood);

            return guitar.ToString();
        }
    }
}
