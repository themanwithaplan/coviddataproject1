using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

///Users/snn/Documents/GitHub2020/coviddataproject1/coviddataproject1/city_community_table-2020-06-01.csv
///Users/snn/Documents/GitHub2020/coviddataproject1/coviddataproject1/city_community_table-2020-06-02.csv
//6/1/2020
//6/2/2020

///Users/snn/Documents/GitHub2020/coviddataproject1/coviddataproject1/city_community_table-2020-06-03.csv
///Users/snn/Documents/GitHub2020/coviddataproject1/coviddataproject1/city_community_table-2020-06-04.csv
//6/3/2020
//6/4/2020

namespace coviddataproject1
{
    class Program
    {
        static List<City> cityList;
        static City city;

        static void displayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nLocal COVID - Main Menu \n");

            Console.WriteLine("c) List all cities \n" +
                "i) Import data \n" +
                "x) Exit \n");

            while (true)
            {
                Console.Write("Please enter your choice: ");
                string mainMenuChoice = Console.ReadLine();
                if (mainMenuChoice.ToLower() == "x")
                {
                    Environment.Exit(0);
                }
                else if (mainMenuChoice.ToLower() == "c")
                {
                    displayCitiesMenu();
                }
                else if (mainMenuChoice.ToLower() == "i")
                {
                    Console.Write("What date is the data for?: ");
                    string dataDate = Console.ReadLine();
                    Console.Write("Please enter the path to import the file: ");

                    // Get the data from path.
                    string csvData = Console.ReadLine();

                    string[,] values = LoadCSV(csvData);
                    int num_rows = values.GetUpperBound(0) + 1;

                    //Read the data and add to List 
                    for (int r = 1; r < num_rows; r++)
                    {
                        city = new City(values[r, 1], int.Parse(values[r, 11]), int.Parse(values[r, 2]),
                            int.Parse(values[r, 5]), int.Parse(values[r, 8]), dataDate);
                        cityList.Add(city);
                    }
                    Console.WriteLine("File has been successfully imported!\n");
                }
            }
        }

        static void displayCitiesMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\nLocal COVID - Cities \n");
                Console.WriteLine("a) Add a city \n" +
                    "m) Back to Main Menu \n" +
                    "x) Exit");

                int count = 1;
                var distinctCities = cityList.GroupBy(x => x.Name).Select(y => y.First());
                var distinctCitiesSorted = distinctCities.OrderBy(r => r.Name);
                List<String> cityNames = new List<String>();

                foreach (var city in distinctCitiesSorted)
                {
                    Console.WriteLine("{0}) {1}", count, city.Name);
                    String cityName1 = city.Name.ToString();
                    cityNames.Add(cityName1);
                    count++;
                }

                Console.Write("\nPlease enter your choice: ");
                string citiesMenuChoice = Console.ReadLine();
                if (citiesMenuChoice.ToLower() == "x")
                {
                    Environment.Exit(0);
                }
                else if (citiesMenuChoice.ToLower() == "m")
                {
                    displayMainMenu();
                }
                else if (citiesMenuChoice.ToLower() == "a")
                {
                    addCity();
                }
                else
                {
                    int cityChosen = Int16.Parse(citiesMenuChoice);
                    var currentCityName = cityNames[cityChosen-1];
                    displayCityMenu(currentCityName);
                }
            }
        }

        static void displayCityMenu(string chosenCityName)
        {
            Console.Clear();
            //var currentCity = cityList[cityChosen + 1];
            var currentCitytoDisplay = from city in cityList
                                       where city.Name == chosenCityName
                                       orderby city.Date
                                       select city;

            

            var cityPopulation = from city in cityList
                                 where city.Name == chosenCityName
                                 select city.Population;
            

            while (true)
            {
                Console.WriteLine("Local COVID - {0} (Population: {1})", chosenCityName, currentCitytoDisplay.First().Population);
                Console.WriteLine("\n{0,-8}   {1,-8}   {2,-8}   {3,-8}", "Date", "Cases", "Deaths", "Tested");

                foreach (var dat in currentCitytoDisplay)
                {
                    Console.WriteLine("{0,-8}   {1,-8}   {2,-8}   {3,-8}", dat.Date, dat.Cases, dat.Deaths, dat.Tests);
                }

                Console.WriteLine("\nc) Back to Cities \n" +
                    "m) Back to Main Menu \n" +
                    "x) Exit");

                Console.Write("\nPlease enter your choice: ");
                string cityMenuChoice = Console.ReadLine();

                if (cityMenuChoice.ToLower() == "x")
                {
                    Environment.Exit(0);
                }
                else if (cityMenuChoice.ToLower() == "m")
                {
                    displayMainMenu();
                }
                else if (cityMenuChoice.ToLower() == "c")
                {
                    displayCitiesMenu();
                }
            }
        }

        static void addCity()
        {
            Console.Write("Please enter the name of the city you want to add: ");
            string cityName = Console.ReadLine();
            Console.Write("Please enter the population of the city you want to add: ");
            string cityPopulation = Console.ReadLine();
            city = new City(cityName, int.Parse(cityPopulation), 0, 0, 0, null);
            cityList.Add(city);
        }

        private static string[,] LoadCSV(string filename)
        {
            // Get the file's text.
            string whole_file = System.IO.File.ReadAllText(filename);

            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
            StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;

            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];

            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }
            // Return the values.
            return values;
        }

        static void Main(string[] args)
        {
            //Program p = new Program();
            //p.loadMainMenu();
            Console.Clear();
            
            cityList = new List<City>();
            displayMainMenu();
        }
    }
}