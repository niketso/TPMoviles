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
    private WaitForSeconds shotDuration = new WaitForSeconds(.1f);
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
            bool HitsEnemy = Physics.Raycast(lineOrigin, cam.transform.forward, out hit, weaponRange, layers);            

            if (HitsEnemy && !(hit.transform.gameObject.GetComponent<EnemyMove>().IsDead))
            {
                Debug.Log("Enemy HIT");
                hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Dead");
                hit.transform.gameObject.GetComponent<Animator>().SetInteger("Speed", 0);
                hit.transform.gameObject.GetComponent<EnemyMove>().IsDead = true;
                Destroy(hit.collider.gameObject,6);
                score++;
                puntos.text = score.ToString();
                if (score == 10)
                    SceneManager.LoadScene(nextLevel);
                

            }

        }
        
	}
}


