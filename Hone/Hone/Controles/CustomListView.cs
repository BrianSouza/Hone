using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hone.Controles
{
    public class CustomListView : ListView
    {
        public static readonly BindableProperty LoadCommandProperty = BindableProperty.Create<CustomListView, ICommand>(T0 => T0.LoadCommand, default(ICommand));

        public ICommand LoadCommand
        {
            get
            {
                return (ICommand)this.GetValue(LoadCommandProperty);
            }
            set
            {
                this.SetValue(LoadCommandProperty, value);
            }
        }
        public CustomListView()
        {
            this.ItemAppearing += CustomListView_ItemAppearing;
        }

        private void CustomListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var itens = this.ItemsSource as IList;
            if(itens != null && e.Item == itens[itens.Count - 1])
            {
                this.LoadCommand.Execute(null);
            }

        }
    }
}
