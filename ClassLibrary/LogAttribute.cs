using log4net;
using PostSharp.Aspects;
using PostSharp.Serialization;

[assembly: ClassLibrary.Log] // An example for the whole assembly.
namespace ClassLibrary
{
	[Log(AttributeExclude = true)] // Excludes this class from code injection.
	[PSerializable]
	public class LogAttribute : OnMethodBoundaryAspect
	{
		#region Fields

		private static ILog _log;

		#endregion

		#region Properties

		protected internal virtual ILog Log
		{
			get { return _log ?? (_log = LogManager.GetLogger(typeof(LogAttribute))); }
			set { _log = value; }
		}

		#endregion
		
		#region Methods

		public sealed override void OnEntry(MethodExecutionArgs args)
		{
			if (this.Log.IsInfoEnabled)
				this.Log.InfoFormat("Entering the method \"{0}\".", args.Method.Name);
		}

		public sealed override void OnException(MethodExecutionArgs args)
		{
			if (this.Log.IsErrorEnabled)
				this.Log.Error("There was an exception.", args.Exception);
		}

		public sealed override void OnExit(MethodExecutionArgs args)
		{
			if (this.Log.IsInfoEnabled)
				this.Log.InfoFormat("Exiting the method \"{0}\".", args.Method.Name);
		}

		#endregion
	}
}