using InformationSystemForPhysics.DataBase;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InformationSystemForPhysics
{
    public partial class MainWindow : Window
    {
        private string _urlTheme;

        //PhysicBookDataBase - ADO модель базы
        PhysicBookDataBase dataBase = new PhysicBookDataBase();
        public MainWindow()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            try
            {
                //Themes - таблица PhysicBookDataBase
                DataThemsGrid.ItemsSource = dataBase.Themes.ToList();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке данных!");
            }
        }

        private void CurrentConversionToAmperes_Click(object sender, RoutedEventArgs e)
        {
            ConverConversionToAmperesWindow converWindow = new ConverConversionToAmperesWindow();
            converWindow.Show();
            this.Close();
        }

        private void OhmLawCalculator_Click(object sender, RoutedEventArgs e)
        {
            OhmLawCalculatorWindow calculatorWindow = new OhmLawCalculatorWindow();
            calculatorWindow.Show();
            this.Close();
        }

        private void AddTheme_Click(object sender, RoutedEventArgs e)
        {
            AddThemWindow addThemWindow = new AddThemWindow();
            addThemWindow.Show();
            this.Close();
        }

        private void CallForHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Что бы выбрать тему сначала нажмите на интерисующую вас тему в таблице слева от кнопки <Выбрать тему>, а затем нажмите на саму кнопку.");
        }

        private void SelectTheme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(_urlTheme + ".txt");
                string text = reader.ReadToEnd();
                ThemeContent.Text = text;
            }
            catch
            {
                MessageBox.Show("Вы не выбрали тему!");
            }
        }

        private void DataThemsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Themes _itemGrid = DataThemsGrid.SelectedItem as Themes;
            _urlTheme = _itemGrid.NameTheme.ToString();
        }
    }
}
