//using System.Numerics;
//using static System.Net.Mime.MediaTypeNames;

//namespace OOP02
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
#region Question 1 Part 1
//a) What is the difference between a class and a struct?

//A class is a reference type that is used to create objects and is suitable for complex data and large applications.A struct is a value type that is mainly used for small and simple data structures.

//b) Why are classes more suitable than structs for large applications?

//Classes are more suitable for large applications because they support important OOP concepts such as inheritance, polymorphism, and encapsulation.They also make code easier to reuse, organize, maintain, and extend.
#endregion

#region Question 2 Part1
//a) Which class is the parent class?

//Shipment is the parent class.

//b) Which class is the child class?

//ExpressShipment is the child class.

//c) What members are inherited by ExpressShipment?

//ExpressShipment inherits the TrackingCode property from the Shipment class.

//d) Why is inheritance better than duplicating the same code in multiple classes?

//Inheritance reduces code duplication, allows code reuse, and makes the code easier to maintain and extend.

#endregion

#region Part 02 

#region Program.cs
//using System;

//namespace SmartDeliverySystem
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter Delivery Center Name: ");
//            string centerName = Console.ReadLine();

//            DeliveryCenter center = new DeliveryCenter(centerName);

//            StandardShipment s1 = new StandardShipment("SH001", "Laptop", 3, 80, new DeliveryAddress("Cairo", "Main St"));
//            if (center.AddShipment(s1)) Console.WriteLine("Shipment Added Successfully.");

//            ExpressShipment s2 = new ExpressShipment("SH002", "Mobile Phone", 2, 60, new DeliveryAddress("Cairo", "Nasser St"), 30);
//            if (center.AddShipment(s2)) Console.WriteLine("Shipment Added Successfully.");

//            InternationalShipment s3 = new InternationalShipment("SH003", "Television", 8, 120, new DeliveryAddress("Berlin", "1st St"), "Germany", 100);
//            if (center.AddShipment(s3)) Console.WriteLine("Shipment Added Successfully.");

//            Console.WriteLine();
//            center.PrintAllShipments();

//            Console.Write("Enter Tracking Code to Remove: ");
//            string codeToRemove = Console.ReadLine();

//            if (center.RemoveShipment(codeToRemove))
//            {
//                Console.WriteLine("\nShipment Removed Successfully.\n");
//            }
//            else
//            {
//                Console.WriteLine("\nShipment Not Found.\n");
//            }

//            Console.WriteLine("==================================================");
//            Console.WriteLine("Remaining Shipments");
//            Console.WriteLine("==================================================\n");

//            center.PrintAllShipments();
//        }
//    }
//}
#endregion

#region Class DeliveryCenter

//using System;

//namespace SmartDeliverySystem
//{
//    public class DeliveryCenter
//    {
//        public string CenterName { get; set; }
//        private Shipment[] shipments = new Shipment[20];
//        private int count = 0;

//        public DeliveryCenter(string centerName)
//        {
//            CenterName = centerName;
//        }

//        public Shipment this[string trackingCode]
//        {
//            get
//            {
//                for (int i = 0; i < count; i++)
//                {
//                    if (shipments[i].TrackingCode == trackingCode)
//                        return shipments[i];
//                }
//                return null;
//            }
//        }

//        public bool AddShipment(Shipment shipment)
//        {
//            if (count < 20 && shipment != null)
//            {
//                shipments[count++] = shipment;
//                return true;
//            }
//            return false;
//        }

//        public bool RemoveShipment(string trackingCode)
//        {
//            for (int i = 0; i < count; i++)
//            {
//                if (shipments[i].TrackingCode == trackingCode)
//                {
//                    for (int j = i; j < count - 1; j++)
//                    {
//                        shipments[j] = shipments[j + 1];
//                    }
//                    shipments[count - 1] = null;
//                    count--;
//                    return true;
//                }
//            }
//            return false;
//        }

//        public void PrintAllShipments()
//        {
//            Console.WriteLine("--------------------------------------------------");
//            Console.WriteLine($"Delivery Center : {CenterName}");
//            Console.WriteLine("==================================================");

//            for (int i = 0; i < count; i++)
//            {
//                if (shipments[i] is StandardShipment)
//                    Console.WriteLine("Standard Shipment\n");
//                else if (shipments[i] is ExpressShipment)
//                    Console.WriteLine("Express Shipment\n");
//                else if (shipments[i] is InternationalShipment)
//                    Console.WriteLine("International Shipment\n");

