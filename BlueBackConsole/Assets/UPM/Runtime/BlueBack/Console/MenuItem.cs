

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
namespace BlueBack.Console
{
	/** MenuItem
	*/
	public static class MenuItem
	{
		/** MenuItem_Enable
		*/
		#if(UNITY_EDITOR)
		[UnityEditor.MenuItem("BlueBack/Console/CallBack/Enable")]
		private static void MenuItem_Enable()
		{
			CallBack.s_enable = true;
		}
		#endif

		/** MenuItem_Disable
		*/
		#if(UNITY_EDITOR)
		[UnityEditor.MenuItem("BlueBack/Console/CallBack/Disable")]
		private static void MenuItem_Disable()
		{
			CallBack.s_enable = false;
			FileWriter.CloseFileStream();
		}
		#endif

		/** MenuItem_CloseFile
		*/
		#if(UNITY_EDITOR)
		[UnityEditor.MenuItem("BlueBack/Console/FileWriter/CloseFile")]
		private static void MenuItem_CloseFile()
		{
			FileWriter.CloseFileStream();
		}
		#endif
	}
}
#endif

