namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;

    public class BassGuitar : Guitar, IBassGuitar
    {
        private const int BassGuitarNumberOfStrings = 4;
        private const bool BassGuitarIsElectric = true;

        public BassGuitar(string make, string model, decimal price, string color, 
            string bodyWood, string fingerboardWood)
            : base(make, model, price, color, BassGuitarIsElectric, bodyWood, fingerboardWood, BassGuitarNumberOfStrings)
        {
        }
    }
}
