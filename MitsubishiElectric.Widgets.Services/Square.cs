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
    public class Square : Widget, ISize
    {
        private readonly IRenderer _renderer;

        public Square(IRenderer renderer)
        {
            _renderer = renderer;
            this.Name = Shape.Square.ToString();
        }

        [Range(0.001, Double.MaxValue, ErrorMessage = _widgetParamErrorMessage)]
        [WidgetParam]        
        public decimal Side { get; set; }

        public decimal CalculateSize()
        {
            return Math.Round(this.Side * this.Side, 3);
        }

        public override void Draw()
        {
            _renderer.Render($"{Shape.Square.ToString()} Size: {this.CalculateSize()} Position: (x:{this.XCoordinate}, y:{this.YCoordinate})");
        }
    }
}
