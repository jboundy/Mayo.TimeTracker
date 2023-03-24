﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : Page
    {
        public Category()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var checkedValue = ControlGrid.Children.OfType<RadioButton>()
                        .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);

            if(checkedValue != null)
            {
                var content = checkedValue.Content;
                var nameFind = checkedValue.Name.Remove(0, 2);
                var textBox = ControlGrid.Children.OfType<TextBox>()
                            .FirstOrDefault(t => t.Name == $"tb{nameFind}");

                if(textBox != null)
                {
                    //get all content and save to db
                }
            }
        }
    }
}
