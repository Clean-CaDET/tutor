using FluentResults;

namespace Tutor.BuildingBlocks.Core.LLM;

public interface ILlmConnection
{
    Task<Result<LlmResponse>> CompleteAsync(List<LlmMessage> req);
}