

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
	/** CallBack
	*/
	public static class CallBack
	{
		/** inner
		*/
		private static bool inner = false;

		/** SetCallBack
		*/
		public static void SetCallBack()
		{
			UnityEngine.Application.logMessageReceived -= Inner_CallBack;
			UnityEngine.Application.logMessageReceived += Inner_CallBack;
		}

		/** SetCallBack
		*/
		public static void UnSetCallBack()
		{
			UnityEngine.Application.logMessageReceived -= Inner_CallBack;
		}

		/** Inner_CallBack
		*/
		private static void Inner_CallBack(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
			if(CallBack.inner == false){
				CallBack.inner = true;
				try{
					Console.Action(a_text,a_stacktrace,a_type);
				}finally{
					CallBack.inner = false;
				}
			}
		}
	}
}
#endif

