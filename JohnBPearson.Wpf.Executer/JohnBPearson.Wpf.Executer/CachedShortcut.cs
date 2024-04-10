using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Butlers.QuickLaunch;

namespace JohnBPearson.Wpf.Executer
{
    internal class CachedShortcut
    {
        public System.Windows.Controls.Image Image { get; private set; }
        public IExecutable Shortcut { get; private set; }

        internal CachedShortcut(System.Windows.Controls.Image image, IExecutable shortCut)
        {
            this.Image = image;
            this.Shortcut = shortCut;
        }
    }
}
