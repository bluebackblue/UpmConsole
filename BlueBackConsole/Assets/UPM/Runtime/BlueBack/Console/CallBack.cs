

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
		/** s_inner
		*/
		private static bool s_inner = false;

		/** s_exiter
		*/
		public static Exiter s_exiter;

		/** s_enable
		*/
		public static bool s_enable = true;

		/** s_callback
		*/
		public static bool s_callback = false;

		/** SetCallBack
		*/
		public static void SetCallBack()
		{
			if(s_callback == false){
				s_callback = true;
				UnityEngine.Application.logMessageReceived += Inner_CallBack;
			}
		}

		/** SetCallBack
		*/
		public static void UnSetCallBack()
		{
			if(s_callback == true){
				s_callback = false;
				UnityEngine.Application.logMessageReceived -= Inner_CallBack;
			}
		}

		/** Inner_CallBack
		*/
		private static void Inner_CallBack(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
			if(s_enable == true){
				if(s_inner == false){
					s_inner = true;
					try{
						if(s_exiter == null){
							s_exiter = new Exiter();
						}

						FileWriter.s_instance.Action(a_text,a_stacktrace,a_type);
					}finally{
						s_inner = false;
					}
				}
			}
		}
	}
}
#endif

