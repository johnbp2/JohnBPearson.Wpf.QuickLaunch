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
using Windows.UI.Composition;
using Windows.UI.Notifications;

namespace JohnBPearson.Wpf.Executer
{
    /// <summary>
    /// Interaction logic for SetBoolProperty.xaml
    /// </summary>
    public partial class SetBoolProperty : UserControl
    {

        private bool _propertyValue;

        public bool PropertyValue
        {
            get { return _propertyValue; }
            set { _propertyValue = value; }
        }

        private string propertyName = "";

        public string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }


        //private T propertyHost;

        //public <T> PropertyHost
        //{
        //    get { return propertyHost; }
        //    set { propertyHost = value; }
        //}


        private string header = "";

        public string Header
        {
            get { return header; }
            set { header = value; }
        }


        public SetBoolProperty()
        {
            InitializeComponent();

            //if(propertyHost == null) {
            //    throw new NullReferenceException();

            //}
        }

        private void SetBoolProp_Initialized(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Header))
            {
              // this.prop
            }
        }

        private void radioNo_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
