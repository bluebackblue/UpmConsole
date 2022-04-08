

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
#if(UNITY_EDITOR)
namespace BlueBack.Console
{
	/** MenuItem
	*/
	public static class MenuItem
	{
		/** MenuItem_Enable
		*/
		[UnityEditor.MenuItem("BlueBack/Console/CallBack/Enable")]
		private static void MenuItem_Enable()
		{
			CallBack.s_enable = true;
		}

		/** MenuItem_Disable
		*/
		[UnityEditor.MenuItem("BlueBack/Console/CallBack/Disable")]
		private static void MenuItem_Disable()
		{
			CallBack.s_enable = false;

			#if(!DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE)
			FileWriter.s_instance.CloseFileStream();
			#endif
		}

		/** MenuItem_CloseFile
		*/
		#if(!DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE)
		[UnityEditor.MenuItem("BlueBack/Console/FileWriter/CloseFile")]
		private static void MenuItem_CloseFile()
		{
			FileWriter.s_instance.CloseFileStream();
		}
		#endif
	}
}
#endif
#endif

