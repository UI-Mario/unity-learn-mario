using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ForceJump : MonoBehaviour {
    public enum TriggerType
    {
        CollisionEnter,
        CollisionExit,
        TriggerEnter,
        TriggerExit
    };
    public TriggerType triggerType = TriggerType.CollisionEnter;
    private Collider2D m_collider2D;
    public Rigidbody2D mario;
    public float Jumpforce = 1;


	// Use this for initialization
	void Start () {
        m_collider2D = GetComponent<Collider2D>();
        init();
    }
    void init()
    {

        switch (triggerType)
        {
            case TriggerType.CollisionEnter:
                m_collider2D.isTrigger = false;
                break;
            case TriggerType.CollisionExit:
                m_collider2D.isTrigger = false;
                break;
            case TriggerType.TriggerEnter:
                m_collider2D.isTrigger = true;
                break;
            case TriggerType.TriggerExit:
                m_collider2D.isTrigger = true;
                break;

        }
    }
    void DoActions()
    {
        mario.AddForce(new Vector2(0, Jumpforce));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggerType == TriggerType.CollisionEnter&&mario.position.y>=-1.6)
        {
            DoActions();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
