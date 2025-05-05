using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGUD969.Enums;
using WGUD969.Services;

namespace WGUD969.Models
{
    public interface IUserLocation
    {
        string Country { get; }
        string? City { get; }
        string Timezone { get; }
        string WelcomeMessage(Language language);
    }
    public class UserLocation : IUserLocation
    {
        public string Timezone { get; private set; }
        public string Country { get; private set; }
        public string? City { get; private set; }
        private readonly ITranslationService _Translator;

        public UserLocation(string timezone, string country, string city = null, ITranslationService translator = null)
        {
            Timezone = timezone;
            Country = country;
            City = city;
            _Translator = translator;
        }

        public string WelcomeMessage(Language language)
        {
            string welcomeFrom = _Translator.Translate("Welcome from", language);
            string fromString = City != null ? $"{City}, {Country}" : $"{Country}";
            return $"{welcomeFrom} {fromString}!";
        }

    }
}
