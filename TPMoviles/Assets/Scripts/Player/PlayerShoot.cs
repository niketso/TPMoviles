using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

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
    
    public int score;
    public Text points;
    public Text ammoText;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        //gunAudio = GetComponent<AudioSource>();
    }
            
    void Start()
    {
        currentBullets = bulletsPerMag;
        UpdateAmmoText();
    }

    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            
            if (currentBullets > 0)
                Fire();
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentBullets < bulletsPerMag && totalBullets > 0)
                Reload();
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;

    }

    private void Fire()
    {

        if (fireTimer < fireRate || currentBullets <= 0 /*|| isReloading*/)
        {
            Debug.Log("Fire1");
            return;
        }

        RaycastHit hit;
        Vector3 lineOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        bool Hit = Physics.Raycast(lineOrigin, cam.transform.forward, out hit, weaponRange);

        if (Hit)
        {
            Debug.Log(hit.collider.name);

            if (hit.collider.gameObject.tag == "Enemy" && !(hit.collider.gameObject.GetComponent<EnemyMovement>().IsDead))
            {
                Debug.Log("Enemy HIT");
                hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Dead");
                hit.transform.gameObject.GetComponent<Animator>().SetFloat("Speed", 0);
                hit.transform.gameObject.GetComponent<EnemyMovement>().IsDead = true;
                hit.transform.gameObject.GetComponent<Enemy>().IsDead();
                hit.transform.gameObject.GetComponent<Collider>().enabled = false;
                hit.transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                Destroy(hit.collider.gameObject, 6);
                GameObject.FindGameObjectWithTag("Hand").GetComponent<Collider>().enabled = false;
                score++;
                points.text = score.ToString();
                if (score == 25)
                {
                    SceneManager.LoadScene("StartScreen");
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                }

            }

            currentBullets--;
            UpdateAmmoText();
            fireTimer = 0.0f;
        }
    }
    public void Reload()
    {
        if (totalBullets <= 0)
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