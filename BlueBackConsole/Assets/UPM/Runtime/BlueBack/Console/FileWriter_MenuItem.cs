

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
#if(DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE)
#else
namespace BlueBack.Console
{
	/** FileWriter_MenuItem
	*/
	public static class FileWriter_MenuItem
	{
		/** MenuItem_Enable
		*/
		#if(UNITY_EDITOR)
		[UnityEditor.MenuItem("BlueBack/Console/FileWriter/Enable")]
		private static void MenuItem_Enable()
		{
			FileWriter.s_enable = true;
		}
		#endif

		/** MenuItem_Disable
		*/
		#if(UNITY_EDITOR)
		[UnityEditor.MenuItem("BlueBack/Console/FileWriter/Disable")]
		private static void MenuItem_Disable()
		{
			FileWriter.s_enable = false;

			if(FileWriter.s_filestream != null){
				FileWriter.s_filestream.Flush(true);
				FileWriter.s_filestream.Close();
				FileWriter.s_filestream = null;
			}
		}
		#endif

		/** MenuItem_CloseFile
		*/
		#if(UNITY_EDITOR)
		[UnityEditor.MenuItem("BlueBack/Console/FileWriter/CloseFile")]
		private static void MenuItem_CloseFile()
		{
			if(FileWriter.s_filestream != null){
				FileWriter.s_filestream.Flush(true);
				FileWriter.s_filestream.Close();
				FileWriter.s_filestream = null;
			}
		}
		#endif
	}
}
#endif

