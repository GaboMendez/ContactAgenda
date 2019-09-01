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
    public class myLoginPageViewModel : INotifyPropertyChanged
    {
        public User myUser { get; set; }
        public ICommand loginCommand { get; set; }
        public string Message { get; set; }
        public ICommand goRegister { get; set; }

        public myLoginPageViewModel()
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
                await App.Current.MainPage.Navigation.PushAsync(new myRegisterPage());
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
