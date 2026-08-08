namespace SmartDeliverySystem
{
    public struct DeliveryAddress
    {
        public string City { get; set; }
        public string Street { get; set; }

        public DeliveryAddress(string city, string street)
        {
            City = city;
            Street = street;
        }
    }
}