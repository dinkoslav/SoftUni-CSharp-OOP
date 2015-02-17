using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunesShop
{
    public class Band : Performer, IBand
    {
        private IList<string> members = new List<string>();

        public Band(string name) 
            : base(name)
        {
        }

        public override PerformerType Type
        {
            get { return PerformerType.Band; }
        }

        public IList<string> Members
        {
            get { return new List<string>(members); }
        }

        public void AddMember(string memberName)
        {
            this.members.Add(memberName);
        }
    }
}
