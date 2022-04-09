

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。インストール。
*/


/** BlueBack.Console.Editor
*/
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
#if(UNITY_EDITOR)
namespace BlueBack.Console.Editor
{
	/** Install
	*/
	[UnityEditor.InitializeOnLoad]
	public static class Install
	{
		/** static constructor
		*/
		static Install()
		{
			UnityEngine.TextAsset t_textasset = UnityEngine.Resources.Load<UnityEngine.TextAsset>(Config.SETTING_RESOURCES_PATH);
			if(t_textasset == null){
				InstallMain();
			}
		}

		/** InstallMain
		*/
		public static void InstallMain()
		{
			Setting t_setting = Setting.CreateDefault();
			string t_jsonstring = BlueBack.JsonItem.Convert.ObjectToJsonString(t_setting);
			BlueBack.AssetLib.Editor.CreateDirectoryWithAssetsPath.Create("Resources");
			BlueBack.AssetLib.Editor.SaveTextWithAssetsPath.SaveNoBomUtf8(t_jsonstring,"Resources/" + Config.SETTING_RESOURCES_PATH + ".json",AssetLib.LineFeedOption.CRLF);

			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
}
#endif
#endif

