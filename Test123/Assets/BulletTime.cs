using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    private int currentCollisionCount = 0;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("onTriggerEnter2D bulletTime");
        BulletScript bullet = collider.GetComponent<BulletScript>();
        //MeshRenderer renderer = this.GetComponent<MeshRenderer>();
        if (bullet != null && GetComponent<Renderer>().enabled == true)
        {
            bullet.SlowDown();
            currentCollisionCount += 1;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        BulletScript bullet = collider.GetComponent<BulletScript>();
        if (bullet != null)
        {
            bullet.SpeedUp();
            currentCollisionCount -= 1;
        }
    }

    public void Update()
    {
        if (currentCollisionCount > 0)
        {
            GetComponent<MeshRenderer>().material.SetColor("_Color", Color.cyan);
        }
        else
        {
            GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
        }
    }


}
