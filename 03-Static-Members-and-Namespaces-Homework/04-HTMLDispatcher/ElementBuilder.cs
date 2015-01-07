using System;

namespace _04_HTMLDispatcher
{
    class ElementBuilder
    {
        private string name;
        private string attributes;
        private string content = "";

        public ElementBuilder(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Element name can not be null or empty");
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public static string operator *(ElementBuilder e, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += e;
            }

            return result;
        }

        public void AddAttribute(string attribute, string value)
        {
            this.attributes += " " + attribute + "=\"" + value + "\"";
        }

        public void AddContent(string contentToAdd)
        {
            this.content += contentToAdd;
        }

        public override string ToString()
        {
            return string.Format("<{0}{1}>{2}<\\{0}>", name, attributes, content);
        }
    }
}
