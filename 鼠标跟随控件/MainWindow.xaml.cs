using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System;
using System.Drawing;
namespace 鼠标跟随控件
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer mDataTimer = null;

        private double k=0.3;
        
        public void dataLoad()
        {
            mDataTimer = new DispatcherTimer();
            mDataTimer.Stop();
            mDataTimer.Interval = new System.TimeSpan(0,0,0,0, 10 );
            mDataTimer.Tick += mDataTimer_Tick;
            mDataTimer.Start();
        }
        double X = 0, Y = 0;
        private void mDataTimer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("ss");
            System.Drawing.Point px = System.Windows.Forms.Control.MousePosition;
            System.Windows.Point p = new System.Windows.Point(px.X, px.Y);// 目标位置
            
            System.Windows.Point change = new System.Windows.Point((int)(p.X - X) * k, (int)(p.Y - Y) * k);
            //Console.WriteLine(p.X);
            X += change.X;
            Y += change.Y;
            icon.SetValue(Canvas.LeftProperty, X+10);
            icon.SetValue(Canvas.TopProperty, Y+10);
        }
        
        public struct point
        {
            public int X;
            public int Y;
            public point(int x,int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            
            dataLoad();
        }
    }
}
