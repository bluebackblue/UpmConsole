

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
#if(UNITY_EDITOR)
namespace BlueBack.Console
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

		/** MenuItem_FileClose
		*/
		[UnityEditor.MenuItem("BlueBack/Console/Close")]
		private static void MenuItem_Close()
		{
			Console.Close();
		}
	}
}
#endif
#endif

