using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace RGBModel.ViewModel 
{
    class MainViewModel : INotifyPropertyChanged
    {
        private byte    red,
                        blue,
                        green;
        private SolidColorBrush colour;

        public MainViewModel()
        {
            Red = 100;
            Green = 200;
            Blue = 0;
        }
        public byte Red
        {
            get { return red; }
            set { red = value; NotifyPropertyChanged(); NotifyPropertyChanged("MergedDecimal"); NotifyPropertyChanged("HexaDecimal"); Colour = new SolidColorBrush(Color.FromArgb(255, Red, Green, Blue));  //dodelat u dalsich}
        }

        public byte Blue
        {
            get { return blue; }
            set { blue = value; NotifyPropertyChanged(); NotifyPropertyChanged("MergedDecimal"); NotifyPropertyChanged("HexaDecimal"); }
        }

        public byte Green
        {
            get { return green; }
            set { green = value; NotifyPropertyChanged(); NotifyPropertyChanged("MergedDecimal"); NotifyPropertyChanged("HexaDecimal"); }
        }

        public SolidColorBrush Colour
        {
            get { return colour; }

            set { colour = value; }

        }
        public string MergedDecimal
        {
            get
            {
                return String.Format("({0},{1},{2})", Red, Green, Blue);
            }
        }

        public string Hexadecimal
        {
            get
            {
                string r = Red.ToString("X");
                string g = Green.ToString("X");
                string b = Blue.ToString("X");

                return "#" + r.PadLeft(2, '0') + g.PadLeft(2, '0') + b.PadLeft(2, '0');
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
