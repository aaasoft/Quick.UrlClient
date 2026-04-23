namespace Quick.UrlClient.Tcp;

public class TcpUrlClientOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public int? SendTimeout { get; set; }
    public int? ReceiveTimeout { get; set; }
    public int? SendBufferSize { get; set; }
    public int? ReceiveBufferSize { get; set; }

    public TcpUrlClientOptions() { }
    public TcpUrlClientOptions(Uri uri)
    {
        Host = uri.Host;
        Port = uri.Port;
        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
        foreach (var key in query.AllKeys)
        {
            var v = query.Get(key);
            switch (key)
            {
                case nameof(SendTimeout):
                    SendTimeout = int.Parse(v);
                    break;
                case nameof(SendBufferSize):
                    SendBufferSize = int.Parse(v);
                    break;
                case nameof(ReceiveTimeout):
                    ReceiveTimeout = int.Parse(v);
                    break;
                case nameof(ReceiveBufferSize):
                    ReceiveBufferSize = int.Parse(v);
                    break;
            }
        }
    }
}
