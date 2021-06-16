﻿using CodeModel.CaDETModel.CodeItems;
using DataSetExplorer.DataSetBuilder.Model;
using DataSetExplorer.DataSetSerializer;
using FluentResults;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DataSetExplorer.AnnotationConsistencyTests
{
    public class AnovaTest : IMetricsSignificanceTester
    {
        private readonly string _anovaScriptFile = "../../../AnnotationConsistencyTests/anova_test.py";
        private readonly string _pythonPath = "../../../AnnotationConsistencyTests/venv/Scripts/python.exe";
        private string _annotatedInstancesFile;
        private string _dependentVariable;
        private string _independentVariable;
        private readonly string _annotatedInstancesFolderPath = "D:/ccadet/annotations/sanity_check/anova/Output/";

        private delegate Dictionary<string, string> TestCodeSmellDelegate(int? id, List<DataSetInstance> instances, string codeSmell, List<CaDETMetric> metrics);

        public Result<Dictionary<string, Dictionary<string, string>>> TestForSingleAnnotator(int annotatorId, IEnumerable<IGrouping<string, DataSetInstance>> instancesGroupedBySmells)
        {
            return Test(instancesGroupedBySmells, TestCodeSmellForAnnotator, annotatorId);
        }

        public Result<Dictionary<string, Dictionary<string, string>>> TestBetweenAnnotators(IEnumerable<IGrouping<string, DataSetInstance>> instancesGroupedBySmells)
        {
            return Test(instancesGroupedBySmells, TestCodeSmellBetweenAnnotators);
        }

        private Result<Dictionary<string, Dictionary<string, string>>> Test(IEnumerable<IGrouping<string, DataSetInstance>> instancesGroupedBySmells, TestCodeSmellDelegate testCodeSmell, int? annotatorId = null)
        {
            var results = new Dictionary<string, Dictionary<string, string>>();
            foreach (var codeSmellGroup in instancesGroupedBySmells)
            {
                var codeSmell = codeSmellGroup.Key.Replace(" ", "_");
                var metrics = codeSmellGroup.First().MetricFeatures.Keys.ToList();
                var instances = codeSmellGroup.ToList();
                results[codeSmell] = testCodeSmell(annotatorId, instances, codeSmell, metrics);
            }
            return Result.Ok(results);
        }
       
        private Dictionary<string, string> TestCodeSmellForAnnotator(int? annotatorId, List<DataSetInstance> instances, string codeSmell, List<CaDETMetric> metrics)
        {
            var results = new Dictionary<string, string>();
            string exportedAnnotationsFile = ExportAnnotationsForAnnotator(annotatorId.Value, instances, codeSmell);
            foreach (var metric in metrics)
            {
                SetupTestArguments(exportedAnnotationsFile, metric, "Annotation");
                results[metric.ToString()] = StartProcess();
            }
            return results;
        }

        private Dictionary<string, string> TestCodeSmellBetweenAnnotators(int? annotatorId, List<DataSetInstance> instances, string codeSmell, List<CaDETMetric> metrics)
        {
            var results = new Dictionary<string, string>();
            string exportedAnnotationsFile = ExportAllAnnotations(instances, codeSmell);
            foreach (var metric in metrics)
            {
                SetupTestArguments(exportedAnnotationsFile, metric, "Annotator*Annotation");
                results[metric.ToString()] = StartProcess();
            }
            return results;
        }

        private string ExportAnnotationsForAnnotator(int annotatorId, List<DataSetInstance> instances, string codeSmell)
        {
            var exportedAnnotationsFile = "MetricsSignificance_" + codeSmell + "_Annotator_" + annotatorId;
            var exporter = new AnnotationConsistencyByMetricsExporter(_annotatedInstancesFolderPath);
            exporter.ExportAnnotationsFromAnnotator(annotatorId, instances, exportedAnnotationsFile);
            return exportedAnnotationsFile;
        }

        private string ExportAllAnnotations(List<DataSetInstance> instances, string codeSmell)
        {
            var exportedAnnotationsFile = "MetricsSignificance_" + codeSmell;
            var exporter = new AnnotationConsistencyByMetricsExporter(_annotatedInstancesFolderPath);
            exporter.ExportAllAnnotations(instances, exportedAnnotationsFile);
            return exportedAnnotationsFile;
        }

        private void SetupTestArguments(string exportedAnnotationsFile, CaDETMetric metric, string independentVariable)
        {
            _annotatedInstancesFile = _annotatedInstancesFolderPath + exportedAnnotationsFile + ".xlsx";
            _dependentVariable = metric.ToString();
            _independentVariable = independentVariable;
        }

        private string StartProcess()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = _pythonPath,
                Arguments = $"{_anovaScriptFile} {_annotatedInstancesFile} \"{_dependentVariable}\" {_independentVariable}",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            Process process = Process.Start(startInfo);
            StreamReader reader = process.StandardOutput;
            var result = reader.ReadToEnd();
            return result.Equals("") ? "Unable to calculate test result." : result;
        }
    }
}
