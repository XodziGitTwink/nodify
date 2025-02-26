using SkyUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Nodify.Calculator
{
    public class OperationsMenuViewModel : ObservableObject
    {
        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                SetProperty(ref _isVisible, value);
                if (!value)
                {
                    Closed?.Invoke();
                }
            }
        }

        private Point _location;
        public Point Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        public event Action? Closed;

        public void OpenAt(Point targetLocation)
        {
            Close();
            Location = targetLocation;
            IsVisible = true;
        }

        public void Close()
        {
            IsVisible = false;
        }

        public NodifyObservableCollection<OperationInfoViewModel> AvailableOperations { get; }
        public INodifyCommand CreateOperationCommand { get; }
        private readonly CalculatorViewModel _calculator;

        public OperationsMenuViewModel(CalculatorViewModel calculator, List<Command> commands)
        {
            _calculator = calculator;
            List<OperationInfoViewModel> operations = new List<OperationInfoViewModel>
            {
                new OperationInfoViewModel
                {
                    Type = OperationType.Expando,
                    MaxInput = 2,
                    Title = "Команда",
                },
                new OperationInfoViewModel
                {
                    CommandType = CommandType.ScreenShot,
                    MaxInput = 2,
                    Title = "Скриншот",
                },
            };
            foreach (var com in commands)
            {
                operations.Add(new OperationInfoViewModel
                {
                    Type = OperationType.Expando,
                    MaxInput = 2,
                    Title = com.Name,
                });
            }
            foreach (CommandType type in Enum.GetValues(typeof(CommandType)))
            {
                
            }
            //operations.AddRange(OperationFactory.GetOperationsInfo(typeof(OperationsContainer)));

            AvailableOperations = new NodifyObservableCollection<OperationInfoViewModel>(operations);
            CreateOperationCommand = new DelegateCommand<OperationInfoViewModel>(CreateOperation);
        }

        private void CreateOperation(OperationInfoViewModel operationInfo)
        {
            OperationViewModel op = OperationFactory.GetOperation(operationInfo);
            op.Location = Location;

            _calculator.Operations.Add(op);

            var pending = _calculator.PendingConnection;
            if (pending.IsVisible)
            {
                var connector = pending.Source.IsInput ? op.Output : op.Input.FirstOrDefault();
                if (connector != null && _calculator.CanCreateConnection(pending.Source, connector))
                {
                    _calculator.CreateConnection(pending.Source, connector);
                }
            }
            Close();
        }
    }
}
