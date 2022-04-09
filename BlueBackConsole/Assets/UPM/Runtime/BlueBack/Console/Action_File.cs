

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。ファイル。
*/


/** BlueBack.Console
*/
#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE))
namespace BlueBack.Console
{
	/** Action_File
	*/
	public sealed class Action_File
	{
		/** filestream
		*/
		public System.IO.FileStream filestream;

		/** path
		*/
		public string path;

		/** constructor
		*/
		public Action_File(in Setting a_setting)
		{
			//filestream
			this.filestream = null;

			//path
			if(a_setting.file.path == null){
				this.path = UnityEngine.Application.dataPath + "/" + a_setting.file.filename;
			}else{
				this.path = a_setting.file.path + "/" + a_setting.file.filename;
			}
		}

		/** destructor
		*/
		~Action_File()
		{
			if(this.filestream != null){
				this.filestream.Flush(true);
				this.filestream.Close();
				this.filestream = null;
			}
		}

		/** Dispose
		*/
		public void Dispose()
		{
			if(this.filestream != null){
				this.filestream.Flush(true);
				this.filestream.Close();
				this.filestream = null;
			}
		}

		/** Close
		*/
		public void Close()
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

			byte[] t_binary = System.Text.Encoding.UTF32.GetBytes(a_text + "\n" + a_stacktrace + "\n");

			this.filestream.Write(t_binary);
			this.filestream.Flush(true);
		}
	}
}
#endif

