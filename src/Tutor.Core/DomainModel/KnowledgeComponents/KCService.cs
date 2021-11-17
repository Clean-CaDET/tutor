using System.Collections.Generic;

namespace Tutor.Core.DomainModel.KnowledgeComponents
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