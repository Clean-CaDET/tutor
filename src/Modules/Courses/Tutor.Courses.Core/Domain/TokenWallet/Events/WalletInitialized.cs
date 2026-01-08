namespace Tutor.Courses.Core.Domain.TokenWallet.Events;

public class WalletInitialized : WalletEvent
{
    public int InitialAllowance { get; set; }
}
