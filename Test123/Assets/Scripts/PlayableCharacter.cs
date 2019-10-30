using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = .5f;
    public Rigidbody2D ridB;
    public Rigidbody2D bullet;

    void Start()
    {
        ridB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 movingV = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ridB.transform.Translate(movingV * speed);


        if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D clone;
            clone = Instantiate(bullet, transform.position + transform.right * 1, transform.rotation);



            var force = transform.right * speed;
            Debug.Log($"force: {force}");
            clone.AddForce(force, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
