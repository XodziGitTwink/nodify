﻿using SkyUtils;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;

namespace Nodify.Calculator
{
    public class OperationViewModel : ObservableObject
    {
        public OperationViewModel()
        {
            Input.WhenAdded(x =>
            {
                x.Operation = this;
                x.IsInput = true;
                x.PropertyChanged += OnInputValueChanged;
            })
            .WhenRemoved(x =>
            {
                x.PropertyChanged -= OnInputValueChanged;
            });
        }
        private void OnInputValueChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ConnectorViewModel.Value))
            {
                //OnInputValueChanged();
            }
        }

        private Point _location;
        public Point Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        private Size _size;
        public Size Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }

        public SkyUtils.CommandType CommandType { get; set; }

        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public bool IsReadOnly { get; set; }

        private ICommandAction? _operation;
        public ICommandAction? Operation
        {
            get => _operation;
            set => SetProperty(ref _operation, value);
        }

        private string _parametr;

        public virtual string Parametr
        {
            get => _parametr;
            set
            {
                if (_parametr != value)
                {
                    _parametr = value;
                    OnPropertyChanged(nameof(Parametr));
                }
            }
        }

        public NodifyObservableCollection<ConnectorViewModel> Input { get; } = new NodifyObservableCollection<ConnectorViewModel>();

        private ConnectorViewModel? _output;
        public ConnectorViewModel? Output
        {
            get => _output;
            set
            {
                if (SetProperty(ref _output, value) && _output != null)
                {
                    _output.Operation = this;
                }
            }
        }

        //protected virtual void OnInputValueChanged()
        //{
        //    if (Output != null && Operation != null)
        //    {
        //        try
        //        {
        //            var input = Input.Select(i => i.Value).ToArray();
        //            Output.Value = Operation?.Execute(input) ?? 0;
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}
    }
}
