using SkyUtils;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Nodify.Calculator
{
    public class EditorViewModel : ObservableObject
    {
        public event Action<EditorViewModel, CalculatorViewModel>? OnOpenInnerCalculator;

        public EditorViewModel? Parent { get; set; }

        public EditorViewModel(List<Command>? commands = null)
        {
            Calculator = new CalculatorViewModel(commands);
            OpenCalculatorCommand = new DelegateCommand<CalculatorViewModel>(calculator =>
            {
                OnOpenInnerCalculator?.Invoke(this, calculator);
            });
        }

        public INodifyCommand OpenCalculatorCommand { get; }

        public Guid Id { get; } = Guid.NewGuid();

        private CalculatorViewModel _calculator = default!;
        public CalculatorViewModel Calculator 
        {
            get => _calculator;
            set => SetProperty(ref _calculator, value);
        }

        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string? _scenarionName;
        public string? ScenarioName
        {
            get => _scenarionName;
            set => SetProperty(ref _scenarionName, value);
        }

        private string? _scenarioDesc;
        public string? ScenarioDesc
        {
            get => _scenarioDesc;
            set => SetProperty(ref _scenarioDesc, value);
        }
        private string? _scenarioPhrase;
        public string? ScenarioPhrase
        {
            get => _scenarioPhrase;
            set => SetProperty(ref _scenarioPhrase, value);
        }
    }
}
