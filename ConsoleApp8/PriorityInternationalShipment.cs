using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string describtion, decimal weight, decimal deliveryFee, DeliverAddress destenation, decimal customsfee, string destinationcountry)
            : base(trackingCode, describtion, weight, deliveryFee, destenation, customsfee, destinationcountry) { }
        public override void GenrateCustomerReport()
        {
            Console.WriteLine("Priority  Customs Report");
        }
    }



}
