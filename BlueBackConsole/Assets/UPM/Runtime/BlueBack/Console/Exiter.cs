

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
	/** Exiter
	*/
	public sealed class Exiter
	{
		/** destructor
		*/
		~Exiter()
		{
			FileWriter.CloseFileStream();
			CallBack.s_exiter = null;
		}
	}
}
#endif

