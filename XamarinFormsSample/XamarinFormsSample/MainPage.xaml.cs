﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinFormsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            Permissions.RequestAsync<Permissions.LocationAlways>();
        }
    }
}

