using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class DeliverAddress
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
}
