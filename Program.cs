namespace AsmDay1
{
    public enum CarType
    {
        Electric,
        Fuel
    }

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }

        public Car(string make, string model, int year, CarType type)
        {
            Make = make;
            Model = model;
            Year = year;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Make} {Model} {Year} ({Type})";
        }
    }

    internal class Program
    {
        private static List<Car> cars = new List<Car>(
            [
                new Car("Toyota", "Corolla", 2021, CarType.Fuel),
                new Car("Tesla", "Model S", 2021, CarType.Electric),
                new Car("Ford", "Mustang", 2021, CarType.Fuel),
                new Car("Tesla", "Leaf", 2021, CarType.Electric),
                new Car("Chevrolet", "Bolt", 2021, CarType.Electric)
            ]
            );

        private static void Main()


        {
            while (true)
            {
                Console.WriteLine("Menu:" +
                    "\n1. Add a car" +
                    "\n2. View all cars" +
                    "\n3. Search car by Make" +
                    "\n4. Filter car by Type" +
                    "\n5. Remove a car by Model" +
                    "\n6. Exit" +
                    "\nEnter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        ViewAllCars();
                        break;
                    case "3":
                        SearchCarByMake();
                        break;
                    case "4":
                        FilterCarByType();
                        break;
                    case "5":
                        RemoveCarByModel();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddCar()
        {
            Console.Write("Enter Make: ");
            string make = Console.ReadLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();
            int year;
            while (true)
            {
                Console.Write("Enter Year: ");
                var yearInput = Console.ReadLine();
                if (int.TryParse(yearInput, out year) && year > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid year. Please enter a valid year.");
                }
            }

            CarType type;
            while (true)
            {
                Console.Write("Enter Type (Electric/Fuel): ");
                var typeInput = Console.ReadLine();
                if (Enum.TryParse(typeInput, true, out type))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid car type. Please enter 'Electric' or 'Fuel'.");
                }
            }

            cars.Add(new Car(make, model, year, type));
            Console.WriteLine("Car added successfully.");
        }

        private static void ViewAllCars()
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void SearchCarByMake()
        {
            Console.Write("Enter Make to search: ");
            var make = Console.ReadLine();
            var results = cars.Where(c => c.Make.Equals(make, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Any())
            {
                foreach (var car in results)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("No cars found with the specified make.");
            }
        }

        private static void FilterCarByType()
        {

            CarType type;
            while (true)
            {
                Console.Write("Enter Type to filter (Electric/Fuel): ");

                var typeInput = Console.ReadLine();
                if (Enum.TryParse(typeInput, true, out type))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid car type. Please enter 'Electric' or 'Fuel'.");
                }
            }

            Console.WriteLine("Car added successfully.");
            var results = cars.Where(c => c.Type == type).ToList();

            if (results.Any())
            {
                foreach (var car in results)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("No cars found with the specified type.");
            }
        }

        private static void RemoveCarByModel()
        {
            Console.Write("Enter Model to remove: ");

            var model = Console.ReadLine();

            var carToRemove = cars.FirstOrDefault(c => c.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
                Console.WriteLine("Car removed successfully.");
            }
            else
            {
                Console.WriteLine("No car found with the specified model.");
            }
        }
    }

}
