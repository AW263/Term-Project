using System;
using System.Text.RegularExpressions;

namespace Term_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Deliviries deliviries = new Deliviries();
            int id = 1;
            int daysCounter = 0;
            
     
          
            string[] command = Console.ReadLine().Split(": ");
            while (command[0] !="Stop")
            {
                if(command[0] == "Add")
                {
                    
                    string adress = Console.ReadLine();
                    Regex regex = new Regex("Country: (.+), City: (.+), Street: (.+), Number: (.+), Person: (\\w+) (\\w+)");
                    if (regex.IsMatch(adress))
                    {
                        Match match = regex.Match(adress);
                        Delivery delivery = new Delivery(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, int.Parse(match.Groups[4].Value), false, id, match.Groups[5].Value, match.Groups[6].Value);
                        deliviries.Add(delivery);
                        
                       
                        id++;
                    }
                    else
                        Console.WriteLine("Failed attempt! Wrong adress!");
                }
                else if(command[0] == "Delivered")
                {
                    if (!deliviries.Contains(int.Parse(command[1])))
                        Console.WriteLine("Wrong id");
                    else
                    {
                        deliviries.Remove(int.Parse(command[1]));
                        Console.WriteLine("Done");
                    }
                }
                else if(command[0]=="Status")
                {
                    if (!deliviries.Contains(int.Parse(command[1])))
                        Console.WriteLine("Wrong id");
                    else
                        deliviries.Status(int.Parse(command[1]));

                }
                else if(command[0]=="Redirected")
                {
                    string[] newa = Console.ReadLine().Split();
                    if (!deliviries.Contains(int.Parse(command[1])))
                        Console.WriteLine("Wrong id");
                    else
                    deliviries.Redirect(int.Parse(newa[0]), newa[1], newa[2], newa[3], int.Parse(newa[4]));
                   
                }
                else if(command[0]=="End")
                {
                    Console.WriteLine($"End of day {daysCounter}");
                    Console.WriteLine("Items that must be delivered:");
                    foreach (Delivery item in deliviries)
                    {
                        Console.WriteLine($"ID: {item.Id}, Country: {item.Country}, City: {item.City}, Street: {item.Street}, Person: {item.FirstName} {item.LastName}");
                    }

                    daysCounter++;
                }
                
                else if(command[0]=="Change person")
                {
                    string[] newa = Console.ReadLine().Split();
                    if (!deliviries.Contains(int.Parse(command[1])))
                        Console.WriteLine("Wrong id");

                    else
                    {
                        deliviries.ChangePerson(int.Parse(newa[0]), newa[1], newa[2]);
                        Console.WriteLine("Done");
                    }

                }
                command = Console.ReadLine().Split(": ");
            }




            Console.WriteLine("Items that must be delivered:");
            foreach (Delivery item in deliviries)
            {
                Console.WriteLine($"ID: {item.Id}, Country: {item.Country}, City: {item.City}, Street: {item.Street}, Person: {item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Items that were delivered");
            deliviries.Print();
        }
                
    }
}
