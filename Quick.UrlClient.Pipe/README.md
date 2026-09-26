# Quick.UrlClient

Quick.UrlClient库的命名管道实现

URL示例： pipe://./PipeName

参数说明
--------
- ConnectTimeout: 连接超时, 单位: 毫秒
- WriteTimeout: 写入超时, 单位: 毫秒
- ReadTimeout: 读取超时, 单位: 毫秒
- Direction: 方向, In=进,Out=出,InOut=进出
- Options: 管道参数, Asynchronous=异步读取和写入,WriteThrough=指示系统应跳过中间缓存直接写入管道,None=指示没有其他参数,CurrentUserOnly=仅当前用户
- ReadMode: 读取模式, Byte=字节,Message=消息(仅Windows)

使用示例
--------
```
using Quick.UrlClient;
using Quick.UrlClient.Pipe;

//注册要使用的URL架构
PipeUrlClient.Register();

var url = "pipe://./PipeName";
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