using System;

namespace Domain.Interface.Models
{
    public class LeadInformation
    {
        public string CustomerFirstname { get; }
        public string CustomerLastname { get; }
        public string CustomerCity { get; }
        public string VehicleManufacturer { get; }
        public string CurrentVehicle { get; }
        public string ModelOfInterest { get; }
        public string CampaignName { get; }
        public string Origin { get; }
        public string Type { get; }
        public string DealerAddress { get; }
        public DateTime Created { get; }
        public DateTime AssignedSalesman { get; }
        public string PinCode { get; }
        public string ElinkId { get; }
        public string Notice { get; }

        public LeadInformation(string customerFirstname, string customerLastname, string customerCity, string vehicleManufacturer,
            string currentVehicle, string modelOfInterest, string campaignName, string origin, string type, string dealerAddress,
            DateTime created, DateTime assignedSalesman, string pinCode, string elinkId, string notice)
        {
            CustomerFirstname = customerFirstname;
            CustomerLastname = customerLastname;
            CustomerCity = customerCity;
            VehicleManufacturer = vehicleManufacturer;
            CurrentVehicle = currentVehicle;
            ModelOfInterest = modelOfInterest;
            CampaignName = campaignName;
            Origin = origin;
            Type = type;
            DealerAddress = dealerAddress;
            Created = created;
            AssignedSalesman = assignedSalesman;
            PinCode = pinCode;
            ElinkId = elinkId;
            Notice = notice;
        }
    }
}