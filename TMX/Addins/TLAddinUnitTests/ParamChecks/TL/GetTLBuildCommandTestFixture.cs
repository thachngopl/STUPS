﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 8:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.CheckCmdletParameters
{
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetTLBuildCommand.
    /// </summary>
    [TestFixture]
    public class GetTLBuildCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLBuild_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLBuild;");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLBuild_Name()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLBuild -Name '1.2.3.4';");
        }
        
        [Test]
        [Category("Fast")]
        public void Get_TLBuild_Id()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                "Get-TLBuild -Id 123;");
        }
    }
}
