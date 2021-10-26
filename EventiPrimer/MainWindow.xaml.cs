using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventiPrimer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new Nesto();

			dugme.Click += Klik;

			if (DataContext is INotifyPropertyChanged bla)
				bla.PropertyChanged += DesilaSePromena;
		}

		private void Klik(object posiljaoc, EventArgs bla)
		{
			(DataContext as Nesto).Txt = "Promennna";
		}

		private void DesilaSePromena(object posiljaoc, EventArgs bla)
		{
			MessageBox.Show("AHA DESILO SE NESTO!! :D");
		}
	}

	public class Nesto : INotifyPropertyChanged
	{
		private string _txt = "ABC";
		public string Txt 
		{ 
			get => _txt; 
			set
			{
				_txt = value;

				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Txt"));
			}
		} 

		public event PropertyChangedEventHandler PropertyChanged;
	}

}
