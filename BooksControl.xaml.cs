using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dns
{
    /// <summary>
    /// Interaction logic for BooksControl.xaml
    /// </summary>
    public partial class BooksControl : UserControl
    {
        public event Action<int> BookSelected;
        public BooksControl()
        {
            InitializeComponent();
            dgBooks.SelectionChanged += dgBooks_SelectionChanged;

        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBooks.SelectedItem is Book selectedBook)
            {
               int id = selectedBook.Id;
                BookSelected?.Invoke(id);
            }
        }
    }
}
