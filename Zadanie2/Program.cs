//zadanie 2a

using Zadanie2;


class Program
            {
                public static void Main()
                {
                    var student1 = new zadanie2A.Student("Andriy",1234);
                    var student2 = new zadanie2A.Student("Danilo",4567);
            
                    var course1 = new zadanie2A.Course("UI");
            
                    course1.AddStudent(student1);
                    course1.AddStudent(student2);
            
                    foreach (var VARIABLE in course1.GetStudents())
                    { 
                        Console.WriteLine($"Name Student: {VARIABLE.GetName()}\nStudent Id: {VARIABLE.GetStudentId()}");
                        Console.WriteLine("----------------------");
                    }
                    
                    
                    
                    
                    Zadanie2B.Product product1 = new Zadanie2B.Product("T-shorts", 15);
                    Zadanie2B.Product product2 = new Zadanie2B.Product("Table", 18);
                    Zadanie2B.Product product3 = new Zadanie2B.Product("Shoes", 45);
                    Zadanie2B.Product product4 = new Zadanie2B.Product("Ball", 5);

                    var provider1 = new Zadanie2B.Provider();
                    provider1.AddProduct(product1);
                    provider1.AddProduct(product3);
                    var provider2 = new Zadanie2B.Provider();
                    provider2.AddProduct(product2);
                    provider2.AddProduct(product4);
                    foreach (var VARIABLE in provider1.GatProduct())
                    {
                        Console.WriteLine($"Product name: {VARIABLE.GetName()}\nProduct price: {VARIABLE.GetPrice()}");
                    }
                    foreach (var VARIABLE in provider2.GatProduct())
                    {
                        Console.WriteLine($"Product name: {VARIABLE.GetName()}\nProduct price: {VARIABLE.GetPrice()}");
                    }
                    

                }
            }
