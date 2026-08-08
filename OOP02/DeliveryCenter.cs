using System;

namespace SmartDeliverySystem
{
    public class DeliveryCenter
    {
        public string CenterName { get; set; }
        private Shipment[] shipments = new Shipment[20];
        private int count = 0;

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (shipments[i].TrackingCode == trackingCode)
                        return shipments[i];
                }
                return null;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            if (count < 20 && shipment != null)
            {
                shipments[count++] = shipment;
                return true;
            }
            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < count; i++)
            {
                if (shipments[i].TrackingCode == trackingCode)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        shipments[j] = shipments[j + 1];
                    }
                    shipments[count - 1] = null;
                    count--;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Delivery Center : {CenterName}");
            Console.WriteLine("==================================================");

            for (int i = 0; i < count; i++)
            {
                if (shipments[i] is StandardShipment)
                    Console.WriteLine("Standard Shipment\n");
                else if (shipments[i] is ExpressShipment)
                    Console.WriteLine("Express Shipment\n");
                else if (shipments[i] is InternationalShipment)
                    Console.WriteLine("International Shipment\n");

                shipments[i].PrintShipment();
                Console.WriteLine("\n--------------------------------------------------\n");
            }
        }
    }
}