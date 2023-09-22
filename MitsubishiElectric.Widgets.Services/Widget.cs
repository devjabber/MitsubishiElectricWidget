using MitsubishiElectric.Widgets.Services.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitsubishiElectric.Widgets.Services
{
    public abstract class Widget
    {
        public const string _widgetParamErrorMessage = "The value must be greater than zero.";
        public string Name { get; set; }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = _widgetParamErrorMessage)]
        [WidgetParam]
        public int XCoordinate { get; set; }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = _widgetParamErrorMessage)]
        [WidgetParam]
        public int YCoordinate { get; set; }

        public abstract void Draw();
    }
}
