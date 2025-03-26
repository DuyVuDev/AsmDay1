namespace AsmDay1
{
    internal class CarManager
    {
        private List<Car> cars;

        public CarManager()
        {
            cars = new List<Car>();
        }
        //public CarManager(List<Car> initialCars)
        //{
        //    cars = initialCars ?? new List<Car>();
        //}
        //public CarManager(Car[] initialCars)
        //{
        //    cars = initialCars?.ToList() ?? new List<Car>();
        //}

        public void AddCar()
        {
            string? make;
            do
            {
                Console.Write("Enter Make: ");
                make = Console.ReadLine();
                if (string.IsNullOrEmpty(make))
                {
                    Console.WriteLine("Make cannot be empty.");
                }
            } while (string.IsNullOrEmpty(make));

            string? model;
            do
            {
                Console.Write("Enter Model: ");
                model = Console.ReadLine();
                if (string.IsNullOrEmpty(model))
                {
                    Console.WriteLine("Model cannot be empty.");
                }
            } while (string.IsNullOrEmpty(model));

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

        public void ViewAllCars()
        {
            if (!cars.Any())
            {
                Console.WriteLine("No cars found.");
                return;
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
        }

        public void SearchCarByMake()
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

        public void FilterCarByType()
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

        public void RemoveCarByModel()
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
