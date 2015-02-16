using System.Linq;

namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles = new List<IArticle>();

        public MusicShop(string name)
        {
            if (IsValidName(name))
            {
                this.name = name;
            }
        }

        public string Name
        {
            get { return this.name; }
        }

        public IList<IArticle> Articles
        {
            get { return new List<IArticle>(articles); }
        }

        public void AddArticle(IArticle article)
        {
            this.articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder musicShop = new StringBuilder();

            musicShop.AppendFormat("===== {0} =====", this.Name);

            if (this.Articles.Count == 0)
            {
                musicShop.AppendLine().AppendFormat("The shop is empty. Come back soon.");
            }
            else
            {
                var sortedMicrophones =
                    from article in this.Articles
                    where article is Microphone
                    orderby article.Make, article.Model
                    select article;

                var sortedDrums =
                    from article in this.Articles
                    where article is Drums
                    orderby article.Make, article.Model
                    select article;

                var sortedElectricGuitars =
                    from article in this.Articles
                    where article is ElectricGuitar
                    orderby article.Make, article.Model
                    select article;

                var sortedAcousticGuitars =
                    from article in this.Articles
                    where article is AcousticGuitar
                    orderby article.Make, article.Model
                    select article;

                var sortedBassGuitars =
                    from article in this.Articles
                    where article is BassGuitar
                    orderby article.Make, article.Model
                    select article;

                if (sortedMicrophones.Count() > 0)
                {
                    musicShop.AppendLine().AppendFormat("----- Microphones -----");

                    foreach (var sortedMicrophone in sortedMicrophones)
                    {
                        musicShop.AppendLine().Append(sortedMicrophone);
                    }
                }

                if (sortedDrums.Count() > 0)
                {
                    musicShop.AppendLine().AppendFormat("----- Drums -----");

                    foreach (var sortedDrum in sortedDrums)
                    {
                        musicShop.AppendLine().Append(sortedDrum);
                    }
                }

                if (sortedElectricGuitars.Count() > 0)
                {
                    musicShop.AppendLine().AppendFormat("----- Electric guitars -----");

                    foreach (var sortedElectricGuitar in sortedElectricGuitars)
                    {
                        musicShop.AppendLine().Append(sortedElectricGuitar);
                    }
                }

                if (sortedAcousticGuitars.Count() > 0)
                {
                    musicShop.AppendLine().AppendFormat("----- Acoustic guitars -----");

                    foreach (var sortedAcousticGuitar in sortedAcousticGuitars)
                    {
                        musicShop.AppendLine().Append(sortedAcousticGuitar);
                    }
                }

                if (sortedBassGuitars.Count() > 0)
                {
                    musicShop.AppendLine().AppendFormat("----- Bass guitars -----");

                    foreach (var sortedBassGuitar in sortedBassGuitars)
                    {
                        musicShop.AppendLine().Append(sortedBassGuitar);
                    }
                }
            }

            return musicShop.ToString();
        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The name is required.");
            }

            return true;
        }
    }
}
