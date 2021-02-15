using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D element) 
    {
        if (element.tag == "Player")
        {
            LevelGenerator.sharedInstance.AddNewBlock();
            LevelGenerator.sharedInstance.RemoveOldBlock();
        }
    }
}
