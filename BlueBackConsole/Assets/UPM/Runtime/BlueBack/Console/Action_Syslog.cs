

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンソール。syslog
*/


/** BlueBack.Console
*/
#if((!DEF_BLUEBACK_CONSOLE_DISABLE)&&(!DEF_BLUEBACK_CONSOLE_SYSLOG_DISABLE))
namespace BlueBack.Console
{
	/** Action_Syslog
	*/
	public sealed class Action_Syslog
	{
		/** udpclient
		*/
		private System.Net.Sockets.UdpClient udpclient;

		/** myname
		*/
		public string myname;

		/** host
		*/
		public string host;

		/** port
		*/
		public int port;

		/** constructor
		*/
		public Action_Syslog(in Setting a_setting)
		{
			//udpclient
			this.udpclient = null;

			//myname
			this.myname = "127.0.0.1";

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
				this.myname = System.Net.Dns.GetHostName();
			}

			int t_facility = 1;
			int t_severity = 6;
			int t_pri = t_facility * 8 + t_severity;

			System.DateTime t_now = System.DateTime.Now;

			string t_timestamp = string.Format("{0} {1}{2} {3}",
				t_now.ToString("MMM",System.Globalization.CultureInfo.CreateSpecificCulture("en-US")),
				t_now.Day < 10 ? " " : "",
				t_now.Day,
				t_now.ToString("hh:mm:ss")
			);

			byte[] t_binary = System.Text.Encoding.UTF8.GetBytes(string.Format("<{0}>{1} {2} {3}:{4}",t_pri,t_timestamp,this.myname,"Unity",a_text + "\n" + a_stacktrace));

			int t_length = t_binary.Length;
			if(t_length > 1000){
				t_length = 999;
				t_binary[t_length + 0] = 0x00;
				t_binary[t_length + 1] = 0x00;
			}

			this.udpclient.Send(t_binary,t_length);
		}
	}
}
#endif

