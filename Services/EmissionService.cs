using System;
using System.Threading;
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
            var emissionResponse = new EmissionResponse
            {
                NonUser = await CalculateEmission(request.NonUser, timeOption),
                User = await CalculateEmission(request.User, timeOption),
            };

            emissionResponse.SavedTrees = (int)((emissionResponse.NonUser.TotalTons - emissionResponse.User.TotalTons) / 0.02);
            emissionResponse.SavedCost = Math.Round(emissionResponse.NonUser.TotalCost - emissionResponse.User.TotalCost, 2);

            return emissionResponse;
        }

        public async Task<EmissionResult> CalculateEmission(CarbonFootprintRequest request, TimeOption timeOption)
        {
            CarbonFootprintResult flightsEmission = new CarbonFootprintResult();
            CarbonFootprintResult accomodationEmission = new CarbonFootprintResult();
            CarbonFootprintResult paperEmission = new CarbonFootprintResult();

            Task t1 = Task.Run(async () => { flightsEmission = await CalculateFlightEmission(request.FlightOption, timeOption); });
            Task t2 = Task.Run(async () => { accomodationEmission = await CalculateAccomodationEmmision(request.AccomodationOption, timeOption); });
            Task t3 = Task.Run(async () => { paperEmission = await CalculatePaperEmmision(request.PaperOption, timeOption); });

            await Task.WhenAll(t1, t2, t3);

            var totalTons = Math.Round(flightsEmission.Tons + accomodationEmission.Tons + paperEmission.Tons, 2);
            var totalCost = Math.Round(flightsEmission.Cost + accomodationEmission.Cost + paperEmission.Cost, 2);

            if (totalTons != 0)
            {
                flightsEmission.TonsPct = Math.Round(flightsEmission.Tons * 100 / totalTons, 2);
                accomodationEmission.TonsPct = Math.Round(accomodationEmission.Tons * 100 / totalTons, 2);
                paperEmission.TonsPct = Math.Round(paperEmission.Tons * 100 / totalTons, 2);
            }
            else
            {
                flightsEmission.TonsPct = 0;
                accomodationEmission.TonsPct = 0;
                paperEmission.TonsPct = 0;
            }

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
