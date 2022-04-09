

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief Preferences
*/


/** BlueBack.Console.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.Console.Editor
{
	/** Preferences
	*/
	public sealed class Preferences : UnityEditor.SettingsProvider
	{
		/** CreateProvider
		*/
		[UnityEditor.SettingsProvider]
		public static UnityEditor.SettingsProvider CreateProvider()
		{
			return new Preferences();
		}

		/** constructor
		*/
		public Preferences()
			:
			base("BlueBack/BlueBack.Console",UnityEditor.SettingsScope.User)
		{
			this.keywords = new string[]{
				"BlueBack",
				"Console"
			};
		}

		/** OnGUI
		*/
		public override void OnGUI(string a_search_context)
		{
			#if(DEF_BLUEBACK_CONSOLE_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_DISABLE : {0}","1"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_DISABLE : {0}","0"));
			#endif

			#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE))
			UnityEditor.EditorGUILayout.LabelField(string.Format("File : filestream : {0}",BlueBack.Console.Console.s_action_file.filestream != null ? true : false));
			UnityEditor.EditorGUILayout.LabelField(string.Format("File : path : {0}",BlueBack.Console.Console.s_action_file.path != null ? BlueBack.Console.Console.s_action_file.path : ""));
			#endif

			#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE))
			UnityEditor.EditorGUILayout.LabelField(string.Format("File : myname : {0}",BlueBack.Console.Console.s_action_syslog.myname != null ? BlueBack.Console.Console.s_action_syslog.myname : ""));
			UnityEditor.EditorGUILayout.LabelField(string.Format("File : host : {0}",BlueBack.Console.Console.s_action_syslog.host != null ? BlueBack.Console.Console.s_action_syslog.host : ""));
			UnityEditor.EditorGUILayout.LabelField(string.Format("File : port : {0}",BlueBack.Console.Console.s_action_syslog.port));
			#endif
		}
	}
}
#endif

