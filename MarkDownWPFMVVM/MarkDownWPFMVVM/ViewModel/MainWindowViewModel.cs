using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using MarkDownWPFMVVM.Model;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

namespace MarkDownWPFMVVM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        MarkDownToHtmlConverter _converter = new MarkDownToHtmlConverter();
        MarkDownAddSyntax _mdTextEditor = new MarkDownAddSyntax();

        //+++++++++++++++++++++++++++++++++ TextBox.AutoCompleteMode Property автозаполнение

        private int _curPosition = 0;
        private int _selectLength = 0;
        public int CursorPosition
        {
            set
            {
                if (value < 0)
                    return;
                _curPosition = value;
            }
            get
            {
                return _curPosition;
            }
        }
        public int SelectionLength
        {
            set
            {
                if (value < 0)
                    return;
                _selectLength = value;
            }
            get
            {
                return _selectLength;
            }
        }


        private int _caretIndex = 0; 
        public int CrtIndex
        {
            get
            {
                return _caretIndex;
            }
            set
            {
                _caretIndex = value;
                RaisePropertyChanged("CaretIndex");
            }
        }

        // убрать tttt, ExecuteTextChangedMD изменить в конце
        #region Mark Down
        private string _mdText = "tttt";
        public string MdText
        {
            get
            {
                return _mdText;
            }
            set
            {
                _mdText = value;
                RaisePropertyChanged("MDText");

                ExecuteTextChangedMd();
            }
        }

        private void ExecuteTextChangedMd()
        {
            HtmlText = _converter.ToHtml(MdText);
        }
        #endregion

        #region HTML
        private string _htmlText = " ";
        public string HtmlText
        {
            get
            {
                return _htmlText;
            }
            set
            {
                _htmlText = value;
                RaisePropertyChanged("HTMLText");
            }
        }
        #endregion

        #region Btn
        private RelayCommand<string> _addTextBtnPress;
        public ICommand AddTextBtnPressCommand
        {
            get
            {
                if (_addTextBtnPress == null)
                {
                    _addTextBtnPress = new RelayCommand<string>(
                        ExecuteAddTextBtnPress, CanAddTextBtnPress);
                }
                return _addTextBtnPress;
            }
        }

        private void ExecuteAddTextBtnPress(string btn)
        {
            switch (btn)
            {
                case "Header":
                    MdText = _mdTextEditor.Header(MdText, _curPosition);
                    break;

                case "HorizontalRule":
                    MdText = _mdTextEditor.HorizontalRule(MdText, _curPosition);
                    break;

                case "Email":
                    MdText = _mdTextEditor.Email(MdText, _curPosition);
                    break;

                case "HTTP":
                    MdText = _mdTextEditor.Http(MdText, _curPosition);
                    break;

                case "Bold":
                    MdText = _mdTextEditor.Bold(MdText, _curPosition, SelectionLength);
                    break;

                case "Italic":
                    MdText = _mdTextEditor.Italic(MdText, _curPosition, SelectionLength);
                    break;

                case "Blockquote":
                    MdText = _mdTextEditor.Blockquote(MdText, _curPosition, SelectionLength);
                    break;

                case "CodeSpan":
                    MdText = _mdTextEditor.CodeSpan(MdText, _curPosition, SelectionLength);
                    break;

                case "Strikethrough":
                    MdText = _mdTextEditor.Strikethrough(MdText, _curPosition, SelectionLength);
                    break;
            }

            //curPosition = 0; 
            _selectLength = 0; 
        }

        private bool CanAddTextBtnPress(string btn)
        {
            if (string.IsNullOrEmpty(MdText))
                return false;

            return true;
        }
        #endregion

        #region Save 
        private RelayCommand _saveBtnPress;
        public ICommand SaveBtnPressCommand
        {
            get
            {
                if (_saveBtnPress == null)
                {
                    _saveBtnPress = new RelayCommand(
                        ExecuteSaveBtnPress, CanSaveBtnPress);
                }
                return _saveBtnPress;
            }
        }
        private bool CanSaveBtnPress()
        {
            return true;
        }
        private void ExecuteSaveBtnPress()
        {
            MessageBoxResult result = MessageBox.Show(
                "First will be save Mark Down text then will be save HTML text",
                "Save", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if(result == MessageBoxResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // Mark Down
                saveFileDialog.Filter = "txt file (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    streamWriter.WriteLine(_mdText);
                    streamWriter.Close();
                }

                // html
                saveFileDialog.Filter = "txt file (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    streamWriter.WriteLine(_htmlText);
                    streamWriter.Close();
                }
            }
        }
        #endregion

        #region Load
        private RelayCommand _loadBtnPress;
        public ICommand LoadBtnPressCommand
        {
            get
            {
                if (_loadBtnPress == null)
                {
                    _loadBtnPress = new RelayCommand(
                        ExecuteLoadBtnPress, CanLoadBtnPress);
                }
                return _loadBtnPress;
            }
        }
        private bool CanLoadBtnPress()
        {
            return true;
        }
        private void ExecuteLoadBtnPress()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|Mark Down files (*.md)|*.md|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == true)
            {
                MdText = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
            }
        }
        #endregion
        
        #region Clear
        private RelayCommand _clearBtnPress;
        public ICommand ClearBtnPressCommand
        {
            get
            {
                if (_clearBtnPress == null)
                {
                    _clearBtnPress = new RelayCommand(
                        ExecuteClearBtnPress, CanClearBtnPress);
                }
                return _clearBtnPress;
            }
        }
        private bool CanClearBtnPress()
        {
            return true;
        }
        private void ExecuteClearBtnPress()
        {
            MdText = " ";
        }
        #endregion

        //создать дополнительное окно
        #region About
        private RelayCommand _aboutBtnPress;
        public ICommand AboutBtnPressCommand
        {
            get
            {
                if (_aboutBtnPress == null)
                {
                    _aboutBtnPress = new RelayCommand(
                        ExecuteAboutBtnPress, CanAboutBtnPress);
                }
                return _aboutBtnPress;
            }
        }
        private bool CanAboutBtnPress()
        {
            return true;
        }
        private void ExecuteAboutBtnPress()
        {
            //MessageBox.Show(converter.About(), "Syntax", MessageBoxButton.OK, MessageBoxImage.Information);
            UserControlAbout name = new UserControlAbout();
            //Container.Children.Add(new MdiChild
            //{
            //    Content = Name,
            //    Title = "Name",
            //});
        }
        #endregion
    }
}
