using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DunGenPortal : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(tag == "End_Portal")
        {
            if (col.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }

}
