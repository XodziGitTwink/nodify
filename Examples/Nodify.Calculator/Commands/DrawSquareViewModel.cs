﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodify.Calculator.Commands
{
    public class DrawSquareViewModel : OperationViewModel
    {
        public int SideLength {  get; set; }

        public DrawSquareViewModel() {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
        }
    }
}
