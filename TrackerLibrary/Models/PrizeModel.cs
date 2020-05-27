using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }

        public PrizeModel(string placeNumber, string placeName, string prizeAmount, string prizePercantage)
        {
            int.TryParse(placeNumber, out int placeNumberValue);
            decimal.TryParse(prizeAmount, out decimal prizeAmountValue);
            double.TryParse(prizePercantage, out double prizePercentageValue);
            
            PlaceNumber = placeNumberValue;
            PlaceName = placeName;
            PrizeAmount = prizeAmountValue;
            PrizePercentage = prizePercentageValue;
        }
    }
}
