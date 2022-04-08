

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。
*/


/** BlueBack.Console
*/
#if(!DEF_BLUEBACK_CONSOLE_DISABLE)
namespace BlueBack.Console
{
	/** Action_Syslog
	*/
	public sealed class Action_Syslog
	{
		/** udpclient
		*/
		private System.Net.Sockets.UdpClient udpclient;

		/** host
		*/
		private string host;

		/** port
		*/
		private int port;

		/** constructor
		*/
		public Action_Syslog(in Setting a_setting)
		{
			//udpclient
			this.udpclient = null;

			//host
			if(a_setting.syslog.host == null){
				this.host = "127.0.0.1";
			}else{
				this.host = a_setting.syslog.host;
			}

			//port
			if(a_setting.syslog.port == 0){
				this.port = 514;
			}else{
				this.port = a_setting.syslog.port;
			}
		}

		/** destructor
		*/
		~Action_Syslog()
		{
			if(this.udpclient != null){
				this.udpclient.Close();
				this.udpclient = null;
			}
		}

		/** Dispose
		*/
		public void Dispose()
		{
			if(this.udpclient != null){
				this.udpclient.Close();
				this.udpclient = null;
			}
		}

		/** Close
		*/
		public void Close()
		{
			if(this.udpclient != null){
				this.udpclient.Close();
				this.udpclient = null;
			}
		}

		/** Action
		*/
		public void Action(string a_text,string a_stacktrace,UnityEngine.LogType a_type)
		{
			if(this.udpclient == null){
				this.udpclient = new System.Net.Sockets.UdpClient(this.host,this.port);
			}

			byte[] t_binary = System.Text.Encoding.UTF8.GetBytes("host BlueBack.Console " + a_text + ":" + a_stacktrace);

			this.udpclient.Send(t_binary,t_binary.Length);
		}
	}
}
#endif

