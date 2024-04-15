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

namespace DeviceDashboard.Components
{
    /// <summary>
    /// WaterProgress.xaml 的交互逻辑
    /// </summary>
    public partial class WaterProgress : UserControl
    {



        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(WaterProgress), new PropertyMetadata(0.0, new PropertyChangedCallback(OnValueChange)));



        public WaterProgress()
        {
            InitializeComponent();
        }


        private static void OnValueChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            double newValue = (double)e.NewValue;
            WaterProgress source = d as WaterProgress;
            if (source != null)
            {
                source.tth.Y = 166 - (newValue * (166*1.0 / 100));
            }
        }
    }
}
