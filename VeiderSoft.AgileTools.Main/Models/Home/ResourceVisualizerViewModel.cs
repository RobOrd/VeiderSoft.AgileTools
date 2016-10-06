using CODE.Framework.Wpf.Controls;
using CODE.Framework.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace VeiderSoft.AgileTools.Main.Models.Home
{
    public class IconWrapper
    {
        public string Name { get; set; }
        public ResourceDictionary Dictionary { get; set; }

        public Brush Icon
        {
            get { return (Brush)Dictionary[Name]; }
        }
    }


    public class ResourceVisualizerViewModel : ViewModel
    {
        private ObservableCollection<IconWrapper> items;
        public ObservableCollection<IconWrapper> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                NotifyChanged("Items");
            }
        }

        public ViewAction DropedElementDetectedCommand { get; private set; }

        public ResourceVisualizerViewModel()
        {
            this.DropedElementDetectedCommand = new ViewAction(execute: (a, o) => { DropedElementDetected(o); });

            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true));

            this.Items = new ObservableCollection<IconWrapper>();
        }

        private void DropedElementDetected(object o)
        {
            var isCorrect = true;
            var ecp = o as EventCommandParameters;
            var e = ecp.EventArgs as DragEventArgs;
            FileInfo info = null;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true) == true)
            {
                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                foreach (string filename in filenames)
                {
                    if (File.Exists(filename) == false)
                    {
                        isCorrect = false;
                        break;
                    }
                    info = new FileInfo(filename);
                    if (info.Extension != ".xaml")
                    {
                        isCorrect = false;
                        break;
                    }
                }

                if (isCorrect == true)
                    e.Effects = DragDropEffects.All;
                else
                    e.Effects = DragDropEffects.None;
                e.Handled = true;
            }

            if (isCorrect)
                LoadResources(info);
            else
                Controller.Status("El archivo debe tener la extensión .xaml");
        }
        private void LoadResources(FileInfo file)
        {
            LoadRDFromFile(file.FullName);
            LoadIconsFromResource();
        }

        private void LoadRDFromFile(string filePath)
        {
            Application.Current.Resources
                .MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri(filePath, UriKind.Absolute)
                });
        }
        private void LoadIconsFromResource()
        {
            var list = new List<IconWrapper>();
            var keys = new List<string>();
            foreach (var key in Application.Current.Resources.MergedDictionaries[2].Keys)
                keys.Add(key.ToString());

            foreach (string key in keys.OrderBy(k => k))
                if (Application.Current.Resources.MergedDictionaries[2][key] is Brush)
                    list.Add(new IconWrapper { Name = key, Dictionary = Application.Current.Resources.MergedDictionaries[2] });

            this.Items.AddRange(list);
        }
    }
}
