using System;
using System.Collections.Generic;
using SpaceVIL;

namespace TrimCalc.UI
{
    public class UI_TrimStack
    {
        public Dictionary<int, TextEdit> Trims = new Dictionary<int, TextEdit>();

        private ButtonCore _addButton;
        private ListBox _trimList;

        public UI_TrimStack(HorizontalSplitArea parent)
        {
            var mainLayout = new VerticalStack();
            parent.AssignTopItem(mainLayout);

            var header = new HorizontalStack();
            header.SetStyle(Look.BarStyle());
            mainLayout.AddItem(header);

            // Header Buttons
            var buttonAdd = new ButtonCore("Add");
            buttonAdd.SetStyle(Look.ButtonStyle(header.GetWidth() / 4));

            var buttonDel = new ButtonCore("Del");
            buttonDel.SetStyle(Look.ButtonStyle(header.GetWidth() / 4));

            var buttonUp = new ButtonCore("Up");
            buttonUp.SetStyle(Look.ButtonStyle(header.GetWidth() / 4));

            var buttonDown = new ButtonCore("Dw");
            buttonDown.SetStyle(Look.ButtonStyle(header.GetWidth() / 4));

            header.AddItem(buttonAdd);
            header.AddItem(buttonDel);
            header.AddItem(buttonUp);
            header.AddItem(buttonDown);

            // List
            var listLayout = new ListBox();
            _trimList = listLayout;
            listLayout.SetStyle(Look.ListStyle());
            mainLayout.AddItem(listLayout);

            var addButton = CreateButton("Add Trim");
            _addButton = addButton;
            _addButton.EventMouseClick = (sender, args) =>
            {
                AddNewItem();
            };

        listLayout.AddItem(addButton);
            
        }

        private ButtonCore CreateButton(string name)
        {
            var btn = new ButtonCore(name);
            btn.SetStyle(Look.ListItemStyle());

            return btn;
        }
        
        private TextEdit CreateTrim(string name)
        {
            var btn = new TextEdit(name);
            btn.EventMouseDoubleClick = (sender, args) =>
            {
                
            };
            btn.SetStyle(Look.ListItemStyle());

            return btn;
        }
        
        private void AddNewItem()
        {
            var btn = CreateTrim("New Trim " + Trims.Count.ToString());
            btn.SetStyle(Look.ListItemStyle());
            
            _trimList.AddItem(btn);
            Trims.Add(Trims.Count, btn);
            
            _trimList.RemoveItem(_addButton);
            _trimList.AddItem(_addButton);
            
            _addButton.EventMouseClick = (sender, args) =>
            {
                AddNewItem();
            };
        }
    }
}
