using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ClickArea : MonoBehaviour
{
   
    public GameObject GameContainer;
    public Vector2 touchPosition;
    public Camera gCamera;
    public GameObject g_ClickArea;

    public BoxCollider2D stuff;
    // Use this for initialization
    void Start()
    {
        gCamera = GameContainer.GetComponent<Camera>();
      
    }

    // Update is called once per frame
    void Update()
    {
     /*   

        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            float theDistance;

            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);

            

            if(Physics.Raycast(transform.position,(forward), out hit))
            {
                theDistance = hit.distance;
                Debug.Log(theDistance+""+hit.collider.gameObject.name);
            }
        }*/
    }





    void OnTriggerEnter2D(Collider2D other)
    {

     /*   if (other.gameObject.tag == "tiles")
        {
         //Debug.Log("Leave");
            other.gameObject.GetComponent<Tile_self_script>().bool_ontrigger = true;
           
        }*/

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.transform.position.x < g_ClickArea.gameObject.transform.position.x)
        {
            if (other.gameObject.tag == "tiles")
            {
                if (GameContainer.GetComponent<TileSpawner>().bool_bossmode)
                {
                    if (GameContainer.GetComponent<BossMode>().currentBoss == 3)
                    {
                        if (other.gameObject.GetComponent<Tile_self_script>().bool_pressed == false)
                        {
                            GameContainer.GetComponent<TileSpawner>().hud_player_bar.transform.localScale = new Vector3(GameContainer.GetComponent<TileSpawner>().hud_T_PlayerBar.x, GameContainer.GetComponent<TileSpawner>().hud_T_PlayerBar.y, GameContainer.GetComponent<TileSpawner>().hud_T_PlayerBar.z);
                            GameContainer.GetComponent<TileSpawner>().hud_T_PlayerBar.x = GameContainer.GetComponent<TileSpawner>().hud_T_PlayerBar.x - 0.1f;
                            GameContainer.GetComponent<TileSpawner>().source.PlayOneShot(GameContainer.GetComponent<TileSpawner>().damage, 0.7f);

                            if (GameContainer.GetComponent<TileSpawner>().hud_T_PlayerBar.x < 0)
                            {
                                //coinAnimator.SetBool("Clicked", true);
                                //coinAnimator.Play("coinadded", -1, 0f);
                                GameContainer.GetComponent<TileSpawner>().game_lose(true);
                            }
                        }
                    }
                }

               

                if (GameContainer.GetComponent<TileSpawner>().bool_canLose)
                {
                    if (GameContainer.GetComponent<TileSpawner>().bool_game_play)
                    {
                        if (other.gameObject.GetComponent<Tile_self_script>().bool_pressed == false)
                        {
                            if (GameContainer.GetComponent<TileSpawner>().bool_bossmode)
                            {
                                
                               
                            }
                            else
                            {
                                if (GameContainer.GetComponent<TileSpawner>().variant_reverseTile)
                                {
                                    Debug.Log("I would have lost");
                                }
                                else
                                {
                                    Debug.Log("I lost even though I shouldnt");
                                    GameContainer.GetComponent<TileSpawner>().game_lose(false);
                                }
                            }
                           
                        }
                    }
                }
            }
        }
    }
}

