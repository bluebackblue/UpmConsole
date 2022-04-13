

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


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
		/** s_setting
		*/
		public static Setting s_setting = null;

		/** s_action_file
		*/
		#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
		public static Action_File s_action_file = null;
		#endif

		/** s_action_syslog
		*/
		#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
		public static Action_Syslog s_action_syslog = null;
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
		{
			#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			if(s_action_file != null){
				s_action_file.Dispose();
				s_action_file = null;
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(s_action_syslog != null){
				s_action_syslog.Dispose();
				s_action_syslog = null;
			}
			#endif

			try{
				UnityEngine.TextAsset t_textasset = UnityEngine.Resources.Load<UnityEngine.TextAsset>(Config.SETTING_RESOURCES_PATH);
				if(t_textasset != null){
					string t_jsonstring = BlueBack.JsonItem.Convert.ConvertToNormailze(t_textasset.text);
					s_setting = BlueBack.JsonItem.Convert.JsonStringToObject<Setting>(t_jsonstring);

					#if(UNITY_EDITOR) && false
					DebugTool.EditorLog(string.Format("{0} {1}",t_setting.file.enable,t_setting.file.path));
					DebugTool.EditorLog(string.Format("{0} {1} {2}",t_setting.syslog.enable,t_setting.syslog.host,t_setting.syslog.port));
					#endif
				}else{
					s_setting = Setting.CreateDefault();
				}
			}catch(System.Exception){
				//シリアライズ中などはロードできない。
				s_setting = null;
			}

			if(s_setting != null){
				#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
				if(s_setting.file.enable == true){
					s_action_file = new Action_File(s_setting);
				}
				#endif

				#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
				if(s_setting.syslog.enable == true){
					s_action_syslog = new Action_Syslog(s_setting);
				}
				#endif
			}
		}

		/** Action
		*/
		public static void Action(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
			if(s_setting == null){
				LoadSetting();
			}

			#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			if(s_action_file != null){
				s_action_file.Action(a_text,a_stacktrace,a_type);
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(s_action_syslog != null){
				s_action_syslog.Action(a_text,a_stacktrace,a_type);
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
			if(s_action_file != null){
				s_action_file.Close();
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(s_action_syslog != null){
				s_action_syslog.Close();
			}
			#endif
		}

		/** Close
		*/
		public static void Close()
		{
			#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			if(s_action_file != null){
				s_action_file.Close();
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(s_action_syslog != null){
				s_action_syslog.Close();
			}
			#endif
		}
	}
}
#endif

