using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public Transform _player;
	
	
	void Update()
	{
		if (_player.position.y > transform.position.y){
			transform.position = new Vector3(transform.position.x, _player.position.y, transform.position.z);
		}
	}
	
	
}
