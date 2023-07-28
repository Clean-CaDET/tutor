﻿using Tutor.BuildingBlocks.Core.Domain;
using Tutor.LmConversations.API.Dtos;
using Tutor.LmConversations.API.Dtos.Integration.Response;

namespace Tutor.LmConversations.Core.Domain;

public class Conversation : Entity
{
    public int LearnerId { get; private set; }
    public int ContextId { get; private set; }
    // TODO: proveriti da li cuvati jednu za prikaz, jednu za slanje
        // problem sto moramo da cuvamo lm poruke u originalnoj strukturi kako bismo ih vratili llm-u
        // neke poruke imaju posebna mapiranja unutar sebe gde se deserijalizuju sa tutor-ai strane i ne bih da dupliramo posao ovde, pogotovo ako se nacin promeni
    public List<LmMessageDto> LmMessages { get; private set; }
    public List<ConversationMessageDto> Messages { get; private set; }

    public Conversation(int id, int learnerId, int contextId)
    {
        Id = id;
        LearnerId = learnerId;
        ContextId = contextId;
        LmMessages = new List<LmMessageDto>();
        Messages = new List<ConversationMessageDto>();
    }

    public void AddLmMessages(List<LmMessageDto> lmMessages)
    {
        LmMessages.AddRange(lmMessages);
    }

    public void AddMessages(ConversationMessageDto request, ConversationMessageDto response)
    {
        request.Sender = SenderType.Learner;
        Messages.Add(request);
        response.Sender = SenderType.Lm;
        Messages.Add(response);
    }
}
