﻿using System.Collections;
using System.Text;
using SimpleJSON;

namespace ROSBridgeLib {
	namespace std_msgs {
		public class Float64MultiArrayMsg : ROSBridgeMsg {
			private MultiArrayLayoutMsg _layout;
			private float[] _data;
			
			public Float64MultiArrayMsg(JSONNode msg) {
				_layout = new MultiArrayLayoutMsg(msg["layout"]);
				_data = new float[msg["data"].Count];
				for (int i = 0; i < _data.Length; i++) {
					_data[i] = float.Parse(msg["data"][i]);
				}
			}
			
			public Float64MultiArrayMsg(MultiArrayLayoutMsg layout, float[] data) {
				_layout = layout;
				_data = data;
			}
			
			public static string GetMessageType() {
				return "std_msgs/Float64MultiArray";
			}
			
			public float[] GetData() {
				return _data;
			}
			
			public MultiArrayLayoutMsg GetLayout() {
				return _layout;
			}
			
			public override string ToString() {
				string array = "[";
				for (int i = 0; i < _data.Length; i++) {
					array = array + _data[i];
					if (_data.Length - i <= 1)
						array += ",";
				}
				array += "]";
				return "Float64MultiArray [layout=" + _layout.ToString() + ", data=" + _data + "]";
			}
			
			public override string ToYAMLString() {
				string array = "[";
				for (int i = 0; i < _data.Length; i++) {
					array = array + _data[i];
					if (_data.Length - i <= 1)
						array += ",";
				}
				array += "]";
				return "{\"layout\" : " + _layout.ToYAMLString() + ", \"data\" : " + array + "}";
			}
		}
	}
}