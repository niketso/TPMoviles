using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public LayerMask layers;
    public int gunDamage;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public Transform gunEnd;

    private Camera cam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
   // private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;


    void Start()
    {
        laserLine = GetComponentInChildren<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            //StartCoroutine(ShotEffect());

            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (cam.transform.forward * weaponRange));
            }
        }

    }

    private IEnumerator ShotEffect()
    {
        //gunAudio.Play();

        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
        
    }



}