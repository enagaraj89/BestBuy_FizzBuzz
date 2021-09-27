namespace BestBuy_FizzBuzz.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// FizzBuzzModel.
    /// </summary>
    public class FizzBuzzModel
    {
        /// <summary>
        /// Gets or Sets InputValues property.
        /// </summary>
        [Display(Name = "Enter a list of values")]
        [Required]
        public string InputValues { get; set; }

        /// <summary>
        /// Gets or Sets Output property.
        /// </summary>
        public List<string> Output { get; set; }
    }
}
