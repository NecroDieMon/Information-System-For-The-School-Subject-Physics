using System;
using System.Windows;
using System.Windows.Controls;

namespace InformationSystemForPhysics
{
    public partial class ConverConversionToAmperesWindow : Window
    {
        private int _indexValue;
        public ConverConversionToAmperesWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double myNumber = double.Parse(MyNumber.Text);

            double result;

            if (_indexValue == 0)
            {
                result = myNumber / Math.Pow(10, 3);
                MessageBox.Show($"{result} Килоампер");
            }
            else if (_indexValue == 1)
            {
                result = myNumber / Math.Pow(10, 6);
                MessageBox.Show($"{result} Мегаампер");
            }
            else if (_indexValue == 2)
            {
                result = myNumber / Math.Pow(10, -6);
                MessageBox.Show($"{result} Микроампер");
            }
            else
            {
                MessageBox.Show("Вы не выбрали еденицу измерения!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void UnitsOfMeasurement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _indexValue = UnitsOfMeasurement.SelectedIndex;
        }
    }
}
