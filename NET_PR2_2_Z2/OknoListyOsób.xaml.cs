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
	private ObservableCollection<Osoba> KolekcjaOsób = new();
	//ListBox ListaOsób;
	public OknoListyOsób()
	{
		DataContext = KolekcjaOsób;
		InitializeComponent();
	}

	private void Edycja(object sender, RoutedEventArgs e)
	{
		new OknoSzczegółów(
			(Osoba)ListaOsób.SelectedItem
			).Show();
	}

	private void Dodaj(object sender, RoutedEventArgs e)
	{
		Osoba nowa = new Osoba();
		KolekcjaOsób.Add(nowa);
		new OknoSzczegółów(
			nowa
			).Show();
	}

	private void Usuń(object sender, RoutedEventArgs e)
	{
		KolekcjaOsób.Remove(
			(Osoba)ListaOsób.SelectedItem
			);
	}
}
