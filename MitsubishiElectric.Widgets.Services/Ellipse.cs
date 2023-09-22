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
    public class Ellipse : Widget, ISize
    {
        private readonly IRenderer _renderer;

        public Ellipse(IRenderer renderer)
        {
            _renderer = renderer;
            this.Name = Shape.Ellipse.ToString();
        }

        [Range(0.001, Double.MaxValue, ErrorMessage = _widgetParamErrorMessage)]
        [WidgetParam]
        public decimal AxisA { get; set; }

        [Range(0.001, Double.MaxValue, ErrorMessage = _widgetParamErrorMessage)]
        [WidgetParam]
        public decimal AxisB { get; set; }

        public decimal CalculateSize()
        {
            return Math.Round(((decimal)Math.PI * this.AxisA * this.AxisB), 3);
        }

        public override void Draw()
        {
            _renderer.Render($"{Shape.Ellipse.ToString()} Size: {this.CalculateSize()} Horizontal Diameter: {this.AxisA} Vertical Diameter: {this.AxisB} Position: (x:{this.XCoordinate}, y:{this.YCoordinate})");
        }
    }
}