//                shipments[i].PrintShipment();
//                Console.WriteLine("\n--------------------------------------------------\n");
//            }
//        }
//    }
//}
#endregion

#region Class InternationalShipment

//using System;

//namespace SmartDeliverySystem
//{
//    public class InternationalShipment : Shipment
//    {
//        private string destinationCountry;
//        private decimal customsFee;

//        public string DestinationCountry
//        {
//            get => destinationCountry;
//            set => destinationCountry = !string.IsNullOrWhiteSpace(value) ? value : "Unknown";
//        }

//        public decimal CustomsFee
//        {
//            get => customsFee;
//            set => customsFee = value >= 0 ? value : 0;
//        }

//        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + CustomsFee;

//        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
//            : base(trackingCode, description, weight, deliveryFee, destination)
//        {
//            DestinationCountry = destinationCountry;
//            CustomsFee = customsFee;
//        }

//        public override void PrintShipment()
//        {
//            Console.WriteLine($"Tracking Code      : {TrackingCode}");
//            Console.WriteLine($"Description        : {Description}");
//            Console.WriteLine($"Weight             : {Weight} KG");
//            Console.WriteLine($"Delivery Fee       : {DeliveryFee} EGP");
//            Console.WriteLine($"Destination Country: {DestinationCountry}");
//            Console.WriteLine($"Customs Fee        : {CustomsFee} EGP");
//            Console.WriteLine($"Estimated Cost     : {EstimatedCost} EGP");
//        }
//    }
//}

#endregion

#region Class ExpressShipment 

//using System;

//namespace SmartDeliverySystem
//{
//    public class ExpressShipment : Shipment
//    {
//        private decimal extraFee;

//        public decimal ExtraFee
//        {
//            get => extraFee;
//            set => extraFee = value >= 0 ? value : 0;
//        }

//        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + ExtraFee;

//        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
//            : base(trackingCode, description, weight, deliveryFee, destination)
//        {
//            ExtraFee = extraFee;
//        }

//        public override void PrintShipment()
//        {
//            Console.WriteLine($"Tracking Code : {TrackingCode}");
//            Console.WriteLine($"Description   : {Description}");
//            Console.WriteLine($"Weight        : {Weight} KG");
//            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
//            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
//            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
//        }
//    }
//}



#endregion

#region Class StandardShipment

//namespace SmartDeliverySystem
//{
//    public class StandardShipment : Shipment
//    {
//        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
//            : base(trackingCode, description, weight, deliveryFee, destination)
//        {
//        }
//    }
//}

#endregion

#region Class Shipment

//using System;

//namespace SmartDeliverySystem
//{
//    public class Shipment
//    {
//        private decimal weight;
//        private decimal deliveryFee;

//        public string TrackingCode { get; set; }
//        public string Description { get; set; }
//        public DeliveryAddress Destination { get; set; }

//        public decimal Weight
//        {
//            get => weight;
//            set => weight = value >= 0 ? value : 0;
//        }

//        public decimal DeliveryFee
//        {
//            get => deliveryFee;
//            set => deliveryFee = value >= 0 ? value : 0;
//        }

//        public virtual decimal EstimatedCost => DeliveryFee + (Weight * 5);

//        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
//        {
//            TrackingCode = trackingCode;
//            Description = description;
//            Weight = weight;
//            DeliveryFee = deliveryFee;
//            Destination = destination;
//        }

//        public void UpdateDeliveryFee(decimal newFee)
//        {
//            DeliveryFee = newFee;
//        }

//        public virtual void PrintShipment()
//        {
//            Console.WriteLine($"Tracking Code : {TrackingCode}");
//            Console.WriteLine($"Description   : {Description}");
//            Console.WriteLine($"Weight        : {Weight} KG");
//            Console.WriteLine($"Delivery Fee  : {DeliveryFee} EGP");
//            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
//        }
//    }
//}

#endregion

#region struct DeliveryAddress 

//namespace SmartDeliverySystem
//{
//    public struct DeliveryAddress
//    {
//        public string City { get; set; }
//        public string Street { get; set; }

//        public DeliveryAddress(string city, string street)
//        {
//            City = city;
//            Street = street;
//        }
//    }
//}

#endregion

#endregion





//        }
//    }
//}
