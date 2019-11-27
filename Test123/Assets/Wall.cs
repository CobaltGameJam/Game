using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int health;
    public int fullHealth;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateDamageColor()
    {
        float healthPerc = 1 - ((float)health / (float)fullHealth);
        GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1, 1 - healthPerc, 1 - healthPerc, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {


        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
