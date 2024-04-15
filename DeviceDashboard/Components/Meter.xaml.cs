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
    /// Meter.xaml 的交互逻辑
    /// </summary>
    public partial class Meter : UserControl
    {
        //半径
        double radius;
        //一共要画50个刻度
        //从刻度0到刻度100大概220°，每个刻度4.4°，0°在x轴正方向，所以刻度0的位置在160°位置
        double step = 220.0 / 50;
        double start_angle = 160;

        //数据
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Meter), new PropertyMetadata(0.0, new PropertyChangedCallback(OnValueChanged)));



        //单位
        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Unit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(Meter), new PropertyMetadata(""));



        //Value改变时回调
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Meter meter = d as Meter;
            if (meter != null)
            {
                meter.Update();
            }
        }

        /// <summary>
        /// 更新仪表进度条
        /// </summary>
        private void Update()
        {
            //起点
            double x1 = radius + radius * 0.6 * Math.Cos(start_angle * Math.PI / 180);
            double y1 = radius + radius * 0.6 * Math.Sin(start_angle * Math.PI / 180);


            //根据Value计算出度数
            //因为圆弧总共220°，算出Value在220°中的占比，再加上起始度数，就是value的度数
            double current = this.Value / 100 * 220 + start_angle;

            //终点
            double x2 = radius + radius * 0.6 * Math.Cos(current * Math.PI / 180);
            double y2 = radius + radius * 0.6 * Math.Sin(current * Math.PI / 180);

            //根据观察，当value大于82的时候应该用大弧，小于82的时候用小弧
            int flag = Value > 82 ? 1 : 0;
            //M 起始点 M 10,10
            //A 母椭圆尺寸 旋转角度 是否大弧 顺 / 逆时针 终点 （这里解释了为啥坐标用逗号）A 180,180 45 1 1 150,150
            string data_str = $"M{x1},{y1} A {radius * 0.6},{radius * 0.6} 0 {flag} 1 {x2},{y2}";
            this.path_value.Data = PathGeometry.Parse(data_str);
        }

        public Meter()
        {
            InitializeComponent();
            this.SizeChanged += Meter_SizeChanged;
        }

        private void Meter_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.canvas.Children.Clear();
            //画半圆刻度
            double width = e.NewSize.Width;
            radius = width / 2;

            int flag = 0;
            int tag = 0;
            for (int i = 0; i < 51; i++)
            {
                //刻度线的起点
                double x1 = radius + radius * Math.Cos((start_angle + i * step) * Math.PI / 180);
                double y1 = radius + radius * Math.Sin((start_angle + i * step) * Math.PI / 180);

                flag = 5;
                if (i % 5 == 0)
                {
                    //5的倍数个刻度长一点
                    flag = 10;

                    //添加刻度标签
                    TextBlock textBlock = new TextBlock();
                    textBlock.Width = 30;
                    textBlock.FontSize = 9;
                    textBlock.TextAlignment = TextAlignment.Center;
                    textBlock.Foreground = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    textBlock.Text = tag.ToString();
                    double tx1 = radius - 15 + (radius - 20) * Math.Cos((start_angle + i * step) * Math.PI / 180);
                    double ty1 = radius - 5 + (radius - 20) * Math.Sin((start_angle + i * step) * Math.PI / 180);
                    tag += 10;
                    Canvas.SetLeft(textBlock, tx1);
                    Canvas.SetTop(textBlock, ty1);
                    this.canvas.Children.Add(textBlock);
                }

                //刻度线的终点
                double x2 = radius + (radius - flag) * Math.Cos((start_angle + i * step) * Math.PI / 180);
                double y2 = radius + (radius - flag) * Math.Sin((start_angle + i * step) * Math.PI / 180);
                Line line = new Line()
                {
                    Stroke = new SolidColorBrush(Color.FromArgb(90, 255, 255, 255)),
                    StrokeThickness = 1,
                    X1 = x1,
                    Y1 = y1,
                    X2 = x2,
                    Y2 = y2,
                };

                this.canvas.Children.Add(line);
            }

            //画进度条 进度条的半径应该只有整体半径的60%
            //起点
            double px1 = radius + radius * 0.6 * Math.Cos(start_angle * Math.PI / 180);
            double py1 = radius + radius * 0.6 * Math.Sin(start_angle * Math.PI / 180);
            //终点
            double px2 = radius + radius * 0.6 * Math.Cos((start_angle + 220) * Math.PI / 180);
            double py2 = radius + radius * 0.6 * Math.Sin((start_angle + 220) * Math.PI / 180);

            //M 起始点 M 10,10
            //A 母椭圆尺寸 旋转角度 是否大弧 顺 / 逆时针 终点 （这里解释了为啥坐标用逗号）A 180,180 45 1 1 150,150
            string data_str = $"M{px1},{py1} A {radius * 0.6},{radius * 0.6} 0 1 1 {px2},{py2}";
            this.path_back.Data = PathGeometry.Parse(data_str);
            Update();
        }
    }
}
