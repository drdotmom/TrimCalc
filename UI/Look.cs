using System.Drawing;
using SpaceVIL;
using SpaceVIL.Core;
using SpaceVIL.Decorations;

namespace TrimCalc.UI
{
    public static class Look
    {
        public static Color ButtonBase = Color.FromArgb(255, 40, 40, 40);
        
        public static Color Background = Color.FromArgb(255, 50, 50, 50);
        public static Color Primary = Color.FromArgb(255, 40, 40, 57);
        public static Color Secondary = Color.FromArgb(255, 47, 47, 67);
        public static Color Foreground = Color.FromArgb(255, 255, 255, 155);
        public static Color Hover = Color.FromArgb(30, 255, 255, 255);
        public static Color Focus = Color.FromArgb(20, 180, 180, 180);
        public static Color Press = Color.FromArgb(50, 255, 255, 255);

        public static Color TextActiveColor = Color.FromArgb(255, 255, 255, 255);
        
        public static CornerRadius Corners = new CornerRadius(2);
        
        
        internal static Style BarStyle()
        {
            Style style = Style.GetHorizontalStackStyle();
            style.SetBackground(Primary.R, Primary.G, Primary.B, Primary.A);
            style.Foreground = Color.FromArgb(Foreground.R, Foreground.G, Foreground.B);
            style.BorderRadius = Corners;
            style.SetSizePolicy(SizePolicy.Expand, SizePolicy.Fixed);
            style.SetSize(128, 32);
            style.AddItemState(ItemStateType.Hovered, new ItemState(Hover));
            style.AddItemState(ItemStateType.Focused, new ItemState(Focus));

            return style;
        }
        
        internal static Style MainStyle(ActiveWindow parent)
        {
            Style style = Style.GetVerticalSplitAreaStyle();
            style.SetBackground(Background.R, Background.G, Background.B, Background.A);
            style.Foreground = Color.FromArgb(Foreground.R, Foreground.G, Foreground.B);
            style.BorderRadius = Corners;
            style.AddItemState(ItemStateType.Hovered, new ItemState(Hover));
            style.AddItemState(ItemStateType.Focused, new ItemState(Focus));
            style.SetSize(parent.GetWidth(), parent.GetHeight()-64);
            
            return style;
        }
        
        internal static Style ButtonStyle(int width = 128)
        {
            Style style = Style.GetLabelStyle();
            style.SetBackground(ButtonBase.R, ButtonBase.G, ButtonBase.B, ButtonBase.A);
            style.Foreground = Color.FromArgb(TextActiveColor.R, TextActiveColor.G, TextActiveColor.B);
            style.BorderRadius = Corners;
            style.AddItemState(ItemStateType.Hovered, new ItemState(Hover));
            //style.AddItemState(ItemStateType.Focused, new ItemState(Focus));
            style.AddItemState(ItemStateType.Pressed, new ItemState(Press));
            style.SetTextAlignment(ItemAlignment.HCenter, ItemAlignment.VCenter);
            style.SetSizePolicy(SizePolicy.Fixed, SizePolicy.Fixed);
            style.SetSize(width, 32);
            
            return style;
        }
        
        internal static Style ListStyle()
        {
            Style style = Style.GetLabelStyle();
            style.SetBackground(Background.R, Background.G, Background.B, Background.A);
            style.Foreground = Color.FromArgb(TextActiveColor.R, TextActiveColor.G, TextActiveColor.B);
            style.BorderRadius = Corners;
            style.SetSizePolicy(SizePolicy.Expand, SizePolicy.Expand);

            return style;
        }
        
        internal static Style ListItemStyle()
        {
            Style style = Style.GetLabelStyle();
            style.SetBackground(ButtonBase.R, ButtonBase.G, ButtonBase.B, ButtonBase.A);
            style.Foreground = Color.FromArgb(TextActiveColor.R, TextActiveColor.G, TextActiveColor.B);
            style.BorderRadius = Corners;
            style.AddItemState(ItemStateType.Hovered, new ItemState(Hover));
            style.AddItemState(ItemStateType.Focused, new ItemState(Focus));
            style.AddItemState(ItemStateType.Pressed, new ItemState(Press));
            style.SetTextAlignment(ItemAlignment.HCenter, ItemAlignment.VCenter);
            style.SetBorder(new Border());
            style.SetSizePolicy(SizePolicy.Expand, SizePolicy.Fixed);
            style.SetSize(128, 24);
            
            return style;
        }
        
        internal static Style SettingsLabelStyle()
        {
            Style style = Style.GetLabelStyle();
            style.SetBackground(ButtonBase.R, ButtonBase.G, ButtonBase.B, ButtonBase.A);
            style.Foreground = Color.FromArgb(TextActiveColor.R, TextActiveColor.G, TextActiveColor.B);
            style.BorderRadius = Corners;
            style.AddItemState(ItemStateType.Hovered, new ItemState(Hover));
            style.AddItemState(ItemStateType.Focused, new ItemState(Focus));
            style.AddItemState(ItemStateType.Pressed, new ItemState(Press));
            style.SetTextAlignment(ItemAlignment.HCenter, ItemAlignment.Left);
            style.SetPadding(10, 4, 0, 0);
            style.SetBorder(new Border());
            style.SetSizePolicy(SizePolicy.Expand, SizePolicy.Fixed);
            style.SetSize(128, 24);
            
            return style;
        }
        
        internal static Style LineInputStyle()
        {
            Style style = Style.GetTextLineStyle();
            style.SetBackground(255, 255, 255, 255);
            style.Foreground = Color.FromArgb(255, TextActiveColor.R, TextActiveColor.G, TextActiveColor.B);
            style.BorderRadius = Corners;
            style.SetTextAlignment(ItemAlignment.HCenter, ItemAlignment.Left);
            style.SetPadding(6, 0, 0, 0);
            style.SetSizePolicy(SizePolicy.Expand, SizePolicy.Fixed);
            style.SetSize(128, 32);
            
            return style;
        }
    }
}
