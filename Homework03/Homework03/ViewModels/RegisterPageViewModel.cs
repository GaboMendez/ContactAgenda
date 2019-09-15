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
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        public User myNewUser { get; set; }
        public ICommand registerCommand { get; set; }
        public string Message { get; set; }

        public RegisterPageViewModel()
        {
            myNewUser = new User();

            registerCommand = new Command(async () =>
            {
                if (string.IsNullOrEmpty(myNewUser.Matricula))
                {
                    Message = "Field cannot be empty!";
                }
                else if (string.IsNullOrEmpty(myNewUser.Name))
                {
                    Message = "Field cannot be empty!";
                }
                else if (string.IsNullOrEmpty(myNewUser.Password))
                {
                    Message = "Field cannot be empty!";
                }
                else if (string.IsNullOrEmpty(myNewUser.confirmPassword))
                {
                    Message = "Field cannot be empty!";
                }
                else if (myNewUser.Password != myNewUser.confirmPassword)
                {
                    Message = "Password do not match!";
                }
                else
                {
                    Message = "Your account has been successfully created";
                    await Task.Delay(3000);
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage(myNewUser));
                }
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
