using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Infrastructure.Security.Authorization.JWT;

namespace Tutor.Web.Hubs
{
    public class SessionHub : Hub
    {
        private readonly IKCService _kcService;

        public SessionHub(IKCService kcService)
        {
            _kcService = kcService;
        }

        public void LaunchSession(int knowledgeComponentId)
        {
            var result = _kcService.LaunchSession(Context.User.Id(), knowledgeComponentId);
            if (result.IsSuccess)
                Context.Items.Add("knowledgeComponentId", knowledgeComponentId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            object knowledgeComponentId;
            if (Context.Items.TryGetValue("knowledgeComponentId", out knowledgeComponentId))
            {
                if (exception == null)
                    _kcService.TerminateSession(Context.User.Id(), (knowledgeComponentId as int?).Value);
                else
                    _kcService.AbandonSession(Context.User.Id(), (knowledgeComponentId as int?).Value);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
