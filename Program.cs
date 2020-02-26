using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
	class Program
	{
		public static List<Artikal> a = new List<Artikal>(); //null u ovom trenutku
		static void Main(string[] args)
		{
			do
			{
				StampajMeni();
				ConsoleKeyInfo unos = Console.ReadKey();
				
				switch(unos.KeyChar)
				{
					case '1':
						Unos();
						break;
					case '2':
						Console.WriteLine();
						foreach (Artikal art in a)
						{ 
							Console.WriteLine($"{art.naziv} - {art.uCena} - {art.marza} --- {art.IzlaznaCena()}");
						}
						break;
					case '3':
						Environment.Exit(123);
						break;
				}
				
			} while(true);
		}

		static void Unos()
		{
			do
			{
				
				Console.WriteLine("\nUnesite sifru naziv cenu marzu:");
				string unos = Console.ReadLine();
				//001, plazam, 200, 35
				// 0     1      2    3

				if (unos.Split(' ').Length == 4)
				{
					if (decimal.TryParse(unos.Split(' ')[2], out decimal cena))
					{
						if (int.TryParse(unos.Split(' ')[3], out int marza))
						{
							a.Add(new Artikal(unos.Split(' ')[1], unos.Split(' ')[0],
								cena, marza));
							break;
						} else
						{
							Console.WriteLine("Proverite marzu! ");
						}
						
					} else
					{
						Console.WriteLine("Proverite cenu! ");
					}

				} else
				{
					Console.WriteLine("Doslo je do greske u unosu, pokusajte opet!");
				}
			} while (true);

		}

		static void StampajMeni()
		{
			Console.WriteLine("1. Unos artikla");
			Console.WriteLine("2. Ispis artikala");
			Console.WriteLine("3. Izlaz");
			Console.WriteLine("------------");
			Console.Write("Izaberite: ");
		}
	}

	public class Artikal
	{
		public string naziv, sifra;
		public decimal uCena;
		public int marza;
		//TODO Za domaci, uvesti i porez :) 

		public decimal IzlaznaCena()
		{
			return uCena * (1 + (decimal)marza / 100);
		}

		public Artikal(string n, string s, decimal c, int m)
		{
			naziv = n;
			sifra = s;
			uCena = c;
			marza = m;
		}
	}
}
