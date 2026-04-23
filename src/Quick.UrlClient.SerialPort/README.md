# Quick.UrlClient

Quick.UrlClient库的串口实现

URL示例： serial://./COM1?BaudRate=9600

参数说明
--------
- BaudRate: 波特率
- Parity: 奇偶校验, None=不校验,Odd=奇校验,Even=偶校验,Mark=将奇偶校验位设置为1,Space=将奇偶校验位设置为0
- DataBits: 数据位, 此属性的值范围为5到8。默认值为8。
- StopBits: 停止位, None=不使用停止位,One=使用一个停止位,Two=使用两个停止位=使用1.5个停止位
- WriteTimeout: 写入超时, 单位: 毫秒
- WriteBufferSize: 写入缓冲区大小
- ReadTimeout: 读取超时, 单位: 毫秒
- ReadBufferSize: 读取缓冲区大小

使用示例
--------
```
using Quick.UrlClient;
using Quick.UrlClient.SerialPort;

//注册要使用的URL架构
SerialPortUrlClient.Register();

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