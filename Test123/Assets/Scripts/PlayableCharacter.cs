using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0.4f;
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
        // Movement
        Vector2 movingV = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movingV *= Time.deltaTime;
        ridB.transform.Translate(movingV * moveSpeed);

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


    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
    }
}
