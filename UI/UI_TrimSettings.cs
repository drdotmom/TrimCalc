using SpaceVIL;
using SpaceVIL.Core;

namespace TrimCalc.UI
{
    public class UI_TrimSettings
    {
        public UI_TrimSettings(HorizontalSplitArea parent)
        {
            // Main Layout
            var layout = new VerticalStack();
            parent.AssignBottomItem(layout);
            
            // Label
            var label = new Label("Trim Settings:");
            label.SetStyle(Look.SettingsLabelStyle());
            layout.AddItem(label);
            
            // Set Padding
            var padding = new Label("Padding: 16");
            padding.SetStyle(Look.SettingsLabelStyle());
            layout.AddItem(padding);
            
            // Set Size
            var size = new Label("Size: 1024");
            size.SetStyle(Look.SettingsLabelStyle());
            layout.AddItem(size);
        }
    }
}
