using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_PR2_2_Z2;
internal class Osoba
{
	public string Imię { get; set; }
	public string Nazwisko { get; set; }
	public string ImięNazwisko => $"{Imię} {Nazwisko}";
}
