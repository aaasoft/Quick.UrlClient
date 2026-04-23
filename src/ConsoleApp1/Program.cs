using Quick.UrlClient;
using Quick.UrlClient.Pipe;
using Quick.UrlClient.SerialPort;
using Quick.UrlClient.Tcp;

TcpUrlClient.Register();
SerialPortUrlClient.Register();
PipeUrlClient.Register();

var urlClient = UrlClientFactory.Build("serial://./COM1?BaudRate=9600");
urlClient.Open();
Console.ReadLine();
urlClient.Close();