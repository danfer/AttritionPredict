using Microsoft.ML;
using SDCA.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDCA.ML.Base
{
    public class BaseML
    {
        protected static string ModelPath => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_FILENAME);

        protected readonly MLContext MlContext;

        protected BaseML()
        {
            MlContext = new MLContext(2020);
        }
    }
}
