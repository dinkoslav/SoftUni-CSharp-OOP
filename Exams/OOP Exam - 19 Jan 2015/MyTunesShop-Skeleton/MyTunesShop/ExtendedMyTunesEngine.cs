using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesShop
{
    class ExtendedMyTunesEngine : MyTunesEngine
    {
        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song_to_album":
                    this.ExecuteInsertSongToAlbumCommand(commandWords);
                    break;
                case "member_to_band":
                    this.ExecuteInsertMemberToBandCommand(commandWords);
                    break;
                default:
                    base.ExecuteInsertCommand(commandWords);
                    break;
            }
        }

        private void ExecuteInsertMemberToBandCommand(string[] commandWords)
        {
            var band = this.performers.FirstOrDefault(b => (b.Name == commandWords[2]) && b is Band);
            if (band == null)
            {
                this.Printer.PrintLine("The band does not exist in the database.");
                return;
            }

            (band as Band).AddMember(commandWords[3]);
            this.Printer.PrintLine("The member {0} has been added to the band {1}.", commandWords[3], band.Name);
        }

        private void ExecuteInsertSongToAlbumCommand(string[] commandWords)
        {
            var album = this.media.FirstOrDefault(a => (a.Title == commandWords[2]) && a is Album);
            var song = this.media.FirstOrDefault(s => (s.Title == commandWords[3]) && s is Song);
            if (album == null)
            {
                this.Printer.PrintLine("The album does not exist in the database.");
                return;
            }
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }

            (album as Album).AddSong((song as Song));
            this.Printer.PrintLine("The song {0} has been added to the album {1}.", song.Title, album.Title);
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    var album = new Album(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        performer,
                        commandWords[6],
                        int.Parse(commandWords[7]));
                    this.InsertAlbum(album, performer);
                    break;
                default:
                    base.ExecuteInsertMediaCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    base.ExecuteInsertPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteRateCommand(string[] commandWords)
        {
            int rating = int.Parse(commandWords[3]);
            var song = this.media.FirstOrDefault(s => (s.Title == commandWords[2]) && s is Song);
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }

            (song as Song).PlaceRating(rating);
            this.Printer.PrintLine("The rating has been placed successfully.");
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = this.performers.FirstOrDefault(b => b is Band && b.Name == commandWords[3]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;
                default:
                    base.ExecuteReportPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var album = this.media.FirstOrDefault(a => a is Album && a.Title == commandWords[3]) as Album;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetAlbumReport(album));
                    break;
                default:
                    base.ExecuteReportMediaCommand(commandWords);
                    break;
            }
        }

        protected virtual string GetAlbumReport(Album album)
        {
            var albumSalesInfo = this.mediaSupplies[album];
            StringBuilder albumInfo = new StringBuilder();
            albumInfo.AppendFormat("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold).AppendLine();

            if (album.Songs.Count > 0)
            {
                albumInfo.AppendFormat("Songs:");

                foreach (var song in album.Songs)
                {
                    albumInfo.AppendLine().AppendFormat("{0} ({1:F2})", song.Title, float.Parse(song.Duration));
                }
            }
            else
            {
                albumInfo.AppendFormat("No songs");
            }

            return albumInfo.ToString();
        }

        protected override string GetSongReport(ISong song)
        {
            var songSalesInfo = this.mediaSupplies[song];
            StringBuilder songInfo = new StringBuilder();
            songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price).AppendLine()
                .AppendFormat("Rating: {0}", song.AgerageRating).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);
            return songInfo.ToString();
        }

        private void InsertAlbum(Album album, IPerformer performer)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }

        protected virtual string GetBandReport(Band band)
        {
            StringBuilder bandInfo = new StringBuilder();
            bandInfo.Append(band.Name + ": ");
            if (band.Members.Count > 0)
            {
                bandInfo.Append(string.Join(", ", band.Members));
            }

            if (band.Songs.Any())
            {
                var sortedSongs =
                    from currentSong in band.Songs
                    orderby currentSong.Title
                    select currentSong.Title;

                bandInfo.AppendLine().Append(string.Join("; ", sortedSongs));
            }
            else
            {
                bandInfo.AppendLine().Append("no songs");
            }

            return bandInfo.ToString();
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(a => a is Album && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSupplyCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(a => a is Album && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSellCommand(commandWords);
                    break;
            }
        }
    }
}
