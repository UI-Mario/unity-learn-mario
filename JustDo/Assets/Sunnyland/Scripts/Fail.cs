using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Fail : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider)
    {
        ResourceManager.Instance().gameMenuCtr.showGameOverPanel();
        ResourceManager.Instance().characterCtr.StopControl();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ResourceManager.Instance().gameMenuCtr.showGameOverPanel();
        ResourceManager.Instance().characterCtr.StopControl();
    }
}
