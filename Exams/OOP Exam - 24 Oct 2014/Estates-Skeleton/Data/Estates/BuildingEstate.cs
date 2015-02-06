using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Data.Estates
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;

        public int Rooms
        {
            get { return this.rooms; }
            set
            {
                if (value < 0 || 20 < value)
                {
                    throw new ArgumentOutOfRangeException("Rooms must be in range [0…20]");
                }
                this.rooms = value;
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Append("Rooms: " + this.Rooms + ", ");
            result.Append("Elevator: " + (this.HasElevator ? "Yes" : "No"));
            return result.ToString();
        }
    }
}
