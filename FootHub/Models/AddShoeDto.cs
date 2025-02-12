namespace FootHub.Models

{
    public class AddShoeDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public string ShoeName { get; set; }

        public string ShoePrice { get; set; }

        public int ShoeSize { get; set; }

        public string ShoeColour { get; set; }

        public string ImagePath { get; set; }
    }
}
