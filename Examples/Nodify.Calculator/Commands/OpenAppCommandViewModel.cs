using SkyUtils;
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
        public List<InstalledProgram> Programms { get; set; }

        private InstalledProgramsSearcher _selectedProgram;
        public InstalledProgramsSearcher SelectedProgram
        {
            get => _selectedProgram;
            set
            {
                _selectedProgram = value;
                OnPropertyChanged(nameof(SelectedProgram));
            }
        }
        public OpenAppCommandViewModel() {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
            var result = InstalledProgramsSearcher.GetAllInstalledPrograms();
            var filtered = InstalledProgramsSearcher.GetFilteredPrograms(result, new List<string> { ".NET", "SDK", "Toolkit", "Development", "SQL", "X32", "X64", "X86", "Tools", "Tool", "Support", "Drive" });
            Programms = filtered.Select(p => new InstalledProgram
            {
                Name = p.DisplayName,
                ExecutablePath = p.DisplayIcon
            }).ToList();

        }
    }
}
