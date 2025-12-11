using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BooksControl booksControl;
        private readonly AuthorControl authorControl;

        public MainWindow()
        {
            InitializeComponent();

            booksControl = new BooksControl();
            booksControl.BookSelected += OnBookSelected;
            booksContent.Content = booksControl;

            authorControl = new AuthorControl();
            authorContent.Content = authorControl;
        }

        private void OnBookSelected(int bookId)
        {
            using(var db = new Model1())
            {
                var author= db.Authors.FirstOrDefault((a) => a.Books.Any(b=> b.Id == bookId));
                if(author != null)
                {
                    authorControl.txtSelectedBook.Text = db.Books.Find(bookId).Title;
                    authorControl.txtAuthor.Text = author.Name;
                    authorControl.txtBio.Text = author.Bio;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new Model1())
            {
                booksControl.dgBooks.ItemsSource = db.Books.ToList();
            }
        }
    }
}
