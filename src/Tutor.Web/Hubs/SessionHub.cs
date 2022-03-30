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

        //public void LaunchSession(int knowledgeComponentId)
        //{
        //    var result = _kcService.LaunchSession(Context.User.Id(), knowledgeComponentId);
        //    if (result.IsSuccess)
        //        Context.Items.Add("knowledgeComponentId", knowledgeComponentId);
        //}

        public void LaunchSession(int knowledgeComponentId, int learnerId)
        {
            var result = _kcService.LaunchSession(learnerId, knowledgeComponentId);
            if (result.IsSuccess)
            {
                Context.Items.Add("knowledgeComponentId", knowledgeComponentId);
                Context.Items.Add("learnerId", learnerId);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            object knowledgeComponentId;
            object  learnerId;
            if (Context.Items.TryGetValue("knowledgeComponentId", out knowledgeComponentId)
                && Context.Items.TryGetValue("learnerId", out learnerId))
            {
                if (exception == null)
                    _kcService.TerminateSession((learnerId as int?).Value, (knowledgeComponentId as int?).Value);
                else
                    _kcService.AbandonSession((learnerId as int?).Value, (knowledgeComponentId as int?).Value);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
