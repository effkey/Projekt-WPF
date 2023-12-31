﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Projekt_wpf.Components
{
    /// <summary>
    /// Interaction logic for BindAblePasswordBox.xaml
    /// </summary>
    public partial class BindAblePasswordBox : UserControl
    {
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindAblePasswordBox), new PropertyMetadata(string.Empty));


        public BindAblePasswordBox()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChnged(object sender, RoutedEventArgs e)
        {
            Password = passwordBox.Password;
        }
    }
}
