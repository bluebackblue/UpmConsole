
/** BlueBack.Console.Samples.Simple
*/
namespace BlueBack.Console.Samples.Simple
{
	/** Main_MonoBehaviour
	*/
    public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
    {
		/** Awake
		*/
		private void Awake()
		{
			UnityEngine.Debug.Log("BlueBack.Console.Samples.Simple.Main_MonoBehaviour.Awake start");

			#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_FILEWRITER_DISABLE))
			UnityEngine.Debug.Log("path = " + BlueBack.Console.FileWriter.s_instance.path);
			#endif

			UnityEngine.Debug.Log("BlueBack.Console.Samples.Simple.Main_MonoBehaviour.Awake end");
		}
	}
}

