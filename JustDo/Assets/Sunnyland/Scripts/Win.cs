using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Win : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider) {
        ResourceManager.Instance().gameMenuCtr.showWinpanel();
        ResourceManager.Instance().characterCtr.StopControl();
    }


}
