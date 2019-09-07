using Homework03.Models;
using Homework03.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homework03.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public User myUser { get; set; }
        public ICommand loginCommand { get; set; }
        public string Message { get; set; }
        public ICommand goRegister { get; set; }

        public LoginPageViewModel()
        {
            myUser = new User();
            loginCommand = new Command(async () =>
            {
                if (string.IsNullOrEmpty(myUser.Matricula))
                {
                    Message = "Field cannot be empty!";
                }
                else if (string.IsNullOrEmpty(myUser.Password))
                {
                    Message = "Field cannot be empty!";
                }
                else
                {
                    Message = $"Welcome: {myUser.Matricula} !!";
                    await Task.Delay(3000);
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());


                }
            });

            goRegister = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
