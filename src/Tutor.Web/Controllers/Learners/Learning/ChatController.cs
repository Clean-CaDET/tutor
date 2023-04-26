using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.LearningUtilities;
using Tutor.Infrastructure.Database;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Web.Controllers.Learners.Learning;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/chat")]
public class ChatController : BaseApiController
{
    protected readonly TutorContext DbContext;
    private readonly IUnitOfWork _unitOfWork;

    public ChatController(TutorContext dbContext, IUnitOfWork unitOfWork)
    {
        DbContext = dbContext;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public Result<Chat> SaveChat([FromBody] string[] messages)
    {
        Chat newChat = new Chat(User.LearnerId(), DateTime.Now.ToUniversalTime(), messages);
        DbContext.Chats.Attach(newChat);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(newChat);
    }
}
