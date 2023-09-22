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
    public class SquareTests
    {
        [Fact]
        public void CalculateSize_WhenCalled_ReturnsArea()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var square = new Square(mockRenderer.Object);
            square.Side = 5;
            decimal expected = 25;

            // Act
            var actual = square.CalculateSize();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Draw_WhenCalled_CallsRenderer()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var square = new Square(mockRenderer.Object);
            square.Side = 5;
            square.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render(It.IsAny<string>()), Times.Once());
        }

        
        [Fact]
        public void Draw_WhenCalled_CallsRenderer_With_RenderResponse()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var square = new Square(mockRenderer.Object);
            square.Side = 5;
            square.XCoordinate = 0;
            square.YCoordinate = 1;
            square.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render($"{Shape.Square.ToString()} Size: 25 Position: (x:0, y:1)"), Times.Once());
        }
    }
}
