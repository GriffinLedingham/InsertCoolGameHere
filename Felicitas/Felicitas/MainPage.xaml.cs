using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Felicitas.Resources;

namespace Felicitas {
    public partial class MainPage : PhoneApplicationPage {

        Platformer MainGame;

        // Constructor
        public MainPage() {
            InitializeComponent();

        }

        private void BackGroundGrid_Loaded(object sender, RoutedEventArgs e) {

            MainGame = new Platformer();
            MainGame.Run(BackgroundGrid);

        }

    }
}