using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterData))]
public class CharacterControl : MonoBehaviour {
	private CharacterData m_data;
	private bool m_jump=false;
	private float horizontalInput;
	// Use this for initialization
	void Start () {
		m_data = GetComponent<CharacterData>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!m_jump && (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)))
		{
			m_jump = true;
		}
		horizontalInput = Input.GetAxis("Horizontal");
	}
	public void StopControl()
	{
		this.enabled = false;
	}
	void FixedUpdate()
	{


		m_data.Move (m_jump, horizontalInput);
		m_jump = false;
	}
}
