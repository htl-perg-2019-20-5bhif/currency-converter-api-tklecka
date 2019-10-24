using System;
using System.Collections.Generic;
using System.Linq;

namespace currency_converter
{
    public class CurrencyConverter
    {
        public static PriceDTO ConvertCurrency(string productsstring, string ratesstring, string productName, string targetCurrency)
        {
            IEnumerable<ProductDTO> products = CSVParser.GetProducts(productsstring);
            IEnumerable<ExchangerateDTO> exchangeRates = CSVParser.GetRates(ratesstring);

            ProductDTO product = products.Where(p => p.Description.Equals(productName)).First();
            if (targetCurrency.Equals(product.Currency))
            {
                return new PriceDTO(Math.Round(product.Price, 2));
            }
            else if (targetCurrency.Equals("EUR"))
            {
                ExchangerateDTO er = exchangeRates.Where(p => p.Currency.Equals(product.Currency)).First();
                return new PriceDTO(Math.Round(product.Price / er.Rate, 2));
            }
            else
            {
                ExchangerateDTO er = exchangeRates.Where(p => p.Currency.Equals(product.Currency)).First();
                return new PriceDTO(Math.Round(product.Price * er.Rate, 2));
            }

        }
    }
}
