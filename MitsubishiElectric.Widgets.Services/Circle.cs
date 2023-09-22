using MitsubishiElectric.Widgets.Services.Attributes;
using MitsubishiElectric.Widgets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitsubishiElectric.Widgets.Services
{
    public class Circle : Widget, ISize
    {
        private readonly IRenderer _renderer;

        public Circle(IRenderer renderer)
        {
            _renderer = renderer;
            this.Name = Shape.Circle.ToString();
        }

        [Range(0.001, Double.MaxValue, ErrorMessage = _widgetParamErrorMessage)]
        [WidgetParam]
        public decimal Radius { get; set; }        

        public decimal CalculateSize()
        {
            return Math.Round(((decimal)Math.PI * this.Radius * this.Radius), 3);
        }

        public override void Draw()
        {
            _renderer.Render($"{Shape.Circle.ToString()} Size: {this.CalculateSize()} Position: (x:{this.XCoordinate}, y:{this.YCoordinate})");
        }
    }
}
