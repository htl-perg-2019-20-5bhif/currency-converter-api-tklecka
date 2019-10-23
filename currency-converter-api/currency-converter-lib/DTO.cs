namespace currency_converter
{
    public class ProductDTO
    {
        public string Description { get; }
        public string Currency { get; }
        public decimal Price { get; }

        public ProductDTO(string desc, string currency, decimal price)
        {
            Description = desc;
            Currency = currency;
            Price = price;
        }
    }

    public class ExchangerateDTO
    {
        public string Currency { get; }
        public decimal Rate { get; }

        public ExchangerateDTO(string curreny, decimal rate)
        {
            Currency = curreny;
            Rate = rate;
        }
    }

    public class PriceDTO
    {
        public decimal Price { get; }

        public PriceDTO(decimal Price)
        {
            this.Price = Price;
        }
    }
}
