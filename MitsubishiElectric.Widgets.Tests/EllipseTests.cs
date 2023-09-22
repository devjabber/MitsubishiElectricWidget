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
    public class EllipseTests
    {
        [Fact]
        public void CalculateSize_WhenCalled_ReturnsArea()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var ellipse = new Ellipse(mockRenderer.Object);
            ellipse.AxisA = 1;
            ellipse.AxisB = 1;
            decimal expected = 3.142m;

            // Act
            var actual = ellipse.CalculateSize();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Draw_WhenCalled_CallsRenderer()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var ellipse = new Ellipse(mockRenderer.Object);
            ellipse.AxisA = 1;
            ellipse.AxisB = 1;
            ellipse.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render(It.IsAny<string>()), Times.Once());
        }


        [Fact]
        public void Draw_WhenCalled_CallsRenderer_With_RenderResponse()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var ellipse = new Ellipse(mockRenderer.Object);
            ellipse.AxisA = 1;
            ellipse.AxisB = 1;
            ellipse.XCoordinate = 0;
            ellipse.YCoordinate = 1;
            ellipse.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render($"{Shape.Ellipse.ToString()} Size: 3.142 Horizontal Diameter: 1 Vertical Diameter: 1 Position: (x:0, y:1)"), Times.Once());
        }
    }
}
