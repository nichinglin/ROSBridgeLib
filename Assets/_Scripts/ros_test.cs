using UnityEngine;
using System;
using System.Collections;

using ROSBridgeLib;
using ROSBridgeLib.sensor_msgs;
using ROSBridgeLib.std_msgs;

public class ros_test : MonoBehaviour  {
	public string ROS_MASTER_URI = "192.168.0.172";
	private ROSBridgeWebSocketConnection ros = null;
	
	void Start() {
		//ros = new ROSBridgeWebSocketConnection ("ws://local", 9090);
		ros = new ROSBridgeWebSocketConnection ("ws://" + ROS_MASTER_URI, 9090);
		ros.AddPublisher(typeof(pup_test));
		ros.AddSubscriber(typeof(sub_test));
		ros.Connect ();

	}
	
	// Extremely important to disconnect from ROS. OTherwise packets continue to flow
	void OnApplicationQuit() {
		if(ros!=null)
			ros.Disconnect ();
	}
	
	// Update is called once per frame in Unity
	void Update () {
		Int32Msg msg = new Int32Msg(3);
		ros.Publish (pup_test.GetMessageTopic(), msg);
		ros.Render ();
	}
}