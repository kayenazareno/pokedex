using Moq;
using PokeDex.Common.Constant;
using PokeDex.Domain.Navigation;
using PokeDex.Services;

namespace PokeDex.Tests.Services
{
    [TestFixture]
    public class ApplicationInitializerTests
    {
        private Mock<INavigationService> _navigationServiceMock;
        private Mock<ISettingsProvider> _settingsServiceMock;

        [SetUp]
        public void SetUp()
        {
            _navigationServiceMock = new Mock<INavigationService>();
            _settingsServiceMock = new Mock<ISettingsProvider>();
        }
        private ApplicationInitializer CreateInitializer()
        {
            return new ApplicationInitializer(_navigationServiceMock.Object, _settingsServiceMock.Object);
        }

    }
}
