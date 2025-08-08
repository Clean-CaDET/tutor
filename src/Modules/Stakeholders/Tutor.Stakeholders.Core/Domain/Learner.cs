namespace Tutor.Stakeholders.Core.Domain;

public class Learner : Stakeholder
{
    public string Index { get; private set; }
    public LearnerType LearnerType { get; private set; }
    public int? WalletId { get; private set; }
    public Wallet? Wallet { get; private set; }
}

public enum LearnerType
{
    Regular,
    Commercial
}