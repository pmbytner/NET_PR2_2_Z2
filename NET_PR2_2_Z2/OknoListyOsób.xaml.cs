using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NET_PR2_2_Z2;
/// <summary>
/// Logika interakcji dla klasy OknoListyOsób.xaml
/// </summary>
public partial class OknoListyOsób : Window
{
	private ObservableCollection<Osoba> KolekcjaOsób = new()
	{
		new Osoba() {
			Imię = "Neo",
			Nazwisko = "Reevs",
			DataUrodzenia = DateTime.Parse("01.01.2001"),
			DataŚmierci = DateTime.Now
		},
		new Osoba() {
			Imię = "Nemo",
			Nazwisko = "Kapitan",
			DataUrodzenia = DateTime.Parse("01.01.1880"),
			DataŚmierci = DateTime.Now
		}
	};
	public OknoListyOsób()
	{
		DataContext = KolekcjaOsób;
		InitializeComponent();
	}
}
