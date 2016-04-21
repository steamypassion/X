﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Viewer.SketchFlow
{
    public class Sketch :ViewModelBase
    {
        public ObservableCollection<SketchPage> Pages { get; set; }

        private SketchPage _SelectedPage;
        public SketchPage SelectedPage {
            get { return _SelectedPage; }
            set {
                if(_SelectedPage != null)_SelectedPage.IsSelected = false;
                _SelectedPage = value;
                RaisePropertyChanged();
                _SelectedPage.IsSelected = true;
            }
        }
        
        public Sketch() {
            Pages = new ObservableCollection<SketchPage>();
        }

        public void ExternalPC(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }
    }

    public class SketchPage : ViewModelBase
    {
        public string Title { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        private bool _IsSelected;
        public bool IsSelected { get { return _IsSelected; } set { _IsSelected = value; RaisePropertyChanged(); } }

        public ObservableCollection<PageLayer> Layers { get; set; }
        
        public SketchPage()
        {
            Layers = new ObservableCollection<PageLayer>();
        }
        public void ExternalPC(string propertyName) {
            RaisePropertyChanged(propertyName);
        }
    }

    public class PageLayer : ViewModelBase
    {
        private bool _isEnabled = true;
        public bool IsEnabled { get { return _isEnabled; } set { _isEnabled = value; RaisePropertyChanged(); } } 
        public bool HasChildContainerCanvas { get; set; } = false;
        public ObservableCollection<XamlFragment> XamlFragments { get; set; }
        
        public PageLayer() {
            XamlFragments = new ObservableCollection<XamlFragment>();
        }

        public void ExternalPC(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }
    }


    public class XamlFragment
    {
        public string Xaml { get; set; }
        public string Uid { get; set; }

        public Type Type { get; set; }
    }

}
