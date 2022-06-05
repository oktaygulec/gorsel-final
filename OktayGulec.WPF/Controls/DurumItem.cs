using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OktayGulec.WPF.Controls
{
    public class DurumItem : UserControl
    {
        public bool Durum
        {
            get { return (bool)GetValue(DurumProperty); }
            set { SetValue(DurumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Durum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DurumProperty =
            DependencyProperty.Register("Durum", typeof(bool), typeof(DurumItem), new PropertyMetadata(false));


        public string DurumText
        {
            get { return (string)GetValue(DurumTextProperty); }
            set { SetValue(DurumTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DurumText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DurumTextProperty =
            DependencyProperty.Register("DurumText", typeof(string), typeof(DurumItem), new PropertyMetadata(""));



        public SolidColorBrush DurumColor
        {
            get { return (SolidColorBrush)GetValue(DurumColorProperty); }
            set { SetValue(DurumColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DurumColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DurumColorProperty =
            DependencyProperty.Register("DurumColor", typeof(SolidColorBrush), typeof(DurumItem), new PropertyMetadata(Brushes.Red));


    }
}
