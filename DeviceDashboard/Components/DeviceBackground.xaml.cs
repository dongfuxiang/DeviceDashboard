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
    /// DeviceBackground.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceBackground : UserControl
    {
        //依赖项属性


        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(DeviceBackground), new PropertyMetadata(null));




        public DeviceBackground()
        {
            InitializeComponent();
            this.SizeChanged += DeviceBackground_SizeChanged;
        }


        private void DeviceBackground_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.canvas.Children.Clear();

            //后台绘制刻度
            double radius = 125;
            for (int i = 0; i < 360; i += 2)
            {

                int flag = i % 4 == 0 ? 5 : 10;
                //求圆周上的点

                //i* Math.PI / 180 角度转弧度
                //2是Border的thickness大小
                double x1 = radius + radius * Math.Cos(i * Math.PI / 180) - 2;
                double y1 = radius + radius * Math.Sin(i * Math.PI / 180) - 2;

                double x2 = radius + (radius - flag) * Math.Cos(i * Math.PI / 180) - 2;
                double y2 = radius + (radius - flag) * Math.Sin(i * Math.PI / 180) - 2;

                Line line = new Line()
                {
                    X1 = x1,
                    Y1 = y1,
                    X2 = x2,
                    Y2 = y2,
                    Stroke = new SolidColorBrush(Color.FromArgb(40, 255, 255, 255)),
                    StrokeThickness = 1,
                };

                this.canvas.Children.Add(line);
            }

        }
    }
}
