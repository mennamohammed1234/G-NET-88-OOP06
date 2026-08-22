using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class InternationalShipment : Shipment, IInsurable, ITrackable
    {

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
            Console.WriteLine("Customes Report");
        }
        public decimal CalculateInsurance()
        {

            return (0.012m) * EstimoatedCost;
        }

        public string GetTrackingStatus()
        {
            return "InternationalShipment is out for delivery";
        }
        public override Shipment CopyShipment()
        {
            return new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, Destination,CustomsFee,DestinationCountry);
        }
        public override Shipment Shallowcopy()
        {
            return (InternationalShipment)this.MemberwiseClone();
        }
        public override Shipment Deepcopy()
        {
            Shipment copy = this.Shallowcopy();
            copy.Destination = new DeliverAddress(Destination.City, Destination.Street, Destination.BuildingNumber);
            return copy;
        }
    }
}
