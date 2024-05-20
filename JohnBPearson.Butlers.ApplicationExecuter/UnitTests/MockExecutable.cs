using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;

namespace UnitTests
{
    internal class MockExecutable : JohnBPearson.Butlers.QuickLaunchCore.IExecutable
    {
        private string _fullPath = @"S:\source\repos\QuickLaunch\JohnBPearson.Wpf.QuickLaunch\JohnBPearson.Butlers.ApplicationExecuter\UnitTests\butler.ico";
        public string FullPath
        {
            get
            {
                return _fullPath;
            }
            private set
            {
                _fullPath = value;
            }
        }
        private string _name = string.Empty;
        public string Name
        {
            get
            {
                return "test";
            }
        }

        private string _extension = string.Empty;
        public string Extension
        {
            get
            {
                return ".exe";
            }
            private set
            {
                if(value != _extension && !string.IsNullOrEmpty(value))
                {
                    _extension = value;
                }
            }
        }


        private Icon _icon;
        public Icon Icon
        {
            get
            {
                return new Icon(this._fullPath);
            }
            private set
            {
                if(value != null)
                {

                    _icon = value;
                }
            }
        }

        private Extension _type;

        public Extension Type
        {
            get
            {
                return _type;
            }
        }


        //  todo add validation patterns


       

        public void Run()
        {
          //  throw new NotImplementedException();
        }
    }
}
