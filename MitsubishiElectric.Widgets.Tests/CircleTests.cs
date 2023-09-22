using MitsubishiElectric.Widgets.Services;
using MitsubishiElectric.Widgets.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MitsubishiElectric.Widgets.Tests
{
    public class CircleTests
    {
        [Fact]
        public void CalculateSize_WhenCalled_ReturnsArea()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var circle = new Circle(mockRenderer.Object);
            circle.Radius = 1;
            decimal expected = 3.142m;

            // Act
            var actual = circle.CalculateSize();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Draw_WhenCalled_CallsRenderer()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var circle = new Circle(mockRenderer.Object);
            circle.Radius = 1;
            circle.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render(It.IsAny<string>()), Times.Once());
        }


        [Fact]
        public void Draw_WhenCalled_CallsRenderer_With_RenderResponse()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var circle = new Circle(mockRenderer.Object);
            circle.Radius = 1;
            circle.XCoordinate = 0;
            circle.YCoordinate = 1;
            circle.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render($"{Shape.Circle.ToString()} Size: 3.142 Position: (x:0, y:1)"), Times.Once());
        }
    }
}
