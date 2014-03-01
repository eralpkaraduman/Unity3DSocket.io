/* Free for copy and use
* Eng Raksa
*/
using UnityEngine;
using System.Collections;
using SocketIOClient;

public class Test : MonoBehaviour
{
		Client client;	
		int i = 0;
		string toserver = "";
		string fromserver = "";
		void Start ()
		{
				client = new Client ("http://127.0.0.1:8080");//because we define 8080 ass port number to node.js server
				client.Opened += SocketOpened;
				client.Message += SocketMessage;
				client.SocketConnectionClosed += SocketConnectionClosed;
				client.Error += SocketError;
				client.Connect ();
		}
		private void SocketOpened (object sender, System.EventArgs e)
		{
				toserver = "SocketOpened";
				fromserver = "SocketOpened";
		}
		private void SocketMessage (object sender, MessageEventArgs e)
		{
				if (e != null && e.Message.Event == "message") {
						string msg = e.Message.MessageText;
						fromserver = "From server: " + i;
				}
		}
		private void SocketConnectionClosed (object sender, System.EventArgs e)
		{
				toserver = "SocketConnectionClosed";
				fromserver = "SocketConnectionClosed";
		}
		private void SocketError (object sender, System.EventArgs e)
		{
				toserver = "SocketError";
				fromserver = "SocketError";
		}
		void OnGUI ()
		{
				if (GUI.Button (new Rect (0, 0, 50, 50), "send")) {
						client.Send ((++i) + "");
						toserver = "To server: " + i;
				}
				GUI.Label (new Rect (55, 0, 100, 50), toserver);
				GUI.Label (new Rect (160, 0, 100, 50), fromserver);
		}
		void OnApplicationQuit ()//close connection while application is being destroyed
		{
				client.Close ();
		}
}
