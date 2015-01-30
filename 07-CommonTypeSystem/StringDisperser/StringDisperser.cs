using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<Char>
    {
        private IList<char> characters = new List<char>();

        public StringDisperser(params string[] words)
        {
            AddCharacters(words);
        }

        public IList<char> Characters
        {
            get { return this.characters; }
        }

        private void CharDisparser(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                this.characters.Add(word[i]);
            }
        }

        public void AddCharacters(params string[] words)
        {
            foreach (var word in words)
            {
                CharDisparser(word);
            }
        }

        public override bool Equals(object obj)
        {
            StringDisperser other = obj as StringDisperser;
            if (other == null)
            {
                return false;
            }

            bool isEqual = Enumerable.SequenceEqual(this.characters, other.characters);
            if (!isEqual)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var character in this.characters)
            {
                result += character + " ";
            }

            return result;
        }

        public override int GetHashCode()
        {
            int result = 0;
            foreach (var character in this.Characters)
            {
                result ^= character.GetHashCode();
            }
            return result;
        }

        public static bool operator ==(StringDisperser sd1, StringDisperser sd2)
        {
            return Equals(sd1, sd2);
        }

        public static bool operator !=(StringDisperser sd1, StringDisperser sd2)
        {
            return !Equals(sd1, sd2);
        }

        public object Clone()
        {
            StringDisperser cloning = new StringDisperser("");
            cloning.characters = new List<char>();
            foreach (var character in this.Characters)
            {
                cloning.characters.Add(character);
            }

            return cloning;
        }

        public int CompareTo(StringDisperser other)
        {
            string thisChar = string.Join("", this.Characters.ToArray());
            string otherChar = string.Join("", other.Characters.ToArray());

            return string.Compare(thisChar, otherChar, false, CultureInfo.CurrentCulture);
        }

        public IEnumerator<Char> GetEnumerator()
        {
            foreach (var character in this.Characters)
            {
                yield return character;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
