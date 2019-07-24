using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Book
    {
        private static int id_generation = 1;
        private int _id;
        public int id
        {
            get { return _id; }
            set { throw new Exception(); }
        }

        public string name;
        public double price;
        public int stock_quantity;

        public Book(string name, double price)
        {
            this.name = name;
            this.price = price;
            this._id = id_generation++;
        }

        public string Description()
        {
            return "The book with the title of " + this.name + " costs RM " + this.price;
        }

        public int Replenish(int quantity)
        {
            stock_quantity += quantity;
            return stock_quantity;
        }

        public bool sell()
        {
            if (stock_quantity == 0)
                return false;

            --stock_quantity;
            return true;
        }
    }

    class Computer
    {
        private static int id_generation = 1;
        private int _id;
        public int id
        {
            get { return _id; }
            set { throw new Exception(); }
        }

        public string name;
        public double price;
        public int stock_quantity;

        public Computer(string name, double price)
        {
            this.name = name;
            this.price = price;
            this._id = id_generation++;
        }

        public string Description()
        {
            return "The computer with the configuration of " + this.name + " costs RM " + this.price;
        }

        public int Replenish(int quantity)
        {
            stock_quantity += quantity;
            return stock_quantity;
        }

        public bool sell()
        {
            if (stock_quantity == 0)
                return false;

            --stock_quantity;
            return true;
        }
    }

    class Clothes
    {
        private static int id_generation = 1;
        private int _id;
        public int id
        {
            get { return _id; }
            set { throw new Exception(); }
        }

        public string name;
        public double price;
        public int stock_quantity;

        public Clothes(string name, double price)
        {
            this.name = name;
            this.price = price;
            this._id = id_generation++;
        }

        public string Description()
        {
            return "The clothes ith the brand of " + this.name + " costs RM " + this.price;
        }

        public int Replenish(int quantity)
        {
            stock_quantity += quantity;
            return stock_quantity;
        }

        public bool sell()
        {
            if (stock_quantity == 0)
                return false;

            --stock_quantity;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book dotnet = new Book(".NET Programming", 55.23);

            while (true)
            { 
                Console.WriteLine(dotnet.id + ":" + dotnet.Description());
                Console.WriteLine("Modify (1) Title, (2) Price, (3) ID");
                int option = Convert.ToInt32(Console.ReadLine());
                string line = "";
                switch(option)
                {
                    case 1:
                        line = Console.ReadLine();
                        dotnet.name = line;
                        break;
                    case 2:
                        line = Console.ReadLine();
                        dotnet.price = Convert.ToDouble(line);
                        break;
                    case 3:
                        line = Console.ReadLine();
                        dotnet.id = Convert.ToInt32(line);
                        break;
                }
            }
        }
    }
