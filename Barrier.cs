using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barrier : MonoBehaviour
{

    public GameObject GameContainer;
    public TileSpawner mainscript;
    public Vector2 originalSize;
    public Vector2 originalPosition;
    public Vector2 prevTileSize;
    public bool DoOnce;
    public int chosenCombination;
    public int previousNum;
    public float TrackofSpeed;
    public bool StartIncreasingSpeed;
    public bool IncreaseorDecreaseSpeed;
    Coroutine IncreaseSpeed = null;
    Coroutine GameAffectors = null;
    public float minlocationTiles;

    // Use this for initialization

    

    void Start()
    {
        minlocationTiles = -3f;
        mainscript = GameContainer.GetComponent<TileSpawner>();

        //var Parent = GameContainer.GetComponent<TileSpawner>();
        // originalSize = Parent.Tiles.GetComponent<SpriteRenderer>().transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //RUNS WHEN TUT FALSE. KEEPS INCREASING SPEED EVERY 10 SECS
       if (!StartIncreasingSpeed)
        {
            if (GameContainer.GetComponent<TileSpawner>().bool_game_play == true)
            {
                if (mainscript.bool_bossmode || mainscript.lang_modeOn)
                {

                }else
                {
                    if (GameContainer.GetComponent<TileSpawner>().bool_game_tutorial == false)
                    {
                       IncreaseSpeed = StartCoroutine(IncreaseSpeedOverTime());
                        GameAffectors = StartCoroutine(getGameAffectors());
                        // StartCoroutine(f_ReverseTiles());
                        StartIncreasingSpeed = true;
                    }
                }
                
            }
            if (GameContainer.GetComponent<TileSpawner>().bool_game_lose )
            {
               /* Debug.Log("I am run");
                StopCoroutine(IncreaseSpeed);
                StopCoroutine(GameAffectors);*/
                StopAllCoroutines();
            }
            
        }if (GameContainer.GetComponent<TileSpawner>().bool_game_pause)
        {
            StopAllCoroutines();
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            var Parent = GameContainer.GetComponent<TileSpawner>();
           /* Parent.variant_reverseTile = true;
            Parent.var_stoppedReverse = true;
            Parent.determineReverseDirection = true;
            Parent.variant_moveselector = true;
        }*/
    }



    void OnTriggerEnter2D(Collider2D other)
    {
       
        var Parent = GameContainer.GetComponent<TileSpawner>();
        //originalSize = Parent.Tiles.GetComponent<SpriteRenderer>().transform.localScale;

        if (other.gameObject.tag == "boss1Fire")
        {
            Debug.Log("sdfdsfsd");
            if (Parent.bool_game_lose)
            {
            
            }
            else
            {
                //Debug.Log("hit");

                // other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.x, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.y / 3, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.z);

                Parent.hud_player_bar.transform.localScale = new Vector3(Parent.hud_T_PlayerBar.x, Parent.hud_T_PlayerBar.y, Parent.hud_T_PlayerBar.z);

                for (int i = 0; i < other.gameObject.GetComponent<ShotsInside>().Shots.Count; i++)
                {
                    if (!other.gameObject.GetComponent<ShotsInside>().Shots[i].GetComponent<Tile_self_script>().bool_pressed)
                    {
                        //  Debug.Log(Parent.hud_player_bar.transform.localScale);

                        Parent.hud_T_PlayerBar.x = Parent.hud_T_PlayerBar.x - 0.1f;
                        Parent.source.PlayOneShot(Parent.damage, 0.7f);
                    }
                    //Debug.Log("sd");
                    Destroy(other.gameObject.GetComponent<ShotsInside>().Shots[i]);
                }

                if (Parent.hud_T_PlayerBar.x < 0)
                {
                    //coinAnimator.SetBool("Clicked", true);
                    //coinAnimator.Play("coinadded", -1, 0f);
                    Parent.game_lose(true);
                }else
                {

                    other.gameObject.GetComponent<ShotsInside>().Shots.Clear();
                    Parent.boss_DetermineFireRate(0,Random.Range(0, 7), other.gameObject);
                    //other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.boss_firemodes[0];
                    GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, false);
                }

            }
            
        }

        if(other.gameObject.tag == "boss2Container")
        {
            if (Parent.bool_game_lose)
            {

            }
            else
            {
                
               

                //Debug.Log("hit");

                // other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.x, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.y / 3, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.z);

                Parent.hud_player_bar.transform.localScale = new Vector3(Parent.hud_T_PlayerBar.x, Parent.hud_T_PlayerBar.y, Parent.hud_T_PlayerBar.z);
                other.gameObject.GetComponent<ShotsInside>().Shots[0].GetComponent<Tile_self_script>().boss2_shieldDestroyed = false;
                for (int i = 0; i < other.gameObject.GetComponent<ShotsInside>().Shots.Count; i++)
                {
                    if (!other.gameObject.GetComponent<ShotsInside>().Shots[i].GetComponent<Tile_self_script>().bool_pressed)
                    {
                        //  Debug.Log(Parent.hud_player_bar.transform.localScale);

                        Parent.hud_T_PlayerBar.x = Parent.hud_T_PlayerBar.x - 0.1f;
                        Parent.source.PlayOneShot(Parent.damage, 0.7f);
                    }
                    //Debug.Log("sd");
                    Destroy(other.gameObject.GetComponent<ShotsInside>().Shots[i]);
                }

                if (Parent.hud_T_PlayerBar.x < 0)
                {
                    //coinAnimator.SetBool("Clicked", true);
                    //coinAnimator.Play("coinadded", -1, 0f);
                    Parent.game_lose(true);
                }
                else
                {

                    other.gameObject.GetComponent<ShotsInside>().Shots.Clear();
                    Parent.boss_DetermineFireRate(1, Random.Range(0, 3), other.gameObject);
                    if (other.gameObject.GetComponent<ShotsInside>().Shield.Count > 0)
                    {
                        Destroy(other.gameObject.GetComponent<ShotsInside>().Shield[0]);
                        other.gameObject.GetComponent<ShotsInside>().Shield.Clear();
                        Parent.boss2_spawnShield(other.gameObject);
                    }

                    //other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.boss_firemodes[0];
                    GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, false);
                }

            }


        }


            if (other.gameObject.tag == "tiles")
        {
            for (int i = 0; i < GameContainer.GetComponent<TileSpawner>().array_tiles.Count; i++)
            {
                if (other.gameObject == GameContainer.GetComponent<TileSpawner>().array_tiles[i])
                {
                    if (GameContainer.GetComponent<TileSpawner>().bool_game_play)
                    {
                        //TUTORIAL
                        #region
                        if (GameContainer.GetComponent<TileSpawner>().bool_game_tutorial && !GameContainer.GetComponent<TileSpawner>().lang_modeOn)
                        {
                            if (Parent.variant_changesize)
                            {

                                if (other.gameObject.GetComponent<Tile_self_script>().bool_sizeDivided)
                                {

                                    // other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                                    //other.gameObject.GetComponent<SpriteRenderer>().transform.position = originalPosition;
                                    //other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.x, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.y / Random.Range(1f, 3f));
                                    GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, true);
                                    other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                                    // other.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
                                }
                                else
                                {
                                    other.gameObject.GetComponent<Tile_self_script>().bool_sizeDivided = true;
                                    other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.x, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.y / 3, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.z);

                                    //Debug.Log(originalSize);
                                    // ChangeSizeAndPosition(other.gameObject, originalSize);
                                    GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, true);
                                    other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                                    //  other.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;

                                }

                            }
                            else if (Parent.variant_tile_moveY)
                            {
                                other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                                other.gameObject.GetComponent<Tile_self_script>().decideDirection();
                                other.gameObject.GetComponent<Tile_self_script>().moveY = true;
                                GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, false);
                                other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                                // other.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.clear;
                            }
                            else
                            {
                                //RUN WHEN NOT CHANGED
                                if (!DoOnce)
                                {
                                    DoOnce = true;
                                    originalSize = other.gameObject.GetComponent<SpriteRenderer>().transform.localScale;

                                }

                                other.gameObject.GetComponent<Tile_self_script>().moveY = false;
                                other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                                // other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.x, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.y / 3, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.z);
                                GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, false);
                                other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                                // other.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;


                            }
                        }
                        #endregion
                        else if (Parent.bool_bossmode)
                        {

                        }
                        else if(Parent.lang_modeOn)
                        {
                            if (Parent.lang_modeOn)
                            {
                                Parent.lang_changePersonalCover(other.gameObject);
                            }
                            else
                            {
                                other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                            }

                            other.gameObject.GetComponent<Tile_self_script>().moveY = false;
                            other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                            //other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                            GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, false);

                            if (Parent.lang_modeOn)
                            {
                                Parent.lang_changePersonalCover(other.gameObject);
                                other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                            }
                            else
                            {
                                other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                                other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                            }


                        }
                        else{ 

                        
                           
                            
                            if (!DoOnce)
                            {
                                DoOnce = true;
                                originalSize = other.gameObject.GetComponent<SpriteRenderer>().transform.localScale;
                                

                            }
                            Debug.Log(originalSize);
                           // originalSize = new Vector2(256, 768);
                            //RUN WHEN NOT IN TUTORIAL
                            other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                            //other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                            
                          //  other.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
                            //RUN TO GET VARIANTS
                            GetNewVariant(other.gameObject);

                            
                            if (Parent.variant_tile_moveY)
                            {
                                other.gameObject.GetComponent<Tile_self_script>().decideDirection();
                                other.gameObject.GetComponent<Tile_self_script>().moveY = true;
                                
                               
                               
                            }

                            if (Parent.variant_changesize)
                            {
                                BoxCollider2D managerBox = Parent.variant_Selector.GetComponent<BoxCollider2D>();
                                other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                                //Debug.Log(originalSize);
                                int lastIndex = Parent.array_tiles.Count - 2;
                                //Debug.Log("Changing size");
                            
                                other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.x, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.y / 3, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.z);
                                //prevTileSize = other.gameObject.GetComponent<SpriteRenderer>().transform.localScale;
                                if (Parent.lang_modeOn)
                                {
                                    Parent.lang_changePersonalCover(other.gameObject);
                                }
                                else
                                {
                                    other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                                }
                                

                                //other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = prevTileSize;
                                other.gameObject.transform.position = new Vector3(Parent.array_tiles[lastIndex].transform.position.x, 0f, Parent.array_tiles[lastIndex].transform.position.z) + new Vector3(Parent.tiles_width, Random.Range(minlocationTiles, managerBox.bounds.max.y - managerBox.bounds.max.y / 4), 0f);
                                GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, true);
                                

                            }
                            else
                            {
                                //RUN WHEN NOT CHANGED
                                if (!DoOnce)
                                {
                                    DoOnce = true;
                                    originalSize = other.gameObject.GetComponent<SpriteRenderer>().transform.localScale;
                                  
                                }


                                if (Parent.lang_modeOn)
                                {
                                    Parent.lang_changePersonalCover(other.gameObject);
                                }
                                else
                                {
                                    other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                                }
                                // other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.x, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.y / 3, other.gameObject.GetComponent<SpriteRenderer>().transform.localScale.z);
                                GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, false);
                               // other.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;

                            }
                            
                        }




                    }
                    else
                    {
                        if (!DoOnce)
                        {
                            DoOnce = true;
                            originalSize = other.gameObject.GetComponent<SpriteRenderer>().transform.localScale;
                        }
                       
                        //RUN WHEN NOT PLAYING
                        other.gameObject.GetComponent<Tile_self_script>().moveY = false;
                        other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                        //other.gameObject.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
                        GameContainer.GetComponent<TileSpawner>().RealocateTile(other.gameObject, false);

                        if (Parent.lang_modeOn)
                        {
                            Parent.lang_changePersonalCover(other.gameObject);
                            other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        else
                        {
                            other.gameObject.GetComponent<SpriteRenderer>().sprite = Parent.TileSpriteNoTouched[Parent.int_SpriteTile];
                            other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        
                        // other.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
                    }

                }
               
                    }
                    
                   
                   
                }
            }

    public void ChangeSizeAndPosition(GameObject obj, Vector2 size)
    {
        //Debug.Log("d");
       // obj.gameObject.GetComponent<SpriteRenderer>().transform.localScale = size;
       // obj.gameObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(obj.gameObject.GetComponent<SpriteRenderer>().transform.localScale.x, obj.gameObject.GetComponent<SpriteRenderer>().transform.localScale.y / Random.Range(1f, 3f));
       
       
       
        
    }

    public void GetNewVariant(GameObject other)
    {
        var Parent = GameContainer.GetComponent<TileSpawner>();

        if (GameContainer.GetComponent<TileSpawner>().int_current_score >450)
        {
            NumberofCombs(Random.Range(0, 6), other);
            return;
            
        }else if (GameContainer.GetComponent<TileSpawner>().int_current_score > 400)
        {
            NumberofCombs(Random.Range(0, 6), other);
            return;
        }
        else if (GameContainer.GetComponent<TileSpawner>().int_current_score > 350)
        {
            NumberofCombs(Random.Range(0, 5), other);
            return;
        }
        else if (GameContainer.GetComponent<TileSpawner>().int_current_score > 300)
        {
            NumberofCombs(Random.Range(0, 4), other);
            return;
        }
        else if (GameContainer.GetComponent<TileSpawner>().int_current_score > 150)
        {
           
            NumberofCombs(Random.Range(0, 3), other);
            return;
        }
        else if (GameContainer.GetComponent<TileSpawner>().int_current_score > 2)
        {
            //Debug.Log("stuff run");
            NumberofCombs(Random.Range(0, 2), other);
            return;
        }

       
    }

    public void NumberofCombs (int num, GameObject ort)
    {
        ResetVariants(ort);
        int rand = Random.Range(0, 5);
        if(rand ==0 || rand == 1 || rand == 2)
        {
            f_ChosenCombination(Random.Range(0, 3), ort);
        }else
        {
            f_ChosenCombination(Random.Range(0, 3), ort);
            f_ChosenCombination(Random.Range(0, 3), ort);
        }
            


    }

    public void f_ChosenCombination(int daNumber,GameObject variant )
    {
       
        var top = GameContainer.GetComponent<TileSpawner>();
        
        
        /*if(previousNum == daNumber)
        {
            f_ChosenCombination(Random.Range(0, 1), variant);
            return;
        }


         previousNum = daNumber;
         */


        if (daNumber == 0)
        {
            //Debug.Log("Opt0");
        }else if(daNumber == 1)
        {
            //Debug.Log("Opt1");
            top.variant_changesize = true;
        }
      
      
        else if (daNumber == 2)
        {
            //Debug.Log("Opt3");
            top.variant_tile_moveY = true;
        }
     
       

/*

        else if (daNumber == 7)
        {
            //2 3
            top.variant_increase_gamespeed = true;
            top.variant_changesize = true;
        }
        else if (daNumber == 8)
        {
            top.variant_increase_gamespeed = true;
            top.variant_moveselector = true;
        }
        else if (daNumber == 9)
        {
            top.variant_increase_gamespeed = true;
            top.variant_tile_Yposition = true;
        }
        else if (daNumber == 10)
        {
            //2 7
            top.variant_increase_gamespeed = true;
            top.variant_tile_moveY = true;
        }
        else if (daNumber == 11)
        {
            
            top.variant_changesize = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 12)
        {
            //3 4
            top.variant_changesize = true;
            top.variant_moveselector = true;
        }
        else if (daNumber == 13)
        {
            
            top.variant_changesize = true;
            top.variant_tile_Yposition = true;
        }
        else if (daNumber == 14)
        {

            top.variant_changesize = true;
            top.variant_tile_moveY = true;
        }
        else if (daNumber == 15)
        {
            //3 7
            top.variant_changesize = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 16)
        {
            //4 5
            top.variant_moveselector = true;
            top.variant_tile_Yposition = true;
        }
        else if (daNumber == 17)
        {
            
            top.variant_moveselector = true;
            top.variant_tile_moveY = true;
        }
        else if (daNumber == 18)
        {
            //4 7
            top.variant_moveselector = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 19)
        {
            //5 6
            top.variant_tile_Yposition = true;
            top.variant_tile_moveY = true;
        }
        else if (daNumber == 20)
        {
            //5 7
            top.variant_tile_Yposition = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 21)
        {
            //6 7
            top.variant_tile_moveY = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 22)
        {
            //2 3 4
            top.variant_increase_gamespeed = true;
            top.variant_changesize = true;
            top.variant_moveselector = true;
        }
        else if (daNumber == 23)
        {
            //2 3 5
            top.variant_increase_gamespeed = true;
            top.variant_changesize = true;
            top.variant_tile_Yposition = true;
        }
        else if (daNumber == 24)
        {
            //2 3 6
            top.variant_increase_gamespeed = true;
            top.variant_changesize = true;
            top.variant_tile_moveY = true;
        }
        else if (daNumber == 25)
        {
            //2 3 7
            top.variant_increase_gamespeed = true;
            top.variant_changesize = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 26)
        {
            //2 4 5
            top.variant_increase_gamespeed = true;
            top.variant_moveselector = true;
            top.variant_tile_Yposition = true;
        }
        else if (daNumber == 27)
        {
            //2 4 6
            top.variant_increase_gamespeed = true;
            top.variant_moveselector = true;
            top.variant_tile_moveY = true;
        }
        else if (daNumber == 28)
        {
            //2 4 7
            top.variant_increase_gamespeed = true;
            top.variant_moveselector = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 29)
        {
            //2 5 6
            top.variant_increase_gamespeed = true;
            top.variant_tile_Yposition = true;
            top.variant_tile_moveY = true;
        }
        else if (daNumber == 30)
        {
            //2 5 7
            top.variant_increase_gamespeed = true;
            top.variant_tile_Yposition = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 31)
        {
            //2 6 7
            top.variant_increase_gamespeed = true;
            top.variant_tile_moveY = true;
            top.variant_reverseTile = true;
        }
        else if (daNumber == 32)
        {
            //3 4 5
            top.variant_changesize = true;
            top.variant_moveselector = true;
            top.variant_tile_Yposition = true;
        }
        else if (daNumber == 33)
        {
            //3 4 6
            top.variant_changesize = true;
            top.variant_moveselector = true;
            top.variant_tile_moveY = true;
        }
        else if (daNumber == 34)
        {
            //3 4 7
            top.variant_changesize = true;
            top.variant_moveselector = true;
            top.variant_tile_moveY = true;
        }
        */

    }

    IEnumerator IncreaseSpeedOverTime()
    {
        var Parent = GameContainer.GetComponent<TileSpawner>();
        if (Parent.bool_game_play)
        {
            if (Parent.bool_game_pause)
            {

            }else
            {
                yield return new WaitForSeconds(Random.Range(3.0f, 4.0f));



                if (IncreaseorDecreaseSpeed == false)
                {

                    Parent.ActivateGameVariants(-0.01f);
                    TrackofSpeed = TrackofSpeed - 0.01f;

                    if (TrackofSpeed < -0.11f)
                    {
                        Debug.Log("Decrease");
                        IncreaseorDecreaseSpeed = true;
                    }

                }

                else
                {
                    Parent.ActivateGameVariants(0.01f);
                    TrackofSpeed = TrackofSpeed + 0.01f;
                    if (TrackofSpeed > -0.07f)
                    {
                        Debug.Log("Increase");
                        IncreaseorDecreaseSpeed = false;
                    }
                }
                Parent.variant_increase_gamespeed = true;

                //Debug.Log("Run");

                IncreaseSpeed = StartCoroutine(IncreaseSpeedOverTime());
               
            }
            
        }
    }

    public void ResetVariants(GameObject resObj)
    {
        var Topreach = GameContainer.GetComponent<TileSpawner>();
        
        Topreach.variant_changesize = false;
      
        
        Topreach.variant_tile_moveY = false;
    
        resObj.GetComponent<Tile_self_script>().moveY = false;
        resObj.GetComponent<Tile_self_script>().bool_sizeDivided = false;
        resObj.GetComponent<SpriteRenderer>().transform.localScale = originalSize;
        

    }

    //GAME AFFECTORS PART
    IEnumerator getGameAffectors()
    {
        var Parent = GameContainer.GetComponent<TileSpawner>();
        if (Parent.bool_game_pause) {

        }else
        {
            yield return new WaitForSeconds(Random.Range(2.5f, 6.0f));
            if (Parent.bool_game_play)
            {
                ResetGameAffectorVariants();

                /*int numberOfCombs = Random.Range(0, 6);

                if (numberOfCombs == 0 || numberOfCombs == 1 || numberOfCombs == 2 || numberOfCombs == 3)
                {
                    runVariant(Random.Range(0, 3));

                }else if(numberOfCombs == 4 || numberOfCombs == 5)
                {
                    runVariant(Random.Range(0, 3));
                    runVariant(Random.Range(0, 3));
                }else
                {
                    runVariant(Random.Range(0, 3));
                    runVariant(Random.Range(0, 3));
                    runVariant(Random.Range(0, 3));
                }*/
                runVariant(Random.Range(0, 3));

                GameAffectors = StartCoroutine(getGameAffectors());
            }

        
        }
        
    }

    public void ResetGameAffectorVariants()
    {
        var Parent = GameContainer.GetComponent<TileSpawner>();
        Parent.variant_moveselector = false;
       
    }

    public void runVariant(int chosenOne)
    {
        var Parent = GameContainer.GetComponent<TileSpawner>();
        Parent.determineReverseDirection = true;
        Parent.variant_moveselector = true;

        /*if (chosenOne == 0)
        {
            //Parent.variant_increase_gamespeed = true;

            //Parent.ActivateGameVariants(0);
        }else if(chosenOne == 1){
          
        }else{

         

        }*/
     
    }

    IEnumerator f_ReverseTiles()
    {
        var Parent = GameContainer.GetComponent<TileSpawner>();
        if (Parent.bool_game_play)
        {
            if (Parent.bool_game_pause)
            {

            }else
            {
                yield return new WaitForSeconds(Random.Range(3.0f, 9.0f));

                Parent.variant_reverseTile = true;
                Parent.var_stoppedReverse = true;

                StartCoroutine("rerunReverseTiles");
            } 
            
        }
       
    }

    IEnumerator rerunReverseTiles()
    {
        var Parent = GameContainer.GetComponent<TileSpawner>();
      
            yield return new WaitForSeconds(1f);
        if (Parent.bool_game_play)
        {
            Parent.variant_reverseTile = false;
        
            StartCoroutine("f_ReverseTiles");
        }
    }

    }


