

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
#if(!DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE)
namespace BlueBack.Console
{
	/** FileWriter_RuntimeInitializeOnLoadMethod
	*/
	public class FileWriter_RuntimeInitializeOnLoadMethod
	{
		/** Initialize
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
			UnityEngine.Application.logMessageReceived += FileWriter.CallBack;
		}
	}
}
#endif

