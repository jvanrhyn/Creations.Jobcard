using Jobcard.Models;
using Jobcard.Services.Data;
using Shouldly;
using System.Linq;
using Xunit;

namespace Jobcard.Web.Tests.Services.Data
{
    public class DefaultsTests
    {
        [Fact]
        public void BasicTest()
        {
            DefaultsManager defaultsManager = new DefaultsManager();
            defaultsManager.SetDatabase(@"TestDatabase");

            LayerKindDefault layerKindDefault = new LayerKindDefault
            {
                Acceleration = 200,
                Blower = true,
                Corner = 200,
                LayerType = LayerType.Cut,
                Name = "Test",
                Power1 = 55,
                Power1Min = 50,
                Power2 = 80,
                Power2Min = 60
            };

            defaultsManager.GetAll().Count().ShouldBe(0);

            var result = defaultsManager.Add(layerKindDefault);
            result.Id.ShouldNotBe(0);
            
            defaultsManager.GetAll().Count().ShouldBe(1);
        }
    }
}
