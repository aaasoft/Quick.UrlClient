# Quick.UrlClient

一个通用根据URL得到连接客户端的库，支持TCP，命名管道、串口和WebSocket。

URL示例
--------
 - TCP： tcp://127.0.0.1:3000
 - 命名管道： pipe://pipeName
 - 串口： serial://./COM1?BaudRate=9600
 - WebSocket： ws://127.0.0.1:3000/ws/qp

使用示例
--------
```
using Quick.UrlClient;
using Quick.UrlClient.Pipe;
using Quick.UrlClient.SerialPort;
using Quick.UrlClient.Tcp;

//注册要使用的URL架构
TcpUrlClient.Register();
SerialPortUrlClient.Register();
PipeUrlClient.Register();

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
```