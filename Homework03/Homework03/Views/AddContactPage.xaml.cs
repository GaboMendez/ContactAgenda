using Homework03.Models;
using Homework03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homework03.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContactPage : ContentPage
	{
		public AddContactPage (Contact contact, bool updated)
		{
			InitializeComponent ();
            BindingContext = new AddContactPageViewModel(contact, updated);
            

        }
       


    }
}