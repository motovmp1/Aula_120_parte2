using Aula120Parte2.Entities;
using Aula120Parte2.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula120Parte2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter departament name : ");
            string depname = Console.ReadLine();

            Console.WriteLine("\n enter worker data: ");
            Console.WriteLine("\n Name:  ");
            string name = Console.ReadLine();

            Console.WriteLine("\n Enter level Junior/MidLevel/Senior");
            Enum.TryParse(Console.ReadLine(), out WorkerLevel level); // vamos ver se converte o recebido

            Console.WriteLine("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Departament dep = new Departament(depname);

            Worker worker = new Worker(name, level, baseSalary, dep);

            Console.WriteLine("How many contrats to this worker? ");

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.WriteLine("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Duration in hours: ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract1 = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contract1);

            }

            Console.WriteLine("Enter month and year to calculate income:  (MM/YYYY)");
            string monthYear = Console.ReadLine();

            int month = int.Parse(monthYear.Substring(0, 2));

            int year = int.Parse(monthYear.Substring(3));

            Console.WriteLine("Name : " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);

            Console.WriteLine("Income for " + monthYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));












        }
    }
}
