namespace jcf_api.Services
{
    public class CalculationService
    {
        public decimal CalculateCarbonFootprint(int fligthsNumber, int accomodationDays, int linesheets)
        {
            var iNumPeople = 0;
            var iNumCars = 0;
            var iNumFlights = 0;
            var iNumHomeSqFt = 0;

            var iCarMilesPerYear = 12000; // http://www.epa.gov/otaq/consumer/420f08024.pdf
            var iAverageHomeSqFt = 1971; // http://www.eia.gov/consumption/residential/data/2009/
            var fpHighMeatEaterKgCO2PerDay = 7.19; // http://link.springer.com/article/10.1007%2Fs10584-014-1169-1
            var fpMidMeatEaterKgCO2PerDay = 5.63; // http://link.springer.com/article/10.1007%2Fs10584-014-1169-1
            var fp = 4.67; // http://link.springer.com/article/10.1007%2Fs10584-014-1169-1
            var fpFishEaterKgCO2PerDay = 3.91; // http://link.springer.com/article/10.1007%2Fs10584-014-1169-1
            var fpVegetarianEaterKgCO2PerDay = 3.81; // http://link.springer.com/article/10.1007%2Fs10584-014-1169-1
            var fpVeganEaterKgCO2PerDay = 2.89; // http://link.springer.com/article/10.1007%2Fs10584-014-1169-1
            var fpElectricHeatKgCO2PerMMBTU = 164.126611957796; // http://www.epa.gov/climateleadership/documents/emission-factors.pdf
            // TODO: Finish heat or just use calculation
            var fpTonsCO2HomeEnergyPerAverageHousehold = 9.904832; // http://www.epa.gov/climateleadership/documents/emission-factors.pdf and http://www.eia.gov/consumption/residential/data/2009/index.cfm?view=consumption
            var fpHoursPerFlight = 3.0; 
            var fpTonsCO2PerPersonPerFlightPerHour = 0.25; // http://carbonindependent.org/sources_aviation.htm
            var fpAverageMilesPerGallonForPersonalCar = 23.3; // http://www.rita.dot.gov/bts/sites/rita.dot.gov.bts/files/publications/national_transportation_statistics/html/table_04_11.html
            var fpTonsCO2PerGallonForPersonalCar = 0.0088; // http://www.epa.gov/climateleadership/documents/emission-factors.pdf
            // Calculate car emissions
            var fpCarEmissions = iNumCars * iCarMilesPerYear * fpTonsCO2PerGallonForPersonalCar / fpAverageMilesPerGallonForPersonalCar;
            // alert("Car emissions: " + fpCarEmissions.toString() );
            // Calculate flight emissions
            var fpFlightEmissions = iNumFlights * fpHoursPerFlight * fpTonsCO2PerPersonPerFlightPerHour;
            // alert("Flight emissions: " + fpFlightEmissions.toString() );
            // Calculate home energy emissions
            var fpHomeEnergyEmissions = iNumHomeSqFt * fpTonsCO2HomeEnergyPerAverageHousehold / iAverageHomeSqFt;

            var fpDietFactor = 0;
            // switch (slcDiet.value) {
            //     case "Meat":
            //         fpDietFactor = fpMidMeatEaterKgCO2PerDay;
            //         break;
            //     case "Fish":
            //         fpDietFactor = fpFishEaterKgCO2PerDay;
            //         break;
            //     case "Veggie":
            //         fpDietFactor = fpVegetarianEaterKgCO2PerDay;
            //         break;
            //     case "Vegan":
            //         fpDietFactor = fpVeganEaterKgCO2PerDay;
            //         break;
            // }
            // // alert(fpDietFactor.toString());
            // var fpDietEmissions = iNumPeople * 365 * fpDietFactor / 1000;  // Multiply by 365 and divide by 1000 b/c factor is _Kg_CO2 per person per day
            // // alert("Diet-related emissions: " + fpDietEmissions.toString());
            // // Calculate total
            // var fpTotalEmissions = fpCarEmissions + fpFlightEmissions + fpHomeEnergyEmissions + fpDietEmissions;

            return 0;
        }
    }
}
