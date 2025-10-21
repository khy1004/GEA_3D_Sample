using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;

    public Transform firePoint;

    bool otherwapon = false;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(otherwapon == false)
            {
                otherwapon = true;
            }
            else
            {
                otherwapon = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (otherwapon == false)
            {
                Shoot();
            }
            else
            {
                Shoot2();
            }

            
        }

        void Shoot()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 targetpoint;
            targetpoint = ray.GetPoint(50f);
            Vector3 direction = (targetpoint - firePoint.position).normalized;

            GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
        }
        void Shoot2()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 targetpoint;
            targetpoint = ray.GetPoint(50f);
            Vector3 direction = (targetpoint - firePoint.position).normalized;

            GameObject proj = Instantiate(projectilePrefab2, firePoint.position, Quaternion.LookRotation(direction));
        }
    }
}
