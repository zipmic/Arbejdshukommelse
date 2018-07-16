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

    public GameObject WrongEffect, CorrectEffect;

    public GameObject DeathScreen;


    private float FireRate;

    private GameObject ObjectToLift;
    private bool isLifting;

    public GameObject LineR;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {

        FireRate += Time.deltaTime;

        /*if (Input.GetKey(KeyCode.E))
        {
          

            RaycastHit hit;
            if (Physics.Raycast(CameraPoint.transform.position, CameraPoint.transform.forward, out hit, 5, TheLayerMask))
            {
              
                if (hit.collider.tag == "Block")
                {
					string s = hit.collider.gameObject.GetComponent<WordBlock>().BlockText;
					if (QuestGiver.CheckWord(s))
					{
						// Det var altså et rigtigt ord... ih. Du tabte!
						QuestGiver.AddCorrectWord();
						Destroy(hit.collider.gameObject);
					}
					

				}   
            }

           
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isLifting = false;
            ObjectToLift = null;
        }
*/

        if (FireRate >= 0.2f)
        {

            if (Input.GetMouseButtonDown(0))
            {

                LineR.gameObject.SetActive(true);
                StartCoroutine(DisappearLine());
                GameObject g = Instantiate(GunExplosion) as GameObject;
                g.transform.position = GunExplosionPosition.transform.position;

                PistolAnimator.Play("shoot");

                RaycastHit hit;
                if (Physics.Raycast(CameraPoint.transform.position, CameraPoint.transform.forward, out hit, 30, TheLayerMask))
                {

                    LineR.GetComponent<LineRenderer>().SetPosition(0, CameraPoint.transform.position);
                    LineR.GetComponent<LineRenderer>().SetPosition(1, CameraPoint.transform.forward * 100);
                    PistolAnimator.SetBool("isShooting", true);
                    if (hit.collider.tag == "Block")
                    {

                        string s = hit.collider.gameObject.GetComponent<WordBlock>().BlockText;
                        if (QuestGiver.CheckWord(s))
                        {
                            // Det er et rigtigt ord, kæmpe eksplosion og point!
                            Instantiate(CorrectEffect, hit.transform.position, Quaternion.identity);

                        }
                        else
                        {
                            // forkert! Lille eksplosion.
                            Instantiate(WrongEffect, hit.transform.position, Quaternion.identity);
                       
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

    IEnumerator DisappearLine()
    {
        yield return new WaitForSeconds(0.1f);
        LineR.gameObject.SetActive(false);
    }

    IEnumerator EndScreenAndRestart()
    {
        DeathScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
