using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_HTMLDispatcher
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string source, string alt, string title)
        {
            ElementBuilder e = new ElementBuilder("img");
            e.AddAttribute("src", source);
            e.AddAttribute("alt", alt);
            e.AddAttribute("title", title);

            return e.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder e = new ElementBuilder("a");
            e.AddAttribute("href", url);
            e.AddAttribute("title", title);
            e.AddContent(text);

            return e.ToString();
        }

        public static string CreateInput(string inputType, string name, string value)
        {
            ElementBuilder e = new ElementBuilder("input");
            e.AddAttribute("type", inputType);
            e.AddAttribute("name", name);
            e.AddAttribute("value", value);

            return e.ToString();
        }
    }
}
