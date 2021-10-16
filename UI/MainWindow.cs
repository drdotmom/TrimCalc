using System;
using System.Collections.Generic;
using SpaceVIL;
using SpaceVIL.Core;

namespace TrimCalc.UI
{
    public class MainWindow : ActiveWindow
    {
        public override void InitWindow()
        {
            SetParameters(nameof(MainWindow), nameof(MainWindow), 800, 600);
            SetMinSize(400, 300);
            SetBackground(32, 34, 37);

            var verticalMain = new VerticalStack();
            AddItem(verticalMain);
            
            // Top Bar
            var topBar = new HorizontalStack();
            topBar.SetStyle(Look.BarStyle());
            verticalMain.AddItem(topBar);
            
            var btn0 = new ButtonCore("Edit");
            btn0.SetStyle(Look.ButtonStyle());
            topBar.AddItem(btn0);
            
            
            // Work Area
            var workBenchLayout = new VerticalSplitArea();
            verticalMain.AddItem(workBenchLayout);
            var trimDataLayout = new HorizontalSplitArea();
            workBenchLayout.AssignLeftItem(trimDataLayout);
            
            // Layers
            var stack = new UI_TrimStack(trimDataLayout);
            // TextureSet
            
            
            // Bottom Bar
            var bottomBar = new HorizontalStack();
            bottomBar.SetStyle(Look.BarStyle());
            bottomBar.AddItem(new Label("Bottom Bar"));
            verticalMain.AddItem(bottomBar);
            
            // Drag N Drop
            
        }
    }
}
