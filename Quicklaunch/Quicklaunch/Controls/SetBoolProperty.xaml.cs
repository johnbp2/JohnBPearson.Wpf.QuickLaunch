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
namespace Quicklaunch.Controls
{
    /// <summary>
    /// Interaction logic for SetBoolProperty.xaml
    /// </summary>
    public partial class SetBoolProperty : System.Windows.Controls.UserControl
    {
        private Views.SettingsPresenter _settingsPresenter = new SettingsPresenter();





        //private T propertyHost;

        //public <T> PropertyHost
        //{
        //    get { return propertyHost; }
        //    set { propertyHost = value; }
        //}

        private string _path = string.Empty;
        private object _header = "";

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

        [System.ComponentModel.Category("Custom Properties")]
        [System.ComponentModel.Description("The header text for the property group box.")]
        [System.ComponentModel.Browsable(true)]
        public System.Windows.Controls.GroupBox groupBox
        {
            get { return this.propertyGroupBox; }
    
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
            this._path = path;
            this._header = header;
            InitializeComponent();
        }

        private void SetBoolProp_Initialized(object sender, EventArgs e)
        {
           if(!string.IsNullOrWhiteSpace(_path)) {
                Bind(_path , _header);
            }
        }


        public void Bind(string path, object header) {
           this.propertyGroupBox.Header = header;
            this.DataContext = _settingsPresenter;
            DataBind.Binding data = new DataBind.Binding();            //    throw new NullReferenceException();
            if (!string.IsNullOrEmpty(path))
            {

                data.Source = _settingsPresenter;

                data.Path = new PropertyPath(path);
                data.Mode = DataBind.BindingMode.TwoWay;
                checkBox1.SetBinding(System.Windows.Controls.CheckBox.IsCheckedProperty, data);
            }
            else
            {
                throw new Exception("path myst be set to a valid property name of the SettingsPresenter class.");
            }
        }

    }
}
