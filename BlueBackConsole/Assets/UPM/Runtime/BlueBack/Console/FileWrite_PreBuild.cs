

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
#if(DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE)
#else
#if(UNITY_EDITOR)
namespace BlueBack.Console
{
	/** FileWrite_PreBuild
	*/
	[UnityEditor.InitializeOnLoad]
	public class FileWrite_PreBuild
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

