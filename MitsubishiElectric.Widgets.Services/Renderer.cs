using MitsubishiElectric.Widgets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitsubishiElectric.Widgets.Services
{
    public class Renderer : IRenderer
    {
        public void Render(string toRender)
        {
            Console.WriteLine(toRender);
        }
    }
}
