namespace ConsoleApp8
{
    using System.Data;
    

  
        internal class Program
        {
        /*Q1 — Abstraction
a) What is Abstraction in OOP?
Abstraction is the process of hiding implementation details and showing only the essential features of an object to the user.
b) Why is abstraction one of the four pillars of OOP?
Because it reduces complexity, hides unnecessary implementation details, and allows the programmer to focus on what an object does rather than how it does it.
Q2 — Abstract Classes vs. Interfaces
a) What is the difference between an Abstract Class and an Interface?
Abstract Class: Can contain both abstract methods and implemented methods, fields, properties, and constructors. A class can inherit from only one abstract/base class.
Interface: Mainly defines a contract that a class must follow. A class can implement multiple interfaces.
b) When would you choose an Interface instead of an Abstract Class?
Choose an Interface when you want unrelated classes to share the same behavior/contract, especially when a class may need to implement multiple behaviors. */

        public struct DeliverAddress
            {
                public string City;
                public string Street;
                public int BuildingNumber;
                public DeliverAddress(string City, string Street, int BuildingNumber)
                {
                    this.City = City;
                    this.Street = Street;
                    this.BuildingNumber = BuildingNumber;
                }
                public string GetFullADddress()
                {
                    string Address = ($"City: {City} Street: {Street} BuildingNumber: {BuildingNumber}");
                    return Address;

                }
            }
          public abstract class Shipment
            {
                string trackingCode;
                string description;
                decimal weight;
                decimal deliveryFee;

                public string TrackingCode { get { return trackingCode; } }
                public string Description
                {
                    get { return description; }
                    set { if (!string.IsNullOrWhiteSpace(value)) { description = value; } }
                }
                public decimal Weight { get { return weight; } set { if (value > 0) weight = value; } }
                public decimal DeliveryFee { get { return deliveryFee; } private set { if (value > 0) deliveryFee = value; } }
                public DeliverAddress Destination { get; set; }

                public abstract decimal EstimoatedCost { get; }
                public Shipment(string trackingCode)
                {
                    this.trackingCode = trackingCode;
                    Description = "UnKnown";
                    Weight = 1;
                    DeliveryFee = 50;
                    Destination = new DeliverAddress();
                }
                public Shipment(string trackingCode, string describtion, decimal weight, decimal deliveryfee, DeliverAddress destination)
                {
                    this.trackingCode = trackingCode;
                    Description = describtion;
                    Weight = weight;
                    DeliveryFee = deliveryfee;
                    Destination = destination;
                }
                public void UpdateDeliveryFee(decimal deliveryFee)
                {
                    DeliveryFee = deliveryFee;
                }
            public abstract void printshipment();
                
                public void UpdateWeight(decimal new_weight)
                {
                    Weight = new_weight;
                }
                public void UpdateWeight(decimal new_weight, decimal ExtraWeight)
                {
                    Weight = new_weight + ExtraWeight;
                }

            }
        class DeliveryCenter
        {
            string CenterName;

            Shipment[] shipments;
            public DeliveryCenter(string Name, Driver driver)
            {
                shipments = new Shipment[20];
                CenterName = Name;
                this.driver = driver;
            }
            public Driver driver { get; set; }
            public Shipment this[int index]
            {
                get
                {
                    if (index < shipments.Length & index >= 0) { return shipments[index]; }
                    return default(Shipment);
                }
                set
                {
                    if (index < shipments.Length & index >= 0) { shipments[index] = value; }
                }

            }
            public Shipment this[string trackingcode]
            {
                get
                {
                    for (int i = 0; i < shipments.Length; i++)
                    {
                        if (shipments[i].TrackingCode == trackingcode)
                        {
                            return shipments[i];
                        }

                    }
                    return null;
                }
            }

