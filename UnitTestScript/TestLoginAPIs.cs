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
    public class TestLoginsAPIs : UnitTestAPI
    {
        private readonly string TestReportLink = "C:\\Users\\Si\\source\\repos\\" +
                "Benri.APIs.Test\\TestReport\\testReport.tsv";
        [Fact]
        public async Task TestLogin_Successfully()
        {
            string URI = "api/Logins";

            Account inputData = new Account();
            inputData.UserName = "testAPI";
            inputData.Password = "123456x@X";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Log in successfully";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
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
        [Fact]
        public async Task TestLogin_Failed_WrongPassword()
        {
            string URI = "api/Logins";

            Account inputData = new Account();
            inputData.UserName = "testAPI";
            inputData.Password = "123456x@X222";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "Invalid credentials";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Log in failed with wrong password";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
            testCase.ExpectedStatus = 400;
            testCase.ActualStatus = (int)response.StatusCode;
            testCase.ExpectedMessage = expectedMessage;
            testCase.ActualMessage = responseMessage;
            if (testCase.ExpectedMessage.Equals(testCase.ActualMessage) &&
               testCase.ExpectedStatus.Equals(testCase.ActualStatus))
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
        [Fact]
        public async Task TestLogin_Failed_WrongUserName()
        {
            string URI = "api/Logins";

            Account inputData = new Account();
            inputData.UserName = "testAPI222";
            inputData.Password = "123456x@X";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "Invalid credentials";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Log in failed with wrong username";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
            testCase.ExpectedStatus = 400;
            testCase.ActualStatus = (int)response.StatusCode;
            testCase.ExpectedMessage = expectedMessage;
            testCase.ActualMessage = responseMessage;
            if (testCase.ExpectedMessage.Equals(testCase.ActualMessage) &&
               testCase.ExpectedStatus.Equals(testCase.ActualStatus))
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
        [Fact]
        public async Task TestLogin_Failed_NullUserName()
        {
            string URI = "api/Logins";

            Account inputData = new Account();
            inputData.UserName = null;
            inputData.Password = "123456x@X";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "Some parameter is null";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Log in failed with null username";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
            testCase.ExpectedStatus = 400;
            testCase.ActualStatus = (int)response.StatusCode;
            testCase.ExpectedMessage = expectedMessage;
            testCase.ActualMessage = responseMessage;
            if (testCase.ExpectedMessage.Equals(testCase.ActualMessage) &&
               testCase.ExpectedStatus.Equals(testCase.ActualStatus))
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
        [Fact]
        public async Task TestLogin_Failed_NullPassword()
        {
            string URI = "api/Logins";

            Account inputData = new Account();
            inputData.UserName = "testAPI";
            inputData.Password = null;
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "Some parameter is null";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Log in failed with null password";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
            testCase.ExpectedStatus = 400;
            testCase.ActualStatus = (int)response.StatusCode;
            testCase.ExpectedMessage = expectedMessage;
            testCase.ActualMessage = responseMessage;
            if (testCase.ExpectedMessage.Equals(testCase.ActualMessage) &&
               testCase.ExpectedStatus.Equals(testCase.ActualStatus))
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