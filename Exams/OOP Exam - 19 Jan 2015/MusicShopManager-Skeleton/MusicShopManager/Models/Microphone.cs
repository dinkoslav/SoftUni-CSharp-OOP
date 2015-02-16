namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using System.Text;

    public class Microphone : Article, IMicrophone
    {
        private bool hasCable;

        public Microphone(string make, string model, decimal price, bool hasCable) 
            : base(make, model, price)
        {
            this.hasCable = hasCable;
        }

        public bool HasCable
        {
            get { return this.hasCable; }
        }

        public override string ToString()
        {
            StringBuilder microphone = new StringBuilder();

            microphone.AppendLine(base.ToString())
                .AppendFormat("Cable: {0}", this.hasCable ? "yes" : "no");

            return microphone.ToString();
        }
    }
}
