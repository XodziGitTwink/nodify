using Nodify.Interactivity;
using SkyUtils;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Nodify.Calculator
{
    public partial class MainWindow : Window
    {
        private ApplicationViewModel vm;
        public MainWindow(List<Command> commands)
        {
            InitializeComponent();
            this.vm = new ApplicationViewModel(commands);
            this.DataContext = this.vm;

            EditorGestures.Mappings.Editor.Cutting.Unbind();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var test = this.vm.Editors.FirstOrDefault().Calculator.Operations;
            var stop = 5;
        }
    }
}
