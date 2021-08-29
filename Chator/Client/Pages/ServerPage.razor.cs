using Microsoft.AspNetCore.Components;

namespace Chator.Client.Pages
{
    public class ServerPageBase : ComponentBase
    {
        [Parameter]
        public string serverid { get; set; }

        [Parameter]
        public string channelid { get; set; }

    }
}
