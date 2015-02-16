namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using System;
    using System.Text;

    public class Drums : Instrument, IDrums
    {
        private const bool DrumsIsElectric = false;

        private int width;
        private int height;

        public Drums(string make, string model, decimal price, string color, int width, int height)
            : base(make, model, price, color, DrumsIsElectric)
        {
            if (IsValidWidth(width))
            {
                this.width = width;
            }

            if (IsValidHeight(height))
            {
                this.height = height;
            }
        }

        private bool IsValidHeight(int height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("The height must be positive.");
            }

            return true;
        }

        private bool IsValidWidth(int width)
        {
            if (width <= 0)
            {
                throw new ArgumentException("The width must be positive.");
            }

            return true;
        }

        public int Width
        {
            get { return this.width; }
        }

        public int Height
        {
            get { return this.height; }
        }

        public override string ToString()
        {
            StringBuilder drum = new StringBuilder();

            drum.AppendLine(base.ToString())
                .AppendFormat("Size: {0}cm x {1}cm", this.Width, this.Height);

            return drum.ToString();
        }
    }
}
