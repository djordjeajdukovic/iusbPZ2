using System.Collections.ObjectModel;
using NetworkService.Commands;
using NetworkService.Model;

namespace NetworkService.ViewModel
{
    public class NetworkEntitiesViewModel : BindableBase
    {
        public ObservableCollection<NetworkEntity> Entities { get; set; }
        public ObservableCollection<string> Types { get; set; }
        public ObservableCollection<string> HistoryItems { get; set; }

        public NetworkEntitiesViewModel()
        {
            Types = new ObservableCollection<string>
            {
                "Kablovski senzor",
                "Digitalni manometar"
            };

            Entities = new ObservableCollection<NetworkEntity>
            {
                new NetworkEntity { Id = 1, Name = "Ventil A1", Type = new EntityType { Name = "Kablovski senzor" }, Value = 10.5 },
                new NetworkEntity { Id = 2, Name = "Ventil B2", Type = new EntityType { Name = "Digitalni manometar" }, Value = 13.2 },
                new NetworkEntity { Id = 3, Name = "Ventil C3", Type = new EntityType { Name = "Kablovski senzor" }, Value = 7.8 },
                new NetworkEntity { Id = 4, Name = "Ventil D4", Type = new EntityType { Name = "Digitalni manometar" }, Value = 18.1 }
            };

            HistoryItems = new ObservableCollection<string>
            {
                "10:12 - Dodavanje: Ventil A1",
                "10:14 - Dodavanje: Ventil B2",
                "10:20 - Pretraga po nazivu: Ventil",
                "10:22 - CG4 filter: samo nevalidni"
            };
        }
    }
}
