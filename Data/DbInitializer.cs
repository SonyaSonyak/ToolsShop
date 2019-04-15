using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Models;

namespace TS.Data
{
    public class DbInitializer
    {
        public static void Initialize(TSContext context)
        {
            context.Database.EnsureCreated();

            if (context.Brands.Any())
            {
                return;
            }
            var providers = new Providers[]
            {
                new Providers{Name = "ANDRAX Co.", Address = "Україна"},
                new Providers{Name = "JONNESWAY ENTERPRISE CO., LTD", Address = "Японія"},
                new Providers{Name = "King Tony Co.", Address = "Японія"},
                new Providers{Name = "Toptul Co., LTD", Address = "Китай"},
                new Providers{Name = "JOBI", Address = "Польща"}


            };

            foreach (Providers p in providers)
            {
                context.Providers.Add(p);
            }
            context.SaveChanges();

            var brands = new Brands[]
            {
                new Brands{Name = "ANDRMAX", Info = "Заснований в 2002.", ProvidersID=1},
                new Brands{Name = "Jonnesway", Info = "Заснований в 1982, в Україні з 2001.", ProvidersID=2},
                new Brands{Name = "KingTony", Info = "Заснований в 1977, в Україні з 1998.", ProvidersID=3},
                new Brands{Name = "Toptul", Info = "Заснований в 1998, в Україні з 2003.", ProvidersID=4},
                new Brands{Name = "Jobi", Info = "Заснований в 1979, в Україні з 1995.", ProvidersID=5}


            };

            foreach (Brands b in brands)
            {
                context.Brands.Add(b);
            }
            context.SaveChanges();

            var products = new Products[]
           {
                new Products{Name = "Автообладнання", Price = 980, BrandsID=1},
                new Products{Name = "Обладннаня для автомайстерні", Price = 875, BrandsID=2},
                new Products{Name = "Ручний інструмент", Price = 754, BrandsID=3},
                new Products{Name = "Компресори", Price = 7098, BrandsID=4},
                new Products{Name = "професійний іструмент", Price = 907, BrandsID=5}


           };

            foreach (Products pr in products)
            {
                context.Products.Add(pr);
            }
            context.SaveChanges();

            var owners = new Owners[]
           {
                new Owners{Name = "Коломієць Анатолій Петрович",  BrandsID=1},
                new Owners{Name = "Павловська Юлія Олегівна", BrandsID=2},
                new Owners{Name = "Мацута Ілья Борисович", BrandsID=3},
                new Owners{Name = "Вишняков Сергій Дмит", BrandsID=4},
                new Owners{Name = "Каролінська Наталія Федорівна", BrandsID=5}


           };

            foreach (Owners o in owners)
            {
                context.Owners.Add(o);
            }
            context.SaveChanges();

            var shops = new Shops[]
           {
                new Shops{Name = "ANRMAX", Address="Київ, вулиця Шевченка 122", OwnersID=1},
                new Shops{Name = "Jonnesway Ukraine", Address="Київ, вулиця Ломоносова 76", OwnersID=2},
                new Shops{Name = "KingTony UK", Address="Львів, вулиця Леся Курбаса 12",OwnersID=3},
                new Shops{Name = "Топтул", Address="Київ, проспект Перемоги 67", OwnersID=4},
                new Shops{Name = "Jo", Address="Львів, вулиця Свободи 18", OwnersID=5}


           };

            foreach (Shops s in shops)
            {
                context.Shops.Add(s);
            }
            context.SaveChanges();
        }
    }
}
