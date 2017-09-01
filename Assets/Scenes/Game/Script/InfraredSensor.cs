using UnityEngine;
using System.Collections;
using Uniduino;

public class InfraredSensor : MonoBehaviour , IFlipperInput {

	//赤外線センサー
	//Arduinoにアクセスして、そこから赤外線センサーの入力値を受け取る

	public Arduino arduino;
	public int SensorPinNum = 0;	//赤外線センサーの入力を受け付けるArduinoのポート番号

	void Start(){
		arduino = Arduino.global;
		arduino.Setup (ConfigurePins);
	}

	void ConfigurePins(){
		arduino.pinMode (SensorPinNum, PinMode.ANALOG);
		arduino.reportAnalog (SensorPinNum, 1);
	}
		
	int OriginalSensorValue{
		get{
			return arduino.analogRead (SensorPinNum);
		}
	}

	float ConvertSensorValueTo01(float originalValue){
		if (originalValue > 600f) {
			return 1f;
		}
		return (float)originalValue / 600f;
	}

	//センサーの入力を0~1fの範囲に納めたもの
	public float Angle01 {
		get {
			return 1f - ConvertSensorValueTo01(OriginalSensorValue);
		}
	}
}

public interface IFlipperInput{
	float Angle01{
		get;
	}
}