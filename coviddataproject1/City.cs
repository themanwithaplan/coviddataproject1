using System;
namespace coviddataproject1
{
    public class City
    {
        string name;
        int population;
        int cases;
        int deaths;
        int tests;
        string date;

        public City(string n, int p, int c, int d, int t, string dDate)
        {
            name = n;
            population = p;
            cases = c;
            deaths = d;
            tests = t;
            date = dDate;
        }

        public string Name { get => name; set => name = value; }
        public int Population { get => population; set => population = value; }
        public int Cases { get => cases; set => cases = value; }
        public int Deaths { get => deaths; set => deaths = value; }
        public int Tests { get => tests; set => tests = value; }
        public string Date { get => date; set => date = value; }
    }
}
