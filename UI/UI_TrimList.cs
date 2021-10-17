using System;
using System.Collections.Generic;
using SpaceVIL;

namespace TrimCalc.UI
{
    public class UI_TrimList
    {
        public List<UI_GroupID> Groups = new List<UI_GroupID>();

        private ButtonCore _addButton;
        private ListBox _trimList;
        private UI_TrimGroup _trimGroupHandler;
        
        // Generate Layout
        public void Init(HorizontalSplitArea parent, UI_TrimGroup trimGroupHandler)
        {
            _trimGroupHandler = trimGroupHandler;
            
            var mainLayout = new VerticalStack();
            parent.AssignTopItem(mainLayout);
            
            // Header Layout
            var header = new HorizontalStack();
            header.SetStyle(Look.BarStyle());
            mainLayout.AddItem(header);

            // Header Button
            var headerText = new Label("Trims: ");
            headerText.SetStyle(Look.SettingsLabelStyle());
            header.AddItem(headerText);
            
            // Generate Layout
            var listLayout = new ListBox();

            _trimList = listLayout;
            listLayout.SetStyle(Look.ListStyle());
            mainLayout.AddItem(listLayout);

            // Create Add Button
            var addButton = new ButtonCore("Add Trim");
            addButton.SetStyle(Look.ListItemStyle());
            _addButton = addButton;
            _addButton.EventMouseClick = (sender, args) =>
            {
                UpdateList(true);
            };

            _trimList.AddItem(addButton);
        }
        
        private void UpdateList(bool addItem)
        {
            if (addItem)
            {
                // Create New Trim
                var newItemName = "New Trim " + Groups.Count;
                var item = new UI_GroupID(_trimList, newItemName, true);

                _trimList.AddItem(item.Item);
                item.InitItem();
            
                item.ItemClickZone.EventMousePress = (sender, args) =>
                {
                    _trimGroupHandler.ActiveGroup = item;
                    _trimGroupHandler.UpdateGroup(item);
                };
            
                item.RemoveButton.EventMouseClick = (sender, args) =>
                {
                    _trimGroupHandler.RemoveGroup();
                    Groups.Remove(item);
                    item.GroupContent.Clear();
                    _trimList.RemoveItem(item.Item);
                    UpdateList(false);
                };
                Groups.Add(item);
            }

            else
            {
                foreach (var group in Groups)
                {
                    _trimList.AddItem(group.Item);
                    group.InitItem();
                    
                    group.ItemClickZone.EventMousePress = (sender, args) =>
                    {
                        _trimGroupHandler.ActiveGroup = group;
                        _trimGroupHandler.UpdateGroup(group);
                    };
            
                    group.RemoveButton.EventMouseClick = (sender, args) =>
                    {
                        _trimGroupHandler.RemoveGroup();
                        Groups.Remove(group);
                        group.GroupContent.Clear();
                        _trimList.RemoveItem(group.Item);
                        UpdateList(false);
                    };
                }
            }
            
            // Update AddButton Position
            _trimList.RemoveItem(_addButton);
            _trimList.AddItem(_addButton);
            
            // Update Button Event
            _addButton.EventMouseClick = (sender, args) =>
            {
                UpdateList(true);
            };
        }
    }
}
