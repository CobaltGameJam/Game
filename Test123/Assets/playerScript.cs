using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private PlayableCharacter Body { get; set; }
    public float moveSpeed = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        Body = this.GetComponentInChildren<PlayableCharacter>();


    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector2 movingV = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movingV *= Time.deltaTime;
        this.transform.Translate(movingV * moveSpeed);
    }
}
