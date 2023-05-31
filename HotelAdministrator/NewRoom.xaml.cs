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
    /// Логика взаимодействия для NewRoom.xaml
    /// </summary>
    public partial class NewRoom : Window
    {
        public NewRoom()
        {
            InitializeComponent();
            LoadCombo();
        }

        void LoadCombo()
        {
            cmb.ItemsSource = Enum.GetValues(typeof(Categories));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomsActions r = new RoomsActions();
                string sprice = tprice.Text;
                double price = double.Parse(sprice);
                Room room = new Room { Status_FK = 1,Category = (Categories)cmb.SelectedItem, Day_Price = price};
                r.AddRoom(room);
                r.SaveThis();
                this.Close();
                MessageBox.Show("Номер успешно добавлен!");
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Неверный формат!");
            }
        }
    }
}
