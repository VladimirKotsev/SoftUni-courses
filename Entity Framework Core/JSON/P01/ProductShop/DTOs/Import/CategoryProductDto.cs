namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;
    public class CategoryProductDto
    {
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }

        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }
    }
}
