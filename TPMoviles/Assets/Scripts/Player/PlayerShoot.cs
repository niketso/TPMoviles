﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System;

public class PlayerShoot : MonoBehaviour
{

    public LayerMask layers;
    bool HitsEnemy;
    private Camera cam;
    //private AudioSource gunAudio;
    public float weaponRange = 50f;    
    [SerializeField] private int bulletsPerMag = 7;
    [SerializeField] private int totalBullets = 90;
    public int currentBullets;
    public float fireRate = 0.1f;
    float fireTimer;
    public bool infiniteAmmoActivated = false;
    
    public int score;
    public Text points;
    public Text ammoText;

    AudioSource audioSource;

    [SerializeField] GameObject canvasUI;
    [SerializeField] AudioClip enemyDie;
    [SerializeField] AudioClip dryGun;
    [SerializeField] AudioClip shot;
    [SerializeField] GameObject impact;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
    }
            
    void Start()
    {
        currentBullets = bulletsPerMag;
        UpdateAmmoText();
    }

    void Update()
    {

        if (InputManager.Instance.GetFireButton())
        {
            
            if (currentBullets > 0)
                Fire();
            else
                audioSource.PlayOneShot(dryGun, 0.5f);

        }

        if (InputManager.Instance.GetReloadButton())
        {
            if (currentBullets < bulletsPerMag && totalBullets > 0)
                Reload();
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;

        if (infiniteAmmoActivated)
        {
            canvasUI.SetActive(false);
        }
        else
        {
            canvasUI.SetActive(true);
        }

    }

    private void Fire()
    {
        audioSource.PlayOneShot(shot, 0.5f);
        if (fireTimer < fireRate || currentBullets <= 0 /*|| isReloading*/)
        {
            //Debug.Log("Fire1");
            return;
        }

        RaycastHit hit;
        Vector3 lineOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        bool Hit = Physics.Raycast(lineOrigin, cam.transform.forward, out hit, weaponRange);

        if (Hit)
        {
            if (hit.collider.gameObject.tag == "Enemy" && !(hit.collider.gameObject.GetComponent<EnemyMovement>().IsDead))
            {
                Debug.Log("Enemy HIT");
                GameObject impactGO = Instantiate(impact, hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 0.5f);

                if (hit.transform.gameObject.GetComponent<Enemy>().life == 1)
                {
                    //-----------------CUANDO SE MUERE UN ENEMIGO---------------------//
                    hit.transform.gameObject.GetComponent<Enemy>().life = 0;
                    hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Dead");
                    hit.transform.gameObject.GetComponent<Animator>().SetFloat("Speed", 0);
                    hit.transform.gameObject.GetComponent<EnemyMovement>().IsDead = true;
                    hit.transform.gameObject.GetComponent<Enemy>().IsDead();
                    hit.transform.gameObject.GetComponent<Collider>().enabled = false;
                    hit.transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    Destroy(hit.collider.gameObject, 6);
                    audioSource.PlayOneShot(enemyDie, 1F);
                    GameObject.FindGameObjectWithTag("Hand").GetComponent<Collider>().enabled = false;
                    score++;
                    points.text = score.ToString();
                }
                else hit.transform.gameObject.GetComponent<Enemy>().life--;
            }

            if (!infiniteAmmoActivated)
          
            {
                canvasUI.SetActive(true);
                currentBullets--;
                UpdateAmmoText();
                fireTimer = 0.0f;
            }

            
        }
    }        

    public void Reload()
    {
        if (totalBullets <= 0 && currentBullets == 0)
        {
            return;
        }

        int bulletsToLoad = bulletsPerMag - currentBullets;

        int bulletsToUse = (totalBullets >= bulletsToLoad) ? bulletsToLoad : totalBullets;

        totalBullets -= bulletsToUse;
        currentBullets += bulletsToUse;
        UpdateAmmoText();

    }

    private void UpdateAmmoText()
    {
        ammoText.text = currentBullets + " / " + totalBullets;
    }
}