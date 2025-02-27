using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodify.Calculator.Commands
{
    class OpenAppCommandViewModel : OperationViewModel
    {
        public string Description {  get; set; }
        public OpenAppCommandViewModel() {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
        }
    }
}
