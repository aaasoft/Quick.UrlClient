using System.Net.Sockets;
using Quick.UrlClient;

namespace Quick.UrlClient.Tcp;

public class TcpUrlClient : IUrlClient
{
    public static void Register() => UrlClientFactory.RegisterScheme("tcp", t => new TcpUrlClient(t));

    private TcpUrlClientOptions options;
    private TcpClient tcpClient;

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

    public TcpUrlClient(Uri uri) : this(new TcpUrlClientOptions(uri))
    {
    }

    public void Open() => tcpClient.Connect(options.Host, options.Port);
    public async Task OpenAsync(CancellationToken cancellationToken) => await tcpClient.ConnectAsync(options.Host, options.Port, cancellationToken);
    public Stream GetStream() => tcpClient.GetStream();
    public void Close() => tcpClient.Close();
    public void Dispose() => tcpClient.Dispose();
}
