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
    public class Rectangle : Widget, ISize
    {
        private readonly IRenderer _renderer;

        public Rectangle(IRenderer renderer)
        {
            _renderer = renderer;
            this.Name = Shape.Rectangle.ToString();
        }

        [Range(0.001, Double.MaxValue, ErrorMessage = _widgetParamErrorMessage)]
        [WidgetParam]
        public decimal Height { get; set; }

        [Range(0.001, Double.MaxValue, ErrorMessage = _widgetParamErrorMessage)]
        [WidgetParam]
        public decimal Width { get; set; }

        public decimal CalculateSize()
        {
            return Math.Round(Height * Width, 3);
        }

        public override void Draw()
        {
            _renderer.Render($"{Shape.Rectangle.ToString()} Size: {this.CalculateSize()} Height: {this.Height} Width: {this.Width} Position: (x:{this.XCoordinate}, y:{this.YCoordinate})");
        }
    }
}
