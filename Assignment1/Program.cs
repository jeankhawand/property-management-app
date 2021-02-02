using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Core.Models;
using Project.DAL;

namespace Assignment1
{
    class Program
    {
        static void DisplayProperties()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Display all properties in the console.");
            Console.ResetColor();
                 using (var context = new ConsoleDbContext())
                {
                    foreach (var apartment in context.Apartments.ToList())
                {
                    Console.WriteLine("Property Type: {0}",apartment.GetType().Name);
                    Console.WriteLine("Apartment Title: {0}",apartment.Title);
                    Console.WriteLine("Apartment Address: {0}",apartment.Address);
                    Console.WriteLine("Apartment Number Of Rooms: {0}",apartment.NbOfRooms);
                    Console.WriteLine("Apartment Price: "+apartment.Price.ToString("N"));
                    Console.WriteLine("\n");
                }

                foreach (var land in context.Lands.ToList())
                {
                    Console.WriteLine("Property Type: {0}",land.GetType().Name);
                    Console.WriteLine("Land Title: {0}",land.Title);
                    Console.WriteLine("Land Address: {0}",land.Address);
                    Console.WriteLine("Land Price: "+land.Price.ToString("N"));
                    Console.WriteLine("Land Area: "+land.Area);
                    Console.WriteLine("Can Be Farmed ? : "+((land.CanBeFarmed==true) ? "Yes" : "No"));
                    Console.WriteLine("\n");
                }
                foreach (var shop in context.Shops.ToList())
                {
                    Console.WriteLine("Property Type: {0}",shop.GetType().Name);
                    Console.WriteLine("Shop Title: {0}",shop.Title);
                    Console.WriteLine("Shop Address: {0}",shop.Address);
                    Console.WriteLine("Shop Price: "+shop.Price.ToString("N"));
                    Console.WriteLine("Shop Area: "+shop.Area);
                    Console.WriteLine("Shop Business Type: "+shop.Business);
                    Console.WriteLine("\n");
                }

            }
        }
        
        static void Main(string[] args)
        {
            
            /*
             *    Create five apartments, two lands, and 3 shops. Every property should have different property
                values and different prices. The Id of a property should be auto-incremented and cannot be set
                by a calling class.
             */
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Create five apartments, two lands, and 3 shops. Every property should have different property values and different prices. The Id of a property should be auto-incremented and cannot be set by a calling class..");
            Console.ResetColor();
            List<Apartment> apartments = new List<Apartment>()
            {
                new Apartment() {Title = "Apartment A", Address = "Beirut", NbOfRooms = 5},
                new Apartment() {Title = "Apartment B", Address = "Baabda", NbOfRooms = 8},
                new Apartment() {Title = "Apartment C", Address = "Jounieh", NbOfRooms = 3},
                new Apartment() {Title = "Apartment D", Address = "Jbeil", NbOfRooms = 8},
                new Apartment() {Title = "Apartment E", Address = "Hadath", NbOfRooms = 4}
            };
            List<Land> lands = new List<Land>()
            {
                new Land() {Title = "Land A", Address = "Beirut", Area = 2000,CanBeFarmed = true},
                new Land() {Title = "Land B", Address = "Baabda", Area = 250,CanBeFarmed = false}
            };
            List<Shop> shops = new List<Shop>()
            {
                new Shop() {Title = "Shop A", Address = "Beirut", Area = 5000, Business = Business.Food},
                new Shop() {Title = "Shop B", Address = "Baabda", Area = 100,Business = Business.Repair},
                new Shop() {Title = "Shop C", Address = "Jounieh", Area = 1000,Business = Business.Retail}
            };
           
            using (var context = new ConsoleDbContext())
            {
                
                context.Apartments.AddRange(apartments);
                context.Lands.AddRange(lands);
                context.Shops.AddRange(shops);
                context.SaveChanges();
            }
            /*
             * 2. Create three buyers:
                    a. Buyer 1 with credit 60,000
                    b. Buyer 2 with credit 10,000
                    c. Buyer 3 with credit 400,000
             */
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2. Create three buyers: \n a. Buyer 1 with credit 60,000 \n b. Buyer 2 with credit 10,000 \n c. Buyer 3 with credit 400,000");
            Console.ResetColor();
            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer(){FullName = "Buyer 1", Credits = 60000},
                new Buyer(){FullName = "Buyer 2", Credits = 10000},
                new Buyer(){FullName = "Buyer 3", Credits = 400000},
            };
            
