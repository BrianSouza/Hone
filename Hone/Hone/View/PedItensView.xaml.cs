﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hone.ViewModel;
using Xamarin.Forms;

namespace Hone.View
{
    public partial class PedItensView : ContentPage
    {
        PedItensViewModel pedItensVM = new PedItensViewModel();
        public PedItensView()
        {
            InitializeComponent();
            this.BindingContext = pedItensVM;
        }
    }
}
