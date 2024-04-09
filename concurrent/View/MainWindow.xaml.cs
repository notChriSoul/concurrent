using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace concurrent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // to jest do commita, zero zmian
            InitializeComponent();
            TextBlock block = new TextBlock();
            block.Text = "Hello World!!!";
            block.HorizontalAlignment = HorizontalAlignment.Left;
            block.VerticalAlignment = VerticalAlignment.Top;
            block.FontSize = 30;
            block.Foreground = Brushes.DarkSalmon;
            this.Content = block;
            this.RegisterName("Text", block);
        }
    }
}