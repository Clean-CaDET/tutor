﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Core.ProgressModel.Progress;
using Tutor.Web.Controllers.Content.DTOs;
using Tutor.Web.Controllers.Learners.DTOs;
using Tutor.Web.Controllers.Progress;
using Xunit;

namespace Tutor.Web.Tests.Integration
{
    public class ProgressTests : IClassFixture<TutorApplicationTestFactory<Startup>>
    {
        private readonly TutorApplicationTestFactory<Startup> _factory;

        public ProgressTests(TutorApplicationTestFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Finds_lecture_nodes()
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new ProgressController(_factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IProgressService>());

            var node = ((OkObjectResult) controller.GetLectureNodes(1).Result).Value as List<NodeProgressDTO>;

            node.Count.ShouldBe(4);
        }

        [Fact]
        public void No_lecture_nodes()
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new ProgressController(_factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IProgressService>());

            var code = ((NotFoundObjectResult)controller.GetLectureNodes(111).Result).StatusCode;

            code.ShouldBe(404);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Delivers_content(int nodeId, NodeProgressDTO expectedNode)
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new ProgressController(_factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IProgressService>());

            var actualNode = ((OkObjectResult)controller.GetNodeContent(nodeId).Result).Value as NodeProgressDTO;

            actualNode.Status.ShouldBe(expectedNode.Status);
            var actualLOIds = actualNode.LearningObjects.Select(lo => lo.Id);
            var expectedLOIds = expectedNode.LearningObjects.Select(lo => lo.Id);
            actualLOIds.Count().ShouldBe(expectedLOIds.Count());
            actualLOIds.All(expectedLOIds.Contains).ShouldBeTrue();
        }

        public static IEnumerable<object[]> TestData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    1,
                    new NodeProgressDTO
                    {
                        Status = NodeStatus.Unlocked,
                        LearningObjects = new List<LearningObjectDTO>
                        {
                            new() {Id = 1},
                            new() {Id = 2},
                            new() {Id = 3},
                            new() {Id = 4}
                        }
                    },
                },
                new object[]
                {
                    2,
                    new NodeProgressDTO
                    {
                        Status = NodeStatus.Unlocked,
                        LearningObjects = new List<LearningObjectDTO>
                        {
                            new() {Id = 6},
                            new() {Id = 10},
                            new() {Id = 12}
                        }
                    },
                }
            };
        }
    }
}
