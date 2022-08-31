namespace FA22.P02.Web.DTOs
{
    public class Products
    { 
        public int Id { get; set; }
        public string? ProductName { get; set; }

        public string? Description { get; set; }
        public decimal Price { get; set; }

    }
    public class ProductDto
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }

}
