namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using MusicShopManager.Models;
    using System;
    using System.Text;

    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private const int AcousticGuitarNumberOfStrings = 6;
        private const bool AcousticGuitarIsElectric = false;

        private bool caseIncluded;
        private StringMaterial stringMaterial;

        public AcousticGuitar(string make, string model, decimal price, string color, 
            string bodyWood, string fingerboardWood, 
            bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, AcousticGuitarIsElectric, bodyWood, fingerboardWood, AcousticGuitarNumberOfStrings)
        {
            this.caseIncluded = caseIncluded;
            this.stringMaterial = stringMaterial;
        }

        public bool CaseIncluded
        {
            get { return this.caseIncluded; }
        }

        public StringMaterial StringMaterial
        {
            get { return this.stringMaterial; }
        }

        public override string ToString()
        {
            StringBuilder acousticGuitar = new StringBuilder();

            acousticGuitar.AppendLine(base.ToString())
                .AppendFormat("Case included: {0}", this.CaseIncluded ? "yes" : "no").AppendLine()
                .AppendFormat("String material: {0}", this.StringMaterial.ToString());

            return acousticGuitar.ToString();
        }
    }
}
