using System.Windows;
using MarkDownWPFMVVM.ViewModel;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Text;

namespace MarkDownWPFMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        /// 

        //MainWindowViewModel vm;
        public MainWindow()
        {
            //vm = new MainWindowViewModel();
            InitializeComponent();

            //привязалViewModel
            this.DataContext = new MainWindowViewModel();
        }
        int _position;
        // передача index выделеного текста пользователем и его точное место положение в MVVM
        private void Ck(object sender, RoutedEventArgs e)
        {
            _position = MdTextBox.CaretIndex;

            (this.DataContext as MainWindowViewModel).CursorPosition = MdTextBox.SelectionStart;
            (this.DataContext as MainWindowViewModel).SelectionLength = MdTextBox.SelectionLength;

            //возвращение курсора
            MdTextBox.Focus();
            MdTextBox.Select(_position, 0);
        }

        //изменение положения в HTMLTextBox когда меняется положение курсора в MDTextBox
        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

            //int caretPosition = MDTextBox.CaretIndex;
            if(HtmlTextBox != null)
                HtmlTextBox.ScrollToLine(MdTextBox.GetLineIndexFromCharacterIndex(MdTextBox.SelectionStart));

            //put your handling code here...
        }

        private void MDTextBox_Changed(object sender, TextChangedEventArgs e)
        {
            //нужна для привязки изменения текста
            var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }


        private void FormatOfText(object sender, RoutedEventArgs e)
        {
            //пример изменение настроек шрифта в WPF:
            //http://blogs.msdn.com/b/text/archive/2006/11/01/sample-font-chooser.aspx
            //if (TextStyle.ShowDialog() == DialogResult.OK)
            //{
            //    MDTextBox.FontStyle .Font = TextStyle.Font;
            //    HTMLTextBox.Font = TextStyle.Font;
            //}
        }
 
        private void PrewCursorPosition(object sender, RoutedEventArgs e)
        {
            MdTextBox.Focus();
            MdTextBox.Select(_position, 0);
        }
        private void Undo(object sender, RoutedEventArgs e)
        {
            MdTextBox.Undo();
        }


    }
}