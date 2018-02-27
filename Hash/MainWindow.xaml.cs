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
using System.IO;

namespace Hash
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private mode mode;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = combo.SelectedIndex;
            switch(index)
            {
                case 0:
                    mode = mode.md5;
                    break;
                case 1:
                    mode = mode.sha1;
                    break;
                case 2:
                    mode = mode.sha256;
                    break;
                case 3:
                    mode = mode.sha384;
                    break;
                case 4:
                    mode = mode.sha512;
                    break;
            }

        }

        private void inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Hasher hasher = new Hasher();
            if(fromText != null && fromText.IsChecked != false)
            {
                resultBox.Text = hasher.Calculate(inputBox.Text, mode).ToString();
            }
        }

        private void fromText_Checked(object sender, RoutedEventArgs e)
        {
            if(button != null)
                button.IsEnabled = false;
        }

        private void fromFile_Checked(object sender, RoutedEventArgs e)
        {
            if (button != null)
                button.IsEnabled = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FileInfo info = new FileInfo(inputBox.Text);
            if(!info.Exists)
            {
                resultBox.Text = "文件不存在";
                return;
            }
            else
            {
                FileStream fileStream = info.Open(FileMode.Open);
                Hasher hasher = new Hasher();
                resultBox.Text = hasher.Calculate(fileStream, mode).ToString();
            }
        }
    }
}
