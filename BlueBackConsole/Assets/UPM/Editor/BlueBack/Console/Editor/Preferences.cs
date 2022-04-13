

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
			UnityEditor.EditorGUILayout.LabelField(string.Format("{0}","機能を無効化する。"));
			#if(DEF_BLUEBACK_CONSOLE_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format(" DEF_BLUEBACK_CONSOLE_DISABLE : {0}","1"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_DISABLE : {0}","0"));
			#endif
			UnityEditor.EditorGUILayout.Separator();

			UnityEditor.EditorGUILayout.LabelField(string.Format("{0}","ファイル出力を無効化する。"));
			#if(DEF_BLUEBACK_CONSOLE_FILE_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_FILE_DISABLE : {0}","1"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_FILE_DISABLE : {0}","0"));
			#endif
			UnityEditor.EditorGUILayout.Separator();

			UnityEditor.EditorGUILayout.LabelField(string.Format("{0}","送信を無効化する。"));
			#if(DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE : {0}","1"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE : {0}","0"));
			#endif
			UnityEditor.EditorGUILayout.Separator();

			UnityEditor.EditorGUILayout.LabelField(string.Format("{0}","エディター起動時の自動インストールを無効化する。"));
			#if(DEF_BLUEBACK_CONSOLE_INSTALL_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_INSTALL_DISABLE : {0}","1"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_INSTALL_DISABLE : {0}","0"));
			#endif
			UnityEditor.EditorGUILayout.Separator();

			UnityEditor.EditorGUILayout.LabelField(string.Format("{0}","ゲーム開始時の初期化を無効化する。"));
			#if(DEF_BLUEBACK_CONSOLE_RUNTIMEINITIALIZE_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_RUNTIMEINITIALIZE_DISABLE : {0}","1"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_RUNTIMEINITIALIZE_DISABLE : {0}","0"));
			#endif
			UnityEditor.EditorGUILayout.Separator();

			UnityEditor.EditorGUILayout.LabelField(string.Format("{0}","エディター起動時の初期化を無効化する。"));
			#if(DEF_BLUEBACK_CONSOLE_INITIALIZEONLOAD_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_INITIALIZEONLOAD_DISABLE : {0}","1"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_INITIALIZEONLOAD_DISABLE : {0}","0"));
			#endif
			UnityEditor.EditorGUILayout.Separator();

			UnityEditor.EditorGUILayout.LabelField(string.Format("{0}","ビルド時の初期化を無効化する。"));
			#if(DEF_BLUEBACK_CONSOLE_BUILDPIPELINE_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_BUILDPIPELINE_DISABLE : {0}","1"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_BUILDPIPELINE_DISABLE : {0}","0"));
			#endif
			UnityEditor.EditorGUILayout.Separator();

			#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_FILE_DISABLE))
			if(BlueBack.Console.Console.s_action_file == null){
				UnityEditor.EditorGUILayout.LabelField(string.Format("File : instance : {0}","null"));
			}else{
				UnityEditor.EditorGUILayout.LabelField(string.Format("File : filestream : {0}",BlueBack.Console.Console.s_action_file.filestream != null ? "open" : "null"));
				UnityEditor.EditorGUILayout.LabelField(string.Format("File : path : {0}",BlueBack.Console.Console.s_action_file.path != null ? BlueBack.Console.Console.s_action_file.path : "null"));
			}
			#endif
			UnityEditor.EditorGUILayout.Separator();

			#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE))
			if(BlueBack.Console.Console.s_action_syslog == null){
				UnityEditor.EditorGUILayout.LabelField(string.Format("Syslog : instance : {0}","null"));
			}else{
				UnityEditor.EditorGUILayout.LabelField(string.Format("Syslog : udpclient : {0}",BlueBack.Console.Console.s_action_syslog.udpclient != null ? "open" : "null"));
				UnityEditor.EditorGUILayout.LabelField(string.Format("Syslog : myname : {0}",BlueBack.Console.Console.s_action_syslog.myname != null ? BlueBack.Console.Console.s_action_syslog.myname : "null"));
				UnityEditor.EditorGUILayout.LabelField(string.Format("Syslog : server_name : {0}",BlueBack.Console.Console.s_action_syslog.server_name != null ? BlueBack.Console.Console.s_action_syslog.server_name : "null"));
				UnityEditor.EditorGUILayout.LabelField(string.Format("Syslog : server_port : {0}",BlueBack.Console.Console.s_action_syslog.server_port));
			}
			#endif
		}
	}
}
#endif

