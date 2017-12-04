using System.Collections;
using System.Text;
using SimpleJSON;

/**
 * This (mostly empty) class is the parent class for all RosBridgeMsg's (the actual message) from
 * ROS. As the message can be empty....
 * <p>
 * This could be omitted I suppose, but it is retained here as (i) it nicely parallels the
 * ROSBRidgePacket class which encapsulates the top of the ROSBridge messages which are not
 * empty, and (ii) someday ROS may actually define a  minimal message.
 * 
 * Version History
 * 3.1 - changed methods to start with an upper case letter to be more consistent with c#
 * style.
 * 3.0 - modification from hand crafted version 2.0
 * 
 * @author Michael Jenkin, Robert Codd-Downey and Andrew Speers
 * @version 3.1
 */

public class ROSBridgeMsg  {

	public ROSBridgeMsg() {}


	public virtual string ToYAMLString() {
		StringBuilder x = new StringBuilder();
		x.Append("{");
		x.Append("}");
		return x.ToString();
	}

	public static string Advertise(string messageTopic, string messageType) {
		return "{\"op\": \"advertise\", \"topic\": \"" + messageTopic + "\", \"type\": \"" + messageType + "\"}";
	}
	
	public static string UnAdvertise(string messageTopic) {
		return "{\"op\": \"unadvertise\", \"topic\": \"" + messageTopic + "\"}";
	}
	
	public static string Publish(string messageTopic, string message) {
		//return "{\"op\": \"publish\", \"topic\": \"" + messageTopic + "\", \"msg\": " + message + "}";
		/*string _format = "jpeg";
		byte[] _data = new byte[] {
			0x30, 0x32, 0x32, 0x32, 0xe7, 0x30, 0xaa, 0x7f, 0x32, 0x32, 0x32, 0x32, 0xf9, 0x40, 0xbc, 0x7f,
			0x03, 0x03, 0x03, 0x03, 0xf6, 0x30, 0x02, 0x05, 0x03, 0x03, 0x03, 0x03, 0xf4, 0x30, 0x03, 0x06,
			0x32, 0x32, 0x32, 0x32, 0xf7, 0x40, 0xaa, 0x7f, 0x32, 0xf2, 0x02, 0xa8, 0xe7, 0x30, 0xff, 0xff,
			0x03, 0x03, 0x03, 0xff, 0xe6, 0x40, 0x00, 0x0f, 0x00, 0xff, 0x00, 0xaa, 0xe9, 0x40, 0x9f, 0xff,
			0x5b, 0x03, 0x03, 0x03, 0xca, 0x6a, 0x0f, 0x30, 0x03, 0x03, 0x03, 0xff, 0xca, 0x68, 0x0f, 0x30,
			0xaa, 0x94, 0x90, 0x40, 0xba, 0x5b, 0xaf, 0x68, 0x40, 0x00, 0x00, 0xff, 0xca, 0x58, 0x0f, 0x20,
			0x00, 0x00, 0x00, 0xff, 0xe6, 0x40, 0x01, 0x2c, 0x00, 0xff, 0x00, 0xaa, 0xdb, 0x41, 0xff, 0xff,
			0x00, 0x00, 0x00, 0xff, 0xe8, 0x40, 0x01, 0x1c, 0x00, 0xff, 0x00, 0xaa, 0xbb, 0x40, 0xff, 0xff,
		};
		string _header = "";
		string _test = "{\"format\": " + "\"" + _format + "\", \"data\": \"" + System.Convert.ToBase64String (_data) + "\", \"header\": " + _header + "}";

		messageTopic = "/c_c/camera_node/image/compressed";
		message = _test;*/
		return "{\"op\": \"publish\", \"topic\": \"" + messageTopic + "\", \"msg\": " + message + "}";
	}
	
	public static string Subscribe(string messageTopic) {
		return "{\"op\": \"subscribe\", \"topic\": \"" + messageTopic +  "\"}";
	}
	
	public static string Subscribe(string messageTopic, string messageType) {
		return "{\"op\": \"subscribe\", \"topic\": \"" + messageTopic +  "\", \"type\": \"" + messageType + "\"}";
	}
	
	public static string UnSubscribe(string messageTopic) {
		return "{\"op\": \"unsubscribe\", \"topic\": \"" + messageTopic +  "\"}";
	}
	
	public static string CallService(string service, string args) {
		if((args == null)|| args.Equals(""))
			return "{\"op\": \"call_service\", \"service\": \"" + service +  "\"}";
		else
			return "{\"op\": \"call_service\", \"service\": \"" + service +  "\", \"args\" : " + args + "}";
	}
	
	public static string CallService(string service) {
		return "{\"op\": \"call_service\", \"service\": \"" + service +  "\"}";
	}
	
}
