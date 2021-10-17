using System;
using System.Collections.Generic;
using SpaceVIL;
using SpaceVIL.Core;

namespace TrimCalc.UI
{
    public class MainWindow : ActiveWindow
    {
        public List<TrimGroupTexture> Trims = new List<TrimGroupTexture>();
        public TrimSheetParams Params;
        
        public override void InitWindow()
        {
            // Main Window
            SetParameters(nameof(MainWindow), "TrimSheet Builder", 800, 600);
            SetMinSize(400, 300);
            SetBackground(32, 34, 37);

            var verticalMain = new VerticalStack();
            AddItem(verticalMain);
            
            // Top Bar
            var topBar = new HorizontalStack();
            topBar.SetStyle(Look.BarStyle());
            verticalMain.AddItem(topBar);

            // Work Area
            var workBenchLayout = new VerticalSplitArea();
            verticalMain.AddItem(workBenchLayout);
            var trimDataLayout = new HorizontalSplitArea();
            workBenchLayout.AssignLeftItem(trimDataLayout);
            
            // Layers
            UI_TrimList layers = new UI_TrimList();
            
            // TextureSet Area
            var subLayout = new HorizontalSplitArea();
            trimDataLayout.AssignBottomItem(subLayout);
            
            // Tex List
            var texList = new UI_TrimGroup(this, subLayout, layers);
            texList.Init();
            
            layers.Init(trimDataLayout, texList);
            
            // TrimSet Settings
            var settings = new UI_TrimSettings(subLayout);
            
            // Bottom Bar
            var bottomBar = new HorizontalStack();
            bottomBar.SetStyle(Look.BarStyle());
            verticalMain.AddItem(bottomBar);
            var appendButton = new ButtonCore("Append");

            appendButton.EventMouseClick = (sender, args) =>
            {
                var groups = layers.Groups;

                foreach (var group in groups)
                {
                    Console.WriteLine("GROUP:");
                    foreach (var image in group.GroupContent)
                    {
                        Console.WriteLine(image.FullPath);
                    }
                }
            };
            
            bottomBar.AddItem(appendButton);
        }
    }
}
