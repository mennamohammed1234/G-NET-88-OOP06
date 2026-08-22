using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp8.Program;

namespace ConsoleApp8
{
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
            foreach (ITrackable shipment in shipments)
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

}
