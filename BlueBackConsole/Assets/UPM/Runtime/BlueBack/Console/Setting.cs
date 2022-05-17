

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
namespace BlueBack.Console
{
	/** Setting
	*/
	public class Setting
	{
		/** File
		*/
		public struct File
		{
			/** 有効フラグ。
			*/
			public bool enable;

			/** 出力。

				output_path == null : UnityEngine.Application.dataPath が設定される。

			*/
			public string output_path;
			public string output_filename;
		}

		/** Syslog
		*/
		public struct Syslog
		{
			/** 有効フラグ。
			*/
			public bool enable;

			/** サーバー。
			*/
			public string server_name;
			public int server_port;

			/** タグ。

				tag : 32文字以内。

			*/
			public string tag;
		}

		/** file
		*/
		public File file;

		/** syslog
		*/
		public Syslog syslog;

		/** CreateDefault
		*/
		public static Setting CreateDefault()
		{
			return new Setting()
			{
				file = new File()
				{
					enable = false,
					output_path = null,
					output_filename = "consolelog.txt",
				},
				syslog = new Syslog()
				{
					enable = false,
					server_name = "127.0.0.1",
					server_port = 514,
					tag = "Unity",
				}
			};
		}
	}
}

