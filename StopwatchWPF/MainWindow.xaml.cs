﻿using System;
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
using System.Windows.Threading;
using System.Diagnostics;
using System.Media;

namespace StopwatchWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        DispatcherTimer dt = new();
        Stopwatch sw = new ();
        string currentTime = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            dt.Tick += dt_Tick;
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            SoundPlayer player = new SoundPlayer("Faunts-M4-Part-II.wav");
            player.Play();
        }
        void dt_Tick(object sender, EventArgs e)
        {
            
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                clocktxtblock.Text = currentTime;
           
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            sw.Start();
            dt.Start();
            elapsedtimeitem.Items.Remove(currentTime);
            Start.IsEnabled = false;
            Stop.IsEnabled = true;

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
                sw.Stop();
                dt.Stop();
                elapsedtimeitem.Items.Add(currentTime);
                Start.IsEnabled = true;
                Stop.IsEnabled = false;
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sw.Reset();
            clocktxtblock.Text = "00:00:00";
        }
    }
}
