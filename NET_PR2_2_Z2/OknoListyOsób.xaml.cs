using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace NET_PR2_2_Z2;
/// <summary>
/// Logika interakcji dla klasy OknoListyOsób.xaml
/// </summary>
public partial class OknoListyOsób : Window
{
	private const string ŚcieżkaIO = "listaOsób.xml";
	private readonly ObservableCollection<Osoba> KolekcjaOsób = new();
	//ListBox ListaOsób;
	public OknoListyOsób()
	{
		DataContext = KolekcjaOsób;
		Import(this, new RoutedEventArgs());
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

	private void Eksport(object sender, RoutedEventArgs e)
	{
		XmlSerializer serializator = new XmlSerializer(typeof(ObservableCollection<Osoba>));
		TextWriter strumieńZapisu = new StreamWriter(ŚcieżkaIO);
		serializator.Serialize(
			strumieńZapisu,
			KolekcjaOsób
			);
		strumieńZapisu.Close();
	}

	private void Import(object sender, RoutedEventArgs e)
	{
		XmlSerializer serializator = new XmlSerializer(typeof(ObservableCollection<Osoba>));
		FileStream plik = new FileStream(ŚcieżkaIO, FileMode.Open);
		ObservableCollection<Osoba> wczytane
			= (ObservableCollection<Osoba>) serializator.Deserialize(plik);
		KolekcjaOsób.Clear();
		foreach(Osoba osoba in wczytane)
			KolekcjaOsób.Add(osoba);
		plik.Close();
	}
}
