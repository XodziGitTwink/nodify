using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nodify.Calculator.Commands
{
    internal class ScreenShotCommandViewModel : OperationViewModel
    {
        public ScreenShotCommandViewModel()
        {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
        }
    }
}
