using System.Collections.Generic;

namespace Tutor.Web.Mappings.Stakeholders;

public class BulkAccountsDto
{
    public List<StakeholderAccountDto> ExistingAccounts { get; set; }
    public List<StakeholderAccountDto> NewAccounts { get; set; }
}