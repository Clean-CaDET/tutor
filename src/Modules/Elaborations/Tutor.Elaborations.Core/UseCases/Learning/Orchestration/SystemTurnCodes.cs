namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public static class SystemTurnCodes
{
    public const string SoftCapNudge = "SOFT_CAP\n";
    public const string InClosingTransition = "CLOSING_TRANSITION\n";
    public const string NonSubstantiveInClosingNudge = "CLOSING_NUDGE\n";
    public const string ExpiredNotice = "EXPIRED\n";
    public const string OffTopic = "OFF_TOPIC\n";
}
