namespace Quick.UrlClient.SerialPort;

public class SerialPortUrlClient : IUrlClient
{
    public static void Register() => UrlClientFactory.RegisterScheme("serial", t => new SerialPortUrlClient(t));

    private SerialPortUrlClientOptions options;
    private System.IO.Ports.SerialPort serialPort;

    public string Url => options.Url;

    public SerialPortUrlClient(SerialPortUrlClientOptions options)
    {
        this.options = options;
        serialPort = new(options.PortName,
            options.BaudRate,
            Enum.Parse<System.IO.Ports.Parity>(options.Parity),
            options.DataBits,
            Enum.Parse<System.IO.Ports.StopBits>(options.StopBits));

        if (options.WriteTimeout.HasValue)
            serialPort.WriteTimeout = options.WriteTimeout.Value;
        if (options.ReadTimeout.HasValue)
            serialPort.ReadTimeout = options.ReadTimeout.Value;
        if (options.WriteBufferSize.HasValue)
            serialPort.WriteBufferSize = options.WriteBufferSize.Value;
        if (options.ReadBufferSize.HasValue)
            serialPort.ReadBufferSize = options.ReadBufferSize.Value;
    }

    public SerialPortUrlClient(string url) : this(new SerialPortUrlClientOptions(url)) { }

    public void Open() => serialPort.Open();
    public async Task OpenAsync(CancellationToken cancellationToken) => await Task.Run(Open);
    public Stream GetStream() => serialPort.BaseStream;
    public void Close() => serialPort.Close();
    public void Dispose() => serialPort.Dispose();
}
