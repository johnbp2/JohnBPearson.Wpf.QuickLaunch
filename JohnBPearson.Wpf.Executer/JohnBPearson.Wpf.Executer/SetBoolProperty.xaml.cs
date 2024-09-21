using System.Configuration;
using System.Windows;
using System.Windows.Controls;


namespace JohnBPearson.Wpf.Executer
{
  
    /// <summary>
    /// Interaction logic for SetBoolProperty.xaml
    /// </summary>
    public partial class SetBoolProperty : UserControl
    {
        private SettingsProperty? _property;

        public SetBoolProperty()
        {
            InitializeComponent();

        }

        public bool? Yes
        {
            get {
                //. var eval =  this.radioYes.IsChecked ?? false;
                return this.radioYes.IsChecked;
            }
        }

        private string _propertyName = "";

        public string PropertyName
        {
            get { return _propertyName; }
           private  set { _propertyName = value; }
        }


        //private object? _objectContainingMember = null;

        //public object? ObjectContainingMemeber
        //{
        //    get { return _objectContainingMember; }
        //    set { _objectContainingMember = value; }
        //}


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
            set
            {
                _caption = value;
                this.propertyGroupBox.Header = this.Caption;
            }
        }
  

        internal void Init(string PropertyName, string Caption, bool currentPropertyValue)
        {
            if (currentPropertyValue)
            {
                this.radioYes.IsChecked = true;
            }   else {   this.radioNo.IsChecked = true;
            }

                

                
                //   settings.Properties
                this._propertyName = PropertyName;
            //    this._objectContainingMember = settings;
                //    var test = this._objectContainingMember.GetType();
                //    if (test.GetProperty(PropertyName) != null)
                //    {
                //        this._propertyName = PropertyName;
                //        this._property = test.GetProperty(PropertyName);
                //        var getPropValue = new object();
                //        bool getBoolPropValue;



                //        PropertyInfo? fieldPropertyInfo = Object.GetType().GetProperties()
                //                     .FirstOrDefault(p => p.Name == PropertyName.ToLower());

                //        // also you should check if the propertyInfo is assigned, because the 
                //        // given property looks like a variable.
                //        if (fieldPropertyInfo == null)
                //            throw new Exception(string.Format("Property {0} not found", this.PropertyName.ToLower()));

                //        // you are overwriting the original businessObject
                //        var businessObjectPropValue = fieldPropertyInfo.GetValue(fieldPropertyInfo, null);

                //        // fieldPropertyInfo.SetValue(fieldPropertyInfo, replacementValue, null);
                //        this._property = fieldPropertyInfo;
                //        if (this._property != null)
                //        {
                //            var testNull = this._property.GetValue(getPropValue);
                //            if (testNull != null)
                //            {
                //                if (Boolean.TryParse(testNull.ToString(), out getBoolPropValue))
                //                {
                //                    this.PropertyValue = getBoolPropValue;
                //                    if (this.PropertyValue)
                //                    {

                //                        this.radioYes.IsChecked = true;
                //                    }
                //                    else
                //                    {
                //                        this.radioNo.IsChecked = true;
                //                    }

                //                }
                //                //                       Boolean.TryParse(GetValue().ToString(), out _propertyValue);
                //            }
                //            else
                //            {
                //                throw new ArgumentException($"{PropertyName} has a null value.");
                //            }
                //        }
                //        else
                //        {
                //            throw new ArgumentException($"Could not find {PropertyName} using reflection.");
                //        }
                //    }
                //    else
                //    {

                //        throw new ArgumentException($"{PropertyName} does not exist on object.");
                //    }
                //}
                //else
                //{
                //    throw new ArgumentNullException("Object cannot be null.");
                //}
                if (!string.IsNullOrEmpty(Caption))
                {
                    this._caption = Caption;
                }
            }
        }
      






    }
