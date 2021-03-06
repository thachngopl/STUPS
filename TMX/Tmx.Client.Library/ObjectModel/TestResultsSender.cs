﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/28/2014
 * Time: 4:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Library.ObjectModel
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using Core;
    using Core.Types.Remoting;
    using Interfaces;
    using Interfaces.Exceptions;
    using Interfaces.Server;
    using Helpers;
    using Spring.Rest.Client;
//using System.Collections.Generic;
    //using System.Xml.Linq;
    //using Spring.Http;

    /// <summary>
    /// Description of TestResultsSender.
    /// </summary>
    public class TestResultsSender
    {
        // volatile RestTemplate _restTemplate;
        readonly IRestOperations _restTemplate; // chrome-extension://aejoelaoggembcahagimdiliamlcdmfm/dhc.html#void
        
        //public TestResultsSender(IRestRequestCreator requestCreator)
        //{
        //    _restTemplate = requestCreator.GetRestTemplate();
        //}

        public TestResultsSender()
        {
            _restTemplate = RestRequestFactory.GetRestRequestCreator().GetRestTemplate();
        }
        
        public virtual bool SendTestResults()
        {
            Trace.TraceInformation("SendTestResults().1");
            
            var testResultsExporter = new TestResultsExporter();
            
            Trace.TraceInformation("SendTestResults().2");
            
            var xDoc = testResultsExporter.GetTestResultsAsXdocument(
                        new SearchCmdletBaseDataObject {
                            FilterAll = true
                        },
                        TestData.TestSuites,
                        TestData.TestPlatforms);
            
            Trace.TraceInformation("SendTestResults().3");
            
            var dataObject = new TestResultsDataObject {
                Data = xDoc.ToString()
            };
            
            Trace.TraceInformation("SendTestResults().4");
            
            try {
                var url = UrlList.TestResults_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrlList.TestResultsPostingPoint_forClient_relPath;
                
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("SendTestResults().5: testRun id = {0}, url = {1}", ClientSettings.Instance.CurrentClient.TestRunId, url);
                
                
                var sendingResultsResponse = _restTemplate.PostForMessage(url, dataObject);
                
                Trace.TraceInformation("SendTestResults().6 sendingResultsResponse is null? {0}", null == sendingResultsResponse);
                // 20150316
                if (null == sendingResultsResponse)
                    throw  new Exception("Failed to send test results.");
                
                return HttpStatusCode.Created == sendingResultsResponse.StatusCode;
            }
            catch (RestClientException eSendingTestResults) {
                // TODO: AOP
                Trace.TraceError("SendTestResults()");
                Trace.TraceError(eSendingTestResults.Message);
                throw new SendingTestResultsException("Failed to send test results. " + eSendingTestResults.Message);
            }
        }
    }
}
