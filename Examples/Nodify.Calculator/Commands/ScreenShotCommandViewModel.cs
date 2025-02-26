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
        private OperationViewModel InnerOutput { get; } = new OperationViewModel
        {
            Title = "Output Parameters",
            Input = { new ConnectorViewModel() },
            Location = new Point(500, 300),
            IsReadOnly = true
        };

        private CalculatorInputOperationViewModel InnerInput { get; } = new CalculatorInputOperationViewModel
        {
            Title = "Input Parameters",
            Location = new Point(300, 300),
            IsReadOnly = true
        };
    }
}
