using System.Collections.ObjectModel;
using NetworkService.Commands;

namespace NetworkService.ViewModel
{
    public class NetworkDisplayViewModel : BindableBase
    {
        public ObservableCollection<string> HistoryItems { get; set; }

        public NetworkDisplayViewModel()
        {
            HistoryItems = new ObservableCollection<string>
            {
                "10:25 - Ventil A1 prevucen na polje 1",
                "10:27 - Ventil B2 prevucen na polje 2",
                "10:29 - Veza: Ventil A1 - Ventil B2",
                "10:32 - Ventil C3 premesten na polje 6"
            };
        }
    }
}
