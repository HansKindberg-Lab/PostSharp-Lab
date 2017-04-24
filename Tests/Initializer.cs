using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public static class Initializer
	{
		#region Methods

		[AssemblyInitialize]
		public static void Initialize(TestContext testContext)
		{
			var loggerRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			var configured = loggerRepository.Configured;

			if(!configured)
				XmlConfigurator.Configure(loggerRepository, new FileInfo(Path.Combine(AppContext.BaseDirectory, "log4net.config")));
			//System.Diagnostics.Debug.Write("Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitialize");
		}

		#endregion
	}
}