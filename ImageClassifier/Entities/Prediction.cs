using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageClassifier.Entities
{
    public class Prediction
    {
        public double Probability { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
    }
}
