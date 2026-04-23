using System.Net.WebSockets;

namespace Quick.UrlClient.WebSocket;

public class WebSocketUrlClient : IUrlClient
{
    public static void Register()
    {
        UrlClientFactory.RegisterScheme("ws", t => new WebSocketUrlClient(t));
        UrlClientFactory.RegisterScheme("wss", t => new WebSocketUrlClient(t));
    }

    private WebSocketUrlClientOptions options;
    private ClientWebSocket client;

    public string Url => options.Url;

    public WebSocketUrlClient(WebSocketUrlClientOptions options)
    {
        this.options = options;
        client = new();
    }

    public WebSocketUrlClient(string url) : this(new WebSocketUrlClientOptions(url)) { }

    public void Open() => client.ConnectAsync(options.Uri, CancellationToken.None).Wait();
    public Task OpenAsync(CancellationToken cancellationToken) => client.ConnectAsync(options.Uri, cancellationToken);
    public Stream GetStream() => WebSocketStream.Create(client, WebSocketMessageType.Binary, false);
    public void Close() => client.CloseAsync(WebSocketCloseStatus.NormalClosure, nameof(WebSocketCloseStatus.NormalClosure), CancellationToken.None).Wait();
    public void Dispose() => client.Dispose();
}
