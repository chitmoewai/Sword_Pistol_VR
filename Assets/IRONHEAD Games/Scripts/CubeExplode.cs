using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplode : MonoBehaviour
{

    public GameObject shatteredObject;
    public GameObject mainCube;
    // Start is called before the first frame update
    void Start()
    {
        mainCube.SetActive(true);
        shatteredObject.SetActive(false);
    }

    public void IsShot()
    {
        Destroy(mainCube);
        shatteredObject.SetActive(true);
        var shatterAnimation = shatteredObject.GetComponent<Animation>().Play();
        // Vibrate the controller
        VibrationManager.instance.VibrateController(0.4f, 1, 0.3f, OVRInput.Controller.LTouch);
        // Add score
        ScoreManager.instance.AddScore(ScorePoints.GUNCUBE_SCOREPOINT);
        Destroy(shatteredObject,1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            IsShot();
        }
    }


}
