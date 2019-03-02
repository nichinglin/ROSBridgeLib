using UnityEngine;
using System.Collections;

using ROSBridgeLib;
using ROSBridgeLib.sensor_msgs;
using ROSBridgeLib.std_msgs;
using SimpleJSON;

public class pup_test : ROSBridgePublisher {
	
	
	public static string GetMessageTopic() {
		return "pub_test";
	}  
	
	public static string GetMessageType() {
		return Int32Msg.GetMessageType();
	}
	
	public static string ToYAMLString(Int32Msg msg) {
		//return msg.GetData().ToString();
		return msg.ToYAMLString();
	}
}
