using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletSpeed = 15f;
    public Rigidbody2D ridB;
    public Rigidbody2D bullet;

    public int StepsBetweenFire = 20;

    private int fireAlarm;


    void Start()
    {
        ridB = GetComponent<Rigidbody2D>();
        fireAlarm = 0;
    }

    void FixedUpdate()
    {


        // Fire Weapon
        fireAlarm--;
        if(Input.GetButton("Fire1"))
        {

            if (fireAlarm <= 0)
            {
                Rigidbody2D clone;
                clone = Instantiate(bullet, transform.position + transform.right * 1, transform.rotation);

                var force = transform.right * bulletSpeed;
                Debug.Log($"force: {force}");
                clone.AddForce(force, ForceMode2D.Impulse);

                // reset alarm:
                fireAlarm = StepsBetweenFire;
            }
        }

        if (Input.GetButtonDown("ActivateBulletTime"))
        {
            Transform t = transform.Find("BulletTime");
            if (t != null)
            {
                t.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if (Input.GetButtonUp("ActivateBulletTime"))
        {
            Transform t = transform.Find("BulletTime");
            if (t != null)
            {
                t.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        //var mouse_pos = Input.mousePosition;

        Vector2 mouse_pos = Input.mousePosition;
        //mouse_pos.z = 5.23; //The distance between the camera and object
        var object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        var angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //transform.Rotate(new Vector3(0, 0, 1), angle);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
