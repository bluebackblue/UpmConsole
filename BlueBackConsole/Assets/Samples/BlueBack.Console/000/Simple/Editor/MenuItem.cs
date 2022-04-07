

/** BlueBack.Console.Samples.Simple.Editor
*/
namespace BlueBack.Console.Samples.Simple.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** ログ。
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.Console/Simple/Log")]
		private static void MenuItem_Log()
		{
			UnityEngine.Debug.Log("ログ");
		}

		/** エラー。
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.Console/Simple/LogError")]
		private static void MenuItem_LogError()
		{
			UnityEngine.Debug.LogError("エラー");
		}

		/** ワーニング。
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.Console/Simple/LogWarning")]
		private static void MenuItem_LogWarning()
		{
			UnityEngine.Debug.LogWarning("ワーニング");
		}
	}
	#endif
}

