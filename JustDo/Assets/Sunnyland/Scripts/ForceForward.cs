using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class ForceForward : MonoBehaviour {
    public enum TriggerType
    {
        CollisionEnter,
        CollisionExit,
        TriggerEnter,
        TriggerExit
    };
    public TriggerType triggerType = TriggerType.CollisionEnter;
    private Collider2D m2_collider2D;
    public Rigidbody2D mario2;
    public float jumpForce = 1;
    public float forwardForce = 1;


    // Use this for initialization
    void Start()
    {
        m2_collider2D = GetComponent<Collider2D>();
        init2();
    }
    void init2()
    {

        switch (triggerType)
        {
            case TriggerType.CollisionEnter:
                m2_collider2D.isTrigger = false;
                break;
            case TriggerType.CollisionExit:
                m2_collider2D.isTrigger = false;
                break;
            case TriggerType.TriggerEnter:
                m2_collider2D.isTrigger = true;
                break;
            case TriggerType.TriggerExit:
                m2_collider2D.isTrigger = true;
                break;

        }
    }
    void DoActions()
    {
        mario2.AddForce(new Vector2(forwardForce, jumpForce));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggerType == TriggerType.CollisionEnter)
        {
            DoActions();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
