﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/13/2014
 * Time: 9:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
	public enum TestTaskStatuses
	{
		New = 0,
		Accepted = 1,
		CompletedSuccessfully = 2,
		Failed = 3,
		Canceled = 4
	}
	
	public enum TestTaskExecutionTypes
	{
	    Inline = 0,
	    RemoteApp = 1,
	    PsRemoting = 2,
	    Ssh = 10
	}
	
	public enum ServerControlCommands
	{
	    LoadConfiguraiton = 0,
	    Reset = 1,
	    Stop = 2
	}
}