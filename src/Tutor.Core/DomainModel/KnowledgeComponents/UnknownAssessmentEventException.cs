using System;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class UnknownAssessmentEventException : DomainException
    {
        public UnknownAssessmentEventException() { }

        public UnknownAssessmentEventException(string message) : base(message) { }

        public UnknownAssessmentEventException(string message, Exception innerException) : base(message, innerException) { }
    }
}
