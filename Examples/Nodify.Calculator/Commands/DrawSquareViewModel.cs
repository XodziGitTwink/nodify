using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodify.Calculator.Commands
{
    internal class DrawSquareViewModel : OperationViewModel
    {
        public int Diameter {  get; set; }

        public DrawSquareViewModel() {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
        }
    }
}
