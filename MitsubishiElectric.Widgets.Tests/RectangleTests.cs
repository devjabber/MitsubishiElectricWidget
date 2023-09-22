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
    public class RectangleTests
    {
        [Fact]
        public void CalculateSize_WhenCalled_ReturnsArea()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var rectangle = new Rectangle(mockRenderer.Object);
            rectangle.Width = 2;
            rectangle.Height = 3;
            decimal expected = 6;

            // Act
            var actual = rectangle.CalculateSize();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Draw_WhenCalled_CallsRenderer()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var rectangle = new Rectangle(mockRenderer.Object);
            rectangle.Width = 2;
            rectangle.Height = 3;
            rectangle.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render(It.IsAny<string>()), Times.Once());
        }

        
        [Fact]
        public void Draw_WhenCalled_CallsRenderer_With_RenderResponse()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var rectangle = new Rectangle(mockRenderer.Object);
            rectangle.Width = 3;
            rectangle.Height = 2;
            rectangle.XCoordinate = 0;
            rectangle.YCoordinate = 1;
            rectangle.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render($"{Shape.Rectangle.ToString()} Size: 6 Height: 2 Width: 3 Position: (x:0, y:1)"), Times.Once());
        }
    }
}
