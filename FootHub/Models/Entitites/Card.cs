using FootHub.Models.Entitites;
using System;
using System.ComponentModel.DataAnnotations;

namespace FootHub.Models.Entities
{
    public class Card
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Card number is required.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number must be 16 digits.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Cardholder name is required.")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "CVV is required.")]
        [Range(100, 999, ErrorMessage = "CVV must be 3 digits.")]
        public int CVV { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

      
        [Range(0, double.MaxValue, ErrorMessage = "Balance cannot be negative.")]
        public decimal Balance { get; set; }  
    }
}