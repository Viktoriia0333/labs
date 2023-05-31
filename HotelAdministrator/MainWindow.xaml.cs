using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DAL;
using HotelAdministrator.BLL;

namespace HotelAdministrator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RoomsActions r = new RoomsActions();

        public MainWindow()
        {
            InitializeComponent();
            LoadDG();
        }

        void LoadDG()
        {

            List<Room> hotels = new List<Room>();
            foreach (var item in r.GetRooms())
            {
                if (item.Status_FK == 1)
                {
                    hotels.Add(item);
                }
            }

            dg.ItemsSource = hotels.ToList();

        }

        Room CalculateRoom()
        {
            try
            {
                var item = (Room)dg.SelectedItem;
                int choose = int.Parse(((ComboBoxItem)Dayscount.SelectedItem).Content.ToString());
                item.DateTo = DateTime.Now.AddDays(choose);
                item.Status_FK = 2;
                Doc.Text = Doc.Text = "Категория: " + item.Category + "\nЦена: " + item.Day_Price * choose + "$" + "\nБронь до: " + item.DateTo.Value;
                return item;
            }

            catch (System.NullReferenceException)
            {
                MessageBox.Show("Выберите количество дней!");
                return null;
            }

        }

        private void Dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Dg_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            CalculateRoom();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            r.ChangeRoom(CalculateRoom());
            LoadDG();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OtherRooms o = new OtherRooms();
            this.Hide();
            o.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NewRoom newRoom = new NewRoom();
            newRoom.Closed += NewRoom_Closed;
            newRoom.Show();


        }

        private void NewRoom_Closed(object sender, EventArgs e)
        {
            LoadDG();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LoadDG();
        }

    }
}
