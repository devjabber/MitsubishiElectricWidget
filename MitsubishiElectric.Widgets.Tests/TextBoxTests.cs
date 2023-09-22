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
    public class TextBoxTests
    {
       
        [Fact]
        public void Draw_WhenCalled_CallsRenderer()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var textbox = new TextBox(mockRenderer.Object);
            textbox.BackgroundColour = "Green";
            textbox.Width = 2;
            textbox.Height = 3;
            textbox.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render(It.IsAny<string>()), Times.Once());
        }


        [Fact]
        public void Draw_WhenCalled_With_Empty_Text_ResultsIn_BackgroundColor_Red()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var textbox = new TextBox(mockRenderer.Object);
            textbox.Width = 3;
            textbox.Height = 2;
            textbox.BackgroundColour = "Blue";
            textbox.Text = "";
            textbox.XCoordinate = 0;
            textbox.YCoordinate = 1;
            textbox.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render($"{Shape.TextBox.ToString()} Size: 6 Height: 2 Width: 3 Position: (x:0, y:1) " +
                $"Background Colour: Red Text Content: "), Times.Once());
        }

        [Fact]
        public void Draw_WhenCalled_With_Text_Sets_BackgroundColor()
        {
            // Arrange
            var mockRenderer = new Mock<IRenderer>();
            var textbox = new TextBox(mockRenderer.Object);
            textbox.Width = 3;
            textbox.Height = 2;
            textbox.BackgroundColour = "Blue";
            textbox.Text = "Test";
            textbox.XCoordinate = 0;
            textbox.YCoordinate = 1;
            textbox.Draw();

            // Act
            // Assert
            mockRenderer.Verify(x => x.Render($"{Shape.TextBox.ToString()} Size: 6 Height: 2 Width: 3 Position: (x:0, y:1) " +
                $"Background Colour: Blue Text Content: Test"), Times.Once());
        }
    }
}
