using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Camera CameraPoint;
    public LayerMask TheLayerMask;
    public Quest QuestGiver;

    public Animator PistolAnimator;

    public GameObject GunExplosion;
    public GameObject GunExplosionPosition;

    public GameObject EffectAtBlock;

    public GameObject DeathScreen;


    private float FireRate;

    private GameObject ObjectToLift;
    private bool isLifting;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {

        FireRate += Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
        {
            
            if (isLifting)
            {
                ObjectToLift.transform.position = transform.position+CameraPoint.transform.forward * 3.5f;
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5, TheLayerMask))
            {
              
                if (hit.collider.tag == "Block" && isLifting == false)
                {
                    // løft blokken
                    ObjectToLift = hit.collider.gameObject;
                    isLifting = true;


                }   
            }

           
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isLifting = false;
            ObjectToLift = null;
        }


        if (FireRate >= 0.2f)
        {
            

            // du skød en jeg tror det er den
            if (Input.GetMouseButtonDown(0))
            {

                GameObject g = Instantiate(GunExplosion) as GameObject;
                g.transform.position = GunExplosionPosition.transform.position;

                PistolAnimator.Play("shoot");

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 100, TheLayerMask))
                {
                    PistolAnimator.SetBool("isShooting", true);
                    if (hit.collider.tag == "Block")
                    {

                        string s = hit.collider.gameObject.GetComponent<WordBlock>().BlockText;
                        if (QuestGiver.CheckWord(s))
                        {
                            // Det var altså et rigtigt ord... ih. Du tabte!
                            StartCoroutine(EndScreenAndRestart());
                        }
                        else
                        {
                            // Dræb den!
                            Destroy(hit.collider.gameObject);
                            Instantiate(EffectAtBlock, hit.transform.position, Quaternion.identity);
                       
                        }
                    }   
                }

                FireRate = 0;
            }
     

        }
        else
        {
            PistolAnimator.SetBool("isShooting", false);
        }
            
		
    }

    IEnumerator EndScreenAndRestart()
    {
        DeathScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
