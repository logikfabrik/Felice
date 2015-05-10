using System.ComponentModel.DataAnnotations;
using Logikfabrik.Umbraco.Jet;

namespace Logikfabrik.Felice.Models
{
    [DocumentType(
        "Lunch menu",
        Description = "A lunch menu for a full week")]
    public class LunchMenu
    {
        /// <summary>
        /// Gets or sets the first preamble.
        /// </summary>
        [ScaffoldColumn(false)]
        public string Preamble1 { get; set; }

        /// <summary>
        /// Gets or sets the second preamble.
        /// </summary>
        [ScaffoldColumn(false)]
        public string Preamble2 { get; set; }

        /// <summary>
        /// Gets or sets the year the lunch menu is for.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the week the lunch menu is for.
        /// </summary>
        public int Week { get; set; }
        
        /// <summary>
        /// Gets or sets the dish for Monday.
        /// </summary>
        public string Monday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Tuesday.
        /// </summary>
        public string Tuesday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Wednesday.
        /// </summary>
        public string Wednesday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Thursday.
        /// </summary>
        public string Thursday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Friday.
        /// </summary>
        public string Friday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Saturday.
        /// </summary>
        public string Saturday { get; set; }

        /// <summary>
        /// Gets or sets the dish for Sunday.
        /// </summary>
        public string Sunday { get; set; }
    }
}