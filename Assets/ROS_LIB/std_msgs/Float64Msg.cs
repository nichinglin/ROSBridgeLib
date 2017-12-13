using System.Collections;
using System.Text;
using SimpleJSON;

namespace ROSBridgeLib {
	namespace std_msgs {
		public class Float64Msg : ROSBridgeMsg {
			private float _data;
			
			public Float64Msg(JSONNode msg) {
				_data = float.Parse(msg["data"]);
			}
			
			public Float64Msg(float data) {
				_data = data;
			}
			
			public static string GetMessageType() {
				return "std_msgs/Float64";
			}
			
			public float GetData() {
				return _data;
			}
			
			public override string ToString() {
				return "Float64 [data=" + _data + "]";
			}
			
			public override string ToYAMLString() {
				return "{\"data\" : " + _data + "}";
			}
		}
	}
}