using Logikfabrik.Umbraco.Jet;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Menu",
        Description = "A menu",
        AllowedChildNodeTypes = new[] { typeof(MenuDish) },
        Icon = "icon-food")]
    public class Menu
    {
    }
}