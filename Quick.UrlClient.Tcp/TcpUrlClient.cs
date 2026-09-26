using System.Net.Sockets;

namespace Quick.UrlClient.Tcp;

public class TcpUrlClient : IUrlClient
{
    public static void Register() => UrlClientFactory.RegisterScheme("tcp", t => new TcpUrlClient(t));

    private TcpUrlClientOptions options;
    private TcpClient tcpClient;

    public string Url => options.Url;

    public TcpUrlClient(TcpUrlClientOptions options)
    {
        this.options = options;
        tcpClient = new();
        if (options.SendTimeout.HasValue)
            tcpClient.SendTimeout = options.SendTimeout.Value;
        if (options.ReceiveTimeout.HasValue)
            tcpClient.ReceiveTimeout = options.ReceiveTimeout.Value;
        if (options.SendBufferSize.HasValue)
            tcpClient.SendBufferSize = options.SendBufferSize.Value;
        if (options.ReceiveBufferSize.HasValue)
            tcpClient.ReceiveBufferSize = options.ReceiveBufferSize.Value;
    }

    public TcpUrlClient(string url) : this(new TcpUrlClientOptions(url)) { }

    public void Open() => tcpClient.Connect(options.Host, options.Port);
    public async Task OpenAsync(CancellationToken cancellationToken) => await tcpClient.ConnectAsync(options.Host, options.Port, cancellationToken);
    public Stream GetStream() => tcpClient.GetStream();
    public void Close() => tcpClient.Close();
    public void Dispose() => tcpClient.Dispose();
}
