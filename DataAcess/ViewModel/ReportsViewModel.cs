using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafeClient.BusinessLogic.Managers;
using CafeClient.Presentation.ViewModels;
using Microsoft.Win32;
using System.IO;

namespace diplom.DataAcess.ViewModel
{
    public class ReportsViewModel : INotifyPropertyChanged
    {
        private readonly ReportManager _reportManager;
        private string _selectedReport;
        private string _reportResult;

        public ReportsViewModel(ReportManager reportManager)
        {
            _reportManager = reportManager;
            GenerateReportCommand = new RelayCommand(GenerateReport);
            SaveReportCommand = new RelayCommand(SaveReport, _ => !string.IsNullOrEmpty(ReportResult));
        }

        public string SelectedReport
        {
            get => _selectedReport;
            set { _selectedReport = value; OnPropertyChanged(); }
        }

        public string ReportResult
        {
            get => _reportResult;
            set { _reportResult = value; OnPropertyChanged(); }
        }

        public ICommand GenerateReportCommand { get; }
        public ICommand SaveReportCommand { get; }

        private void GenerateReport(object obj)
        {
            switch (SelectedReport.Split(':')[1].Trim())
            {
                case "Статистика по клиентам":
                    ReportResult = _reportManager.GenerateClientsStatsReport();
                    break;
                case "Популярные товары":
                    ReportResult = _reportManager.GeneratePopularItemsReport();
                    break;
                case "Динамика заказов":
                    ReportResult = _reportManager.GenerateOrdersDynamicsReport();
                    break;
                case "Эффективность лояльности":
                    ReportResult = _reportManager.GenerateLoyaltyEfficiencyReport();
                    break;
                default:
                    ReportResult = "Выберите тип отчета.";
                    break;
            }
        }

        private void SaveReport(object obj)
        {
            var dialog = new SaveFileDialog { Filter = "Text files (*.txt)|*.txt", FileName = "report.txt" };
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, ReportResult);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
