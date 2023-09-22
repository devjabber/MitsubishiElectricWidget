using MitsubishiElectric.Widgets.Services.Exceptions;
using MitsubishiElectric.Widgets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitsubishiElectric.Widgets.Services
{
    public class WidgetFactory : IWidgetFactory
    {
        private readonly IRenderer _renderer;

        public WidgetFactory(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public Widget CreateWidget(Shape shape)
        {
            switch (shape)
            {
                case Shape.Square:
                    return new Square(_renderer);
                case Shape.Rectangle:
                    return new Rectangle(_renderer);
                case Shape.Circle:
                    return new Circle(_renderer);
                case Shape.Ellipse:
                    return new Ellipse(_renderer);
                case Shape.TextBox:
                    return new TextBox(_renderer);
                default:
                    throw new InvalidParameterTypeException();
            }
        }
    }
}
