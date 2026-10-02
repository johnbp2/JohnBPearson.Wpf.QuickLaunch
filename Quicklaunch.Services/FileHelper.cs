using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quicklaunch.Services
{
    public class FileHelperService :IDisposable
    {
        public event EventHandler<string> RefreshNeeded;
        private string _directoryPath;

        private FileSystemWatcher _watcher;
        public void WatchDirectory(string directoryPath)
        {
            if (!System.IO.Directory.Exists(directoryPath))
            {
                throw new ArgumentException($"The directory '{directoryPath}' does not exist.");
            }
            _watcher = new System.IO.FileSystemWatcher(directoryPath);
            _watcher.NotifyFilter = System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName | System.IO.NotifyFilters.LastWrite;
            _watcher.Changed += OnChanged;
            _watcher.Created += OnChanged;
            _watcher.Deleted += OnChanged;
            _watcher.Renamed += OnChanged;
            _watcher.IncludeSubdirectories = true;
            _watcher.Filter = "*.*"; // Watch all files
            _watcher.EnableRaisingEvents = true;
          //  Console.WriteLine($"Watching directory: {directoryPath}");
        }

        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

        private  void OnChanged(object sender, FileSystemEventArgs e)
        {
          RefreshNeeded?.Invoke(this, _directoryPath);
        }

        public void Dispose()
        {
            _watcher?.Dispose();
        }

        //private  void OnChanged(object sender, System.IO.FileSystemEventArgs e)
        //{
        //    Console.WriteLine($"File {e.ChangeType}: {e.FullPath}");
        //}

        //private  void OnRenamed(object sender, System.IO.RenamedEventArgs e)
        //{
        //    Console.WriteLine($"File Renamed: {e.OldFullPath} to {e.FullPath}");
        //}
    }
}
