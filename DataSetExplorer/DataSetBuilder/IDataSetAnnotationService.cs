﻿using DataSetExplorer.DataSetBuilder.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataSetExplorer.DataSetBuilder
{
    public interface IDataSetAnnotationService
    {
        public Result<string> AddDataSetAnnotation(DataSetAnnotation annotation, int dataSetInstanceId, int annotatorId);
    }
}