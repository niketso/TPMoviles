using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUI : MonoBehaviour {

    public AnimationCurve curve;
    public float speed = 2f;
    PlayerShoot playerShoot;
    GameObject mainCamera;

    float timer = 0.0f;

    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
        playerShoot = mainCamera.GetComponent<PlayerShoot>();
    }

    void Update ()
    {
        if (playerShoot.currentBullets == 0) 
            Animate();
	}

    void Animate()
    {
        timer += speed * Time.deltaTime;
        timer = Mathf.Clamp01(timer);

        float c = curve.Evaluate(timer);

        this.transform.localScale = new Vector3(c, c, 1);

        if (timer >= 1)
            timer = 0;
    }
}
