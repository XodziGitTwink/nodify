using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodify.Calculator.Commands
{
    public class OpenSiteViewModel : OperationViewModel
    {
        public string Url { get; set; }
        public OpenSiteViewModel()
        {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
        }
    }
}
