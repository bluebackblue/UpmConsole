

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
	/** FileWriter
	*/
	#if(UNITY_EDITOR)
	[UnityEditor.InitializeOnLoad]
	#endif
	public static class FileWriter_InitializeOnLoad
	{
		/** static constructor
		*/
		static FileWriter_InitializeOnLoad()
		{
			UnityEngine.Application.logMessageReceived += FileWriter.CallBack;
		}
	}
}
#endif

