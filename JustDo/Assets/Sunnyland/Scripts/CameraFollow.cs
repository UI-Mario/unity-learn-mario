using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform Followtarget;
    public float MoveSpeed = 3;
    private Vector2 targetPos;
    private Vector2 selfPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        targetPos = new Vector2(Followtarget.position.x, Followtarget.position.y);
        selfPos = new Vector2(transform.position.x, transform.position.y);
       
        if(Followtarget.position.x<targetPos.x)
        {
            targetPos = new Vector2(transform.position.x, Followtarget.position.y);

        }
        Vector2 result = Vector3.Lerp(transform.position, Followtarget.position, MoveSpeed * Time.deltaTime);
        transform.position = new Vector3(result.x, result.y, transform.position.z);

    }
}
