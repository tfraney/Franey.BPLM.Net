using Franey.BPUL.Net.Interfaces;

namespace ColorAnalizerCorService;

public class ColorPacket : IPacket
{
    public PrimaryColors Name { get; set; }

    public Temperature Temperature { get; set; }

    public Code Code { get; set; }
    public IPacketResponse? Response { get; set; }

    public void CreateResponse(bool successful, string message, string response, string? error = null)
    {
        Response = new ColorResponse { Successful = successful, Response = response, Error = error, Message = message };
    }
}

public class ColorResponse : IPacketResponse
{
    public string? Message { get; set; }
    public string? Error { get; set; }
    public string? Response { get; set; }
    public bool Successful { get; set; }
}