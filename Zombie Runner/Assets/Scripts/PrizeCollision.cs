using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeCollision : MonoBehaviour
{
    string playerTag = "Player";
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
