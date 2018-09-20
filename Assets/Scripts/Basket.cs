using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {
	// Update is called once per frame
	void Update () 
    {
        //getting the current mouse position
        Vector3 mousePos2D = Input.mousePosition;
        //the camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);
        }
    }
}
