using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	private float horInput;
	private float verInput;
	
	[SerializeField] private float brakeForce;
	private float currbrakeForce;
	private float steerAngle;
	private bool isBreaking;
	
	[SerializeField] private float motorForce;
	[SerializeField] private float maxSteerangle;
	[SerializeField] private float traction;
	
	[SerializeField] private WheelCollider frontLeftWheelCollider;
	[SerializeField] private WheelCollider frontRightWheelCollider;
	[SerializeField] private WheelCollider backRightWheelCollider;
	[SerializeField] private WheelCollider backLeftWheelCollider;
	
		
	[SerializeField] private Transform frontLeftWheelTransform;
	[SerializeField] private Transform frontRightWheelTransform;
	[SerializeField] private Transform backRightWheelTransform;
	[SerializeField] private Transform backLeftWheelTransform;
	
	private void Start(){

	
	}
	private void FixedUpdate(){
		GetInput();
		HandleMotor();
		HandleSteering();
		UpdateWheels();
		ApplyBrakes();
		
	}
	private void GetInput(){
		horInput = Input.GetAxis("Horizontal");
		verInput = Input.GetAxis("Vertical");
		isBreaking =Input.GetKey(KeyCode.Space);

	}
	private void HandleMotor(){


		frontLeftWheelCollider.motorTorque = motorForce * verInput;
		frontRightWheelCollider.motorTorque = motorForce * verInput;
		currbrakeForce = isBreaking ? brakeForce : 0f;
		if (isBreaking)
		{
			ApplyBrakes();
		}
		
	}
	private void HandleSteering(){
		steerAngle = maxSteerangle * horInput;
		frontLeftWheelCollider.steerAngle = steerAngle;
		frontRightWheelCollider.steerAngle= steerAngle;
	}
	private void UpdateWheels(){
		UpdateSingleWheel(frontLeftWheelCollider,frontLeftWheelTransform);
		UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
		UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
		UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
	}
	private void ApplyBrakes(){
		frontLeftWheelCollider.brakeTorque = currbrakeForce;
		frontRightWheelCollider.brakeTorque = currbrakeForce;
		backRightWheelCollider.brakeTorque = currbrakeForce;
		backLeftWheelCollider.brakeTorque = currbrakeForce;
	}
	private void UpdateSingleWheel(WheelCollider _wheelCollider, Transform _transform){
		Vector3 pos;
		Quaternion rot;
		_wheelCollider.GetWorldPose(out pos,out rot);
		_transform.position = pos;
		_transform.rotation = rot;
	}
	private void UpdateInput(){
		
	}
	
}

