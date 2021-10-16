using System;
using System.Collections.Generic;
using SpaceVIL;

namespace TrimCalc.UI
{
    public class DragNDropHandler
    {
        public List<string> Dropped = new List<string>();
        
        public DragNDropHandler(ActiveWindow window)
        {
            window.EventDrop = (item, args) =>
            {
                var Dropped = args.Paths;
                Console.WriteLine(args.Count);
                foreach (var f in Dropped)
                {
                    Console.WriteLine(f);
                }
            };
        }
    }
}
