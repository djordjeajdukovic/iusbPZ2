using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NetworkService.Commands;

namespace NetworkService.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private BindableBase currentViewModel;
        private readonly NetworkEntitiesViewModel networkEntitiesViewModel;
        private readonly NetworkDisplayViewModel networkDisplayViewModel;
        private readonly MeasurementGraphViewModel measurementGraphViewModel;
        private int count = 3;

        public MyICommand<string> NavCommand { get; private set; }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        public MainWindowViewModel()
        {
            networkEntitiesViewModel = new NetworkEntitiesViewModel();
            networkDisplayViewModel = new NetworkDisplayViewModel();
            measurementGraphViewModel = new MeasurementGraphViewModel();

            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = networkEntitiesViewModel;

            CreateListener();
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "entities":
                    CurrentViewModel = networkEntitiesViewModel;
                    break;
                case "display":
                    CurrentViewModel = networkDisplayViewModel;
                    break;
                case "graph":
                    CurrentViewModel = measurementGraphViewModel;
                    break;
            }
        }

        private void CreateListener()
        {
            Thread listeningThread = new Thread(() =>
            {
                try
                {
                    TcpListener tcp = new TcpListener(IPAddress.Any, 25675);
                    tcp.Start();

                    while (true)
                    {
                        TcpClient tcpClient = tcp.AcceptTcpClient();
                        ThreadPool.QueueUserWorkItem(param =>
                        {
                            using (tcpClient)
                            {
                                NetworkStream stream = tcpClient.GetStream();
                                byte[] bytes = new byte[1024];
                                int i = stream.Read(bytes, 0, bytes.Length);
                                string incoming = Encoding.ASCII.GetString(bytes, 0, i);

                                if (incoming.Equals("Need object count"))
                                {
                                    byte[] data = Encoding.ASCII.GetBytes(count.ToString());
                                    stream.Write(data, 0, data.Length);
                                }
                            }
                        });
                    }
                }
                catch
                {
                    // Wireframe faza: ako je port vec zauzet, aplikacija i dalje prikazuje prototip.
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }
    }
}
