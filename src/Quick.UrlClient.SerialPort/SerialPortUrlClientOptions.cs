namespace Quick.UrlClient.SerialPort;

public class SerialPortUrlClientOptions
{
    public string PortName { get; set; }
    public int BaudRate { get; set; }
    public string Parity { get; set; } = nameof(System.IO.Ports.Parity.None);
    public int DataBits { get; set; } = 8;
    public string StopBits { get; set; } = nameof(System.IO.Ports.StopBits.One);

    public int? WriteTimeout { get; set; }
    public int? ReadTimeout { get; set; }
    public int? WriteBufferSize { get; set; }
    public int? ReadBufferSize { get; set; }
    private const string unixPortNamePrefix = "/dev";

    public SerialPortUrlClientOptions() { }
    public SerialPortUrlClientOptions(Uri uri)
    {
        PortName = uri.AbsolutePath;
        if (OperatingSystem.IsWindows())
        {
            PortName = PortName.Trim('/');
        }
        else
        {
            if (!PortName.StartsWith(unixPortNamePrefix))
                PortName = unixPortNamePrefix + PortName;
        }
        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
        foreach (var key in query.AllKeys)
        {
            var v = query.Get(key);
            switch (key)
            {
                case nameof(BaudRate):
                    BaudRate = int.Parse(v);
                    break;
                case nameof(Parity):
                    Parity = v;
                    break;
                case nameof(DataBits):
                    DataBits = int.Parse(v);
                    break;
                case nameof(StopBits):
                    StopBits = v;
                    break;
                case nameof(WriteTimeout):
                    WriteTimeout = int.Parse(v);
                    break;
                case nameof(WriteBufferSize):
                    WriteBufferSize = int.Parse(v);
                    break;
                case nameof(ReadTimeout):
                    ReadTimeout = int.Parse(v);
                    break;
                case nameof(ReadBufferSize):
                    ReadBufferSize = int.Parse(v);
                    break;
            }
        }
    }
}
