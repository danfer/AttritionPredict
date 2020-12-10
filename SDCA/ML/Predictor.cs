﻿using Microsoft.ML;
using Newtonsoft.Json;
using SDCA.ML.Base;
using SDCA.ML.Objects;
using SDCA.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDCA.ML
{
    public class Predictor: BaseML
    {
        public void Predict(string inputDataFile)
        {
            if (!File.Exists(ModelPath))
            {
                Console.WriteLine($"Failed to find model at {ModelPath}");

                return;
            }
            if (!File.Exists(inputDataFile))
            {
                Console.WriteLine($"Failed to find input data at {inputDataFile}");

                return;
            }

            ITransformer mlModel;

            using (var stream = new FileStream(ModelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = MlContext.Model.Load(stream, out _);
            }

            if (mlModel == null)
            {
                Console.WriteLine("Failed to load model");

                return;
            }

            var predictionEngine = MlContext.Model.CreatePredictionEngine<EmploymentHistory, EmploymentHistoryPrediction>(mlModel);

            var json = File.ReadAllText(inputDataFile);

            var prediction = predictionEngine.Predict(JsonConvert.DeserializeObject<EmploymentHistory>(json));

            Console.WriteLine(
                               $"Based on input json:{System.Environment.NewLine}" +
                               $"{json}{System.Environment.NewLine}" +
                               $"The employee is predicted to work {prediction.DurationInMonths:#.##} months.");
        }
    }
}
