using System.Collections.Generic;
using System.Globalization;

namespace currency_converter
{
    public class CSVParser
    {
        public static IEnumerable<ProductDTO> GetProducts(string content)
        {
            var lines = ParseCSV(content);
            List<ProductDTO> products = new List<ProductDTO>();

            foreach (string[] product in lines)
            {
                products.Add(new ProductDTO(product[0], product[1], decimal.Parse(product[2], CultureInfo.InvariantCulture)));
            }

            return products;
        }

        public static IEnumerable<ExchangerateDTO> GetRates(string content)
        {
            var lines = ParseCSV(content);
            List<ExchangerateDTO> exchanges = new List<ExchangerateDTO>();

            foreach (string[] exchange in lines)
            {
                exchanges.Add(new ExchangerateDTO(exchange[0], decimal.Parse(exchange[1], CultureInfo.InvariantCulture)));
            }

            return exchanges;
        }

        public static IEnumerable<string[]> ParseCSV(string content)
        {
            List<string[]> elements = new List<string[]>();
            string[] lines = content.Replace("\r", string.Empty)
                .Split("\n");
            for (int i = 1; i < lines.Length; i++)
            {
                string[] curElements = lines[i]
                    .Split(",");
                if (curElements.Length > 1)
                    elements.Add(curElements);
            }

            return elements;
        }
    }
}
