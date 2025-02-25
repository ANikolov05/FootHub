namespace FootHub.Models.Entitites
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
        public int Quantity { get; set; }
    }
}
