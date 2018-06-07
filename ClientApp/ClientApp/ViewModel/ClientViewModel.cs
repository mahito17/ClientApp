using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClientApp.ViewModel
{
    class ClientViewModel
    {
        public Command SaveCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public bool IsEnabled { get; set; }
        public Client ClientModel { get; set; }
    }
}