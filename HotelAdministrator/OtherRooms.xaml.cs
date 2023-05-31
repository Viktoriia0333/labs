using System;
using System.Collections.Generic;
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
using DAL;
using HotelAdministrator.BLL;

namespace HotelAdministrator
{
    /// <summary>
    /// Логика взаимодействия для OtherRooms.xaml
    /// </summary>
    public partial class OtherRooms : Window
    {
        RoomsActions r = new RoomsActions();
        public OtherRooms()
        {
            InitializeComponent();
            LoadDG();
        }

        void LoadDG()
        {

            List<Room> hotels = new List<Room>();
            foreach (var item in r.GetRooms())
            {
                if (item.Status_FK != 1)
                {
                    hotels.Add(item);
                }
            }

            dg.ItemsSource = hotels.ToList();

        }

        Room Correct()
        {
            try
            {
                var item = (Room)dg.SelectedItem;
                string choose =((ComboBoxItem)cmd.SelectedItem).Content.ToString();
                if(choose == "Занят")
                {
                    item.Status_FK = 3;
                }
                else if(choose == "Свободен")
                {
                    item.Status_FK = 1;
                    item.DateTo = null;
                }
                return item;
            }

            catch (System.NullReferenceException)
            {
                MessageBox.Show("Выберите статус!");
                return null;
            }

        }

        private void Dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            r.ChangeRoom(Correct());
            LoadDG();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow o = new MainWindow();
            this.Hide();
            o.Show();
        }
    }
}
