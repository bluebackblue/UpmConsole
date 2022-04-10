

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ビルド時。
*/


/** BlueBack.Console.Editor
*/
#if(UNITY_EDITOR)
#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_BUILDPIPELINE_DISABLE))
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
			UnityEditor.BuildPlayerWindow.RegisterBuildPlayerHandler(Inner_CallBack);
		}
 
		/** Inner_CallBack
		*/
		private static void Inner_CallBack(UnityEditor.BuildPlayerOptions a_option)
		{
			UnityEditor.BuildPipeline.BuildPlayer(a_option);
		}
	}
}
#endif
#endif

