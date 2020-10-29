﻿namespace RepositoryCompiler.CodeModel.CaDETModel.Metrics
{
    public class CaDETClassMetrics
    {
        public int LOC { get; set; }
        public double? LCOM { get; set; }
        public int NMD { get; set; }
        public int NAD { get; set; }
        public int WMC { get; set; }
        /// <summary>
        /// ATFD: Access To Foreign Data
        /// DOI: 10.1109/ESEM.2009.5314231
        /// </summary>
        public int ATFD { get; set; }
        /// TCC - Tight Class Cohesion
        /// DOI: 10.1145/223427.211856
        /// </summary>
        public double? TCC { get; set; }
    }
}