using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration
{
    public class DomainTests : IClassFixture<TutorApplicationTestFactory<Startup>>
    {
        private readonly TutorApplicationTestFactory<Startup> _factory;

        public DomainTests(TutorApplicationTestFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Retrieves_units()
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new KCController(_factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>());

            var units = ((OkObjectResult) controller.GetUnits().Result).Value as List<UnitDTO>;

            units.Count.ShouldBe(2);
            units.SelectMany(u => u.KnowledgeComponentIds).Count().ShouldBe(15);
        }
    }
}
