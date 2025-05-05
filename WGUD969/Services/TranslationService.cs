using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WGUD969.Enums;

namespace WGUD969.Services
{
    public interface ITranslationService
    {
        string? Translate(string text, Language language, string? defaultText = null);
        void AddOrUpdateTranslation(string text, Language language, string translation);
    }
    public class TranslationService : ITranslationService
    {
        private readonly IConfiguration _Configuration;
        private Dictionary<string, Dictionary<Language, string>> _Translations = new Dictionary<string, Dictionary<Language, string>>();

        public TranslationService(IConfiguration configuration)
        {
            // Loading any existing translations from configuration
            _Configuration = configuration;
            foreach (var text in _Configuration.GetSection("Translations").GetChildren())
            {
                string textValue = text.Key;

                foreach (var translation in text.GetChildren())
                {
                    if (Enum.TryParse<Language>(translation.Key, out Language language))
                    {
                        AddOrUpdateTranslation(textValue, language, translation.Value);
                    }
                }
            }
        }

        public string? Translate(string text, Language language, string? defaultText = null)
        {
            if (_Translations.ContainsKey(text) && _Translations[text].ContainsKey(language))
            {
                return _Translations[text][language];
            }

            return defaultText ?? text;
        }

        public void AddOrUpdateTranslation(string text, Language language, string translation)
        {
            if (!_Translations.ContainsKey(text))
            {
                _Translations[text] = new Dictionary<Language, string>();
            }

            _Translations[text][language] = translation;
        }
    }
}
