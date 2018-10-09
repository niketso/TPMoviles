using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayViewer : MonoBehaviour {
    public LayerMask layers;
    public float weaponRange = 50f;
    bool HitsEnemy;
    private Camera cam;
    private AudioSource gunAudio;
    public float fireRate = .25f;
    //private WaitForSeconds shotDuration = new WaitForSeconds(.1f);
    private float nextFire;
    public int score;
    public Text puntos;
    [SerializeField] string nextLevel;

    void Start ()
    {
        cam = GetComponent<Camera>();
        gunAudio = GetComponent<AudioSource>();
    }	
	
	void Update ()
    {

        if(Input.GetButtonDown("Fire1")&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            gunAudio.Play();
            RaycastHit hit;
            Vector3 lineOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            bool HitsEnemy = Physics.Raycast(lineOrigin, cam.transform.forward, out hit, weaponRange);

            if (HitsEnemy)
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
                    Destroy(hit.collider.gameObject,6);
                    GameObject.FindGameObjectWithTag("Hand").GetComponent<Collider>().enabled = false;
                    score++;
                    puntos.text = score.ToString();
                    if (score == 25)
                    {
                        SceneManager.LoadScene("StartScreen");
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;

                    }

                }
            }

        }
        
	}
}


