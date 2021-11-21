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
    public class TestAccountAPIs : UnitTestAPI
    {
        private readonly string TestReportLink = "C:\\Users\\Si\\source\\repos\\" +
                "Benri.APIs.Test\\TestReport\\testReport.tsv";
        [Fact]
        public async Task TestCreateAccount_FullValues_Successful()
        {
            string URI = "api/Accounts/CreateAccount";

            Account inputData = new Account();
            inputData.UserName = CreateUniqueUserName();
            inputData.Password = "123456x@X";
            inputData.Role = "Admin";
            inputData.PhoneNumber = "0949690002";
            inputData.FullName = "Do Trong Si";
            inputData.Address = "HCM City";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "Add account is successful";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Create account with full values (successful)";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
            testCase.ExpectedStatus = 200;
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
            Assert.Contains(expectedMessage, responseMessage);
            
        }
        [Fact]
        public async Task TestCreateAccount_FullValues_UserNameExisting()
        {
            string URI = "api/Accounts/CreateAccount";

            Account inputData = new Account();
            inputData.UserName = "TestAPI";
            inputData.Password = "123456x@X";
            inputData.Role = "Admin";
            inputData.PhoneNumber = "0949690002";
            inputData.FullName = "Do Trong Si";
            inputData.Address = "HCM City";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "This user name is existed";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Create account with full values (user name is existed)";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
            testCase.ExpectedStatus = 409;
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
            Assert.Contains(expectedMessage, responseMessage);
        }
        [Fact]
        public async Task TestCreateAccount_RequiredValues_Successful()
        {
            string URI = "api/Accounts/CreateAccount";

            Account inputData = new Account();
            inputData.UserName = CreateUniqueUserName();
            inputData.Password = "123456x@X";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "Add account is successful";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Create account with required values (successful)";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
            testCase.ExpectedStatus = 200;
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
            Assert.Contains(expectedMessage, responseMessage);
        }
        [Fact]
        public async Task TestCreateAccount_RequiredValues_UserNameExisting()
        {
            string URI = "api/Accounts/CreateAccount";

            Account inputData = new Account();
            inputData.UserName = "TestAPI";
            inputData.Password = "123456x@X";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "This user name is existed";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Create account with required values (user name is existed)";
            testCase.URI = URI;
            testCase.Method = "POST";
            testCase.Body = inputData;
            testCase.ExpectedStatus = 409;
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
            Assert.Contains(expectedMessage, responseMessage);
        }
        [Fact]
        public async Task TestCreateAccount_NotRequiredValues_WithoutUserName()
        {
            string URI = "api/Accounts/CreateAccount";

            Account inputData = new Account();
            inputData.Password = "123456x@X";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "Error in CreateAccount()";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Create account with not required values (without username)";
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
            Assert.Contains(expectedMessage, responseMessage);
        }
        [Fact]
        public async Task TestCreateAccount_NotRequiredValues_WithoutPassword()
        {
            string URI = "api/Accounts/CreateAccount";

            Account inputData = new Account();
            inputData.UserName = "123456x@X";
            //Get result
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = GetMessageClearly(response);
            var expectedMessage = "Error in CreateAccount()";
            //Export to csv file
            TestCase testCase = new TestCase();
            testCase.Description = "Create account with not required values (without password)";
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
            Assert.Contains(expectedMessage, responseMessage);
        }
    }
}
