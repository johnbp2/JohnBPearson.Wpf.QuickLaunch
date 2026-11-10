using Quicklaunch.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DataBind = System.Windows.Data;

using Quicklaunch.Views;
using System.Reflection;
namespace Quicklaunch.Controls
{
    /// <summary>
    /// Interaction logic for SetBoolProperty.xaml
    /// </summary>
    public partial class SetBoolProperty : Quicklaunch.Controls.QuicklaunchUserControlBase
    {
     





        //private T propertyHost;

        //public <T> PropertyHost
        //{
        //    get { return propertyHost; }
        //    set { propertyHost = value; }
        //}

        private string _path = string.Empty;
       // private object _header = "";
        private string _headerText;

        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
                if(propertyGroupBox != null)
                {
                    propertyGroupBox.Header = _headerText;
                }
            }
        }

        //[System.ComponentModel.Category("Custom Properties")]
        //[System.ComponentModel.Description("The header text for the property group box.")]
        //[System.ComponentModel.Browsable(true)]
        //[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        //public string Header
        //{
        //    get { return header; }
        //    set
        //    {
        //        header = value;
        //        //   this.propertyGroupBox.Header = header;
        //    }
        //}

        public System.Windows.Controls.GroupBox groupBox
        {
            get
            {
                return this.propertyGroupBox;
            }

        }

  
        public SetBoolProperty()
        {
            //if(propertyHost == null) {
            // _settingsPresenter = new SettingsPresenter();
            InitializeComponent();


            //}
        }
        public SetBoolProperty(string path, object header)
        {
            //_settingsPresenter = new SettingsPresenter();
  
            InitializeComponent();
            this._path = path;
            this._headerText = header.ToString();
        }

        private void SetBoolProp_Initialized(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(_path))
            {
                Bind(_path);
            }
        }


        public void Bind(string path)
        {
          
            this.DataContext = QuicklaunchUserControlBase.Settings;
            
                     //    throw new NullReferenceException();
            if(!string.IsNullOrEmpty(path) && validatePath(path))
            {

                DataBind.Binding data = new DataBind.Binding();
                //Assembly.GetExecutingAssembly().
                data.Source = QuicklaunchUserControlBase.Settings;

                data.Path = new PropertyPath(path);
                data.Mode = DataBind.BindingMode.TwoWay;
                checkBox1.SetBinding(System.Windows.Controls.CheckBox.IsCheckedProperty, data);
            }
            else
            {
                throw new Exception("path myst be set to a valid property name of the SettingsPresenter class.");
            }
        }

        private bool validatePath(string path)
        {
            bool result = false;
            PropertyInfo[]? myPropertyInfo;
            // Get the properties of 'Type' class object.
            myPropertyInfo = Type.GetType("Quicklaunch.Views.SettingsPresenter")?.GetProperties();
            Console.WriteLine("Properties of System.Type are:");
            if(myPropertyInfo is not null)
            {

                for(int i = 0; i < myPropertyInfo.Length; i++)
                {
                    if(myPropertyInfo[i].Name == path)
                    {
                        result = true;
                        break;
                    }
                    Console.WriteLine(myPropertyInfo[i].Name);
                }
            }
            return result;
        }

        private void SetBoolProp_Loaded(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.HeaderText))
            {
                this.propertyGroupBox.Header = this.HeaderText;
            }
        }
    }
}
