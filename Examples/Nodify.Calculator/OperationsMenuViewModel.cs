﻿using SkyUtils;
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
            List<OperationInfoViewModel> operations = new List<OperationInfoViewModel>();
            if (commands == null || commands.Count == 0)
            {
                operations = new List<OperationInfoViewModel>
            {
                //new OperationInfoViewModel
                //{
                //    Type = OperationType.Expando,
                //    MaxInput = 2,
                //    Title = "Команда",
                //},
                new OperationInfoViewModel
                {
                    CommandType = CommandType.ScreenShot,
                    MaxInput = 2,
                    Title = "Скриншот",
                },
                new OperationInfoViewModel
                {
                    CommandType = CommandType.HideWindow,
                    MaxInput = 2,
                    Title = "Свернуть окно"
                },
                new OperationInfoViewModel
                {
                    CommandType = CommandType.OpenApp,
                    MaxInput = 2,
                    Title = "Открыть",
                    Description = "Тут нужный exe"
                },
                new OperationInfoViewModel
                {
                    CommandType = CommandType.DrawCircle,
                    MaxInput = 1,
                    Title = "Круг",
                },
                new OperationInfoViewModel
                {
                    CommandType = CommandType.MouseMove,
                    MaxInput = 1,
                    Title = "Мышь"
                },
                new OperationInfoViewModel
                {
                    CommandType = CommandType.DrawSquare,
                    MaxInput = 1,
                    Title = "Квадрат"
                },
                new OperationInfoViewModel
                { 
                    CommandType = CommandType.OpenSite,
                    MaxInput = 1,
                    Title = "Открыть сайт",
                }
            };
            }
            else
            {
                operations = new List<OperationInfoViewModel>();
                foreach (var com in commands)
                {
                    operations.Add(new OperationInfoViewModel
                    {
                        Type = OperationType.Expando,
                        MaxInput = 2,
                        Title = com.Name,
                    });
                }
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
