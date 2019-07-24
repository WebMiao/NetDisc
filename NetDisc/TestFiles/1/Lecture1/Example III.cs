using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Product
    {
        private static int id_generator = 1;

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value;  }
        }

        public string name;
        public double price;
        protected int stock_quantity;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
            this._id = id_generator++;
        }

        public virtual string Description()
        {
            throw new NotImplementedException();
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

    class Book
        : Product
    {
        public Book(string name, double price)
            : base(name, price)
        {
            ;
        }

        public override string Description()
        {
            return "This book with the title of " + this.name + " costs RM " + this.price;
        }
    }

    class Computer
        :Product
    {
        public Computer(string name, double price)
            :base(name, price)
        {
            ;
        }

        public override string Description()
        {
            return "This computer with the configuration of " + this.name + " costs RM " + this.price;
        }
    }

    class Clothes
        : Product
    {
        public Clothes(string name, double price)
            :base(name, price)
        {
            ;
        }

        public override string Description()
        {
            return "This clothes is with the branch of " + this.name + " costs RM " + this.price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to operate (1) Book, (2) Computer, (3) Clothes?");
            string line = Console.ReadLine();

            Product item = null;
            switch (Convert.ToInt32(line))
            {
                case 1:
                    item = new Book(".NET Programming", 55.23);
                    break;
                case 2:
                    item = new Computer("Apple MacBook Pro 2018", 10000.1);
                    break;
                case 3:
                    item = new Clothes("Adidas T-Shirt", 100.1);
                    break;
            }

            while (true)
            { 
                Console.WriteLine(item.id + ":" + item.Description());
                Console.WriteLine("Modify (1) Title, (2) Price, (3) ID");
                int option = Convert.ToInt32(Console.ReadLine());
                string answer = "";
                switch(option)
                {
                    case 1:
                        answer = Console.ReadLine();
                        item.name = answer;
                        break;
                    case 2:
                        answer = Console.ReadLine();
                        item.price = Convert.ToDouble(answer);
                        break;
                    case 3:
                        answer = Console.ReadLine();
                        item.id = Convert.ToInt32(answer);
                        break;
                }
            }
        }
    }
}
