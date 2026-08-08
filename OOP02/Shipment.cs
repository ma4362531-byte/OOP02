using System;

namespace SmartDeliverySystem
{
    public class Shipment
    {
        private decimal weight;
        private decimal deliveryFee;

        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public DeliveryAddress Destination { get; set; }

        public decimal Weight
        {
            get => weight;
            set => weight = value >= 0 ? value : 0;
        }

        public decimal DeliveryFee
        {
            get => deliveryFee;
            set => deliveryFee = value >= 0 ? value : 0;
        }

        public virtual decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            DeliveryFee = newFee;
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} KG");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }
    }
}