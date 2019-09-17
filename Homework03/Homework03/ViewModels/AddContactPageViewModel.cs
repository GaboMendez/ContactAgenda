using Homework03.Models;
using Plugin.Media;
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
        private const string DEFAULT_IMAGE = "ic_account_circle";

        public Contact contact { get; set; }
        public ICommand CommandAddContact { get; set; }
        public ICommand CommandPictureFromMedia { get; set; }
        public string PicturePath { get; set; }
        public string Message { get; set; }

        public AddContactPageViewModel(Contact contact, bool updated)
        {
            this.contact = contact;

            if (string.IsNullOrEmpty(contact.Image))
            {
                PicturePath = DEFAULT_IMAGE;
            }
            else
                PicturePath = contact.Image;

            CommandPictureFromMedia = new Command(async () =>
            {
                var photo = await CrossMedia.Current.PickPhotoAsync();

                PicturePath = photo.Path;

            });

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

                    contact.Image = string.IsNullOrEmpty(PicturePath) ? DEFAULT_IMAGE : PicturePath;

                    MessagingCenter.Send<AddContactPageViewModel, Contact>(this, "AddContact", contact);

                    await Task.Delay(3000);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
