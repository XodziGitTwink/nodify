using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodify.Calculator.Commands
{
    public class MouseMoveViewModel : OperationViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Click { get; set; }

        public MouseMoveViewModel()
        {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
        }
    }
}
