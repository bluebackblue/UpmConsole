

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
	public struct Setting
	{
		/** File
		*/
		public struct File
		{
			public bool enable;
			public string path;
		}

		/** Syslog
		*/
		public struct Syslog
		{
			public bool enable;
			public string host;
			public int port;
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
					enable = true,
					path = null,
				},
				syslog = new Syslog()
				{
					enable = false,
					host = "127.0.0.1",
					port = 514,
				}
			};
		}
	}
}

