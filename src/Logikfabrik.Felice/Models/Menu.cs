using Logikfabrik.Umbraco.Jet;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Menu",
        Description = "A menu",
        AllowedChildNodeTypes = new[] { typeof(MenuDish) })]
    public class Menu
    {
    }
}