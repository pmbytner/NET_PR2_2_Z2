using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_PR2_2_Z2;
internal class Osoba : INotifyPropertyChanged
{
	private string imię;
	private string nazwisko;
	private DateTime? dataUrodzenia;
	private DateTime? dataŚmierci;

	public string Imię
	{
		get => imię;
		set
		{
			imię = value;
			NotyfikujZmianęWłaściwości();
		}
	}
	public string Nazwisko
	{
		get => nazwisko;
		set
		{
			nazwisko = value;
			NotyfikujZmianęWłaściwości();
		}
	}
	public DateTime? DataUrodzenia
	{
		get => dataUrodzenia;
		set
		{
			dataUrodzenia = value;
			NotyfikujZmianęWłaściwości();
		}
	}
	public DateTime? DataŚmierci
	{
		get => dataŚmierci;
		set
		{
			dataŚmierci = value;
			NotyfikujZmianęWłaściwości();
		}
	}

	public string ImięNazwisko => $"{Imię} {Nazwisko}";
	public string Wiek {
		get
		{
			if (dataUrodzenia == null)
				return "";
			DateTime
				start = (DateTime)dataUrodzenia,
				stop = (dataŚmierci != null) ?
					(DateTime)dataŚmierci :
					DateTime.Now
				;
			return Math.Round(
				(stop - start).Days / 365.25,
				MidpointRounding.ToZero
				)
				.ToString();
		}
	}
	public string Info => $"{ImięNazwisko}, {Wiek} lat";

	public event PropertyChangedEventHandler? PropertyChanged;
	private void NotyfikujZmianęWłaściwości(
		[CallerMemberName] string nazwaWłaściwości = ""
		)
	{
		PropertyChanged?.Invoke(
			this,
			new PropertyChangedEventArgs(nazwaWłaściwości)
			);
		if(PowiązaneWłaściwości.ContainsKey(nazwaWłaściwości))
			foreach(string powiązanaWłaściwość in PowiązaneWłaściwości[nazwaWłaściwości])
				PropertyChanged?.Invoke(
					this,
					new PropertyChangedEventArgs(powiązanaWłaściwość)
					);
	}
	private readonly static IDictionary<string, IEnumerable<string>>
		PowiązaneWłaściwości = new Dictionary<string, IEnumerable<string>>()
		{
			["Imię"] = new string[] { "ImięNazwisko", "Info" },
			["Nazwisko"] = new string[] { "ImięNazwisko", "Info" },
			["DataUrodzenia"] = new string[] { "Wiek", "Info" },
			["DataŚmierci"] = new string[] { "Wiek", "Info" },
		};
}
