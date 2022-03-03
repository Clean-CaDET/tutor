using System;
using System.Runtime.Serialization;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    [Serializable]
    public class UnknownAssessmentEventException : DomainException
    {
        protected UnknownAssessmentEventException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnknownAssessmentEventException() { }

        public UnknownAssessmentEventException(string message) : base(message) { }

        public UnknownAssessmentEventException(string message, Exception innerException) : base(message, innerException) { }
    }
}
