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
using System.Collections;
using System.IO;
using Microsoft.Win32;
using searchTextSymbols = Ermakov_18_10_21_SymbolsOfStrings.SearchTextSymbols;

namespace Ermakov_18_10_21_SymbolsOfStrings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SearchTextSymbols _searchTextSymbols = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            _searchTextSymbols.Clear_Strings();
            listBox_Input.Items.Clear();
            textBlock.Text = "Выполнена очистка строк!";
        }

        private void button_FindLetter_Click(object sender, RoutedEventArgs e)
        {
            char ch_letter = textbox_Letter.Text[0];
            int count_letter = _searchTextSymbols.Search_Num_Of_Letter(ch_letter);
            string str = "Символ " + ch_letter.ToString() + " встречается в тексте " + count_letter.ToString() + " раз!";
            textBlock.Text = str;
        }

        private void button_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string file_name = openFileDialog.FileName;
                listBox_Input.Items.Clear();
                using (StreamReader r = new(file_name, Encoding.Default))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        listBox_Input.Items.Add(line);
                    }
                }
                ArrayList arr_list = new();
                arr_list.AddRange(listBox_Input.Items);
                string[] strs = arr_list.ToArray(typeof(string)) as string[];
                _searchTextSymbols.LoadStrings(ref strs);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string file_name = openFileDialog.FileName;
                listBox_Input.Items.Clear();
                using (StreamReader r = new(file_name, Encoding.Default))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        listBox_Input.Items.Add(line);
                    }
                }
                ArrayList arr_list = new();
                arr_list.AddRange(listBox_Input.Items);
                string[] strs = arr_list.ToArray(typeof(string)) as string[];
                _searchTextSymbols.LoadStrings(ref strs);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            _searchTextSymbols.Clear_Strings();
            listBox_Input.Items.Clear(); 
            textBlock.Text = "Выполнена очистка строк!";
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
