using System.Windows;

namespace InformationSystemForPhysics
{
    public partial class OhmLawCalculatorWindow : Window
    {
        private int _indexValue;
        public OhmLawCalculatorWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double currentStrength = double.Parse(CurrentStrength.Text);
                double voltage = double.Parse(Voltage.Text);
                double resistance = double.Parse(Resistance.Text);

                double result;

                if (_indexValue == 0)
                {
                    if (voltage == null || resistance == null)
                    {
                        MessageBox.Show("Одно из полей не было заполнено!");
                    }
                    else
                    {
                        result = voltage / resistance;
                        MessageBox.Show($"{result} Ампер");
                    }
                }
                else if (_indexValue == 1)
                {
                    if (currentStrength == null || resistance == null)
                    {
                        MessageBox.Show("Одно из полей не было заполнено!");
                    }
                    else
                    {
                        result = currentStrength * resistance;
                        MessageBox.Show($"{result} Вольт");
                    }
                }
                else if (_indexValue == 2)
                {
                    if (voltage == null && currentStrength == null)
                    {
                        MessageBox.Show("Одно из полей не было заполнено!");
                    }
                    else
                    {
                        result = voltage / currentStrength;
                        MessageBox.Show($"{result} Ом");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали операцию");
                }
            }
            catch
            {
                CurrentStrength.Text = "0";
                Voltage.Text = "0";
                Resistance.Text = "0";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void knownValues_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _indexValue = knownValues.SelectedIndex;
        }
    }
}
