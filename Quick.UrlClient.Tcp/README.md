# Quick.UrlClient.Tcp

Quick.UrlClient库的TCP实现

URL示例： tcp://127.0.0.1:3000

参数说明
--------
- SendTimeout: 发送超时, 单位: 毫秒
- ReceiveTimeout: 接收超时, 单位: 毫秒
- SendBufferSize: 发送缓冲区大小
- ReceiveBufferSize: 接收缓冲区大小

使用示例
--------
```
using Quick.UrlClient;
using Quick.UrlClient.Tcp;

//注册要使用的URL架构
TcpUrlClient.Register();

var url = "tcp://127.0.0.1:3000";
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