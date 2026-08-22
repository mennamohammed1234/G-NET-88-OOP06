using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class ExpressShipment : Shipment, IInsurable, ITrackable
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

        public override Shipment CopyShipment()
        {
            return new ExpressShipment(TrackingCode, Description, Weight, DeliveryFee, Destination,ExtraFee);
        }
        public override Shipment Shallowcopy()
        {
            return (ExpressShipment)this.MemberwiseClone();
        }
        public override Shipment Deepcopy()
        {
            Shipment copy = this.Shallowcopy();
            copy.Destination = new DeliverAddress(Destination.City, Destination.Street, Destination.BuildingNumber);
            return copy;
        }

    }
}
