

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

		rfc3164

	*/
	public sealed class Action_Syslog : System.IDisposable
	{
		/** udpclient
		*/
		public System.Net.Sockets.UdpClient udpclient;

		/** myname
		*/
		public string myname;

		/** server
		*/
		public string server_name;
		public int server_port;

		/** tag
		*/
		public string tag;

		/** FacilityType
		*/
		public enum FacilityType
		{
			KernelMessages = 0,
			UserLevelMessages = 1,
			MailSystem = 2,
			SystemDaemons = 3,
			SecurityAuthorizationMessages1 = 4,
			MessagesGeneratedInternallyBySyslogd = 5,
			LinePrinterSubsystem = 6,
			NetworkNewsSubsystem = 7,
			UucpSubsystem = 8,
			ClockDaemon1 = 9,
			SecurityAuthorizationMessages2 = 10,
			FtpDaemon = 11,
			NtpSubsystem = 12,
			LogAudit = 13,
			LogAlert = 14,
			ClockDaemon_2 = 15,
			LocalUse0 = 16,
			LocalUse1 = 17,
			LocalUse2 = 18,
			LocalUse3 = 19,
			LocalUse4 = 20,
			LocalUse5 = 21,
			LocalUse6 = 22,
			LocalUse7 = 23,
		}

		/** SeverityType
		*/
		public enum SeverityType
		{
			Emergency = 0,
			Alert = 1,
			Critical = 2,
			Error = 3,
			Warning = 4,
			Notice = 5,
			Informational = 6,
			Debug = 7,
		}

		/** constructor
		*/
		public Action_Syslog(Setting a_setting)
		{
			//udpclient
			this.udpclient = null;

			//myname
			this.myname = "127.0.0.1";

			//server
			this.server_name = a_setting.syslog.server_name;
			this.server_port = a_setting.syslog.server_port;

			//tag
			this.tag = a_setting.syslog.tag;
			if(this.tag.Length > 32){
				this.tag = this.tag.Substring(0,32);
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

		/** [System.IDisposable]Dispose
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
				this.udpclient = new System.Net.Sockets.UdpClient(this.server_name,this.server_port);
				this.myname = System.Net.Dns.GetHostName();
			}

			FacilityType t_facility = FacilityType.UserLevelMessages;
			SeverityType t_severity = SeverityType.Informational;
			switch(a_type){
			case UnityEngine.LogType.Assert:
				{
					t_severity = SeverityType.Alert;
				}break;
			case UnityEngine.LogType.Error:
				{
					t_severity = SeverityType.Error;
				}break;
			case UnityEngine.LogType.Exception:
				{
					t_severity = SeverityType.Critical;
				}break;
			case UnityEngine.LogType.Warning:
				{
					t_severity = SeverityType.Warning;
				}break;
			case UnityEngine.LogType.Log:
				{
					t_severity = SeverityType.Informational;
				}break;
			default:
				{
					t_severity = SeverityType.Notice;
				}break;
			}

			int t_priority  = (int)t_facility * 8 + (int)t_severity;

			string t_timestamp;
			{
				System.DateTime t_now = System.DateTime.Now;
				t_timestamp = string.Format("{0} {1}{2} {3}",
					t_now.ToString("MMM",System.Globalization.CultureInfo.CreateSpecificCulture("en-US")),
					t_now.Day < 10 ? " " : "",
					t_now.Day,
					t_now.ToString("hh:mm:ss")
				);
			}

			byte[] t_binary = System.Text.Encoding.UTF8.GetBytes(string.Format("<{0}>{1} {2} {3}:{4}",
				t_priority,
				t_timestamp,
				this.myname,
				"Unity",
				a_text + "\n" + a_stacktrace
			));

			int t_length = t_binary.Length;
			if(t_length > 1000){
				t_length = 999;
				t_binary[999] = 0x00;
				t_binary[1000] = 0x00;
			}

			this.udpclient.Send(t_binary,t_length);
		}
	}
}
#endif

