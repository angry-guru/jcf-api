using System;
using System.Threading.Tasks;
using AutoMapper;
using jcf_api.Clients;
using jcf_api.Extensions;
using jcf_api.Types;

namespace jcf_api.Services
{
    public class EmissionService
    {
        private readonly EmissionClient emissionClient;
        private readonly IMapper mapper;

        public EmissionService(EmissionClient emissionClient,
                               IMapper mapper)
        {
            this.emissionClient = emissionClient ?? throw new ArgumentNullException(nameof(emissionClient));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmissionResponse> CalculateEmissionResponse(EmissionRequest request, TimeOption timeOption)
        {
            return new EmissionResponse
            {
                NonUser = await CalculateEmission(request.NonUser, timeOption),
                User = await CalculateEmission(request.User, timeOption)
            };
        }

        public async Task<EmissionResult> CalculateEmission(CarbonFootprintRequest request, TimeOption timeOption)
        {
            var flightsEmission = await CalculateFlightEmission(request.FlightOption, timeOption);
            var accomodationEmission = await CalculateAccomodationEmmision(request.AccomodationOption, timeOption);
            var paperEmission = await CalculatePaperEmmision(request.PaperOption, timeOption);

            var totalTons = flightsEmission.Tons + accomodationEmission.Tons + paperEmission.Tons;
            var totalCost = flightsEmission.Cost + accomodationEmission.Cost + paperEmission.Cost;

            flightsEmission.TonsPct = Math.Round(flightsEmission.Tons * 100 / totalTons, 2);
            accomodationEmission.TonsPct = Math.Round(accomodationEmission.Tons * 100 / totalTons, 2);
            paperEmission.TonsPct = Math.Round(paperEmission.Tons * 100 / totalTons, 2);

            return new EmissionResult
            {
                Flights = flightsEmission,
                Accomodation = accomodationEmission,
                Paper = paperEmission,
                TotalTons = totalTons,
                TotalCost = totalCost
            };
        }

        private async Task<CarbonFootprintResult> CalculatePaperEmmision(PaperOption paperOption, TimeOption timeOption)
        {
            var yearlyWeight = (paperOption.GetLbsWeight() / timeOption.GetDays()) * TimeOption.year.GetDays();
            
            var response = await emissionClient.GetPaperEmission(yearlyWeight);

            return mapper.Map<CarbonFootprintResult>(response);
        }

        private async Task<CarbonFootprintResult> CalculateAccomodationEmmision(AccomodationOption accomodationOption, TimeOption timeOption)
        {
            var yearlyNumberOfDates = ((double) accomodationOption.GetAverageValue() / timeOption.GetDays()) * TimeOption.year.GetDays();

            var response = await emissionClient.GetHotelEmission(yearlyNumberOfDates);

            return mapper.Map<CarbonFootprintResult>(response);
        }

        private async Task<CarbonFootprintResult> CalculateFlightEmission(FlightOption flightOption, TimeOption timeOption)
        {
            var yearlyNumberOfFlights = ((double) flightOption.GetAverageValue() / timeOption.GetDays()) * TimeOption.year.GetDays();

            var response = await emissionClient.GetHotelEmission(yearlyNumberOfFlights);

            return mapper.Map<CarbonFootprintResult>(response);
        }
    }
}
