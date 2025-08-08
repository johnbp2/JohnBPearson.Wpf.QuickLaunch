using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private PropertyInfo _property;

        private bool _propertyValue;

        public bool PropertyValue
        {
            get { return _propertyValue; }
            set { _propertyValue = value; }
        }

        private string _propertyName = "";

        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }


        private object _objectContainingMember;

        public object ObjectContainingMemeber
        {
            get { return _objectContainingMember; }
            set { _objectContainingMember = value; }
        }


        //private T propertyHost;

        //public <T> PropertyHost
        //{
        //    get { return propertyHost; }
        //    set { propertyHost = value; }
        //}


        private string _caption = "";

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public void Init(object Object, string PropertyName, string Caption)
        {
            if (Object != null)
            {
                this._objectContainingMember = Object;
                var test = this._objectContainingMember.GetType();
                if (test.GetProperty(PropertyName) != null)
                {
                    this._propertyName = PropertyName;
                    this._property = test.GetProperty(PropertyName);
                }
                else
                {

                    throw new ArgumentException($"{PropertyName} does not exist on object.");
                }
            }
            else
            {
                throw new ArgumentNullException("Object cannot be null.");
            }
            if (!string.IsNullOrEmpty(Caption))
            {
                this._caption = Caption;
            }
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
            this.propertyGroupBox.Header = this.Caption;
        }

        private void radioNo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioYes_Checked(object sender, RoutedEventArgs e)
        {
          if(this._property.CanWrite)
            {
                this._property.SetValue(this.ObjectContainingMemeber, this.radioYes.IsChecked);
            }
        }
    }
}