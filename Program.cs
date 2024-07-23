using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adınızı giriniz:");
            string name = Console.ReadLine();

            Console.WriteLine("Soyadınızı giriniz:");
            string surname = Console.ReadLine();

            Console.WriteLine("Doğum yılınızı giriniz:");
            int birthYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Doğum ayınızı giriniz:");
            int birthMonth = int.Parse(Console.ReadLine());

            int score = 0;
            int rollCount = 0;
            int sixCount = 0;
            int oneCount = 0;
            int[] rolls = new int[10];

            Random random = new Random();

            while (rollCount < 10 && score < 500)
            {
                int roll = random.Next(1, 7);
                rolls[rollCount] = roll;
                rollCount++;

                if (roll == 6)
                {
                    score += 100;
                    sixCount++;
                }
                else if (roll == 1)
                {
                    score -= 75;
                    oneCount++;
                }
                else
                    continue;
            }

            if (name.Length > surname.Length)
                score += 50;
            else if (name.Length == surname.Length)
                score += 25;
            else
                score -= 10;

            DateTime birthDate = new DateTime(birthYear, birthMonth, 1);
            DateTime now = DateTime.Now;

            if (birthDate < now.AddMonths(-6))
            {
                score += 30;
            }
            else if (birthDate > now.AddMonths(6))
            {
                score -= 20;
            }

            Console.WriteLine($"Atılan zarlar: {string.Join(", ", rolls)}");
            Console.WriteLine($"Toplam puan: {score}");
            Console.WriteLine($"6 sayısı {sixCount} kez geldi.");
            Console.WriteLine($"1 sayısı {oneCount} kez geldi.");

            if (score >= 500)
                Console.WriteLine("Tebrikler, oyunu kazandınız!");
            else
                Console.WriteLine("Maalesef, oyunu kaybettiniz.");

            Console.ReadLine();
        }
    }
}
