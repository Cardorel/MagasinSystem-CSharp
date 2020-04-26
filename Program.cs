using System;
using System.Collections.Generic;
using System.Linq;

namespace Program2
{
    class Price
    {
        static int id;
        public int numberId
        {
            get
            {
                id++;
                return id;
            }
        }

        public string nameProduct
        {
            get;
            set;
        }

        public string nameMagasin
        {
            get;
            set;
        }

        public double priceProduct
        {
            get;
            set;
        }
    }


    class Program
    {
        static void Menu()
        {
            var listProductInMagasin = new List<Price>()
            {
                new Price
                {
                    nameMagasin = "ATB",
                    nameProduct = "Yaourt",
                    priceProduct= 10.5
                },
                new Price
                {
                    nameMagasin = "ATB" ,
                    nameProduct = "Juis" ,
                    priceProduct= 9.2
                },
                new Price
                {
                    nameMagasin = "FLORA" ,
                    nameProduct = "Water B" ,
                    priceProduct= 10.5
                },
                new Price
                {
                    nameMagasin = "FLORA" ,
                    nameProduct = "Bread" ,
                    priceProduct= 2
                },
                new Price
                {
                    nameMagasin = "FLORA" ,
                    nameProduct = "Beer" ,
                    priceProduct= 5
                },
                new Price
                {
                    nameMagasin = "SILPO" ,
                    nameProduct = "Croissant" ,
                    priceProduct= 3
                },
                new Price
                {
                    nameMagasin = "ATB" ,
                    nameProduct = "Chocolat",
                    priceProduct= 10.5
                },
                new Price
                {
                    nameMagasin = "FLORA" ,
                    nameProduct = "Kefir" ,
                    priceProduct= 7
                },
                new Price
                {
                    nameMagasin = "SILPO" ,
                    nameProduct = "Yaourt" ,
                    priceProduct= 10.5
                }
            };
            var listProductOnLooking = new List<Price>();
            var instance = new Price();
            var setNameOfProduct = "";

            while (true)
            {
                System.Console.WriteLine("\n");
                System.Console.WriteLine("1.Add;");
                System.Console.WriteLine("2.Print");
                System.Console.WriteLine("3.Quit;");
                System.Console.WriteLine("\n");
                System.Console.WriteLine("choose the number...");
                string choose = Console.ReadLine();

                if (choose == "0")
                    break;
                else if (choose == "1")
                {
                    System.Console.WriteLine("\n");
                    System.Console.WriteLine("Enter the name of the Product...");
                    setNameOfProduct = Console.ReadLine();
                    listProductOnLooking.Add(
                        new Price
                        {
                            nameProduct = setNameOfProduct
                        }
                    );
                }
                else if (choose == "2")
                {
                    var query = from x in listProductOnLooking
                                join y in listProductInMagasin
                                on x.nameProduct equals y.nameProduct
                                orderby x.nameMagasin descending
                                select new
                                {
                                    nameOfMagasin = y.nameMagasin,
                                    nameOfProductInSctockage = y.nameProduct,
                                    priceOfProductInStockage = y.priceProduct,
                                    nameOfProductOnLooking = x.nameProduct,
                                };
                    foreach (var item in query)
                    {
                        if (item.nameOfProductInSctockage == item.nameOfProductOnLooking)
                        {
                            System.Console.WriteLine(
                                "number ID: {0}  \nMagasin : {1} \nName of product: {2} \nPrice of product: {3} ",
                                 instance.numberId,
                                 item.nameOfMagasin,
                                 item.nameOfProductInSctockage,
                                 item.priceOfProductInStockage
                                );
                                System.Console.WriteLine("\n");
                        }
                    }
                }

            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
