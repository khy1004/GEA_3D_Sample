using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;

    public float IifeTime = 2f;

    public int Damege = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, IifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damege);

            Destroy(gameObject);
        }
    }
}
