using EasyCaptcha.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using ООО_Питомец.Model;

namespace ООО_Питомец
{
    public partial class MainWindow : Window
    {
        public bool UseSystemPasswordChar { get; set; }
        List<Model.Users> usersList = new List<Model.Users>(); //Создали лист для пользователей
        bool capthaCheck = false;

        public MainWindow()
        {
            InitializeComponent();

            //Связь с базой
            try 
            {
                App.DB = new Model.PetShopDB();
            }
            catch
            {
                MessageBox.Show("Связь с базой неуспешнаю. Приложение не будет запущено");
                System.Windows.Application.Current.Shutdown();
            }

            usersList = App.DB.Users.ToList(); //Заполнили лист для пользователей
        }

        private void catalogOpen()
        {
            Catalog catalog = new Catalog();
            catalog.Show();
            this.Close();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void passwordCheck_Checked(object sender, RoutedEventArgs e)
        {
            textBoxPassword.Text = passwordBoxPassword.Password.ToString();
            passwordBoxPassword.Visibility = Visibility.Hidden;
            textBoxPassword.Visibility = Visibility.Visible;
        }

        private void passwordCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBoxPassword.Password = textBoxPassword.Text;
            passwordBoxPassword.Visibility = Visibility.Visible;
            textBoxPassword.Visibility = Visibility.Hidden;
        }

        private async void buttonLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (capthaCheck == false)
            {
                App.usersHelp = usersList.Where(Users => Users.UserLogin == textBoxLogin.Text && Users.UserPassword == passwordBoxPassword.Password).FirstOrDefault();

                if (App.usersHelp != null)
                {
                    catalogOpen();
                }
                else
                {
                    capthaCheck = true;

                    alertText.Content = "Вы неправильно ввели логин или пароль. Введите дополнительно капчу";

                    buttonReCapthca.Visibility = Visibility.Visible;
                    captcha.Visibility = Visibility.Visible;
                    textBoxCaptcha.Visibility = Visibility.Visible;
                    captcha.CreateCaptcha(Captcha.LetterOption.Alphanumeric, 4);
                }
            }
            else
            {
                App.usersHelp = usersList.Where(Users => Users.UserLogin == textBoxLogin.Text && Users.UserPassword == passwordBoxPassword.Password).FirstOrDefault();

                if (App.usersHelp != null && captcha.CaptchaText == textBoxCaptcha.Text)
                {
                    catalogOpen();
                }
                else
                {
                    alertText.Content = "Вы заблокированы на 10 секунд";
                    Thread.Sleep(10000);
                }
            }
            
        }

        private void buttonGuest_Click(object sender, RoutedEventArgs e)
        {
            catalogOpen();
        }

        private void buttonReCapthca_Click(object sender, RoutedEventArgs e)
        {
            captcha.CreateCaptcha(Captcha.LetterOption.Alphanumeric, 4);
        }
    }
}
