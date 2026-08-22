using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp8.Program;

namespace ConsoleApp8
{
    public  abstract partial class Shipment:ITrackable
    {
        static int TotalShipmentsCreated;
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
            TotalShipmentsCreated++;
            this.trackingCode = trackingCode;
            Description = "UnKnown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = default;
        }
        public Shipment(string trackingCode, string describtion, decimal weight, decimal deliveryfee, DeliverAddress destination)
        {
            TotalShipmentsCreated++;
            this.trackingCode = trackingCode;
            Description = describtion;
            Weight = weight;
            DeliveryFee = deliveryfee;
            Destination = destination;
        }
        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment system initialize");
        }
        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
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
        public abstract Shipment CopyShipment();


        public abstract Shipment Shallowcopy();

        public abstract Shipment Deepcopy();

        partial void OnTrackingCodeStatus(string newstatus);
       
    }
}
