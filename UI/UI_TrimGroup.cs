using System.Collections.Generic;
using System.IO;
using SpaceVIL;
using SpaceVIL.Core;

namespace TrimCalc.UI
{
    public class UI_TrimGroup
    {
        public List<UI_GroupID> Group = new List<UI_GroupID>();
        public UI_GroupID? ActiveGroup = null;
        
        private ActiveWindow _window;
        private HorizontalSplitArea _parent;
        private ListBox _layout;
        private UI_TrimList _trimHandler;
        
        public UI_TrimGroup(ActiveWindow window, HorizontalSplitArea parent, UI_TrimList trimHandler)
        {
            _window = window;
            _parent = parent;
            _trimHandler = trimHandler;
            
            // Generate Layout
            var list = new ListBox();
            _layout = list;
            list.SetStyle(Look.ListStyle());
        }

        public void Init()
        {
            // Pin Layout
            _parent.AssignTopItem(_layout);
            
            // Try restore Group
            if (Group.Count > 0)
            {
                foreach (var tex in Group)
                {
                    _layout.AddItem(tex.Item);
                    tex.InitItem();
                }
            }
            
            if (ActiveGroup is not null)
            {
                // Add drop event
                _window.EventDrop = (item, args) =>
                {
                    var Dropped = args.Paths;
                    
                        foreach (var f in Dropped)
                        {
                            // Create texture from dropped
                            var name = Path.GetFileName(f);
                            var iGroup = new UI_GroupID(_layout, name);
                            iGroup.FullPath = f;
                            _layout.AddItem(iGroup.Item);
                            iGroup.InitItem();
                            // Append to active trim
                            ActiveGroup.GroupContent.Add(iGroup);
                        }
                };
                
                foreach (var content in ActiveGroup.GroupContent)
                {
                    _layout.AddItem(content.Item);
                    content.InitItem();
                }
            }
        }

        public void RemoveGroup()
        {
            foreach (var i in _layout.GetItems())
            {
                _layout.RemoveItem(i);
            }
        }

        private void LoadGroup(UI_GroupID group)
        {
            foreach (var item in group.GroupContent)
            {
                _layout.AddItem(item.Item);
                item.InitItem();
            }
        }

        public void UpdateGroup(UI_GroupID group)
        {
            RemoveGroup();
            Init();
        }
    }
}
