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

        private InstalledProgram _selectedProgram;
        public InstalledProgram SelectedProgram
        {
            get => _selectedProgram;
            set
            {
                _selectedProgram = value;
                OnPropertyChanged(nameof(SelectedProgram));
            }
        }
        public override string Parametr
        {
            get => _selectedProgram?.ExecutablePath;
            set
            {
                if (_selectedProgram == null)
                {
                    _selectedProgram = new InstalledProgram(); // Инициализация, если программа еще не выбрана
                }
                // Если нужно, присваиваем новый ExecutablePath
                _selectedProgram.ExecutablePath = value;
                OnPropertyChanged(nameof(Parametr)); // Вызываем обновление UI
            }
        }

        public OpenAppCommandViewModel() {
            Output = new ConnectorViewModel();
            Input.Add(new ConnectorViewModel());
            var result = InstalledProgramsSearcher.GetAllInstalledPrograms();
            var filtered = InstalledProgramsSearcher.GetFilteredPrograms(result, new List<string> { ".NET", "SDK", "Toolkit", "Development", "SQL", "X32", "X64", "X86", "Tools", "Tool", "Support", "Drive" });
            Programms = InstalledProgramsSearcher.LoadInstalledProgramsFromJson("installedPrograms.json");
        }
    }
}
