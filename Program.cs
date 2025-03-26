namespace AsmDay1
{
    internal class Program
    {
        private static void Main()
        {
            CarManager carManager = new CarManager();
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
                        carManager.AddCar();
                        break;
                    case "2":
                        carManager.ViewAllCars();
                        break;
                    case "3":
                        carManager.SearchCarByMake();
                        break;
                    case "4":
                        carManager.FilterCarByType();
                        break;
                    case "5":
                        carManager.RemoveCarByModel();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }


    }
}
