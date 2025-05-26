using Microsoft.AspNetCore.SignalR;
using MS.SignalRRealTimeApi.Services.SignalRCommentServices;

namespace MS.SignalRRealTimeApi.Hubs;

public class SignalRHub : Hub
{
    private readonly ISignalRCommentServices _signalRCommentServices;

    public SignalRHub(ISignalRCommentServices signalRCommentServices)
    {
        _signalRCommentServices = signalRCommentServices;
    }

    public async Task SendStatisticCount()
    {
        var getTotalCommentCount = await _signalRCommentServices.GetTotalCommentCount();
        await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
    }
}
