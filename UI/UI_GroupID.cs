using System;
using System.Collections.Generic;
using SpaceVIL;
using SpaceVIL.Core;

namespace TrimCalc.UI
{

    public class UI_GroupID
    {
        public bool Renamable = false;
        
        public HorizontalStack Item;
        
        public string FullPath;
        public string ItemLabel = "New TrimSet";
        public ListBox Parent;
        public Label ItemClickZone;
        public ButtonCore RemoveButton;

        public List<UI_GroupID> GroupContent = new List<UI_GroupID>();
        
        public UI_GroupID(ListBox parent, string name, bool canRename = false)
        {
            // Generate Layout
            var layout = new HorizontalStack();
            layout.SetStyle(Look.SettingsLabelStyle());
            
            Renamable = canRename;
            Item = layout;
            ItemLabel = name;
            Parent = parent;
        }

        public void InitItem(string textureName = null)
        {
            // Try load name
            if (textureName is null)
            {
                textureName = ItemLabel;
            }
            Console.WriteLine(textureName);
            
            // Create Label
            var label = new Label(textureName);
            Item.AddItem(label);
            ItemClickZone = label;
            // Create RemoveButton
            var remove = new ButtonCore("Remove");
            RemoveButton = remove;
            remove.EventMouseClick = (sender, args) =>
            {
                Parent.RemoveItem(Item);
            };
            Item.AddItem(remove);
            
            // Rename Event
            if (Renamable)
            {
                label.EventMouseDoubleClick = (sender, args) =>
                {
                    // Create TextField
                    var textField = new TextEdit(label.GetText());
                    textField.SetStyle(Look.LineInputStyle());
                    
                    // Clean Layout
                    Item.RemoveItem(label);
                    Item.RemoveItem(remove);
                    
                    // Pin TextField
                    Item.AddItem(textField);
                    
                    // TextField Enter Event
                    textField.EventKeyPress = (sender, args) =>
                    {
                        if (args.Key == KeyCode.Enter)
                        {
                            ItemLabel = textField.GetText();
                            Rebuild(textField, remove);
                        }
                    };
                };
            }
        }

        private void Rebuild(TextEdit textField, ButtonCore remove)
        {
            Item.RemoveItem(textField);
            Item.RemoveItem(remove);
            
            InitItem();
        }
    }
}
