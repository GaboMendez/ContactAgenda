using Homework03.Models;
using Homework03.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homework03.ViewModels
{
    public class ContactHomePageViewModel : INotifyPropertyChanged
    {
        public ICommand CommandMore { get; set; }
        public ICommand CommandDelete { get; set; }
        public ICommand CommandAdd { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        Contact _selectedContact;


        public Contact selectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                if (_selectedContact != null)
                {
                    ContactDetails(_selectedContact);
                }
            }
        }

        public ContactHomePageViewModel()
        {
            CommandDelete = new Command<Contact>( async (contact) =>
            {
                bool wantsDelete = await App.Current.MainPage.DisplayAlert("Delete Confirm", "Do you want to delete this item?", "Yes", "No");
                if (wantsDelete)
                {
                    Contacts.Remove(contact);

                }
            });

            CommandMore = new Command<Contact>(async (contact) =>
            {
                string call = $"Call +{contact.Phone}";
                string edit = "Edit";
                string result = await App.Current.MainPage.DisplayActionSheet("Title", "Cancel", "Ok", call, edit);
                if (result == call)
                {
                    Device.OpenUri(new Uri(String.Format("tel:{0}", contact.Phone)));
                }
                if (result == edit)
                {

                    await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(contact));
                }
            });

            CommandAdd = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(_selectedContact));
            });

            Contacts.Add(new Contact
            {
                FirstName = "Gabriel",
                LastName = "Mendez",
                Email = "gabomendez16@gmail.com",
                Phone = "829-643-2322",
                Image = "https://image.flaticon.com/icons/svg/109/109468.svg"
            });
        }
    
        async void ContactDetails(Contact contact)
        {
            string msj = $"Name: {contact.FirstName} {contact.LastName} \n" +
                         $"Phone Number: {contact.Phone} \n" +
                         $"Email: {contact.Email}";

            await App.Current.MainPage.DisplayAlert("Details", msj, "Ok");

        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
