using Homework03.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homework03.ViewModels
{
    public class AddContactPageViewModel : INotifyPropertyChanged
    {
        public Contact contact { get; set; }
        public ICommand CommandAddContact { get; set; }

        public string PicturePath { get; set; }
        public string Message { get; set; }


        public AddContactPageViewModel(Contact contact, bool updated)
        {
            this.contact = contact;

            CommandAddContact = new Command (async () => 
            {
                if (string.IsNullOrEmpty(contact.FirstName))
                {
                    Message = "Field cannot be empty!";
                }
                else if (string.IsNullOrEmpty(contact.LastName))
                {
                    Message = "Field cannot be empty!";
                }
                else if (string.IsNullOrEmpty(contact.Phone))
                {
                    Message = "Field cannot be empty!";
                }
                else if (string.IsNullOrEmpty(contact.Email))
                {
                    Message = "Field cannot be empty!";
                }
                else
                {
                    if (updated.Equals(true))
                    {
                        Message = "Your contact has been successfully updated";
                    }else
                        Message = "Your contact has been successfully created";

                    MessagingCenter.Send<AddContactPageViewModel, Contact>(this, "AddContact", contact);
                    MessagingCenter.Send<AddContactPageViewModel>(this, "UpdateList");

                    await Task.Delay(3000);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
