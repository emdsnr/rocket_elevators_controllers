﻿// 60 floors (including G)
// 6 basements
// 4 columns
// 20 elevators

// 90 call buttons
// 345 elevator buttons

using System;

namespace Controller
{
    class Program
    {
        static void ok(string[] args)
        {
            Console.WriteLine("\nwhat's your name?");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nhello, {name}! \n({date:d} at {date:t})");
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }

    class Battery
    {
        public string id;
        public string status;

        public Battery(string battId, string battStatus)
        {
            id = battId;
            status = battStatus;
            
        }

    class Column
    {
        public string id;
        public string status;
        public int minFloor;
        public int maxFloor;
        public int elevNum;

        public Column(string colId, string colStatus, int colMinFloor, int colMaxFloor, int colElevNum)
        {
            id = colId;
            status = colStatus;
            minFloor = colMinFloor;
            maxFloor = colMaxFloor;
            elevNum = colElevNum;
        }

    class Elevator 
    {
        public string id;
        public int floor;
        public string status;
        public int minFloor;
        public int maxFloor;
        public string door;
        public int floorDisplay;

        public Elevator(string elevId, int elevFloor, string elevStatus, int elevMinFloor, int elevMaxFloor, string elevDoor)
        {
            id = elevId;
            floor = elevFloor;
            status = elevStatus;
            minFloor = elevMinFloor;    // excluding ground floor
            maxFloor = elevMaxFloor;    // excluding ground floor
            door = elevDoor;
            floorDisplay = elevFloor;
        }

