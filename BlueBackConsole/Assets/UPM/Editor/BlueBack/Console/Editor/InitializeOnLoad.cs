

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。エディター起動時。
*/


/** BlueBack.Console.Editor
*/
#if(UNITY_EDITOR)
#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_INITIALIZEONLOAD_DISABLE))
namespace BlueBack.Console.Editor
{
	/** InitializeOnLoad
	*/
	[UnityEditor.InitializeOnLoad]
	public static class InitializeOnLoad
	{
		/** static constructor
		*/
		static InitializeOnLoad()
		{
			 CallBack.SetCallBack();
		}
	}
}
#endif
#endif

