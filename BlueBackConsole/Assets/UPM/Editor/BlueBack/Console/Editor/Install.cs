

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief インストール。
*/


/** BlueBack.Console.Editor
*/
#if(UNITY_EDITOR)
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
namespace BlueBack.Console.Editor
{
	/** Install
	*/
	#if(!DEF_BLUEBACK_CONSOLE_INSTALL_DISABLE)
	[UnityEditor.InitializeOnLoad]
	#endif
	public static class Install
	{
		/** static constructor
		*/
		static Install()
		{
			//自動インストール。
			#if(!DEF_BLUEBACK_CONSOLE_INSTALL_DISABLE)
			UnityEngine.TextAsset t_textasset = UnityEngine.Resources.Load<UnityEngine.TextAsset>(Config.SETTING_RESOURCES_PATH);
			if(t_textasset == null){
				InstallMain();
			}
			#endif
		}

		/** InstallMain
		*/
		public static void InstallMain()
		{
			Setting t_setting = Setting.CreateDefault();
			string t_jsonstring = BlueBack.JsonItem.Convert.ObjectToJsonString(t_setting);

			string t_path = "Resources/" + Config.SETTING_RESOURCES_PATH + ".json";
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create(System.IO.Path.GetDirectoryName(t_path));
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_jsonstring,t_path,AssetLib.LineFeedOption.CRLF);

			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
}
#endif
#endif

