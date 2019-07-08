using System;
using System.IO;
using CSharpLibraries.RXCS;
using CSharpLibraries.ObjectManager;
using CSharpLibraries.BaseObjects;
using CSharpLibraries.Logging;
using CSharpLibraries.WebAPITools;
using CSharpLibraries.Generics;
using CSharpLibraries.FileManagement;

namespace ConsoleApp
{
    class Program
    {
        static void TestRXCS()
        {
            SubscribedObject subscribedObject = new SubscribedObject();
            TestObject testObject = new TestObject();

            SimpleObject obj = new SimpleObject
            {
                Name = "Simple Name",
                ObjId = 1
            };

            SimpleObject obj2 = new SimpleObject
            {
                Name = "Simple Name 2",
                ObjId = 2
            };

            EventService.Instance.Subscribe(testObject, obj);

            bool quit = false;
            while (!quit)
            {
                Console.Write("What would you like to do?\n1: Set Id\n2: SetName\nQ: Quit\nU1: Unsubscribe 1\nU2: Unsubscribe 2\nS1: Subscribe 1\nS2: Subscribe 2\n> ");

                string input = Console.ReadLine().Trim();
                switch (input.ToLower())
                {
                    case "1":
                        {
                            Console.Write("Enter new Id: ");
                            if (UInt32.TryParse(Console.ReadLine(), out uint id))
                                obj.ObjId = id;
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Enter new Name: ");
                            obj2.Name = Console.ReadLine().Trim();
                            break;
                        }
                    case "u1":
                        {

                            EventService.Instance.Unsubscribe(subscribedObject, obj);
                            break;
                        }
                    case "u2":
                        {
                            EventService.Instance.Unsubscribe(subscribedObject, obj2);
                            break;
                        }
                    case "s1":
                        {
                            EventService.Instance.Subscribe(subscribedObject, obj);
                            break;
                        }
                    case "s2":
                        {
                            EventService.Instance.Subscribe(subscribedObject, obj2);
                            break;
                        }
                    case "q":
                        {
                            quit = true;
                            break;
                        }
                }
                Console.WriteLine("Subscribed ID: " + subscribedObject.ObjId);
                Console.WriteLine("Subscribed Name: " + subscribedObject.Name);
            }
        }

        static void TestFileManagement()
        {
            string file = @"..\..\Testing.txt";
            string file2 = @"..\..\Testing2.txt";

            uint ref1 = FileReferenceService.Instance.RegisterFile(file);
            Console.WriteLine("Reference 1 id: " + ref1);

            uint ref2 = FileReferenceService.Instance.RegisterFile(file);
            Console.WriteLine("Reference 2 id: " + ref2);

            uint ref3 = FileReferenceService.Instance.RegisterFile(file2);
            Console.WriteLine("Reference 3 id: " + ref3);

            FileReference fileReference = FileReferenceService.Instance.GetReferenceById(ref1);
            Console.WriteLine(fileReference?.Location);
            Console.ReadLine();
        }

        static void TestSaveManager()
        {
            FileStream fs = new FileStream("output.test", FileMode.Create);
            SaveableObject obj = new TestSaveableObject();
            SaveableObject obj2 = new TestSaveableObject2();
            ObjectManagerService.Instance.RegisterObject(obj2);
            ObjectManagerService.Instance.RegisterObject(obj);
            ObjectManagerService.Instance.Save(fs);
            fs.Flush();
            fs.Close();

            FileStream fs2 = new FileStream("output.test", FileMode.Open);
            ObjectManagerService.Instance.Resume(fs2);
            fs2.Close();
        }

        static void TestLogger()
        {
            LoggerOptions loggerOptions = new LoggerOptions()
            {
                OutputToConsole = true,
                OutputToFile = true,
                OutputToWebAPI = false,
                LogFile = "test.log",
                WebAPIUrl = "http://localhost/"
            };
            Logger.Instance.Init(loggerOptions);
            Logger.Instance.Log("Wow", LogLevel.Error);
            Logger.Instance.Log("test", LogLevel.Info);
        }

        static void TestAlgorithms()
        {
            List<string> list = new List<string>();
            list.Add("Test1");
            list.Add("Test2");
            list.Add("Test3");

            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            list.Insert(1, "Test4");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Remove("Test2");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Clear();
            Console.WriteLine("Count: " + list.Count);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            ArrayBag<string> bag = new ArrayBag<string>(12)
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4",
                "Test5",
                "Test6",
                "Test7",
                "Test8",
                "Test9",
                "Test10",
                "Test11",
                "Test12"
            };

            bool full = bag.IsFull;
            bool empty = bag.IsEmpty;
            Console.WriteLine("Is bag full:" + full + "\nIs bag empty: " + empty);

            string itemrem = bag.Remove("Test5");
            Console.WriteLine("Removed item: " + itemrem);

            full = bag.IsFull;
            empty = bag.IsEmpty;
            Console.WriteLine("Is bag full:" + full + "\nIs bag empty: " + empty);

            foreach (var item in bag)
            {
                Console.WriteLine(item);
            }

            LinkedBag<string> linkedbag = new LinkedBag<string>()
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4",
                "Test5",
                "Test6",
                "Test7",
                "Test8",
                "Test9",
                "Test10",
                "Test11",
                "Test12"
            };

            string remitem = linkedbag.Remove();
            Console.WriteLine("Removed item: " + remitem);

            string specitem = linkedbag.Remove("Test5");
            Console.WriteLine("Removed item: " + specitem);

            foreach (var item in linkedbag)
            {
                Console.WriteLine(item);
            }

            Stack<string> stack = new Stack<string>();
            stack.Push("stack1");
            stack.Push("stack2");
            stack.Push("stack3");
            stack.Push("stack4");
            stack.Push("stack5");
            stack.Push("stack6");
            stack.Push("stack7");
            stack.Push("stack8");
            stack.Push("stack9");
            stack.Push("stack10");

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            string peeked = stack.Peek();
            string popped = stack.Pop();
            Console.WriteLine("Peeked item: " + peeked);
            Console.WriteLine("Popped item: " + popped);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            if (args[0].Equals("RXCS"))
                TestRXCS();
            else if (args[0].Equals("FM"))
                TestFileManagement();
            else if (args[0].Equals("SM"))
                TestSaveManager();
            else if (args[0].Equals("LOG"))
                TestLogger();
            else if (args[0].Equals("ALGO"))
                TestAlgorithms();
            else
                return;
        }
    }
}
