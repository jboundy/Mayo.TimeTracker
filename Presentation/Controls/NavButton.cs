﻿using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Presentation
{

    public class NavButton : ButtonBase
    {
        static NavButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
        }
        public static readonly DependencyProperty NavUriProperty =
                            DependencyProperty.Register("NavUri", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));


        public static readonly DependencyProperty TextProperty =
                            DependencyProperty.Register("Text", typeof(string), typeof(NavButton), new PropertyMetadata(null));


        public Uri NavUri
        {
            get { return (Uri)GetValue(NavUriProperty); }
            set { SetValue(NavUriProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
