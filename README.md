# ROSBridgeLib
A Unity library for communicattion with ROS through [RosBridge](http://wiki.ros.org/rosbridge_suite)

The first version of this I believe origins from [Michael Jenkin](https://github.com/michaeljenkin), in the repo [unityros](https://github.com/michaeljenkin/unityros). He has made a sample unity project showing turtlesim, with good instructions on how to use this project. All honor goes to him.

The second version of this is from [Mathias Ciarlo](https://github.com/MathiasCiarlo), in the repo [ROSBridgeLib](https://github.com/MathiasCiarlo/ROSBridgeLib). He has made most ROS msgessage work in Unity. He created this project containing the barebone library.

## Included messages
This repository does not contain every ROS message. If you need to add one, please fork this repository, add the file and make a pull request. Thanks!

## How to start
> If you are a beginer, please take a look [here](https://github.com/nichinglin/ROSBridgeLib/wiki).

Starting a new Unity project:

Windows or Mac part
1. Openthis repo as an Unity project
2. Set ROS_MASTER_URI (Show in Example below)
Linux part
1. roslaunch rosbridge_server rosbridge_websocket.launch

Using existing project:

Windows or Mac part
1. Open a new Unity project
2. Import websocket-sharp.dll
3. Drag and drop Assets/ROS_LIB into your project
4. Set ROS_MASTER_URI (Show in Example below)

Linux part
1. roslaunch rosbridge_server rosbridge_websocket.launch

## Example usage
Main object script:
``` cs
public class RealsenseViewer : MonoBehaviour  {
	public string ROS_MASTER_URI = "10.0.0.1"; //set your ros master ip
  private ROSBridgeWebSocketConnection ros = null;
    
  void Start() {
		ros = new ROSBridgeWebSocketConnection ("ws://" + ROS_MASTER_URI, 9090);
		ros.AddPublisher(typeof(pup_test));
		ros.AddSubscriber(typeof(sub_test));
		ros.Connect ();
  }
  
  // Extremely important to disconnect from ROS. OTherwise packets continue to flow
  void OnApplicationQuit() {
    if(ros!=null) {
      ros.Disconnect ();
    }
  }
  
  // Update is called once per frame in Unity
  void Update () {
    // publish msg
		Int32Msg msg = new Int32Msg(3);
		ros.Publish (pup_test.GetMessageTopic(), msg);
    
    ros.Render ();
  }
}
```
Publisher:
``` cs
public class pup_test : ROSBridgePublisher {
	
	
	public static string GetMessageTopic() {
		return "pup_test";
	}  
	
	public static string GetMessageType() {
		return Int32Msg.GetMessageType();
	}
	
	public static string ToYAMLString(Int32Msg msg) {
		//return msg.GetData().ToString();
		return msg.ToYAMLString();
	}
}
```
Subscriber:
``` cs
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
```

## License
Note: SimpleJSON is included here as a convenience. It has its own licensing requirements. See source code and unity store for details.
