using System.IO.Pipes;
using Quick.UrlClient;

namespace Quick.UrlClient.Pipe;

public class PipeUrlClient : IUrlClient
{
    public static void Register() => UrlClientFactory.RegisterScheme("pipe", t => new PipeUrlClient(t));

    private PipeUrlClientOptions options;
    private NamedPipeClientStream pipeClient;

    public PipeUrlClient(PipeUrlClientOptions options)
    {
        this.options = options;
        pipeClient = new(options.ServerName, options.PipeName, Enum.Parse<PipeDirection>(options.Direction), Enum.Parse<PipeOptions>(options.Options))
        {
            ReadMode = Enum.Parse<PipeTransmissionMode>(options.ReadMode),
        };
        if (options.ReadTimeout.HasValue)
            pipeClient.ReadTimeout = options.ReadTimeout.Value;
        if (options.WriteTimeout.HasValue)
            pipeClient.WriteTimeout = options.WriteTimeout.Value;
    }

    public PipeUrlClient(Uri uri) : this(new PipeUrlClientOptions(uri))
    {
    }

    public void Open() => pipeClient.Connect(options.ConnectTimeout);
    public Task OpenAsync(CancellationToken cancellationToken) => pipeClient.ConnectAsync(options.ConnectTimeout, cancellationToken);
    public Stream GetStream() => pipeClient;
    public void Close() => pipeClient.Close();
    public void Dispose() => pipeClient.Dispose();
}
