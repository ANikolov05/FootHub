namespace FootHub.Models

{
    public class AddShoeDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public string ShoeName { get; set; }

        public decimal ShoePrice { get; set; }

        public string Gender { get; set; }

        public int ShoeSize { get; set; }

        public string ShoeColour { get; set; }

        public string ImagePath { get; set; }
    }
}
