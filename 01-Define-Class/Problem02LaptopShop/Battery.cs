using System;

namespace Problem02LaptopShop
    {
    class Battery
        {

        private string batteryType;
        private float batteryLife;

        public Battery()
            {

            }
        public Battery(string batteryType = null, float batteryLife = 0)
            {
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
            }

        public string BatteryType
            {
            get
                {
                return this.batteryType;
                }
            set
                {
                if (value != "")
                    {
                    this.batteryType = value;
                    }
                else
                    {
                    throw new ArgumentException("Battery type cannot be empty.");
                    }
                }
            }
        public float BatteryLife
            {
            get
                {
                return this.batteryLife;
                }
            set
                {
                if (value >= 0 || value == float.NaN)
                    {
                    this.batteryLife = value;
                    }
                else
                    {
                    throw new ArgumentOutOfRangeException("Battery life cannot be negative.");
                    }
                }
            }
        }
    }
