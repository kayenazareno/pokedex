using PokeDex.Common.Constant;
using PokeDex.Domain.Navigation;

namespace PokeDex.Services
{
    public class ApplicationInitializer : IApplicationInitializer
    {
        private readonly INavigationService _navigationService;
        private readonly ISettingsProvider _settingsProvider;

        public ApplicationInitializer(INavigationService navigationService, ISettingsProvider settingsProvider)
        {
            _navigationService = navigationService;
            _settingsProvider = settingsProvider;
        }

        public void StartApplication()
        {
           _navigationService.PushAsync(ViewNames.PokeDexLogin);
        }
    }
}

