using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Camera mainCamera;
    public int damage;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        System.Random r = new System.Random();
        GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color((float)r.NextDouble(), (float)r.NextDouble(), (float)r.NextDouble(), 1.0f));
        // Debug.Log($"Color values: {GetComponent<MeshRenderer>().material.color}");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Wall wall = collision.collider.GetComponent<Wall>();
        if (wall != null)
        {
            wall.health -= damage;
            wall.UpdateDamageColor();
        }
    }


    public void SlowDown()
    {
        Vector2 vel = transform.GetComponent<Rigidbody2D>().velocity;
        vel = vel * 0.25f;
        transform.GetComponent<Rigidbody2D>().velocity = vel;
        Debug.Log("Slowing bullet..");
    }

    public void SpeedUp()
    {
        Vector2 vel = transform.GetComponent<Rigidbody2D>().velocity;
        vel = vel * 4;
        transform.GetComponent<Rigidbody2D>().velocity = vel;
        Debug.Log("Speeding bullet..");
    }

}
