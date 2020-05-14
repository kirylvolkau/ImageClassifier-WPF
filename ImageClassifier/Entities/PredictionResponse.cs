using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageClassifier.Entities
{
    public class PredictionResponse
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string Iteration { get; set; }
        public DateTime Created { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
}
