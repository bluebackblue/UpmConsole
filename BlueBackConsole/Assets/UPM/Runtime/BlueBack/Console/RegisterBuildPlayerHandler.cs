

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
	/** RegisterBuildPlayerHandler
	*/
	[UnityEditor.InitializeOnLoad]
	public static class RegisterBuildPlayerHandler
	{
		/** Initialize
		*/
		[UnityEditor.InitializeOnLoadMethod]
		private static void Initialize()
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

