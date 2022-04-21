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

namespace WindowsFileChecker
{
    /// <summary>
    /// Interaction logic for PropertiesWindow.xaml
    /// </summary>
    public partial class PropertiesWindow : Window
    {
        public PropertiesWindow()
        {
            InitializeComponent();
            CreateBinding();
        }
        public void CreateBinding()
        {
            WhConfig whConfig = new WhConfig();
            txtBase.Text = whConfig.GetBase();
            txtServer.Text = whConfig.GetServer();
            txtLogin.Text = whConfig.GetUser();
            txtPass.Password = whConfig.GetPass();
            txtWhDir.Text = whConfig.GetWhPath();
            txtUltimaDir.Text = whConfig.GetUltimaPath();
        }
    }
}