            public bool AddShipment(Shipment shipment)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] == null)
                    {
                        shipments[i] = shipment;
                        Console.WriteLine("SHIPMENT ADDED SUCESSFULLY");
                        return true;
                    }
                }
                return false;
            }
            public bool RemoveShipment(string trackingcode)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode == trackingcode) { shipments[i] = null; Console.WriteLine("SHIPMENT REMOVES SUCESSFULLY"); return true; }

                }
                return false;
            }
            public void PrintALLShipments()

            {
                foreach (Shipment shipment in shipments)
                {
                    if (!(shipment == null))
                    {
                        shipment.printshipment();
                        Console.WriteLine("/////////////////////////");
                    }
                }

            }
            public void PrintTrackingStatus()
            {
                foreach(ITrackable shipment in shipments)
                {
                       if (!(shipment == null))
                        Console.WriteLine(shipment.GetTrackingStatus());
                }
            }
            public void PrintInsuranceCost()
            {
                foreach (IInsurable shipment in shipments)
                {
                    if (!(shipment == null))
                    Console.WriteLine(shipment.CalculateInsurance());
                }
            }
        }

                class StandardShipment : Shipment,IInsurable,ITrackable
                {
                    public StandardShipment(string trackingCode, string describtion, decimal weight, decimal deliveryFee, DeliverAddress destenation) : base(trackingCode, describtion, weight, deliveryFee, destenation)
                    {
                    }
                public override decimal EstimoatedCost { get { return DeliveryFee + (Weight * 5); } }
                public override void printshipment()
                    {
                    Console.WriteLine("\nStandardShipment");
                    Console.WriteLine($"TrackingCode:{TrackingCode} \n Description: {Description} \n Weight: {Weight} \n DeliveryFee: {DeliveryFee} \n Destination{Destination.GetFullADddress()} \n ");
                    Console.WriteLine($"Estimatedcost:{EstimoatedCost}");
                    }
              public decimal CalculateInsurance()
                {
                    return (0.05m ) * EstimoatedCost;
                }
                public string GetTrackingStatus()
                {
                    return "ExpressShipment has been delivered";
                }

            }
                class ExpressShipment : Shipment, IInsurable,ITrackable
                {
                    decimal extrafee;
                    public decimal ExtraFee { get { return extrafee; } set { if (value >= 0) extrafee = value; } }
                    public override decimal EstimoatedCost { get { return DeliveryFee + (Weight * 5) + ExtraFee; } }
                    public ExpressShipment(string trackingCode, string describtion, decimal weight, decimal deliveryFee, DeliverAddress destenation, decimal extrafee) : base(trackingCode, describtion, weight, deliveryFee, destenation)
                    {

                        ExtraFee = extrafee;

                    }
                    public override void printshipment()
                    {
                    Console.WriteLine("\nExpressShipment");
                    Console.WriteLine($"ExtraFee: {ExtraFee}");
                    Console.WriteLine($"TrackingCode:{TrackingCode} \n Description: {Description} \n Weight: {Weight} \n DeliveryFee: {DeliveryFee} \n Destination{Destination.GetFullADddress()} \n ");
                    Console.WriteLine($"Estimatedcost:{EstimoatedCost}");
                    }
                public decimal CalculateInsurance()
                {
                    return (0.08m) * EstimoatedCost;
                }
                public string GetTrackingStatus()
                {
                    return "ExpressShipment is ready";
                }
            }

                public class InternationalShipment : Shipment,IInsurable,ITrackable {
                
                    string destinationcountry;
                    decimal customsfee;
                    public string DestinationCountry { get { return destinationcountry; } set { if (!string.IsNullOrWhiteSpace(value)) destinationcountry = value; } }
                    public decimal CustomsFee { get { return customsfee; } set { if (value >= 0) customsfee = value; } }
                    public override decimal EstimoatedCost { get { return DeliveryFee + (Weight * 5) + CustomsFee; } }
                    public InternationalShipment(string trackingCode, string describtion, decimal weight, decimal deliveryFee, DeliverAddress destenation, decimal customsfee, string destinationcountry) : base(trackingCode, describtion, weight, deliveryFee, destenation)
                    {

                        DestinationCountry = destinationcountry;
                        CustomsFee = customsfee;

                    }

                    public override void printshipment()
                    {
                        Console.WriteLine("\nInternationalShipment");
                        Console.WriteLine($"CustomsFee: {CustomsFee}");
                    Console.WriteLine($"TrackingCode:{TrackingCode} \n Description: {Description} \n Weight: {Weight} \n DeliveryFee: {DeliveryFee} \n Destination{Destination.GetFullADddress()} \n ");
                    Console.WriteLine($"DestinationCountry: {DestinationCountry}");
                        Console.WriteLine($"Estimatedcost:{EstimoatedCost}");
                    }
                public virtual void GenrateCustomerReport()
                {
                    Console.WriteLine("Customes Report"); }
                       public decimal CalculateInsurance() { 
                
                    return (0.012m) * EstimoatedCost;
                }

                public string GetTrackingStatus()
                {
                    return "InternationalShipment is out for delivery";
                }
            }

                public static class DeliveryHelper
                {
                    public static void PrintShipmentsDetails(Shipment shipment)
                    {
                        shipment.printshipment();
                    }
                }

            

                public class PriorityInternationalShipment : InternationalShipment
                {
                    public PriorityInternationalShipment(string trackingCode, string describtion, decimal weight, decimal deliveryFee, DeliverAddress destenation, decimal customsfee, string destinationcountry)
                        : base(trackingCode, describtion, weight, deliveryFee, destenation, customsfee, destinationcountry) { }
                    public override void GenrateCustomerReport()
                    {
                        Console.WriteLine("Priority  Customs Report");
                    }
                }
                public class Driver
                {
                    public string Name { get; set; }
                    public Driver(string name)
                    {
                        Name = name;
                    }
                }
            public class DeliveryReport
            {
                public void PrintShipment(ITrackable shipment) {Console.WriteLine( shipment.GetTrackingStatus()); }
                public void PrintInsurance(IInsurable shipment) { Console.WriteLine(shipment.CalculateInsurance()); }
            }
                static void Main(string[] args)
                {
                    Console.WriteLine("Enter driver Name");
                    string Name = Console.ReadLine();
                    Driver driver = new Driver(Name);
                    Console.WriteLine("Enter center name");
                    string centername = Console.ReadLine();
                    DeliveryCenter deliveryCenter = new DeliveryCenter(centername, driver);




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
                    deliveryCenter.AddShipment(standardShipment);
                    deliveryCenter.AddShipment(expressShipment);
                    deliveryCenter.AddShipment(internationalShipment);
                    deliveryCenter.PrintALLShipments();

            Console.WriteLine("Tracking statues by deliverycenter......................");
                 deliveryCenter.PrintTrackingStatus();


            Console.WriteLine("insurance cost by delivery center.........................");
                deliveryCenter.PrintInsuranceCost();


            Console.WriteLine("Tracking statues by  ITrackable[]......................");
            ITrackable[] shipents = {standardShipment, expressShipment,expressShipment};
                     foreach (ITrackable shipment in shipents)
            {
                         Console.WriteLine( shipment.GetTrackingStatus());
            }


            Console.WriteLine("insurance cost by IInsurable[] ........................");
            IInsurable[] shipments = { standardShipment, expressShipment, expressShipment };
            foreach (IInsurable shipment in shipents)
            {
                Console.WriteLine( shipment.CalculateInsurance());
            }
           
                  
                }
            }
        }
    