

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
	/** FileWriter_Exiter
	*/
	public sealed class FileWriter_Exiter
	{
		/** destructor
		*/
		~FileWriter_Exiter()
		{
			if(FileWriter.s_filestream != null){
				FileWriter.s_filestream.Flush(true);
				FileWriter.s_filestream.Close();
				FileWriter.s_filestream = null;
				FileWriter.s_exiter = null;
			}
		}
	}
}
#endif

