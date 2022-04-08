

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
	/** Console
	*/
	public static class Console
	{
		/** s_action_file
		*/
		public static Action_File s_action_file = null;

		/** s_action_syslog
		*/
		public static Action_Syslog s_action_syslog = null;

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
			if(s_action_file != null){
				s_action_file.Dispose();
				s_action_file = null;
			}

			if(s_action_syslog != null){
				s_action_syslog.Dispose();
				s_action_syslog = null;
			}

			Setting t_setting;
			{
				UnityEngine.TextAsset t_textasset = UnityEngine.Resources.Load<UnityEngine.TextAsset>("BlueBackConsoleSetting");
				if(t_textasset != null){
					string t_jsonstring = BlueBack.JsonItem.Convert.ConvertToNormailze(t_textasset.text);
					t_setting = BlueBack.JsonItem.Convert.JsonStringToObject<Setting>(t_jsonstring);

					/*
					#if(UNITY_EDITOR)
					DebugTool.EditorLog(string.Format("{0}{1}",t_setting.file.enable,t_setting.file.path));
					DebugTool.EditorLog(string.Format("{0}{1}{2}",t_setting.syslog.enable,t_setting.syslog.host,t_setting.syslog.port));
					#endif
					*/
				}else{
					t_setting = Setting.CreateDefault();
				}
			}

			if(t_setting.file.enable == true){
				s_action_file = new Action_File(in t_setting);
			}

			if(t_setting.syslog.enable == true){
				s_action_syslog = new Action_Syslog(in t_setting);
			}
		}

		/** Action
		*/
		public static void Action(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
			if(s_action_file != null){
				s_action_file.Action(a_text,a_stacktrace,a_type);
			}
			if(s_action_syslog != null){
				s_action_syslog.Action(a_text,a_stacktrace,a_type);
			}
		}

		/** Enable
		*/
		public static void Enable()
		{
			CallBack.s_enable = true;
		}

		/** Disable
		*/
		public static void Disable()
		{
			CallBack.s_enable = false;

			if(s_action_file != null){
				s_action_file.Close();
			}

			if(s_action_syslog != null){
				s_action_syslog.Close();
			}
		}

		/** Close
		*/
		public static void Close()
		{
			if(s_action_file != null){
				s_action_file.Close();
			}

			if(s_action_syslog != null){
				s_action_syslog.Close();
			}
		}
	}
}
#endif
