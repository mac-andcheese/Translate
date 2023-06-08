﻿using System;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Translate.Pages
{
    public sealed partial class SettingsPage : Page
    {
        internal IPropertySet settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        public event EventHandler<string> SettingChangedEvent;

        public SettingsPage()
        {
            this.InitializeComponent();
            var fontlist = Microsoft.Graphics.Canvas.Text.CanvasTextFormat.GetSystemFontFamilies();
            fonts.ItemsSource = fontlist;
            if (settings["history"] != null)
            {
                bool value = (bool)settings["history"];
                historyswitch.IsOn = value;
            }
            if (settings["compactmode"] != null)
            {
                bool value = (bool)settings["compactmode"];
                compactswitch.IsOn = value;
            }
            if (settings["autotranslate"] != null)
            {
                bool value = (bool)settings["autotranslate"];
                autoswitch.IsOn = value;
            }
            if (settings["fontSize"] != null)
            {
                // make font size retrieving work
            }
            // make font family retrieving work
        }

        private void UpdateSettings()
        {
            bool value = (bool)settings["compactmode"];
                    // TODO: add padding change to infobar
                    if (!value)
                    {
                        settingtitle.FontSize = 30;
                        setting1.Padding = new Thickness(16);
                        setting2.Padding = new Thickness(16);
                        setting3.Padding = new Thickness(16);
                    }
                    else if (value)
                    {
                        settingtitle.FontSize = 20;
                        setting1.Padding = new Thickness(15, 10, 15, 10);
                        setting2.Padding = new Thickness(15, 10, 15, 10);
                        setting3.Padding = new Thickness(15, 10, 15, 10);
                    }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            double width = (sender as Grid).ActualWidth;
            if (width > 1000)
            {
                panel.Width = 1000;
            }
            else
            {
                panel.Width = width;
            }
            System.Diagnostics.Debug.WriteLine($"{panel.Width}, {width}");
        }

        private void compactswitch_Toggled(object sender, RoutedEventArgs e) { string setting = "compactmode"; 
            settings[setting] = (sender as ToggleSwitch).IsOn;
            SettingChangedEvent?.Invoke(this, setting); 
            UpdateSettings(); }

        private void historyswitch_Toggled(object sender, RoutedEventArgs e) { string setting = "history"; settings[setting] = (sender as ToggleSwitch).IsOn; SettingChangedEvent?.Invoke(this, setting); }

        private void autoswitch_Toggled(object sender, RoutedEventArgs e) { string setting = "autotranslate"; settings[setting] = (sender as ToggleSwitch).IsOn; SettingChangedEvent?.Invoke(this, setting); }

        private void NumberBoxSpinButtonPlacementExample_ValueChanged(Microsoft.UI.Xaml.Controls.NumberBox sender, Microsoft.UI.Xaml.Controls.NumberBoxValueChangedEventArgs args)
        {
            if (sender.Value < 5)
            {
                sender.Value = 16;
            }
            string setting = "fontSize";
            // make font size saving work
        }

        private void fonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // make font family saving work
        }
    }
}
