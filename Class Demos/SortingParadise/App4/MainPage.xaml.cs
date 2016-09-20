using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App4
{

    public class MyNumber
    {
        static Random Rnd = new Random();
        public int Value { get; set; }
        public byte RGBValue => (byte)((float)Value / 1.5);
        
        public SolidColorBrush Color => new SolidColorBrush(Windows.UI.Color.FromArgb(255,RGBValue,RGBValue,RGBValue));

        public MyNumber(int n)
        {
            Value = n;
        }

        public MyNumber()
        {
            Value = Rnd.Next(0, 300);
        }
    }
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public ObservableCollection<MyNumber> Numbers { get; set; } = new ObservableCollection<MyNumber>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            for (int i = 0; i < 10; i++)
            {
                Numbers.Add(new MyNumber());
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Sort();
        }

        private async void Sort()
        {
            for(int i=0;i<Numbers.Count-1;i++)
            {
                var x = i;
                for(int j=i+1;j<Numbers.Count;j++)
                {
                    if (Numbers[j].Value<Numbers[x].Value)
                    {
                        x = j;
                    }
                }
                var t = Numbers[i];
                Numbers[i] = Numbers[x];
                Numbers[x] = t;
                await Task.Delay(1000);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedIndex>0)
            {
                Numbers[List.SelectedIndex] = new MyNumber();
                List.Focus(FocusState.Pointer);
                List.SelectedIndex = List.SelectedIndex;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Numbers.Clear();
            for (int i = 0; i < 10; i++)
            {
                Numbers.Add(new MyNumber());
            }
        }
    }
}
