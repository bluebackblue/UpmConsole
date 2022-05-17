

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_JSONITEM)||(USERDEF_BLUEBACK_JSONITEM))
#define ASMDEF_TRUE
#endif


/** BlueBack.Console

	Config.SETTING_RESOURCES_PATHから設定をロードしている。

*/
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
namespace BlueBack.Console
{
	/** Console
	*/
	public static class Console
	{
		/** setting
		*/
		public static Setting setting = null;

		/** action_file
		*/
		#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
		public static Action_File action_file = null;
		#endif

		/** action_syslog
		*/
		#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
		public static Action_Syslog action_syslog = null;
		#endif

		/** static constructor
		*/
		static Console()
		{
			LoadSetting();
		}

		/** LoadSetting
		*/
		public static void LoadSetting()
		#if(ASMDEF_TRUE)
		{
			#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			if(Console.action_file != null){
				Console.action_file.Dispose();
				Console.action_file = null;
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(Console.action_syslog != null){
				Console.action_syslog.Dispose();
				Console.action_syslog = null;
			}
			#endif

			try{
				UnityEngine.TextAsset t_textasset = UnityEngine.Resources.Load<UnityEngine.TextAsset>(Config.SETTING_RESOURCES_PATH);
				if(t_textasset != null){
					string t_jsonstring = BlueBack.JsonItem.Convert.ConvertToNormailze(t_textasset.text);
					Console.setting = BlueBack.JsonItem.Convert.JsonStringToObject<Setting>(t_jsonstring);
				}else{
					Console.setting = Setting.CreateDefault();
				}
			}catch(System.Exception){
				//シリアライズ中などはロードできない。
				Console.setting = null;
			}

			if(Console.setting != null){
				#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
				if(Console.setting.file.enable == true){
					Console.action_file = new Action_File(Console.setting);
				}
				#endif

				#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
				if(Console.setting.syslog.enable == true){
					Console.action_syslog = new Action_Syslog(Console.setting);
				}
				#endif
			}
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif

		/** Action
		*/
		public static void Action(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
			if(Console.setting == null){
				LoadSetting();
			}

			#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			if(Console.action_file != null){
				Console.action_file.Action(a_text,a_stacktrace,a_type);
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(Console.action_syslog != null){
				Console.action_syslog.Action(a_text,a_stacktrace,a_type);
			}
			#endif
		}

		/** Enable
		*/
		public static void Enable()
		{
			CallBack.SetCallBack();
		}

		/** Disable
		*/
		public static void Disable()
		{
			CallBack.UnSetCallBack();

			#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			if(Console.action_file != null){
				Console.action_file.Close();
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(Console.action_syslog != null){
				Console.action_syslog.Close();
			}
			#endif
		}

		/** Close
		*/
		public static void Close()
		{
			#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			if(Console.action_file != null){
				Console.action_file.Close();
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(Console.action_syslog != null){
				Console.action_syslog.Close();
			}
			#endif
		}
	}
}
#endif

