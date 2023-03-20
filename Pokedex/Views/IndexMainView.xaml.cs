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
using System.Windows.Shapes;

namespace Pokedex.Views
{
    /// <summary>
    /// Lógica de interacción para IndexMainView.xaml
    /// </summary>
    public partial class IndexMainView : Window
    {
        public IndexMainView()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) 
                this.DragMove(); 
        }

        private void rbtApagar_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
