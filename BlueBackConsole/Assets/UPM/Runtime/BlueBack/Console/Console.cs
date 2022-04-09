

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console

	UnityEngine.Resources.Load<UnityEngine.TextAsset>("BlueBackConsoleSetting")で設定ＪＳＯＮをロードしている。

*/
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
namespace BlueBack.Console
{
	/** Console
	*/
	public static class Console
	{
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

			Setting t_setting;
			{
				UnityEngine.TextAsset t_textasset = UnityEngine.Resources.Load<UnityEngine.TextAsset>(Config.SETTING_RESOURCES_PATH);
				if(t_textasset != null){
					string t_jsonstring = BlueBack.JsonItem.Convert.ConvertToNormailze(t_textasset.text);
					t_setting = BlueBack.JsonItem.Convert.JsonStringToObject<Setting>(t_jsonstring);

					#if(UNITY_EDITOR) && false
					DebugTool.EditorLog(string.Format("{0} {1}",t_setting.file.enable,t_setting.file.path));
					DebugTool.EditorLog(string.Format("{0} {1} {2}",t_setting.syslog.enable,t_setting.syslog.host,t_setting.syslog.port));
					#endif
				}else{
					t_setting = Setting.CreateDefault();
				}
			}

			#if(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			if(t_setting.file.enable == true){
				s_action_file = new Action_File(in t_setting);
			}
			#endif

			#if(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			if(t_setting.syslog.enable == true){
				s_action_syslog = new Action_Syslog(in t_setting);
			}
			#endif
		}

		/** Action
		*/
		public static void Action(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
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

