# Quick.UrlClient

Quick.UrlClient库的WebSocket实现

URL示例： ws://127.0.0.1:3000/ws/qp


使用示例
--------
```
using Quick.UrlClient;
using Quick.UrlClient.WebSocket;

//注册要使用的URL架构
WebSocketUrlClient.Register();

var url = "ws://127.0.0.1:3000/ws/qp";
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