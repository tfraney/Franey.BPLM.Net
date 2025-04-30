namespace Franey.BPUL.Net.Interfaces;

public interface IPacket 
{
    public IPacketResponse? Response { get; set; }

    public void CreateResponse(bool successful, string message, string response, string? error = null);
}

public interface IPacketResponse
{
    string? Message { get; set; }
    string? Error { get; set; }
    string? Response { get; set; }
    bool Successful { get; set; }
}