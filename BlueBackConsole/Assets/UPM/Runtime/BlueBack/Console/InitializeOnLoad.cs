

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
	/** InitializeOnLoad
	*/
	#if(UNITY_EDITOR)
	[UnityEditor.InitializeOnLoad]
	#endif
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

