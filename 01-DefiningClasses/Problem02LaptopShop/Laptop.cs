using System;

namespace Problem02LaptopShop
    {
    public class Laptop
        {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery = new Battery();
        private int price;

        public Laptop(string model, int price)
            {
            this.Model = model;
            this.Price = price;
            }
        public Laptop(string model, int price, string manufacturer = null, string procesor = null, int ram = 0, string graphicsCard = null,
            string hdd = null, string screen = null, string batteryType = null, float batteryLife = 0)
            {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processor = procesor;
            this.RAM = ram;
            this.GraphicsCard = graphicsCard;
            this.HDD = hdd;
            this.Screen = screen;
            this.battery.BatteryType = batteryType;
            this.battery.BatteryLife = batteryLife;
            }

        private string Model
            {
            set
                {
                if (value != "")
                    {
                    this.model = value;
                    }
                else
                    {
                    throw new ArgumentException("Model cannot be empty.");
                    }
                }
            }
        private string Manufacturer
            {
            set
                {
                if (value != "")
                    {
                    this.manufacturer = value;
                    }
                else
                    {
                    throw new ArgumentException("Manufacturer cannot be empty.");
                    }
                }
            }
        private string Processor
            {
            set
                {
                if (value != "")
                    {
                    this.processor = value;
                    }
                else
                    {
                    throw new ArgumentException("Processor cannot be empty.");
                    }
                }
            }
        private int RAM
            {
            set
                {
                if (value >= 0)
                    {
                    this.ram = value;
                    }
                else
                    {
                    throw new ArgumentException("RAM cannot be negative.");
                    }
                }
            }
        private string GraphicsCard
            {
            set
                {
                if (value != "")
                    {
                    this.graphicsCard = value;
                    }
                else
                    {
                    throw new ArgumentException("GraphicsCard cannot be empty.");
                    }
                }
            }
        private string HDD
            {
            set
                {
                if (value != "")
                    {
                    this.hdd = value;
                    }
                else
                    {
                    throw new ArgumentException("HDD cannot be empty.");
                    }
                }
            }
        private string Screen
            {
            set
                {
                if (value != "")
                    {
                    this.screen = value;
                    }
                else
                    {
                    throw new ArgumentException("Screen cannot be empty.");
                    }
                }
            }
        private int Price
            {
            set
                {
                if (value >= 0)
                    {
                    this.price = value;
                    }
                else
                    {
                    throw new ArgumentException("Price cannot be negative.");
                    }
                }
            }

        public void ToString()
            {
            Console.WriteLine("Model: " + this.model);
            if (this.manufacturer != null)
                {
                Console.WriteLine("Manufacturer: " + this.manufacturer);
                }
            if (this.processor != null)
                {
                Console.WriteLine("Processor: " + this.processor);
                }
            if (this.ram != 0)
                {
                Console.WriteLine("RAM: " + this.processor + " GB");
                }
            if (this.hdd != null)
                {
                Console.WriteLine("HDD: " + this.hdd);
                }
            if (this.screen != null)
                {
                Console.WriteLine("Screen: " + this.screen);
                }
            if (this.battery.BatteryType != null)
                {
                Console.WriteLine("Battery: " + this.battery.BatteryType);
                }
            if (this.battery.BatteryLife != 0)
                {
                Console.WriteLine("Battery Life: " + this.battery.BatteryLife + " hours");
                }
            Console.WriteLine("Price: " + this.price + " lv.");
            }
        }
    }
