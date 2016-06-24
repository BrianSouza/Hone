using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hone.Entidades
{
    public class Group<Tkey,TItem> : ObservableCollection<TItem>
    {
        public Tkey Key { get; private set; }

        public Group(Tkey key,IEnumerable<TItem> items)
        {
            this.Key = key;
            foreach(var item in items)
            {
                this.Items.Add(item);
            }
        }
    }
}
