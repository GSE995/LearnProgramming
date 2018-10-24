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

namespace AmalgamaParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParserWorker<List<string>[]> parser;
        public MainWindow()
        {
            InitializeComponent();
            parser = new ParserWorker<List<string>[]>(new AmalgamaParsers());
            parser.OnCompleted += Parse_OnCompleted;
            parser.OnNeWData += Parse_OneNewDate;
        }

        private void Parse_OneNewDate(object arg1, List<string>[] arg2)
        {
            songsList.Items.Clear();
            TranslateSong.Items.Clear();

            for (int i = 0; i < arg2[0].Count; i++)
            {
                songsList.Items.Add(arg2[0][i]);
                TranslateSong.Items.Add(arg2[1][i]);
            }
            //for (int i = 0; i < arg2[1].Count; i++)
            //{
            //    TranslateSong.Items.Add(arg2[1][i]);
            //}
        }

        private void Parse_OnCompleted(object obj)
        {
            parser.Abort();
        }

        private void textSongs_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArtistName.Text != "" && SongName.Text != "")
            {
                StartParser();
            }else
            {
                Alert.Text = "Введены не все данные!";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
        }


        private void Search(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(ArtistName.Text != "" && SongName.Text != "")
                {
                    Alert.Text = "";
                    StartParser();
                }
                else
                {
                    Alert.Text = "Введены не все данные!";
                }

            }

        }

        void StartParser()
        {
            parser.Settings = new AmalgamaSetings(SongName.Text, ArtistName.Text);
            parser.Start();
        }

        void ClearText()
        {
            ArtistName.Text = "";
            SongName.Text = "";
            songsList.Items.Clear();
            TranslateSong.Items.Clear();

        }

        
    }
}
