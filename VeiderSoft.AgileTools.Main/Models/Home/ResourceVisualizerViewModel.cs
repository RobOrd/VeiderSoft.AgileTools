using CODE.Framework.Wpf.Controls;
using CODE.Framework.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using VeiderSoft.AgileTools.Main.Models.Home.Classes;

namespace VeiderSoft.AgileTools.Main.Models.Home
{
    public class ResourceVisualizerViewModel : ViewModel
    {
        private string filterText;
        private IconWrapper selectedItem;
        private List<IconWrapper> items;

        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                if (value == filterText) return;
                filterText = value;
                NotifyChanged("FilterText");

                if(this.Items != null) this.Items.Refresh();
            }
        }
        public IconWrapper SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value == selectedItem) return;
                selectedItem = value;
                NotifyChanged("SelectedItem");

                this.CopyCommand.InvalidateCanExecute();
            }
        }
        public ICollectionView Items { get; set; }

        public ViewAction CopyCommand { get; private set; }
        public ViewAction DropedElementDetectedCommand { get; private set; }

        public ResourceVisualizerViewModel()
        {
            CopyCommand = new ViewAction("Copy", execute: (a, o) => Copy(), canExecute: (a, o) => { return this.SelectedItem != null; }, brushResourceKey: "CODE.Framework-Icon-Copy");
            this.DropedElementDetectedCommand = new ViewAction(execute: (a, o) => { DropedElementDetected(o); });

            Actions.Add(CopyCommand);
            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true));

            this.SelectedItem = null;
            this.FilterText = string.Empty;
            this.items = new List<IconWrapper>();
            this.Items = CollectionViewSource.GetDefaultView(this.items);
            this.Items.Filter = ApplyFilter;
        }

        private void Copy()
        {
            Clipboard.SetText(this.SelectedItem.Name);
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
            var d = LoadRDFromFile(file.FullName);
            LoadIconsFromResource(d);
        }
        private ResourceDictionary LoadRDFromFile(string filePath)
        {
            try
            {
                return new ResourceDictionary()
                {
                    Source = new Uri(filePath, UriKind.Absolute)
                };
            }
            catch(Exception ex)
            {
                Controller.Message("Resources can't be loaded");
            }

            return null;
        }
        private void LoadIconsFromResource(ResourceDictionary dictionary)
        {
            var list = new List<IconWrapper>();
            var keys = new List<string>();

            foreach (var key in dictionary.Keys)
                keys.Add(key.ToString());

            foreach (string key in keys.OrderBy(k => k))
                if (dictionary[key] is Brush)
                    list.Add(new IconWrapper { Name = key, Dictionary = dictionary });

            this.items.Clear();
            this.items.AddRange(list);
            this.Items.Refresh();
        }

        private bool ApplyFilter(object o)
        {
            var item = o as IconWrapper;
            if (o != null)
                return item.Name.ToUpper().Contains(this.FilterText.Trim().ToUpper());

            return false;   
        }
    }
}
