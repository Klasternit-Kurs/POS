using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
	class Program
	{
		//TODO napraviti izmenu artikala :) 
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
							Console.WriteLine(art);
						}
						break;
					case '3':
						Brisanje();
						break;
					case '4':
						Environment.Exit(123);
						break;
					default:
						Console.WriteLine("\nGreska u unosu!");
						break;
				}
				
			} while(true);
		}

		static void Brisanje()
		{
			//TODO brisanje kao u proslom primeru, tj. Remove a ne 
			//removeAt (preporucljiva metoda sa out varijablom za
			//pronalaznje objekta :) )

			Console.WriteLine("\nUnesite sifru artikla: ");
			string sifra = Console.ReadLine();

			for (int indeks = 0; indeks < a.Count; indeks++)
			{
				if (a[indeks].sifra == sifra)
				{
					a.RemoveAt(indeks);
					Console.WriteLine("Uspesno obrisan artikal!");
					return;
				}
			}
			Console.WriteLine("Nismo nasli artikal sa tom sifrom!");
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
							bool duplikatSifra = false;
							bool duplikatNaziv = false;
							foreach (Artikal art in a)
							{
								if (art.sifra == unos.Split(' ')[0])
								{
									duplikatSifra = true;
								} 
								
								if (art.naziv == unos.Split(' ')[1])
								{
									duplikatNaziv = true;
									break;
								}
							}

							if (!duplikatSifra && !duplikatNaziv)
							{
								a.Add(new Artikal(unos.Split(' ')[1], unos.Split(' ')[0],
																	cena, marza));
								break;
							} else
							{
								if (duplikatSifra)
								{
									Console.WriteLine("Vec postoji sifra!");
								} 

								if (duplikatNaziv)
								{
									Console.WriteLine("Vec postoji naziv!");
								}
							}

							
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
			Console.WriteLine("3. Brisanje");
			Console.WriteLine("4. Izlaz");
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

		public override string ToString()
		{
			return $"{sifra} -- {naziv} ulazna cena:{uCena} marza:{marza}% - izlazna cena: {IzlaznaCena()}";
		}
	}
}
