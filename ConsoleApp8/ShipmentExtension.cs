using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp8.Program;

namespace ConsoleApp8
{
    public static class ShipmentExtension
    {
        public static string GetSummary(this Shipment shipment)

        {
            ITrackable t = (ITrackable)shipment;

            return ($"TrackingCode:{shipment.TrackingCode} \n Description: {shipment.Description} \n Weight: " +
             $"{shipment.Weight}  \n" + $"Estimatedcost:{shipment.EstimoatedCost}" + $"status: {t.GetTrackingStatus()}");

        }


        public static bool Isdelivered(this Shipment shipment)
        {
            ITrackable t = (ITrackable)shipment;
            return (t.GetTrackingStatus() == "deliverd");

        }

    }
}
