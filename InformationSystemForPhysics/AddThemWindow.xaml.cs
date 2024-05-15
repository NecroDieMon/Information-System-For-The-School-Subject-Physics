using InformationSystemForPhysics.DataBase;
using System.IO;
using System.Windows;

namespace InformationSystemForPhysics
{
    public partial class AddThemWindow : Window
    {
        PhysicBookDataBase dataBase = new PhysicBookDataBase();
        public AddThemWindow()
        {
            InitializeComponent();
        }

        private void AddYourTheme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ContentYourTheme.Text))
                {
                    MessageBox.Show("Содержание темы не может быть пустым!");
                }
                else
                {
                    Themes theme = new Themes()
                    {
                        NameTheme = NameYourTheme.Text
                    };
                    dataBase.Themes.Add(theme);
                    dataBase.SaveChanges();

                    FileInfo myTheme = new FileInfo($"{NameYourTheme.Text}.txt");
                    myTheme.Create().Close();

                    StreamWriter writer = new StreamWriter($"{NameYourTheme.Text}.txt", true);
                    writer.WriteLine(ContentYourTheme.Text);
                    writer.Close();
                    MessageBox.Show("Тема успешно добавлена!");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении темы.");
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
