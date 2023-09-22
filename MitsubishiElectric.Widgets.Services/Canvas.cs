using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitsubishiElectric.Widgets.Services.Interfaces;

namespace MitsubishiElectric.Widgets.Services
{
    public class Canvas : ICanvas
    {
        private readonly List<Widget> _widgets;

        public Canvas()
        {
            _widgets = new List<Widget>();
        }
        public int Widgets 
        {
            get => _widgets.Count;
        } 

        public void AddWidget(Widget widget)
        {
            _widgets.Add(widget);
        }

        public void Print()
        {
            foreach (var widget in _widgets)
            {
                widget.Draw();
            }
        }

        public void Clear()
        {
            _widgets.Clear();
        }
    }
}
