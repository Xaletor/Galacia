using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    public Transform target;
    public float offset;
    public void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, target.position.z + offset);

        }
        else
        {
            target = GameObject.Find("Player").GetComponent<Transform>();
        }
    }

}
