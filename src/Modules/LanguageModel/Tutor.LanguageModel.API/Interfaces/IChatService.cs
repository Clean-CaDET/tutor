using FluentResults;
using Tutor.LanguageModel.API.Dtos;

namespace Tutor.LanguageModel.API.Interfaces;

public interface IChatService
{
    Result<ChatDto> Get(int contextId, ContextType contextType, int learnerId);
    // ako ne postoji chat sa id-em koji je prosledjen u messageDto, kreiraj ga
    // ako postoji, dopuni ga
    // to je fer, nema sta da se proverava tu
    // TODO: da li treba proveravati da li Learner sme da pristupi KC-u sa tim id-em
    Result<ChatDto> SendMessage(MessageDto message);
}
