using Benri.APIs.Test.Report;
using BenriShop;
using BenriShop.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Benri.APIs.Test
{
    public class TestGetProducts : UnitTestAPI
    {
        private readonly string TestReportLink = "C:\\Users\\Si\\source\\repos\\" +
                "Benri.APIs.Test\\TestReport\\testReport.tsv";
        [Fact]
        public async Task TestGetProducts_Successfully()
        {
            string URI = "api/Products/GetProducts";

            var response = await ContentObject_GetRequest(URI);
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Get products successfully";
            testCase.URI = URI;
            testCase.Method = "GET";
            testCase.ExpectedStatus = 200;
            testCase.ActualStatus = (int)response.StatusCode;
            if (testCase.ExpectedStatus.Equals(testCase.ActualStatus))
            {
                testCase.TestResult = "Passed";
            }
            else
            {
                testCase.TestResult = "Failed";
            }
            testCase.ExportToTSVFile(TestReportLink);
            //Check result
            Assert.Equal(testCase.ExpectedStatus, testCase.ActualStatus);
        }
    }
}