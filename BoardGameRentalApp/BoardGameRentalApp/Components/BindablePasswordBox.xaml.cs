using System;
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

namespace BoardGameRentalApp.Components
{
    /// <summary>
    /// Logika interakcji dla klasy BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {

        private bool isPasswordChanging;
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox), new PropertyMetadata(string.Empty,PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is BindablePasswordBox MyPasswordBox) 
            {
                MyPasswordBox.UpdatePassword();
            }
        }

        private void UpdatePassword()
        {
            if(isPasswordChanging == false)
            {
                MyPasswordBox.Password = Password;
            }
            
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void MyPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            isPasswordChanging = true;
            Password = MyPasswordBox.Password;
            isPasswordChanging = false;
        }
    }
}
