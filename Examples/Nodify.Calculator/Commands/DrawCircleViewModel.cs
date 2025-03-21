using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodify.Calculator.Commands
{
    public class DrawCircleViewModel : OperationViewModel
    {
        public int Radius { get; set; } = 0;

        public DrawCircleViewModel()
        {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
        }
    }
}
