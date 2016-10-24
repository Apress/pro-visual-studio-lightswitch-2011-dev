using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CentralControlsCS
{
    public partial class RichTextBoxInternal : UserControl
    {
        public RichTextBoxInternal()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return base.GetValue(RichTextBoxInternal.TextProperty).ToString (); }
            set { base.SetValue(RichTextBoxInternal.TextProperty, value); }
        }


        public static readonly DependencyProperty TextProperty = 
            DependencyProperty.Register("Text", typeof(string), typeof(RichTextBoxInternal), new PropertyMetadata(null, OnTextPropertyChanged));

        public static void OnTextPropertyChanged(
            DependencyObject re, DependencyPropertyChangedEventArgs e)
        {
            RichTextBoxInternal richEdit = (RichTextBoxInternal)re;

            if (richEdit.richTextBox.Xaml != (string)e.NewValue)
            {
                try
                {
                    richEdit.richTextBox.Blocks.Clear();

                    if (string.IsNullOrEmpty((string)e.NewValue) == false)
                    {
                        richEdit.richTextBox.Xaml = (string)e.NewValue;
                    }
                }
                catch
                {
                    richEdit.richTextBox.Blocks.Clear();

                    if (string.IsNullOrEmpty((string)e.NewValue) == false)
                    {
                        richEdit.richTextBox.Selection.Text = (string)e.NewValue;
                    }
                }
            }
        }

        private void richTextBox_ContentChanged(object sender, System.Windows.Controls.ContentChangedEventArgs e)
        {
            Text = richTextBox.Xaml;
        }


    
    }
}
