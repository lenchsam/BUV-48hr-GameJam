﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Vehicle : MonoBehaviour{
	
	public bool controllable = true;

	[Header("Components")]
	
	public Transform vehicleModel;
	public Rigidbody sphere;
	
	[Header("Controls")]
	
	public KeyCode accelerate;
	public KeyCode brake;
	public KeyCode steerLeft;
	public KeyCode steerRight;
	public KeyCode jump;
	
	[Header("Parameters")]
	
	[Range(5.0f, 40.0f)] public float acceleration = 30f;
	[Range(20.0f, 160.0f)] public float steering = 80f;
	[Range(50.0f, 80.0f)] public float jumpForce = 60f;
	[Range(0.0f, 20.0f)] public float gravity = 10f;
	[Range(0.0f, 1.0f)] public float drift = 1f;
	
	[Header("Switches")]
	
	public bool jumpAbility = false;
	public bool steerInAir = true;
	public bool Tilt = false;
	public bool alwaysSmoke = false;
	
	// Vehicle components
	
	Transform container, wheelFrontLeft, wheelFrontRight;
	Transform body;
	TrailRenderer trailLeft, trailRight;
	
	ParticleSystem smoke;
	
	// Private
	
	float speed, speedTarget;
	float rotate, rotateTarget;
	
	bool nearGround, onGround;
	
	Vector3 containerBase;
	
	// Functions
	
	void Awake(){
		
		foreach(Transform t in GetComponentsInChildren<Transform>()){
			
			switch(t.name){
				
				// Vehicle components
				case "body": body = t; break;
				
				// Vehicle effects
				
				case "smoke": smoke = t.GetComponent<ParticleSystem>(); break;
				case "trailLeft": trailLeft = t.GetComponent<TrailRenderer>(); break;
				case "trailRight": trailRight = t.GetComponent<TrailRenderer>(); break;
				
			}
			
		}
		
		container = vehicleModel.GetChild(0);
		containerBase = container.localPosition;
		
	}
	
	void Update(){
		
		// Acceleration
		
		speedTarget = Mathf.SmoothStep(speedTarget, speed, Time.deltaTime * 12f); speed = 0f;
		
		if(controllable){
			
			if(Input.GetKey(accelerate)){ speed = acceleration; }
			if(Input.GetKey(brake)){ speed = -acceleration; }
			
		}
		
		// Steering
		
		rotateTarget = Mathf.Lerp(rotateTarget, rotate, Time.deltaTime * 4f); rotate = 0f;
		
		if(controllable && (nearGround || steerInAir)){
			
			if(Input.GetKey(steerLeft)) { rotate = -steering; }
			if(Input.GetKey(steerRight)){ rotate =  steering; }
			
		}
		
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, transform.eulerAngles.y + rotateTarget, 0)), Time.deltaTime * 2.0f);
		
		// Jump
		
		if(controllable && jumpAbility && nearGround && Input.GetKeyDown(jump)){ sphere.AddForce(Vector3.up * (jumpForce * 20), ForceMode.Impulse); }
		
		// Wheel and body tilt
		
		//if(wheelFrontLeft != null){  wheelFrontLeft.localRotation  = Quaternion.Euler(0, rotateTarget / 2, 0); }
		//if(wheelFrontRight != null){ wheelFrontRight.localRotation = Quaternion.Euler(0, rotateTarget / 2, 0); }
		
		//body.localRotation = Quaternion.Slerp(body.localRotation, Quaternion.Euler(new Vector3(speedTarget / 4, 0, rotateTarget / 6)), Time.deltaTime * 4.0f);
		
		// Vehicle tilt
		
		float tilt = 0.0f; if(Tilt){ tilt = -rotateTarget / 1.5f; }
		
		container.localPosition = containerBase + new Vector3(0, Mathf.Abs(tilt) / 2000, 0);
		container.localRotation = Quaternion.Slerp(container.localRotation, Quaternion.Euler(0, rotateTarget / 8, tilt), Time.deltaTime * 10.0f);
		
		// Effects
		
		if(!Tilt){ smoke.transform.localPosition = new Vector3(-rotateTarget / 100, smoke.transform.localPosition.y, smoke.transform.localPosition.z); }
		
		ParticleSystem.EmissionModule smokeEmission = smoke.emission;
		smokeEmission.enabled = onGround && sphere.velocity.magnitude > (acceleration / 4) && (Vector3.Angle(sphere.velocity, vehicleModel.forward) > 30.0f || alwaysSmoke);
		
		if(trailLeft != null){   trailLeft.emitting = smoke.emission.enabled; }
		if(trailRight != null){ trailRight.emitting = smoke.emission.enabled; }
		
		// Stops vehicle from floating around when standing still
		
		if(speed == 0 && sphere.velocity.magnitude < 4f){ sphere.velocity = Vector3.Lerp(sphere.velocity, Vector3.zero, Time.deltaTime * 2.0f); }
		
	}
	
	// Physics update
	
	void FixedUpdate(){
		
		RaycastHit hitOn;
		RaycastHit hitNear;
		
		onGround   = Physics.Raycast(transform.position, Vector3.down, out hitOn, 1.1f);
		nearGround = Physics.Raycast(transform.position, Vector3.down, out hitNear, 2.0f);
		
		// Normal

		vehicleModel.up = Vector3.Lerp(vehicleModel.up, hitNear.normal, Time.deltaTime * 8.0f);
		vehicleModel.Rotate(0, transform.eulerAngles.y, 0);

		// Movement
		
		if(nearGround){
			
			sphere.AddForce(vehicleModel.forward * speedTarget, ForceMode.Acceleration);
			
		}else{
			
			sphere.AddForce(vehicleModel.forward * (speedTarget / 10), ForceMode.Acceleration);
			
			// Simulated gravity
			
			sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
			
		}
		
		transform.position = sphere.transform.position + new Vector3(0, 0.35f, 0);
		
		// Simulated drag on ground thanks to Adam Hunt
		
		Vector3 localVelocity = transform.InverseTransformVector(sphere.velocity);
		localVelocity.x *= 0.9f + (drift / 10);
		
		if(nearGround){
			
			sphere.velocity = transform.TransformVector(localVelocity);
			
		}
		
	}
	
	// Hit objects
	
	void OnTriggerEnter(Collider other){
		
		if(other.GetComponent<PhysicsObject>()){ other.GetComponent<PhysicsObject>().Hit(sphere.velocity); }
    }
}