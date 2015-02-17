using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNeedletail
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.BLData p = new BL.BLData();
            Menu( p);
        }

        
        static void Menu(BL.BLData p) 
        {
            Console.Clear();
            Console.WriteLine("Select an option \n 1.Select a Table \n 2.Insert \n 3.Update \n 4.Delete \n 5.Exit");
            string s=Console.ReadLine();
            switch(s)
            {
                case "1":
                    Select(p);
                    break;
                case "2":
                    Insert(p);
                    Menu(p);
                    break;
                case "3":
                    Update(p);
                    break;
                case "4":
                    Delete(p);
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Incorrect Option");
                    Menu(p); 
                    break;
            }
        }
        static void Insert(BL.BLData p)
        {
            Console.Clear();
            Console.WriteLine("1.Insert a Proyect \n2.Insert an Address \n3.Back To Menu");
                string s=Console.ReadLine();
                string datas = "";
                    switch(s)
                    {
                        case "1":
                            Console.WriteLine("writes data separated by a comma-> Name, Budget");
                            datas=Console.ReadLine();
                            p.CreateProjects(datas);
                            break;
                        case "2":
                            Console.WriteLine("writes data separated by a comma-> Street, ZipCode, Phone");
                            datas=Console.ReadLine();
                            p.CreateAdrress(datas);
                            break;
                        case "3":
                            Menu(p);
                            break;
                        default:
                            Console.WriteLine("Incorrect Option");
                            Insert(p);
                            break;
                    }
        }

        static void  Select(BL.BLData p)
        {
            Console.Clear();
            Console.WriteLine("1.Select Proyects \n2.Select a Addresses \n3.Back To Menu");
            string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    foreach (var _proj in p.GetProjects())
                    {
                        Console.WriteLine(_proj.Id + " |" + _proj.Name + " |" + _proj.Budget + " |" + _proj.StartDate.ToString("MM/dd/yyyy"));
                    }
                    Console.ReadKey();
                    Menu(p);
                    break;
                case "2":
                    foreach (var _addr in p.GetAddress())
                    {
                        Console.WriteLine(_addr.Id + " |" + _addr.Street + " |" + _addr.ZipCode + " |" + _addr.Phone);
                    }
                    Console.ReadKey();
                    Menu(p);
                    break;
                case "3":
                    Menu(p);
                    break;
                default:
                    Console.WriteLine("Incorrect Option");
                    Insert(p);
                    break;
            }
        }

        static void Delete(BL.BLData p)
        {

            Console.Clear();
            Console.WriteLine("1.Delete a Proyect \n2.Delete an Address \n3.Back To Menu");
            string s = Console.ReadLine();
            int del = 0;
            int count = 1;
            switch (s)
            {
                case "1":
                    Console.WriteLine("1.Select number of project that you want to delete");
                    var _projects = p.GetProjects();
                    foreach (var _proj in _projects)
                    {
                        Console.WriteLine(count+".-"+_proj.Id + " |" + _proj.Name + " |" + _proj.Budget + " |" + _proj.StartDate.ToString("MM/dd/yyyy"));
                        count++;
                    }
                    del = Int32.Parse(Console.ReadLine());
                    count = 0;
                    foreach (var _proj in _projects)
                    {
                        if (del-1 == count) 
                        {
                            p.DeleteProjects(_proj.Id);
                        }
                        count++;
                    }
                   
                    Menu(p);
                    break;
                case "2":
                    var _addresses= p.GetAddress();
                    count = 1;
                    foreach (var _addr in _addresses)
                    {
                        Console.WriteLine(count+".-"+_addr.Id + " |" + _addr.Street + " |" + _addr.ZipCode + " |" + _addr.Phone);
                        count++;
                    }
                    del = Int32.Parse(Console.ReadLine());
                    count = 0;
                    foreach (var _addr in _addresses)
                    {
                        if (del-1 == count) 
                        {
                            p.DeleteAddress(_addr.Id);
                        }
                        count++;
                    }
                   
                    Menu(p);
                    break;
                case "3":
                    Menu(p);
                    break;
                default:
                    Console.WriteLine("Incorrect Option");
                    Insert(p);
                    break;
            }
        }

        static void Update(BL.BLData p) 
        {
            Console.Clear();
            Console.WriteLine("1.Update a Proyect \n2.Update an Address \n3.Back To Menu");
            string selectedUpdate=Console.ReadLine();
            Guid guidId = new Guid();
            int count = 1;        
            switch (selectedUpdate) 
            {
                case "1":
                    Console.WriteLine("1.Select number of project that you want to Update");
                        var _projects = p.GetProjects();
                        foreach (var _proj in _projects)
                        {
                            Console.WriteLine(count + ".-" + _proj.Id + " |" + _proj.Name + " |" + _proj.Budget + " |" + _proj.StartDate.ToString("MM/dd/yyyy"));
                            count++;
                        }
                        int del = Int32.Parse(Console.ReadLine());
                        count = 0;
                        foreach (var _proj in _projects)
                        {
                            if (del - 1 == count)
                            {
                                guidId = _proj.Id;

                            }
                            count++;
                        }
                        Console.WriteLine("Enter Update datas-> Name, Budget, StartDate");
                        string dat = Console.ReadLine();
                        p.UpdateProject(dat, guidId);
                        Menu(p);
                    break;
                case "2":
                         Console.WriteLine("1.Select number of project that you want to Update");
                        var _address = p.GetAddress();
                        foreach (var _addr in _address)
                        {
                            Console.WriteLine(count + ".-" + _addr.Id + " |" + _addr.Street + " |" + _addr.ZipCode + " |" + _addr.Phone);
                            count++;
                        }
                        del = Int32.Parse(Console.ReadLine());
                        count = 0;
                        foreach (var _addr in _address)
                        {
                            if (del - 1 == count)
                            {
                                guidId = _addr.Id;

                            }
                            count++;
                        }
                        Console.WriteLine("Enter Update datas-> Street, ZipCode, Phone");
                        dat = Console.ReadLine();
                        p.UpdateAddress(dat, guidId);
                        Menu(p);
                    break;
                case "3":
                    break;
                default:
                    Menu(p);
                    break;
            }
            

        }


        static void UpdateAddress(BL.BLData p)
        {
            Guid guidId = new Guid();
            int count = 1;
            Console.WriteLine("1.Select number of project that you want to Update");
            var _projects = p.GetProjects();
            foreach (var _proj in _projects)
            {
                Console.WriteLine(count + ".-" + _proj.Id + " |" + _proj.Name + " |" + _proj.Budget + " |" + _proj.StartDate.ToString("MM/dd/yyyy"));
                count++;
            }
            int del = Int32.Parse(Console.ReadLine());
            count = 0;
            foreach (var _proj in _projects)
            {
                if (del - 1 == count)
                {
                    guidId = _proj.Id;

                }
                count++;
            }
            Console.WriteLine("Enter Update datas-> Name, Budget, StartDate");
            string dat = Console.ReadLine();
            p.UpdateProject(dat, guidId);
            Menu(p);
        }
    }
}
