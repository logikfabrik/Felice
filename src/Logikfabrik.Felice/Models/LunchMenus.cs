using Logikfabrik.Umbraco.Jet;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Lunch menus",
        Description = "Lunch menus",
        AllowedChildNodeTypes = new[] { typeof(LunchMenu) },
        Icon = "icon-food")]
    public class LunchMenus
    {
        /// <summary>
        /// Gets or sets the first preamble.
        /// </summary>
        public string Preamble1 { get; set; }

        /// <summary>
        /// Gets or sets the second preamble.
        /// </summary>
        public string Preamble2 { get; set; }
    }
}