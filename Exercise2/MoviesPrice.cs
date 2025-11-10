using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class MoviesPrice
    {
        public record PriceResult
        {
            public double Price { get; set; }
            public string Message { get; set; } = "Pris är inte sätt.";
        }

        public static PriceResult CalculatePersonPrice(int age)
        {
            const double youngPrice = 80;
            const double retiredPrice = 90;
            const double standardPrice = 120;

            PriceResult result = new PriceResult();
            // kanske lite överdrivet, men med en record kan vi lätt lägga till fler properties i framtiden om det behövs.
            // löser problemet med a upprepa pris logiken i flera ställen.

            if (age < 5)
            {
                result.Price = 0;
                result.Message = $"Barn under 5 år tittar grattis på Bio: {result.Price:C2}";
                return result;
            }
            else if (age < 20)
            {
                result.Price = youngPrice;
                result.Message = $"Personen är berättigad till ungdomspris: {result.Price:C2}";
                return result;
            }
            else if (age > 100)
            {
                result.Price = 0;
                result.Message = $"Personen är över 100 år! Tittar grattis på Bio: {result.Price:C2}";
                return result;
            }
            else if (age >= 64)
            {
                result.Price = retiredPrice;
                result.Message = $"Personen är berättigad till pensionärspris: {result.Price:C2}";
                return result;
            }
            else
            {
                result.Price = standardPrice;
                result.Message = $"Personen är berättigad till standardpris: {result.Price:C2}";
                return result;
            }
        }
    }
}
