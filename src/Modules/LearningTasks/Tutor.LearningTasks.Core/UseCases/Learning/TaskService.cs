using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Learning
{
    public class TaskService : ITaskService
    {
        private readonly ILearningTaskRepository _taskRepository;
        private readonly IAccessServices _accessServices;
        private readonly IMapper _mapper;

        public TaskService(ILearningTaskRepository taskRepository, IAccessServices accessServices, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _accessServices = accessServices;
            _mapper = mapper;
        }

        public Result<LearningTaskDto> Get(int id, int unitId, int learnerId)
        {
            if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
                return Result.Fail(FailureCode.Forbidden);

            var learningTask = _taskRepository.Get(id);
            if(learningTask == null)
                return Result.Fail(FailureCode.NotFound);

            return _mapper.Map<LearningTaskDto>(learningTask);
        }

        public Result<List<LearningTaskDto>> GetByUnit(int unitId, int learnerId)
        {
            if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
                return Result.Fail(FailureCode.Forbidden);

            var learningTasks = _taskRepository.GetNonTemplateByUnit(unitId);
            return learningTasks.Select(_mapper.Map<LearningTaskDto>).ToList();
        }
    }
}
