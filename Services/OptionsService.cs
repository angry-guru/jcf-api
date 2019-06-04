using System;
using System.Collections.Generic;
using System.Linq;
using jcf_api.Extensions;
using jcf_api.Types;

namespace jcf_api.Services
{
    public class OptionsService
    {
        public IEnumerable<KeyValuePair<AmountOption, string>> GetAmountOptions()
        {
            var enums = Enum.GetValues(typeof(AmountOption)).Cast<AmountOption>();

            return enums.Select(_ => KeyValuePair.Create(_, _.GetDescription()));
        }

        public IEnumerable<KeyValuePair<TimeOption, string>> GetTimeOptions()
        {
            var enums = Enum.GetValues(typeof(TimeOption)).Cast<TimeOption>();

            return enums.Select(_ => KeyValuePair.Create(_, _.GetDescription()));
        }
    }
}
