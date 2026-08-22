using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public partial class Shipment:ITrackable
    {
        string TrackingStatus;
        public void UpdateTrackingStatus(string trackingStatus)
        {
            OnTrackingCodeStatus("NEW STATUS");
            TrackingStatus= trackingStatus;
        }
        partial void OnTrackingCodeStatus(string newstatus)
        {
            Console.WriteLine($"Tracking Status changed to: {newstatus}");
        }
        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }

    }
}
