﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Hone.View
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.MainViewModel();
        }
    }
}
