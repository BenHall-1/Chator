using Microsoft.AspNetCore.Components;

namespace Chator.Client.Pages
{
    /// <summary>
    /// The backend logic for the Server Page.
    /// </summary>
    public class ServerPageBase : ComponentBase
    {
        /// <summary>
        /// Gets or sets the current Server ID.
        /// </summary>
        [Parameter]
        public string Serverid { get; set; }

        /// <summary>
        /// Gets or sets the current Channel ID.
        /// </summary>
        [Parameter]
        public string Channelid { get; set; }
    }
}
