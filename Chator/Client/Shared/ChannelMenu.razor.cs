using Microsoft.AspNetCore.Components;

namespace Chator.Client.Shared
{
    public class ChannelMenuBase : ComponentBase
    {
        [CascadingParameter]
        public string Server { get; set; }

        [CascadingParameter]
        public string ActiveChannelID { get; set; }
    }
}
