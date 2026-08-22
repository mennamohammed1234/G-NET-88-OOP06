namespace ConsoleApp8
{
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Reflection.Metadata;
    using System.Security.Claims;
    using System.Threading.Channels;
    using static ConsoleApp8.Shipment;
// Q1 — Object Copying
//a) What happens when you assign one object variable to another object variable?
//The reference is copied, so both variables refer to the same object in memory.
//b) Does assigning one object to another create a new object? Explain.
//No.Assigning one object variable to another does not create a new object. It only copies the reference to the existing object.
//c) What is the difference between copying an object and copying its reference?
//Copying an object creates a new, independent object, while copying a reference makes two variables point to the same object.

//Q2 — Shallow Copy vs Deep Copy
//a) What is a Shallow Copy?
//A Shallow Copy creates a new object, but its reference - type members still refer to the same objects as the original.
//b) What is a Deep Copy?
//A Deep Copy creates a new object and also creates copies of its reference-type members, making the objects independent.
//c) What happens to reference-type members when a Shallow Copy is created?
//Their references are copied, so the original and copied objects share the same reference-type members.
//d) What happens to reference-type members when a Deep Copy is created?
//New objects are created for the reference-type members, so the original and copied objects have separate references.
//e) Give one situation where Deep Copy would be safer than Shallow Copy.
//Deep Copy is safer when an object contains mutable reference-type members, such as a DeliveryAddress, and we do not want changes in the copied object to affect the original.

//Q3 — Static Members
//a) What is a static field, and how is it different from an instance field?
//A static field belongs to the class itself and is shared by all objects of the class. An instance field belongs to a specific object, so each object has its own copy.
//b) What is a static method? Can a static method directly access instance members?
//A static method belongs to the class rather than an object.No, a static method cannot directly access instance members because it does not belong to a specific object.
//c) What is a static constructor, and when is it executed?
//A static constructor is used to initialize static members.It is executed automatically once, before the class is first used or its first static member is accessed.
//d) What is a static class? Can you create an object from a static class?
//A static class is a class that contains only static members.No, you cannot create an object from a static class.

//Q4 — Extension Methods
//a) What is an Extension Method?
//An Extension Method is a method that allows you to add new methods to an existing type without modifying or inheriting from that type.
//b) What keyword must be used in the first parameter of an extension method?
//The this keyword must be used in the first parameter.
//c) Where must an extension method be declared?
//An extension method must be declared inside a static class.
//d) Can an extension method access private members of the class it extends?
//No.An extension method cannot directly access private members of the class it extends.

//Q5 — Partial Classes and Partial Methods
//a) What is a Partial Class?
//A Partial Class is a class whose definition can be split into multiple files.The parts are combined by the compiler into one class.
//b) Why would a developer split one class into multiple files?
//To organize large classes, separate generated code from custom code, and make the code easier to maintain.
//c) What is a Partial Method?
//A Partial Method is a method declared in one part of a partial class and optionally implemented in another part of the same class.
//d) What happens if a declared partial method has no implementation?
//If a partial method has no implementation, it is removed by the compiler and has no effect on the program.



        internal class Program { 
   
                static void Main(string[] args) { 
                
                DeliveryUtilites.PrintSeperator();
                 DeliveryUtilites.PrintSystemTitle();

                 DeliveryUtilites.PrintSeperator();
            Console.WriteLine("Enter center name");
                    string centername = Console.ReadLine();
                    DeliveryCenter deliveryCenter = new DeliveryCenter(centername, new Driver("Ahmed"));



                 DeliveryUtilites.PrintSeperator();

            Console.WriteLine("Enter Standard Shipment Data:");

                    Console.Write("Tracking Code: ");
                    string trackingCode = Console.ReadLine();

                    Console.Write("Description: ");
                    string description = Console.ReadLine();

                    Console.Write("Weight: ");
                    decimal weight = decimal.Parse(Console.ReadLine());

                    Console.Write("Delivery Fee: ");
                    decimal deliveryFee = decimal.Parse(Console.ReadLine());

                    Console.Write("City: ");
                    string city = Console.ReadLine();

                    Console.Write("Street: ");
                    string street = Console.ReadLine();

                    Console.Write("Building Number: ");
                    int buildingNumber = int.Parse(Console.ReadLine());

                    DeliverAddress destination =
                        new DeliverAddress(city, street, buildingNumber);

                    StandardShipment standardShipment =
                        new StandardShipment(
                            trackingCode,
                            description,
                            weight,
                            deliveryFee,
                            destination);

            DeliveryUtilites.PrintSeperator();
            Console.WriteLine("Enter Express Shipment Data:");

                    Console.Write("Tracking Code: ");
                    string trackingCode2 = Console.ReadLine();

                    Console.Write("Description: ");
                    string description2 = Console.ReadLine();

                    Console.Write("Weight: ");
                    decimal weight2 = decimal.Parse(Console.ReadLine());

                    Console.Write("Delivery Fee: ");
                    decimal deliveryFee2 = decimal.Parse(Console.ReadLine());

                    Console.Write("City: ");
                    string city2 = Console.ReadLine();

                    Console.Write("Street: ");
                    string street2 = Console.ReadLine();

                    Console.Write("Building Number: ");
                    int buildingNumber2 = int.Parse(Console.ReadLine());

                    Console.Write("Extra Fee: ");
                    decimal extraFee = decimal.Parse(Console.ReadLine());

                    DeliverAddress destination2 =
                        new DeliverAddress(city2, street2, buildingNumber2);

                    ExpressShipment expressShipment =
                        new ExpressShipment(
                            trackingCode2,
                            description2,
                            weight2,
                            deliveryFee2,
                            destination2,
                            extraFee);
            DeliveryUtilites.PrintSeperator();
            Console.WriteLine("Enter International Shipment Data:");

                    Console.Write("Tracking Code: ");
                    string trackingCode3 = Console.ReadLine();

                    Console.Write("Description: ");
                    string description3 = Console.ReadLine();

                    Console.Write("Weight: ");
                    decimal weight3 = decimal.Parse(Console.ReadLine());

                    Console.Write("Delivery Fee: ");
                    decimal deliveryFee3 = decimal.Parse(Console.ReadLine());

                    Console.Write("City: ");
                    string city3 = Console.ReadLine();

                    Console.Write("Street: ");
                    string street3 = Console.ReadLine();

                    Console.Write("Building Number: ");
                    int buildingNumber3 = int.Parse(Console.ReadLine());

                    Console.Write("Destination Country: ");
                    string destinationCountry = Console.ReadLine();

                    Console.Write("Customs Fee: ");
                    decimal customsFee = decimal.Parse(Console.ReadLine());

                    DeliverAddress destination3 =
                        new DeliverAddress(city3, street3, buildingNumber3);

                    InternationalShipment internationalShipment =
                        new InternationalShipment(
                            trackingCode3,
                            description3,
                            weight3,
                            deliveryFee3,
                            destination3,
                            customsFee,
                            destinationCountry);
            DeliveryUtilites.PrintSeperator();
            deliveryCenter.AddShipment(standardShipment);
                    deliveryCenter.AddShipment(expressShipment);
                    deliveryCenter.AddShipment(internationalShipment);
                    deliveryCenter.PrintALLShipments();

            //Console.WriteLine("Tracking statues by deliverycenter......................");
            //     deliveryCenter.PrintTrackingStatus();


            //Console.WriteLine("insurance cost by delivery center.........................");
            //    deliveryCenter.PrintInsuranceCost();


            //Console.WriteLine("Tracking statues by  ITrackable[]......................");
            //ITrackable[] shipents = {standardShipment, expressShipment,expressShipment};
            //         foreach (ITrackable shipment in shipents)
            //{
            //             Console.WriteLine( shipment.GetTrackingStatus());
            //}


            //Console.WriteLine("insurance cost by IInsurable[] ........................");
            //IInsurable[] shipments = { standardShipment, expressShipment, expressShipment };
            //foreach (IInsurable shipment in shipents)
            //{
            //    Console.WriteLine( shipment.CalculateInsurance());
            //}


            Shipment sh1 = new StandardShipment(trackingCode, description, 12, deliveryFee, destination);

            //refrence assigment
            Console.WriteLine("refrence assigment");
            Shipment sh3 = sh1;
            Console.WriteLine($" original weight: {sh1.Weight}");//12
            Console.WriteLine($" copy weight: {sh3.Weight}");//12
            sh3.Weight = 44;
            Console.WriteLine("after  sh3.Weight = 44; ");
            Console.WriteLine($" original weight: {sh1.Weight}");
            Console.WriteLine($" copy weight: {sh3.Weight}");//44 // tow refrences sh1,sh3 refer to same object

            DeliveryUtilites.PrintSeperator();

            // shallowcopy
            Console.WriteLine("ShalloCopy");
            Shipment shipment1 = new StandardShipment(trackingCode, description, weight, deliveryFee, destination);
            Shipment shallow = shipment1.Shallowcopy();
            Console.WriteLine($"orignal: {shipment1.Destination.City}");// cairo
            Console.WriteLine($"copy: {shallow.Destination.City}");// cairo
          
            shipment1.Destination.City = "new city";
            Console.WriteLine("after  shipment1.Destination.City = new city;");
            Console.WriteLine($"orignal: {shipment1.Destination.City}");// new city 
            Console.WriteLine($"copy: {shallow.Destination.City}");// new city  cuse describtion is calss refrence type tow refrences refer same destination

            DeliveryUtilites.PrintSeperator();
            // deepcopy
            Console.WriteLine("deepcopy");
            Shipment shipment2 = new StandardShipment(trackingCode, description, weight, deliveryFee, destination);
            Shipment deep = shipment2.Deepcopy();
            Console.WriteLine($"orignal: {shipment2.Destination.City}");// cairo
            Console.WriteLine($"copy: {deep.Destination.City}");// cairo
            deep.Destination.City = "giza";
            Console.WriteLine("after deep.Destination.City = giza;");
            Console.WriteLine($"orignal: {shipment2.Destination.City}");// cairo
            Console.WriteLine($"copy: {deep.Destination.City}");// giza
            ////////////////////////////////////////////////
            DeliveryUtilites.PrintSeperator();

         Console.WriteLine($"total shipments: {Shipment.GetTotalShipmentsCreated()}");

            DeliveryUtilites.PrintSeperator();

           Console.WriteLine( $"Summary: { standardShipment.GetSummary()}");

            DeliveryUtilites.PrintSeperator();

            Console.WriteLine( standardShipment.Isdelivered());

            DeliveryUtilites.PrintSeperator();

            ///////////////////////partial method////////////
            Console.WriteLine(" ///////////////////////partial method////////////");
            shipment2.UpdateTrackingStatus("Deliverd");
          Console.WriteLine(  shipment2.GetTrackingStatus()); //"Deliverd"

        }
            }
        }
    