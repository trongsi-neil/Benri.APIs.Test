using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Benri.APIs.Test.Report
{
    public class TestCase
    {
        public string Description { get; set; }
        public string URI { get; set; }
        public string Method { get; set; }
        public Object Body { get; set; }
        public int ExpectedStatus { get; set; }
        public int ActualStatus { get; set; }
        public string ExpectedMessage { get; set; }
        public string ActualMessage { get; set; }
        public string TestResult { get; set; }

        public string convertObjectToJson(Object input)
        {
            return new JavaScriptSerializer().Serialize(input);
        }
        public void ExportToTSVFile(string fileLink)
        {
            string body = convertObjectToJson(Body);
            string fullTestCaseString = "\n" +
                Description + "\t" + URI + "\t" + Method + "\t" +
                body + "\t" + ExpectedStatus.ToString() + "\t" +
                ActualStatus.ToString() + "\t" + ExpectedMessage + "\t" +
                ActualMessage + "\t" + TestResult;
            TSVFile.updateReport(fileLink, fullTestCaseString);
        }
    }
}
