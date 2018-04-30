using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace baeckerei40
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            this.DataContext = ActiveUser;
        }

        // Benutzername
        private SystemUser ActiveUser = new SystemUser();
        public void setActiveUser(string username)
        {
            ActiveUser.Name = username;
        }


        // Logik des linken Menus
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemBestellung":
                    usc = new Bestellung();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemProduktion":
                    usc = new Produktion();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemLager":
                    usc = new Lager();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemKommissionierung":
                    usc = new Kommissionierung();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemControlling":
                    usc = new Controlling();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        // Linkes Menu einblenden
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        // Linkes Menu ausblenden
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        // Logout Button
        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Wollen Sie Bäckerei 4.0 wirklich verlassen?", "Bestätigen",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }

        // Einstellungen Button
        private void ButtonEinstellungen_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new Einstellungen();
            GridMain.Children.Add(usc);     
        }

        // Account Button
        private void ButtonAccount_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new Account();
            GridMain.Children.Add(usc);
        }

        // Hilfe Button
        private void ButtonHilfe_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new Hilfe();
            GridMain.Children.Add(usc);
        }
    }
}
