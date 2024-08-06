namespace LiveVideo.Hubs;

using Microsoft.AspNetCore.SignalR;

public class VideoHub : Hub
{
    public async Task SendVideo(string user, string videoData)
    {
        await Clients.All.SendAsync("ReceiveVideo", user, videoData);
    }
}