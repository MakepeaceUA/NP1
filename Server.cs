namespace ConsoleApp24
{
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    class UDPServer
    {
        static void Main()
        {
            UdpClient udpServer = new UdpClient(12345);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Сервер запущен,ожидание сообщений...");

            while (true)
            {
                byte[] receiveData = udpServer.Receive(ref remoteEP);
                string receivedMessage = Encoding.UTF8.GetString(receiveData);
                Console.WriteLine($"Получено сообщение от клиента {remoteEP}: {receivedMessage}");

                string response = "Привет, клиент!";
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                udpServer.Send(responseData, responseData.Length, remoteEP);
            }
        }
    }
}