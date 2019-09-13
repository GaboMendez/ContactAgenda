using Homework03.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Homework03.ViewModels
{
    public class AddContactPageViewModel : INotifyPropertyChanged
    {
        public Contact contact { get; set; }

        public AddContactPageViewModel(Contact contact)
        {
            this.contact = contact;

        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
