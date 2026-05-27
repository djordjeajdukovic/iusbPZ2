using System.Collections.ObjectModel;
using NetworkService.Commands;

namespace NetworkService.ViewModel
{
    public class MeasurementGraphViewModel : BindableBase
    {
        public ObservableCollection<string> EntityNames { get; set; }

        public MeasurementGraphViewModel()
        {
            EntityNames = new ObservableCollection<string>
            {
                "1 - Ventil A1",
                "2 - Ventil B2",
                "3 - Ventil C3"
            };
        }
    }
}
