using WpfApp1.MVVM;
using System.Collections.ObjectModel;

namespace WpfApp1.View
{
    internal partial class MAinWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }
        public MAinWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item
            {
                Film = "Kindsofkindness",
                Genre = "Drama",
                Varighed = "2:00:60"
            });
            Items.Add(new Item
            {
                Film = "The Sheperd",
                Genre = "Fantasi",
                Varighed = "2:00:60"
            });
        }


        private Item selectedItem;
        public Item SelectedItem

        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }


        }
    }

}
