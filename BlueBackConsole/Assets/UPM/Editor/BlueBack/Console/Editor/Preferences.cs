

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
			#if(DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE)
			UnityEditor.EditorGUILayout.LabelField(string.Format("DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE : {0}","define"));
			#else
			UnityEditor.EditorGUILayout.LabelField(string.Format("FileStream : {0}",BlueBack.Console.FileWriter.s_filestream != null ? true : false));
			UnityEditor.EditorGUILayout.LabelField(string.Format("Enable : {0}",BlueBack.Console.FileWriter.s_enable));
			#endif
		}
	}
}
#endif

