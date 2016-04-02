﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace X.Viewer.SketchFlow
{
    public sealed partial class SketchView : UserControl, IDisposable
    {
        IContentRenderer _renderer;
        Sketch vm;

        public SketchView(IContentRenderer renderer)
        {
            this.InitializeComponent();

            vm = new Sketch();
            this.DataContext = vm;
            
            _renderer = renderer;

            InitDemo();
        }

        private void InitDemo() {
            var pg = new SketchPage() { Width = 360, Height = 640, Top = 100, Left = 100 };
            pg.Layers.Add(new PageLayer());
            var nc = new Controls.PageLayout() { DataContext = pg, Width = pg.Width, Height = pg.Height };
            nc.SetValue(Canvas.LeftProperty, pg.Left);
            nc.SetValue(Canvas.TopProperty, pg.Top);
            cvMain.Children.Add(nc);
            vm.Pages.Add(pg);

            pg = new SketchPage() { Width = 360, Height = 640, Top = 100, Left = 560 };
            pg.Layers.Add(new PageLayer());
            pg.Layers.Add(new PageLayer());
            pg.Layers.Add(new PageLayer());
            nc = new Controls.PageLayout() { DataContext = pg, Width = pg.Width, Height = pg.Height };
            nc.SetValue(Canvas.LeftProperty, pg.Left);
            nc.SetValue(Canvas.TopProperty, pg.Top);
            cvMain.Children.Add(nc);
            vm.Pages.Add(pg);

            pg = new SketchPage() { Width = 360, Height = 640, Top = 100, Left = 1020 };
            pg.Layers.Add(new PageLayer());
            pg.Layers.Add(new PageLayer());
            nc = new Controls.PageLayout() { DataContext = pg, Width = pg.Width, Height = pg.Height };
            nc.SetValue(Canvas.LeftProperty, pg.Left);
            nc.SetValue(Canvas.TopProperty, pg.Top);
            cvMain.Children.Add(nc);
            vm.Pages.Add(pg);

            vm.Pages[1].Layers[0].XamlFragments.Add(@"<Rectangle HorizontalAlignment=""Stretch"" VerticalAlignment=""Stretch"" Fill=""Black""></Rectangle>");
            vm.Pages[1].ExternalPC("Layers");
        }

        public void Dispose()
        {
            _renderer = null;
        }

        private void toolbar_PerformAction(object sender, EventArgs e)
        {
            var actionToPerform = (string)sender;
            _renderer.SendMessageThru(null, new ContentViewEventArgs() { Type = actionToPerform });
        }

        private void layoutRoot_PointerWheelChanged(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            //var delta = 25;
            var change = e.GetCurrentPoint(null).Properties.MouseWheelDelta;
            var ct = cvMain.RenderTransform as CompositeTransform;
            
            if (change > 0)
            {
                ct.ScaleX += -0.05;
                ct.ScaleY += -0.05;
                if (ct.ScaleX <= 0.3) ct.ScaleX = 0.3;
                if (ct.ScaleY <= 0.3) ct.ScaleY = 0.3;
            }
            else if (change < 0)
            {
                ct.ScaleX += 0.05;
                ct.ScaleY += 0.05;
                if (ct.ScaleX >= 2.0) ct.ScaleX = 2.0;
                if (ct.ScaleY >= 2.0) ct.ScaleY = 2.0;
            }
        }
    }


}
