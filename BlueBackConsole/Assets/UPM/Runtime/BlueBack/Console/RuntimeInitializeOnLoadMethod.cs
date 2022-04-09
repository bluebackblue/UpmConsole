

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

