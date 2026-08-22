using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class StandardShipment : Shipment, IInsurable, ITrackable
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
            return (0.05m) * EstimoatedCost;
        }
        public string GetTrackingStatus()
        {
            return "delivered";
        }
        public override Shipment CopyShipment()
        {
            return new StandardShipment(TrackingCode,Description,Weight,DeliveryFee,Destination);
        }
        public override Shipment Shallowcopy()
        {
            return (StandardShipment)this.MemberwiseClone();
        }
        public override Shipment Deepcopy()
        {
            Shipment copy=this.Shallowcopy();
            copy.Destination=new DeliverAddress(Destination.City,Destination.Street,Destination.BuildingNumber);
            return copy;
        }
    }
}
