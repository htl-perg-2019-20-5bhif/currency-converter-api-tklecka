using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace currency_converter.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly HttpClient client;

        public CurrencyConverterController(IHttpClientFactory factory)
        {
            client = factory.CreateClient("currencyconverter");
        }

        [HttpGet]
        [Route("{product}/price")]
        public async Task<IActionResult> Get(string product, [FromQuery]string targetCurrency)
        {
            var pricesresponse = await client.GetAsync("Prices.csv");
            pricesresponse.EnsureSuccessStatusCode();

            var eratesresponse = await client.GetAsync("ExchangeRates.csv");
            eratesresponse.EnsureSuccessStatusCode();

            string products = await pricesresponse.Content.ReadAsStringAsync();

            string rates = await eratesresponse.Content.ReadAsStringAsync();

            PriceDTO p = CurrencyConverter.ConvertCurrency(products, rates, product, targetCurrency);

            return Ok(p);
        }
    }
}
