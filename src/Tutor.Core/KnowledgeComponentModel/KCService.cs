using System.Collections.Generic;
using Tutor.Core.KnowledgeComponentModel.KnowledgeComponents;

namespace Tutor.Core.KnowledgeComponentModel
{
    public class KCService : IKCService
    {
        private readonly IKCRepository _kcRepository;

        public KCService(IKCRepository kcRepository)
        {
            _kcRepository = kcRepository;
        }

        public List<KnowledgeComponent> GetKnowledgeComponents()
        {
            return _kcRepository.GetKnowledgeComponent();
        }
    }
}