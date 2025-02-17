using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp25
{
    class UDPClient
    {
        static void Main()
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 12345);

            string message = "Привет, сервер!";
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length, serverEP);
            Console.WriteLine("Сообщение отправлено на серверве...");

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] receiveData = udpClient.Receive(ref remoteEP);
            string response = Encoding.UTF8.GetString(receiveData);
            Console.WriteLine($"Ответ сервера: {response}");

            udpClient.Close();
        }
    }
}





