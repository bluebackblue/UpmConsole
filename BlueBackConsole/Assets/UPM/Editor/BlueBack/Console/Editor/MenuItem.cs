

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief メニュー。
*/


/** BlueBack.Console.Editor
*/
#if(UNITY_EDITOR)
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
namespace BlueBack.Console.Editor
{
	/** MenuItem
	*/
	public static class MenuItem
	{
		/** MenuItem_Enable
		*/
		[UnityEditor.MenuItem("BlueBack/Console/Enable")]
		private static void MenuItem_Enable()
		{
			Console.Enable();
		}

		/** MenuItem_Disable
		*/
		[UnityEditor.MenuItem("BlueBack/Console/Disable")]
		private static void MenuItem_Disable()
		{
			Console.Disable();
		}

		/** MenuItem_Disable
		*/
		[UnityEditor.MenuItem("BlueBack/Console/LoadSetting")]
		private static void MenuItem_LoadSetting()
		{
			Console.LoadSetting();
		}

		/** MenuItem_Close
		*/
		[UnityEditor.MenuItem("BlueBack/Console/Close")]
		private static void MenuItem_Close()
		{
			Console.Close();
		}

		/** MenuItem_Install
		*/
		[UnityEditor.MenuItem("BlueBack/Console/Install")]
		private static void MenuItem_Install()
		{
			Install.InstallMain();
		}
	}
}
#endif
#endif