            using (var context = new ConsoleDbContext())
            {
                context.Buyers.AddRange(buyers);
                context.SaveChanges();
            }
            /*
             * Display all properties in the console.
             */
           DisplayProperties();
            /*
           * Display all Land in the console.
           */
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4. Display all Land in the console.");
            Console.ResetColor();
            using (var context = new ConsoleDbContext())
            {
                Console.WriteLine("Lands");
                Console.WriteLine("\n");
                foreach (var land in context.Lands.ToList())
                {
                    Console.WriteLine("Land Title: {0}", land.Title);
                    Console.WriteLine("Land Address: {0}", land.Address);
                    Console.WriteLine("Land Price: {0:0.000}" , land.Price);
                    Console.WriteLine("Land Area: " + land.Area);
                    Console.WriteLine("Can Be Farmed ? : " + ((land.CanBeFarmed == true) ? "Yes" : "No"));
                    Console.WriteLine("\n");
                }
            }
            /*
                * Display all properties whose price is between 45,000 and 100,000 in the console.
            */
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5. Display all properties whose price is between 45,000 and 100,000 in the console.");
            Console.ResetColor();
               using (var context = new ConsoleDbContext()) 
               {
                   foreach (var apartment in apartments.Where(a => a.Price >= 45000 && a.Price <= 100000))
                {
                    
                    Console.WriteLine("Property Type: {0}",apartment.GetType().Name);
                    Console.WriteLine("Apartment Title: {0}",apartment.Title);
                    Console.WriteLine("Apartment Address: {0}",apartment.Address);
                    Console.WriteLine("Apartment Number Of Rooms: {0}",apartment.NbOfRooms);
                    Console.WriteLine("Apartment Price: "+apartment.Price.ToString("N"));
                    Console.WriteLine("\n");
                }

                   Console.WriteLine("\n");
                foreach (var land in lands.Where(l => l.Price >= 45000 && l.Price <= 100000))
                {
                    Console.WriteLine("Property Type: {0}",land.GetType().Name);
                    Console.WriteLine("Land Title: {0}",land.Title);
                    Console.WriteLine("Land Address: {0}",land.Address);
                    Console.WriteLine("Land Price: "+land.Price.ToString("N"));
                    Console.WriteLine("Land Area: "+land.Area);
                    Console.WriteLine("Can Be Farmed ? : "+((land.CanBeFarmed==true) ? "Yes" : "No"));
                    Console.WriteLine("\n");
                }
           

                Console.WriteLine("\n");
                foreach (var shop in shops.Where(s => s.Price >= 45000 && s.Price <= 100000))
                {
                    Console.WriteLine("Property Type: {0}",shop.GetType().Name);
                    Console.WriteLine("Shop Title: {0}",shop.Title);
                    Console.WriteLine("Shop Address: {0}",shop.Address);
                    Console.WriteLine("Shop Price: ",shop.Price.ToString("N"));
                    Console.WriteLine("Shop Area: "+shop.Area);
                    Console.WriteLine("Shop Business Type: "+shop.Business);
                    Console.WriteLine("\n");
                }
            }
            /*
             * Simulate the purchase of properties by the three buyers. If a buyer has enough credit to buy a
                property, then the price of the product should be deducted from their credit, and the property
                should be added to the buyer’s owned properties. Also, an event should be emitted and handledby 
                outputting the following message to the console: “{PropertyType} with ID {Id} was purchased
                by {Buyer Full Name} for {Price}”.
             */
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Simulate the purchase of properties by the three buyers.");
            Console.ResetColor();
            using (var context = new ConsoleDbContext())
            {
                foreach (var apartment in apartments)
                {
                    foreach (var buyer in buyers)
                    {
                        if (buyer.Credits > apartment.Price)
                        {
                            var buyerFound = context.Buyers.Include(b => b.Properties).FirstOrDefault(b => b.Id == buyer.Id);
                            if (buyerFound != null)
                            {
                                var remainingCredits = buyerFound.Credits - apartment.Price;
                                if (remainingCredits < 0)
                                {
                                    break;
                                }
                                else
                                {
                                    buyerFound.Properties.Add(apartment);
                                    buyerFound.Credits -= apartment.Price;
                                    context.Buyers.Update(buyerFound);
                                    context.SaveChanges();
                                    Console.WriteLine("Apartment with ID {0} was purchased by Buyer {1} for {2}",apartment.Id,buyer.Id,apartment.Price);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Unable To Purchase Apartment with ID {0} by Buyer {1} for {2}",apartment.Id,buyer.Id,apartment.Price);
                            }
                            
                        }
                        Console.WriteLine("Unable To Purchase Apartment with ID {0} by  Buyer {1} for {2}",apartment.Id,buyer.Id,apartment.Price);
                        
                    }
                }                
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("7. Display each buyer in the console in the following format");
            Console.ResetColor();
            /*
             * Display each buyer in the console in the following format:
                Buyer: {FullName}
                Nb of Owned Properties: {number of owned properties}
                Remaining Credit: {credit}
                {empty line}
             */
            using (var context = new ConsoleDbContext())
            {
                foreach (var buyer in context.Buyers.Include(b=>b.Properties).ToList())
                {
                    Console.WriteLine("Buyer: " + buyer.FullName);
                    Console.WriteLine("Nb of Owned Properties : " + buyer.Properties.Count());
                    Console.WriteLine("Remaining Credit : " + buyer.Credits.ToString("N"));
                    Console.WriteLine("");
                }                
            }
            /*
             * Fetch the property whose Id equals 2, update its title, then display it in the console.
             */
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. Fetch the property whose Id equals 2, update its title, then display it in the console.");
            Console.ResetColor();
            using (var context = new ConsoleDbContext())
            {
                var apartmentFound = context.Apartments.FirstOrDefault(a => a.Id == 2);
                Console.WriteLine(" Old Apartment Title : "+apartmentFound.Title);
                if (apartmentFound != null)
                {
                    apartmentFound.Title = "Updated Title";
                    Console.WriteLine(" New Apartment Title : "+apartmentFound.Title);
                }
            
                context.Apartments.Update(apartmentFound);
                context.SaveChanges();
            
            }
            
            /*
             * Attempt to remove two properties randomly. Only properties which have not been purchased
                 be removed. Finally, display all remaining properties in the console.
             */
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("9. Attempt to remove two properties randomly. Only properties which have not been purchased \n be removed. Finally, display all remaining properties in the console.");
            Console.ResetColor();
            List<Property> propertiesOwned = new List<Property>();
            using (var context = new ConsoleDbContext())
            {
                foreach (var buyer in context.Buyers.Include(b=>b.Properties).ToList())
                {
                    
                    foreach (var property in buyer.Properties.ToList())
                    {
                        propertiesOwned.Add(property);
                    }
                }                
            }
           
            using (var context = new ConsoleDbContext())
            {
                int deleted = 0;
                foreach (var land in context.Lands.ToList())
                {
                    if (deleted == 2) break;
                        if (!propertiesOwned.Contains(land))
                    {
                        context.Lands.Remove(land);
                        deleted++;
                    }
                }
           
                foreach (var apartment in context.Apartments.ToList())
                {
                    if (deleted == 2) break;    
                    if (!propertiesOwned.Contains(apartment))
                    {
                        context.Apartments.Remove(apartment);
                        deleted++;
                    }
                }
           
                foreach (var shop in context.Shops.ToList())
                {
                    if (deleted == 2) break;
                    if (!propertiesOwned.Contains(shop))
                    {
                        context.Shops.Remove(shop);
                              
                        deleted++;
                    }
                }
           
                context.SaveChanges();
            }
            DisplayProperties();
            
        }
    }
}