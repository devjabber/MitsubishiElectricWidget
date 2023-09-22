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
    public class TextBox : Rectangle
    {
        private readonly IRenderer _renderer;
        private string _backgroundColour;

        public TextBox(IRenderer renderer) : base(renderer)
        {
            _renderer = renderer;
            this.Name = Shape.TextBox.ToString();
        }

        [Required]
        [WidgetParam]
        public string BackgroundColour
        {
            get => string.IsNullOrWhiteSpace(this.Text) ? "Red" : _backgroundColour;
            set => _backgroundColour = value;
        }

        [WidgetParam]
        public string Text { get; set; }

        public override void Draw()
        {
            _renderer.Render($"{Shape.TextBox.ToString()} Size: {this.CalculateSize()} Height: {this.Height} Width: {this.Width} Position: (x:{this.XCoordinate}, y:{this.YCoordinate}) " +
                $"Background Colour: {this.BackgroundColour} Text Content: {this.Text}");
        }
    }
}
