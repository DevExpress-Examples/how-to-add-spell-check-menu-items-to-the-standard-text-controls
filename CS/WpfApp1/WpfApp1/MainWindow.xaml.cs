using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DevExpress.Xpf.SpellChecker;
using DevExpress.XtraSpellChecker.Parser;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public ObservableCollection<object> MenuItems { get; } = new ObservableCollection<object>();

        void RichTextBox_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuItems.Clear();
            var commands = this.richTextBox.GetErrorOperationCommands(e.GetPosition(this.richTextBox));
            foreach (var command in commands)
            {
                var menuItem = new MenuItem();
                menuItem.Header = command.Caption;
                menuItem.Click += (s, args) => command.DoCommand();
                menuItem.IsEnabled = command.Enabled;
                MenuItems.Add(menuItem);
            }
            if (MenuItems.Count == 0)
                MenuItems.Add(new MenuItem() { Header = "No Error", IsEnabled = false });
        }

        void TextBox_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuItems.Clear();
            var commands = this.textBox.GetErrorOperationCommands(this.textBox.SelectionStart);
            foreach (var command in commands)
            {
                var menuItem = new MenuItem();
                menuItem.Header = command.Caption;
                menuItem.Click += (s, args) => command.DoCommand();
                menuItem.IsEnabled = command.Enabled;
                MenuItems.Add(menuItem);
            }
            if (MenuItems.Count == 0)
                MenuItems.Add(new MenuItem() { Header = "No Error", IsEnabled = false });
        }
    }
}
