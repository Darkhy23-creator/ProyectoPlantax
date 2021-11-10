 using System;
using Xunit;
using FakeItEasy;
using System.Threading.Tasks;
using Bunit;
using ProyectoPlantax.Server.Controllers;
using ProyectoPlantax.Server.Data;
using ProyectoPlantax.Client.Resources;
using ProyectoPlantax.Client.Components;
using Microsoft.Extensions.Localization;

namespace TestProject1
{
    public class UnitTest1: TestContext
    {
      
        [Fact]
        public void Multilanguagetest()
        {
            var cut = RenderComponent<Mltest>();

            cut.MarkupMatches(expected: "< p >< i > @localizer[Greting2] </ i ></ p >");
  
        }
    }
}
