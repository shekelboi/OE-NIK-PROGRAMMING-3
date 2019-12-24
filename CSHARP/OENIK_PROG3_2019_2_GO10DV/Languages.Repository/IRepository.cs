namespace Languages.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IRepository
    {
        void InitDB();

        void Remove(string table);

        void Modify(string table);

        void AddLangfamLangLink();

        void AddCountryLangLink();

        void AddLanguageFamily();

        void AddLanguage();

        void AddCountry();

        void NamesOfCountries();
        
        void NumberOfSpeakersRollup();

        void LanguageFamilies();

        void OfficialLanguages();

        void LanguagesByDifficulty();

        void NumberOfSpeakers();

        void ListAll();
    }
}
