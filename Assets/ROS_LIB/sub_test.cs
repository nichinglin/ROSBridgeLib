using UnityEngine;
using System.Collections;

using ROSBridgeLib;
using ROSBridgeLib.sensor_msgs;
using ROSBridgeLib.std_msgs;
using SimpleJSON;

public class sub_test : ROSBridgeSubscriber {
	
	public static string GetMessageTopic() {
		return "sub_test";
	}  
	
	public static string GetMessageType() {
		return StringMsg.GetMessageType();
	}
	
	public static ROSBridgeMsg ParseMessage(JSONNode msg) {
		return new StringMsg(msg);
	}

	public static void CallBack(ROSBridgeMsg msg) {
		Debug.Log(msg.ToYAMLString());
	}
}
