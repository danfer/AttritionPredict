using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDCA.ML.Objects
{
    public class EmploymentHistoryPrediction
    {
        [ColumnName("Score")]
        public float DurationInMonths;
    }
}
