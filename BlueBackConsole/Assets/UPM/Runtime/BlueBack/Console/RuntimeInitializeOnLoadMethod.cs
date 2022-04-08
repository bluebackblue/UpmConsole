

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
	/** RuntimeInitializeOnLoadMethod
	*/
	public static class RuntimeInitializeOnLoadMethod
	{
		#if(false)

		/** AfterAssembliesLoaded
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void AfterAssembliesLoaded()
		{
			FileWriter.SetCallBack();
		}

		/** AfterSceneLoad
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void AfterSceneLoad()
		{
			FileWriter.SetCallBack();
		}

		/** BeforeSceneLoad
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void BeforeSceneLoad()
		{
			FileWriter.SetCallBack();
		}

		/** BeforeSplashScreen
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void BeforeSplashScreen()
		{
			FileWriter.SetCallBack();
		}

		#endif

		/** SubsystemRegistration
		*/
		[UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void SubsystemRegistration()
		{
			CallBack.SetCallBack();
		}
	}
}
#endif

