using System;
using System.Collections.Generic;
using System.Linq;
using jcf_api.Extensions;
using jcf_api.Types;

namespace jcf_api.Services
{
    public class OptionsService
    {
        public IEnumerable<KeyValuePair<FlightOption, string>> GetFlightOptions()
        {
            var enums = Enum.GetValues(typeof(FlightOption)).Cast<FlightOption>();

            return enums.Select(_ => KeyValuePair.Create(_, _.GetDescription()));
        }

        public IEnumerable<KeyValuePair<AccomodationOption, string>> GetAccomodationOptions()
        {
            var enums = Enum.GetValues(typeof(AccomodationOption)).Cast<AccomodationOption>();

            return enums.Select(_ => KeyValuePair.Create(_, _.GetDescription()));
        }

        public IEnumerable<KeyValuePair<PaperOption, string>> GetPaperOptions()
        {
            var enums = Enum.GetValues(typeof(PaperOption)).Cast<PaperOption>();

            return enums.Select(_ => KeyValuePair.Create(_, _.GetDescription()));
        }

        public IEnumerable<dynamic> GetTimeOptions()
        {
            var enums = Enum.GetValues(typeof(TimeOption)).Cast<TimeOption>();

            return enums.Select(_ => new { key = _, value = _.GetDescription(), days = _.GetDays() });
        }
    }
}
