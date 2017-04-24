using ClassLibrary;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Tests
{
	[TestClass]
	public class MyClassTest
	{
		#region Methods

		[TestMethod]
		public void GetValue_Test()
		{
			//var log = LogManager.GetLogger(typeof(MyClassTest));

			//if(log.IsInfoEnabled)
			//	log.Info("Test");

			Assert.AreEqual("Value", new MyClass().GetValue());
		}

		#endregion
	}
}