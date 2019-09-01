using LoginPage.Models;
using LoginPage.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    public class myRegisterPageViewModel : INotifyPropertyChanged
    {
        public User myNewUser { get; set; }
        public ICommand registerCommand { get; set; }
        public string Message { get; set; }

        public myRegisterPageViewModel()
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
                }else if (string.IsNullOrEmpty(myNewUser.confirmPassword))
                {
                    Message = "Field cannot be empty!";
                }else if (myNewUser.Password != myNewUser.confirmPassword)
                {
                    Message = "Password do not match!";
                }
                else
                {
                    Message = "Your account has been successfully created";
                    await Task.Delay(3000);
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
            });
    
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
