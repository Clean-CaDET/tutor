﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Courses;

[Collection("Sequential")]
public class OwnedCoursesTests : BaseWebIntegrationTest
{
    public OwnedCoursesTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [InlineData("-51", 1)]
    [InlineData("-52", 2)]
    public void Retrieves_owned_courses(string instructorId, int expectedCourseCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupOwnedCoursesController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetOwnedCourses().Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedCourseCount);
    }

    [Fact]
    public void Retrieves_owned_course_with_units()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupOwnedCoursesController(scope, "-51");
        var result = ((OkObjectResult)controller.GetCourseWithUnitsAndKcs(-1).Result)?.Value as CourseDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.KnowledgeUnits.Count.ShouldBe(2);
    }

    private OwnedCoursesController SetupOwnedCoursesController(IServiceScope scope, string id)
    {
        return new OwnedCoursesController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ICourseOwnershipService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}