﻿using System;
using System.Collections.Generic;
using System.Linq;
using Recycle.ViewModels;
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

namespace Recycle.Views
{
    /// <summary>
    /// TaskPage.xaml 的互動邏輯
    /// </summary>
    public partial class TaskPage : UserControl
    {
        public static MainViewModel Instance => App.Current.Resources["mainViewModel"] as MainViewModel;

        public TaskPage()
        {
            InitializeComponent();
        }

        private void robot_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            scrollViewer.ScrollToTop();
        }

        private void ButtonApply_Click(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickApplyConfidence(sender, e);
        }

    }
}
