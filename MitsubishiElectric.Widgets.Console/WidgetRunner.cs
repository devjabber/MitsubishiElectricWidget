using MitsubishiElectric.Widgets.Services.Attributes;
using MitsubishiElectric.Widgets.Services.Exceptions;
using MitsubishiElectric.Widgets.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MitsubishiElectric.Widgets.Services.Interfaces;

namespace MitsubishiElectric.Widgets.ConsoleClient
{
    public class WidgetRunner
    {
        private readonly IWidgetFactory _widgetFactory;
        private readonly ICanvas _canvas;

        public WidgetRunner(IWidgetFactory widgetFactory, ICanvas canvas)
        {
            _widgetFactory = widgetFactory;
            _canvas = canvas;
        }

        public void Run()
        {
            while (true)
            {
                Console.Write("Please enter a shape, either square/rectangle/circle/ellipse/textbox or 'x' to quit or 'v' to view widgets on canvas: ");
                var inputShape = Console.ReadLine();

                if (inputShape == "x")
                {
                    break;
                }

                if (inputShape == "v")
                {
                    this.ViewCanvas();
                    continue;
                }

                if (string.IsNullOrWhiteSpace(inputShape))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                if (!Enum.TryParse(inputShape, true, out Shape shape))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                try
                {
                    var widget = _widgetFactory.CreateWidget(shape);

                    Type type = widget.GetType();
                    PropertyInfo[] properties = type.GetProperties();

                    var widgetParamProperties = properties.Where(p => p.GetCustomAttributes(typeof(WidgetParamAttribute), true).Any());

                    foreach (var property in widgetParamProperties)
                    {
                        Console.Write($"Enter a value for parameter {property.Name}: ");
                        var value = Console.ReadLine();

                        switch (property.PropertyType)
                        {
                            case Type _ when property.PropertyType == typeof(string):
                                property.SetValue(widget, value);
                                break;
                            case Type _ when property.PropertyType == typeof(int):
                                if (int.TryParse(value, out int intValue))
                                {
                                    property.SetValue(widget, intValue);
                                }
                                else
                                {
                                    throw new InvalidParameterTypeException();
                                }
                                break;
                            case Type _ when property.PropertyType == typeof(decimal):
                                if (decimal.TryParse(value, out decimal decValue))
                                {
                                    property.SetValue(widget, decValue);
                                }
                                else
                                {
                                    throw new InvalidParameterTypeException();
                                }
                                break;
                        }
                    }

                    var validationResults = new List<ValidationResult>();
                    var validationContext = new ValidationContext(widget);

                    bool isValid = Validator.TryValidateObject(widget, validationContext, validationResults, true);

                    if (!isValid)
                    {
                        foreach (var validationResult in validationResults)
                        {
                            Console.WriteLine($"Invalid input for {validationResult.MemberNames.First()}. {validationResult.ErrorMessage}");
                        }
                        throw new InvalidParameterTypeException();
                    }
                    else
                    {
                        _canvas.AddWidget(widget);
                        Console.WriteLine("Widget added to canvas.");
                    }
                }
                catch (InvalidParameterTypeException iex)
                {
                    Console.WriteLine(iex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine(ex.Message);
                }
            }

            this.ViewCanvas(true);
        }

        private void ViewCanvas(bool onExit = false)
        {
            if (_canvas.Widgets == 0)
            {
                Console.WriteLine("No widgets added to canvas.");                
            }
            else
            {
                Console.WriteLine("Printing widgets on canvas...");
                _canvas.Print();
                Console.WriteLine("Clearing canvas...");
                _canvas.Clear();
            }

            if (onExit)
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
