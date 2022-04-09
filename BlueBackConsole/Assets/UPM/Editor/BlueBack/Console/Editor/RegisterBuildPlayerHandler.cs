

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。ビルド時。
*/


/** BlueBack.Console.Editor
*/
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
#if(UNITY_EDITOR)
namespace BlueBack.Console.Editor
{
	/** RegisterBuildPlayerHandler
	*/
	[UnityEditor.InitializeOnLoad]
	public static class RegisterBuildPlayerHandler
	{
		/** static constructor
		*/
		static RegisterBuildPlayerHandler()
		{
			UnityEditor.BuildPlayerWindow.RegisterBuildPlayerHandler(CallBack);
		}
 
		/** CallBack
		*/
		private static void CallBack(UnityEditor.BuildPlayerOptions a_option)
		{
			UnityEditor.BuildPipeline.BuildPlayer(a_option);
		}
	}
}
#endif
#endif

