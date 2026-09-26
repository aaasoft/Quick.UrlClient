using Quick.UrlClient;
using Quick.UrlClient.Pipe;
using Quick.UrlClient.SerialPort;
using Quick.UrlClient.Tcp;
using Quick.UrlClient.WebSocket;

//注册要使用的URL架构
TcpUrlClient.Register();
SerialPortUrlClient.Register();
PipeUrlClient.Register();
WebSocketUrlClient.Register();

var url = "serial://./COM1?BaudRate=9600";
//根据URL创建客户端
using (var urlClient = UrlClientFactory.Build(url))
{
    //打开连接
    urlClient.Open();
    //得到流读写数据
    using (var stream = urlClient.GetStream())
    {
        // 读写数据
    }
    //关闭
    urlClient.Close();
}