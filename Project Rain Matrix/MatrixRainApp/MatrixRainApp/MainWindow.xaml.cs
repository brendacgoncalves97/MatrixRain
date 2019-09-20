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

namespace MatrixRainApp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FontFamily rfam = new FontFamily(new Uri("pack://application:,,,"), "./font/#Matrix Code NFI");
            mRain.SetParameter(fontFamily: rfam);

            StateChanged += _WindowStateChanged;
            PreviewKeyUp += _MainWindowPreviewKeyUp;
        }

        private void _MainWindowPreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void _StartButton(object sender, RoutedEventArgs e)
        {
            mRain.Start();
        }

        private void _StopButton(object sender, RoutedEventArgs e)
        {
            mRain.Stop();
        }

        private void _ChangeCorButton(object sender, RoutedEventArgs e)
        {
            mRain.SetParameter(textBrush: ((Button)sender).Background);
        }

        private void _WindowStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                //show  ui interaction controls
                UIInterectionContainer.Visibility = Visibility.Hidden;

                mRain.Height = SystemParameters.VirtualScreenHeight;
                mRain.Width = SystemParameters.VirtualScreenWidth;
                mRain.Margin = new Thickness(0, 0, 0, 0);

                Visibility = Visibility.Hidden;
                Topmost = true;
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
                Visibility = Visibility.Visible;

                // to recover focus
                Focus();

                mRain.DimensionChanged();
            }
            else if (WindowState == WindowState.Normal)
            {
                UIInterectionContainer.Visibility = Visibility.Visible;
                mRain.Height = 524;
                mRain.Width = 1172;
                ResizeMode = ResizeMode.CanResize;
                mRain.Margin = new Thickness(10, 35, 0, 0);

                WindowStyle = WindowStyle.SingleBorderWindow;

                mRain.DimensionChanged();
            }
        }
    }
}
