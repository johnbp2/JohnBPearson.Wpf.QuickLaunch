using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quicklaunch.Views;

namespace Quicklaunch.Controls
{
    [ToolboxItem(true)]
   public class QuicklaunchUserControlBase : System.Windows.Controls.UserControl
    {
        public QuicklaunchUserControlBase() : base()
        {
            // Initialize the control
        }
        private static Views.SettingsPresenter _settingsPresenter = new SettingsPresenter();

        internal static SettingsPresenter Settings
        {
            get
            {
                return _settingsPresenter;
            }

        }

    }
}
