﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
	using System;
	using System.Management.Automation;
	using TMX;
	using TMX.Client.Helpers.Commands;
	
	/// <summary>
	/// Description of RegisterTmxSystemUnderTestCommand.
	/// </summary>
	[Cmdlet(VerbsLifecycle.Register, "TmxSystemUnderTest")]
	public class RegisterTmxSystemUnderTestCommand : CommonCmdletBase
	{
	    [Parameter(Mandatory = true)]
	    public string ServerUrl { get; set; }
	    
		protected override void BeginProcessing()
		{
			var command = new RegisterSystemUnderTestCommand(this);
			command.Execute();
		}
	}
}