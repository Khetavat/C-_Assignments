using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Product
    {
        public string ProductName;
        public decimal ProductPrice;
        public string ProductBrandName;

    }
    class Mobile
    {
        public string MobileName;
        public decimal MobilePrice;
        public string MobileBrandName;

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product();
            Mobile mobile1 = new Mobile();

            product1.ProductPrice = 1000;
            product1.ProductName = "Smartphone";
            product1.ProductBrandName = "Jio";

            mobile1 = FromProduct(product1);

            Console.WriteLine(mobile1.MobileName);
            Console.WriteLine(product1.ProductName);

            Console.ReadLine();
        }

        private static Mobile FromProduct(Product product1)
        {
            Mobile mobile2 = new Mobile();

            mobile2.MobilePrice = product1.ProductPrice;
            mobile2.MobileName = product1.ProductName;
            mobile2.MobileBrandName = product1.ProductBrandName;

            return mobile2;
        }
    }
}
