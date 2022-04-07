

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
	public static class FileWriter
	{
		/** s_inner
		*/
		private static bool s_inner = false;

		/** s_filestream
		*/
		public static System.IO.FileStream s_filestream = null;

		/** s_exiter
		*/
		public static FileWriter_Exiter s_exiter;

		/** s_enable
		*/
		public static bool s_enable = true;

		/** s_path
		*/
		public static string s_path = UnityEngine.Application.dataPath + "/consolelog.txt";

		/** static constructor
		*/
		static FileWriter()
		{
			UnityEngine.Application.logMessageReceived += CallBack;
		}

		/** CallBack
		*/
		public static void CallBack(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
			if(s_enable == true){
				if(s_inner == false){
					s_inner = true;

					try{
						if(s_exiter == null){
							s_exiter = new FileWriter_Exiter();
						}

						if(s_filestream == null){
							s_filestream = System.IO.File.Open(s_path,System.IO.FileMode.Append,System.IO.FileAccess.Write,System.IO.FileShare.ReadWrite);
						}

						byte[] t_binary = System.Text.Encoding.UTF8.GetBytes(a_text + "\n" + a_stacktrace + "\n");

						s_filestream.Write(t_binary);
						s_filestream.Flush(true);
					}finally{
						s_inner = false;
					}
				}
			}
		}
	}
}
#endif

