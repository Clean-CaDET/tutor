namespace Tutor.BuildingBlocks.AI.Infrastructure;

public record AiServiceConfiguration
{
    public required string ApiKey { get; init; }
    public required string ChatModelId { get; init; }
}
