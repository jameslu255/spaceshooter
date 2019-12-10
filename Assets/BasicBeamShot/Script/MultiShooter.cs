using UnityEngine;
using System.Collections;

public class MultiShooter : MonoBehaviour
{

    public GameObject Shot1;
    public GameObject Shot2;
    public GameObject Wave;
    public float Disturbance = 0;

    public int ShotType = 0;
    private float nextFire = 0.0F;
    public static float timer = 0.0F;


    public static int laserPowerUp = 0;
    public float laserTimer = 0.0F;
    public bool isFiring = false;

    public static bool fired = false;
    public static bool secondaryFired = false;
    GameController gameController;
    private GameObject NowShot;

    void Start()
    {
        NowShot = null;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void Update()
    {
        GameObject Bullet;
        timer += Time.deltaTime;
        //create BasicBeamShot
        if (Input.GetButtonDown("Fire1") && (timer > nextFire) && isFiring == false)
        {
            nextFire = timer + 1;
            fired = true;
            Bullet = Shot1;
            //Fire
            GameObject s1 = (GameObject)Instantiate(Bullet, this.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            s1.GetComponent<BeamParam>().SetBeamParam(this.GetComponent<BeamParam>());

            GameObject wav = (GameObject)Instantiate(Wave, this.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            wav.transform.localScale *= 0.25f;
            wav.transform.Rotate(Vector3.left, 90.0f);
            wav.GetComponent<BeamWave>().col = this.GetComponent<BeamParam>().BeamColor;

        }
        //create GeroBeam
        if (Input.GetButtonDown("Fire2") && laserPowerUp > 0 && isFiring == false)
        {
            var playerMesh = GameObject.Find("Player").GetComponent<MeshRenderer>();
            playerMesh.material.SetColor("_Color", Color.white);
            secondaryFired = true;
            laserTimer = 0;
            //laserPowerUp--;
            isFiring = true;
            GameObject wav = (GameObject)Instantiate(Wave, this.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            wav.transform.Rotate(Vector3.left, 90.0f);
            wav.GetComponent<BeamWave>().col = this.GetComponent<BeamParam>().BeamColor;

            Bullet = Shot2;
            //Fire
            NowShot = (GameObject)Instantiate(Bullet, this.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            
        }
        //it's Not "GetButtonDown"
        if (Input.GetButton("Fire2") && laserPowerUp > 0)
        {
            laserPowerUp--;
            BeamParam bp = this.GetComponent<BeamParam>();
            if (NowShot.GetComponent<BeamParam>().bGero)
                NowShot.transform.parent = transform;

            Vector3 s = new Vector3(bp.Scale, bp.Scale, bp.Scale);

            NowShot.transform.localScale = s;
            NowShot.GetComponent<BeamParam>().SetBeamParam(bp);
        }

        if (isFiring == true)
        {
            laserTimer += Time.deltaTime;
            if (NowShot != null && laserTimer > 10.0)
            {
                NowShot.GetComponent<BeamParam>().bEnd = true;
                isFiring = false;
            }
        }
    }
}
