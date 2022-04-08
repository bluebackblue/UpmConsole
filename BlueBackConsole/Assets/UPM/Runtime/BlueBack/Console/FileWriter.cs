

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE))
namespace BlueBack.Console
{
	/** FileWriter
	*/
	public sealed class FileWriter
	{
		/** s_instance
		*/
		public static FileWriter s_instance = new FileWriter();

		/** filestream
		*/
		public System.IO.FileStream filestream;

		/** path
		*/
		public string path;

		/** constructor
		*/
		public FileWriter()
		{
			//filestream
			this.filestream = null;

			//path
			this.path = UnityEngine.Application.dataPath + "/consolelog.txt";
		}

		/** destructor
		*/
		~FileWriter()
		{
			if(this.filestream != null){
				this.filestream.Flush(true);
				this.filestream.Close();
				this.filestream = null;
			}
		}

		/** CloseFileStream
		*/
		public void CloseFileStream()
		{
			if(this.filestream != null){
				this.filestream.Flush(true);
				this.filestream.Close();
				this.filestream = null;
			}
		}

		/** Action
		*/
		public void Action(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
			if(this.filestream == null){
				this.filestream = System.IO.File.Open(this.path,System.IO.FileMode.Append,System.IO.FileAccess.Write,System.IO.FileShare.ReadWrite);
			}

			byte[] t_binary = System.Text.Encoding.UTF8.GetBytes(a_text + "\n" + a_stacktrace + "\n");

			this.filestream.Write(t_binary);
			this.filestream.Flush(true);
		}
	}
}
#endif