        static void Main(string[] args)
        {
            Battery A = new Battery("1", "idle");

            Column a = new Column("a", "idle", -5, 0, 5);
            Column b = new Column("b", "idle", 1, 20, 5);
            Column c = new Column("c", "idle", 21, 40, 5);
            Column d = new Column("d", "idle", 41, 60, 5);

            Elevator a1 = new Elevator("a1", -5, "goingUp", -5, 0, "closed");
            Elevator a2 = new Elevator("a2", -4, "goingUp", -5, 0, "closed");
            Elevator a3 = new Elevator("a3", 1, "idle", -5, 0, "closed");
            Elevator a4 = new Elevator("a4", 1, "idle", -5, 0, "closed");
            Elevator a5 = new Elevator("a5", 1, "idle", -5, 0, "closed");

            Elevator b1 = new Elevator("b1", 1, "goingUp", 1, 20, "closed");
            Elevator b2 = new Elevator("b2", 1, "idle", 1, 20, "closed");
            Elevator b3 = new Elevator("b3", 1, "idle", 1, 20, "closed");
            Elevator b4 = new Elevator("b4", 1, "idle", 1, 20, "closed");
            Elevator b5 = new Elevator("b5", 1, "idle", 1, 20, "closed");

            Elevator c1 = new Elevator("c1", 1, "idle", 21, 40, "closed");
            Elevator c2 = new Elevator("c2", 1, "idle", 21, 40, "closed");
            Elevator c3 = new Elevator("c3", 1, "idle", 21, 40, "closed");
            Elevator c4 = new Elevator("c4", 1, "idle", 21, 40, "closed");
            Elevator c5 = new Elevator("c5", 1, "idle", 21, 40, "closed");
            
            Elevator d1 = new Elevator("d1", 1, "idle", 41, 60, "closed");
            Elevator d2 = new Elevator("d2", 1, "idle", 41, 60, "closed");
            Elevator d3 = new Elevator("d3", 1, "idle", 41, 60, "closed");
            Elevator d4 = new Elevator("d4", 1, "idle", 41, 60, "closed");
            Elevator d5 = new Elevator("d5", 1, "idle", 41, 60, "closed");

            
            void status()
            {
                if (a1.status != "idle" | a2.status != "idle" | a3.status != "idle" | a4.status != "idle" | a5.status != "idle")
                {
                    a.status = "active";

                } else 
                {
                    a.status = "idle";
                };

                if (b1.status != "idle" | b2.status != "idle" | b3.status != "idle" | b4.status != "idle" | b5.status != "idle")
                {
                    b.status = "active";
                } else 
                {
                    b.status = "idle";
                };

                if (c1.status != "idle" | c2.status != "idle" | c3.status != "idle" | c4.status != "idle" | c5.status != "idle")
                {
                    c.status = "active";
                } else 
                {
                    c.status = "idle";
                };

                if (d1.status != "idle" | d2.status != "idle" | d3.status != "idle" | d4.status != "idle" | d5.status != "idle")
                {
                    d.status = "active";
                } else 
                {
                    d.status = "idle";
                };


                if (a1.status != "idle" | a2.status != "idle" | a3.status != "idle" | a4.status != "idle" | a5.status != "idle")
                {
                    a.status = "active";
                };
                

                if (a.status != "idle" | b.status != "idle" | c.status != "idle" | d.status != "idle")
                {
                    A.status = "active";
                };
            }

            status();

            void requestElevA(int userFloor, string direction)
            {     
                if (direction == "up") 
                {
                    // userfloor == elevFloor && status == goingUp
                    if (userFloor == a1.floor && a1.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a1");
                        a1.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a1.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"floor display: {a1.floorDisplay}");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a1.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a1.door);

                                while (a1.floor < requestedFloor) 
                                {
                                a1.floor++;
                                a1.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a1.floorDisplay}");
                                };

                                a1.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a1.door);
                                a1.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a1.door);
                                a1.status = "idle";
                                status();
                            
                            };
                        };

                    } else if (userFloor == a2.floor && a2.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a2");
                        a2.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a2.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"floor display: {a2.floorDisplay}");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a2.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a2.door);

                                while (a2.floor < requestedFloor) 
                                {
                                a2.floor++;
                                a2.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a2.floorDisplay}");
                                };

                                a2.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a2.door);
                                a2.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a2.door);
                                a2.status = "idle";
                                status();
                            
                            };
                        };

                    } else if (userFloor == a3.floor && a3.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a3");
                        a3.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a3.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"floor display: {a3.floorDisplay}");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a3.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a3.door);

                                while (a3.floor < requestedFloor) 
                                {
                                a3.floor++;
                                a3.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a3.floorDisplay}");
                                };

                                a3.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a3.door);
                                a3.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a3.door);
                                a3.status = "idle";
                                status();
                            
                            };
                        };

                    } else if (userFloor == a4.floor && a4.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a4");
                        a4.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a4.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"floor display: {a4.floorDisplay}");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a4.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a4.door);

                                while (a4.floor < requestedFloor) 
                                {
                                a4.floor++;
                                a4.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a4.floorDisplay}");
                                };

                                a4.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a4.door);
                                a4.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a4.door);
                                a4.status = "idle";
                                status();
                            
                            };
                        };

                    } else if (userFloor == a5.floor && a5.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a5");
                        a5.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a5.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"floor display: {a5.floorDisplay}");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a5.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a5.door);

                                while (a5.floor < requestedFloor) 
                                {
                                a5.floor++;
                                a5.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a5.floorDisplay}");
                                };

                                a5.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a5.door);
                                a5.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a5.door);
                                a5.status = "idle";
                                status();
                            
                            };
                        };
                        
                    // userFloor > elevFloor && status == goingUp | 5 OPTIONS
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a2.floor && a2.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int w = (userFloor - a2.floor);
                        int x = (userFloor - a3.floor);
                        int y = (userFloor - a4.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(w);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);
                        // Console.WriteLine(z);

                        if (v <= w && v <= x && v <= y && v <= z)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (w <= v && w <= x && w <= y && w <= z)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= v && x <= w && x <= y && x <= z)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= v && y <= w && y <= x && y <= z)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= v && z <= w && z <= x && z <= y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [1] 4 OPTIONS — a1 & a2 & a3 & a4
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a2.floor && a2.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int w = (userFloor - a2.floor);
                        int x = (userFloor - a3.floor);
                        int y = (userFloor - a4.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(w);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (v <= w && v <= x && v <= y)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (w <= v && w <= x && w <= y)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= v && x <= w && x <= y)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= v && y <= w && y <= x)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [2] 4 OPTIONS — a1 & a2 & a3 & a5
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a2.floor && a2.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int w = (userFloor - a2.floor);
                        int x = (userFloor - a3.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(w);
                        // Console.WriteLine(x);
                        // Console.WriteLine(z);

                        if (v <= w && v <= x && v <= z)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (w <= v && w <= x && w <= z)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= v && x <= w && x <= z)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= v && z <= w && z <= x)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [3] 4 OPTIONS — a1 & a2 & a4 & a5
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a2.floor && a2.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int w = (userFloor - a2.floor);
                        int y = (userFloor - a4.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(w);
                        // Console.WriteLine(y);
                        // Console.WriteLine(z);

                        if (v <= w && v <= y && v <= z)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (w <= v && w <= y && w <= z)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= v && y <= w && y <= z)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= v && z <= w && z <= y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [4] 4 OPTIONS — a1 & a3 & a4 & a5
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int x = (userFloor - a3.floor);
                        int y = (userFloor - a4.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);
                        // Console.WriteLine(z);

                        if (v <= x && v <= y && v <= z)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= v && x <= y && x <= z)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= v && y <= x && y <= z)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= v && z <= x && z <= y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [5] 4 OPTIONS — a2 & a3 & a4 & a5
                    } else if (userFloor > a2.floor && a2.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int w = (userFloor - a2.floor);
                        int x = (userFloor - a3.floor);
                        int y = (userFloor - a4.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(w);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);
                        // Console.WriteLine(z);

                        if (w <= x && w <= y && w <= z)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= w && x <= y && x <= z)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= w && y <= x && y <= z)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= w && z <= x && z <= y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [1] 3 OPTIONS — a1 & a2 & a3
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a2.floor && a2.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int w = (userFloor - a2.floor);
                        int x = (userFloor - a3.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(w);
                        // Console.WriteLine(x);

                        if (v <= w && v <= x)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (w <= v && w <= x)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= v && x <= w)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [2] 3 OPTIONS — a1 & a2 & a4
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a2.floor && a2.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int w = (userFloor - a2.floor);
                        int y = (userFloor - a4.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(w);
                        // Console.WriteLine(y);

                        if (v <= w && v <= y)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (w <= v && w <= y)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= v && y <= w)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [3] 3 OPTIONS — a1 & a2 & a5
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a2.floor && a2.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int w = (userFloor - a2.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(w);
                        // Console.WriteLine(z);

                        if (v <= w && v <= z)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (w <= v && w <= z)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= v && z <= w)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [4] 3 OPTIONS — a1 & a3 & a4
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int x = (userFloor - a3.floor);
                        int y = (userFloor - a4.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (v <= x && v <= y)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= v && x <= y)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= v && y <= x)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [5] 3 OPTIONS — a1 & a3 & a5
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int x = (userFloor - a3.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (v <= x && v <= z)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= v && x <= z)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= v && z <= x)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [6] 3 OPTIONS — a1 & a4 & a5
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int v = (userFloor - a1.floor);
                        int y = (userFloor - a4.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(y);
                        // Console.WriteLine(y);

                        if (v <= y && v <= z)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= v && y <= z)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= v && z <= y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [7] 3 OPTIONS — a2 & a3 & a4
                    } else if (userFloor > a2.floor && a2.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        int w = (userFloor - a2.floor);
                        int x = (userFloor - a3.floor);
                        int y = (userFloor - a4.floor);
                        // Console.WriteLine(w);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (w <= x && w <= y)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= w && x <= y)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= w && y <= x)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [8] 3 OPTIONS — a2 & a3 & a5
                    } else if (userFloor > a2.floor && a2.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int w = (userFloor - a2.floor);
                        int x = (userFloor - a3.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(w);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (w <= x && w <= z)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x <= w && x <= z)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= w && z <= x)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [9] 3 OPTIONS — a2 & a4 & a5
                    } else if (userFloor > a2.floor && a2.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int w = (userFloor - a2.floor);
                        int y = (userFloor - a4.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(w);
                        // Console.WriteLine(y);
                        // Console.WriteLine(y);

                        if (w <= y && w <= z)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= w && y <= z)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= w && z <= y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [10] 3 OPTIONS — a3 & a4 & a5
                    } else if (userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int v = (userFloor - a3.floor);
                        int y = (userFloor - a4.floor);
                        int z = (userFloor - a5.floor);
                        // Console.WriteLine(v);
                        // Console.WriteLine(y);
                        // Console.WriteLine(y);

                        if (v <= y && v <= z)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (y <= v && y <= z)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (z <= v && z <= y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                    
                    // userFloor > elevFloor && status == goingUp | [8] 2 OPTIONS — a1 & a2
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a2.floor && a2.status == "goingUp") 
                    {
                        int x = (userFloor - a1.floor);
                        int y = (userFloor - a2.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [8] 2 OPTIONS — a1 & a3
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp") 
                    {
                        int x = (userFloor - a1.floor);
                        int y = (userFloor - a3.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [8] 2 OPTIONS — a1 & a4
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        int x = (userFloor - a1.floor);
                        int y = (userFloor - a4.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [8] 2 OPTIONS — a1 & a5
                    } else if (userFloor > a1.floor && a1.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int x = (userFloor - a1.floor);
                        int y = (userFloor - a5.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a1");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                    
                            while (a1.floor < userFloor) 
                            {
                            a1.floor++;
                            a1.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                            };

                            a1.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a1.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);

                                    while (a1.floor < requestedFloor) 
                                    {
                                    a1.floor++;
                                    a1.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a1.floorDisplay}");
                                    };

                                    a1.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a1.door);
                                    a1.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [8] 2 OPTIONS — a2 & a3
                    } else if (userFloor > a2.floor && a2.status == "goingUp" && userFloor > a3.floor && a3.status == "goingUp") 
                    {
                        int x = (userFloor - a2.floor);
                        int y = (userFloor - a3.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [8] 2 OPTIONS — a2 & a4
                    } else if (userFloor > a2.floor && a2.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        int x = (userFloor - a2.floor);
                        int y = (userFloor - a4.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [8] 2 OPTIONS — a2 & a5
                    } else if (userFloor > a2.floor && a2.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int x = (userFloor - a2.floor);
                        int y = (userFloor - a5.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a2");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                    
                            while (a2.floor < userFloor) 
                            {
                            a2.floor++;
                            a2.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                            };

                            a2.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a2.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);

                                    while (a2.floor < requestedFloor) 
                                    {
                                    a2.floor++;
                                    a2.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a2.floorDisplay}");
                                    };

                                    a2.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a2.door);
                                    a2.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [8] 2 OPTIONS — a3 & a4
                    } else if (userFloor > a3.floor && a3.status == "goingUp" && userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        int x = (userFloor - a3.floor);
                        int y = (userFloor - a4.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [9] 2 OPTIONS — a3 & a5
                    } else if (userFloor > a3.floor && a3.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int x = (userFloor - a3.floor);
                        int y = (userFloor - a5.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a3");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                    
                            while (a3.floor < userFloor) 
                            {
                            a3.floor++;
                            a3.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                            };

                            a3.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a3.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);

                                    while (a3.floor < requestedFloor) 
                                    {
                                    a3.floor++;
                                    a3.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a3.floorDisplay}");
                                    };

                                    a3.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a3.door);
                                    a3.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | [10] 2 OPTIONS — a4 & a5
                    } else if (userFloor > a4.floor && a4.status == "goingUp" && userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        int x = (userFloor - a4.floor);
                        int y = (userFloor - a5.floor);
                        // Console.WriteLine(x);
                        // Console.WriteLine(y);

                        if (x < y)
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        } else if (x > y)
                        {
                            Console.WriteLine("elevator a5");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                    
                            while (a5.floor < userFloor) 
                            {
                            a5.floor++;
                            a5.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                            };

                            a5.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a5.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);

                                    while (a5.floor < requestedFloor) 
                                    {
                                    a5.floor++;
                                    a5.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a5.floorDisplay}");
                                    };

                                    a5.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a5.door);
                                    a5.status = "idle";
                                    status();
                                
                                };
                            };

                        } else
                        {
                            Console.WriteLine("elevator a4");
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                    
                            while (a4.floor < userFloor) 
                            {
                            a4.floor++;
                            a4.floorDisplay++;
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                            };

                            a4.door = "opened";
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("door: " + a4.door);
                            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                            Console.WriteLine("which floor would u like to go to?");
                            
                            bool input = true;
                            while (input) 
                            {
                                int requestedFloor;
                                bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                                if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false) 
                                {
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("please select a valid floor");

                                } else {
                                    
                                    input = false;

                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);

                                    while (a4.floor < requestedFloor) 
                                    {
                                    a4.floor++;
                                    a4.floorDisplay++;
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine($"floor display: {a4.floorDisplay}");
                                    };

                                    a4.door = "opened";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.door = "closed";
                                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                    Console.WriteLine("door: " + a4.door);
                                    a4.status = "idle";
                                    status();
                                
                                };
                            };

                        };
                        
                    // userFloor > elevFloor && status == goingUp | 1 OPTION
                    } else if (userFloor > a1.floor && a1.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a1");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                   
                        while (a1.floor < userFloor) 
                        {
                        a1.floor++;
                        a1.floorDisplay++;
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                        Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                        };

                        a1.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a1.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a1.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a1.door);

                                while (a1.floor < requestedFloor) 
                                {
                                a1.floor++;
                                a1.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a1.floorDisplay}");
                                };

                                a1.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a1.door);
                                a1.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a1.door);
                                a1.status = "idle";
                                status();
                            
                            };
                        };
                        
                    } else if (userFloor > a2.floor && a2.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a2");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                   
                        while (a2.floor < userFloor) 
                        {
                        a2.floor++;
                        a2.floorDisplay++;
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                        Console.WriteLine($"elevator's floor: {a2.floorDisplay}");
                        };

                        a2.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a2.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a2.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a2.door);

                                while (a2.floor < requestedFloor) 
                                {
                                a2.floor++;
                                a2.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a2.floorDisplay}");
                                };

                                a2.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a2.door);
                                a2.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a2.door);
                                a2.status = "idle";
                                status();
                            
                            };
                        };
                        
                    } else if (userFloor > a3.floor && a3.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a3");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                   
                        while (a3.floor < userFloor) 
                        {
                        a3.floor++;
                        a3.floorDisplay++;
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                        Console.WriteLine($"elevator's floor: {a3.floorDisplay}");
                        };

                        a3.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a3.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a3.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a3.door);

                                while (a3.floor < requestedFloor) 
                                {
                                a3.floor++;
                                a3.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a3.floorDisplay}");
                                };

                                a3.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a3.door);
                                a3.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a3.door);
                                a3.status = "idle";
                                status();
                            
                            };
                        };
                        
                    } else if (userFloor > a4.floor && a4.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a4");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                   
                        while (a4.floor < userFloor) 
                        {
                        a4.floor++;
                        a4.floorDisplay++;
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                        Console.WriteLine($"elevator's floor: {a4.floorDisplay}");
                        };

                        a4.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a4.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a4.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a4.door);

                                while (a4.floor < requestedFloor) 
                                {
                                a4.floor++;
                                a4.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a4.floorDisplay}");
                                };

                                a4.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a4.door);
                                a4.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a4.door);
                                a4.status = "idle";
                                status();
                            
                            };
                        };
                        
                    } else if (userFloor > a5.floor && a5.status == "goingUp") 
                    {
                        Console.WriteLine("elevator a5");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                   
                        while (a5.floor < userFloor) 
                        {
                        a5.floor++;
                        a5.floorDisplay++;
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                        Console.WriteLine($"elevator's floor: {a5.floorDisplay}");
                        };

                        a5.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a5.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a5.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a5.door);

                                while (a5.floor < requestedFloor) 
                                {
                                a5.floor++;
                                a5.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a5.floorDisplay}");
                                };

                                a5.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a5.door);
                                a5.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a5.door);
                                a5.status = "idle";
                                status();
                            
                            };
                        };
                    
                    // userFloor = elevFloor && status == idle
                    } else if (userFloor == a1.floor && a1.status == "idle") 
                    {
                        Console.WriteLine("elevator a1");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                   
                        while (a1.floor < userFloor) 
                        {
                        a1.floor++;
                        a1.floorDisplay++;
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                        Console.WriteLine($"elevator's floor: {a1.floorDisplay}");
                        };

                        a1.door = "opened";
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("door: " + a1.door);
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                        Console.WriteLine("which floor would u like to go to?");
                        
                        bool input = true;
                        while (input) 
                        {
                            int requestedFloor;
                            bool valid = int.TryParse(Console.ReadLine(), out requestedFloor);

                            if (requestedFloor <= -5 || requestedFloor > 1 || requestedFloor == userFloor || valid == false)  
                            {
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("please select a valid floor");

                            } else {
                                
                                input = false;

                                a1.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a1.door);

                                while (a1.floor < requestedFloor) 
                                {
                                a1.floor++;
                                a1.floorDisplay++;
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine($"floor display: {a1.floorDisplay}");
                                };

                                a1.door = "opened";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
                                Console.WriteLine("door: " + a1.door);
                                a1.door = "closed";
                                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                                Console.WriteLine("door: " + a1.door);
                                a1.status = "idle";
                                status();
                            
                            };
                        };
                    }

                }
            }

            requestElevA(-5, "up");
            // Console.WriteLine(c.minFloor);
            // Console.WriteLine(a1.floorDisplay);
            // Console.WriteLine(a.status);
            // Console.WriteLine(A.status);
        }
    }
    }
    }
}