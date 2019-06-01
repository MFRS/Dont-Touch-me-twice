using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using ChartboostSDK;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;




public class TileSpawner : MonoBehaviour
{


    //bool_game_play will be the var that checks whether the pressed tiles and whether if you lost or not

    //Boss menu is for boss menu. Stops clicking in the game. Boss mode is when playing boss

    [Header("Sound mode")]
    public GameObject ost_lose;
    public GameObject ost_boss1;
    public GameObject ost_mainmenu;
    public GameObject ost_game;

    [Header("Unlock mode")]
    public List<bool> unlock_adrelative; 



    [Header("Boss mode")]
    public bool bool_bossmode;
    public bool bool_Inmenu;
    public bool[] bossComplete;
    public GameObject con_Bossmode;
    public GameObject con_boss1_fire1;
    public GameObject boss2_enemy;
    public GameObject boss2_shield;
    public List<Sprite> boss2_enemysprites;
    public GameObject boss2_container;
    public GameObject con_fire_container;
    public GameObject con_shieldContainer;
    public Sprite[] boss_firemodes;
    public GameObject hud_coinicon;
    public GameObject hud_text;
    public GameObject hud_player_bar;
    public GameObject hud_player_icon;
    public Vector3 hud_T_PlayerBar;
    public Vector3 hud_T_EnemyBar;
    public GameObject hud_enemyPanel;
    public GameObject hud_enemyLifebar;
    public GameObject hud_enemyIcon;
    public GameObject hud_PlayerPanel;
    public GameObject con_victory;
    public Text boss_coins;
    public bool boss_victory;
    public int boss_levels_num;
    public bool[] boss_levels;
    public AudioClip putDownFire;
    public AudioClip damage;
    public GameObject boss3_container;
    public List<Sprite> Boss3_sprites;
   

    [Header("Language mode")]
    public Text language_Coins;
    public int lang_num;
    public bool[] langs;
    public GameObject con_lang;
    public List<Sprite> Lang_Tiles;
    public int Lang_TileCount;
    public bool lang_modeOn;
    public GameObject Lang_Text;
    public GameObject lang_panel;


    
    //public bool lang_bool_langmenu;




    //Game Variants
    public Vector2 vector_tilesize;
    public Vector2 vector_tile_y_position;
    public Vector2 vector_selector_position;


    [Header("Score Vars")]
    public int int_current_score;
    public int int_highscore;
    public int int_alltimecoins;
    public int int_coins;

    [Header("Shop")]
   
    public GameObject con_shop;
    public Text shop_currentcoins;
    public int shop_shopitemsnum;
    public bool[] shopItems; 
    




    [Header("Main Menu")]
    public Text mmenu_high_score;
    public GameObject mmenu_Title;
    public Vector3 lose_pos;
    public Text mmenu_CurrentCoins;

    [Header("Pause")]
    
    public GameObject pause_bg;
    public GameObject pause_pauandplay;
    public List<Sprite> pause_twosprites;
    public GameObject pause_coin;
    public AudioClip coinSound;
    public AudioSource source;
    public Animator coinAnimator;
    public bool pause_mutesound;
    public List<Sprite> pause_mutesprites;
    public GameObject pause_mutebtn;
    public GameObject hud_scoreText;



    [Header("Spawn Tile Vars")]
    public Transform Barrier_position;
    public Vector2 vector_previous_tile_position;
    public List<GameObject> array_tiles;
    public float tiles_width;
    public Sprite Spr1;
    public Sprite Spr2;
    public bool bool_spawntiles;
    public int int_tile_spawnrate;
    public GameObject currentTile;
    public Vector2 size_tiles;


    public Vector3 screenPosition = new Vector3(0, 0, 0);

    //
    [Header("Game Object Containers")]
    public GameObject selfContainer;

    public GameObject TileContainer;
    public GameObject Barrier_Container;
    public Camera GameCamera;
    public GameObject Tiles;
    public List<Sprite> TileSpriteNoTouched;
    public List<Sprite> CrunchedTileSpriteNoTouched;
    public List<Sprite> TileSpriteTouched;
    public List<Sprite> CrunchedTileSpriteTouched;
    public List<Sprite> Covers;
    public List<Sprite> Selectors;
    public List<Sprite> Covers_Streched;
    public List<Sprite> Cover_Container;
    public List<Sprite> Cover_1920;
    public GameObject con_Covers;
    

    public int int_SpriteTile;
    public int int_SpriteSelector;
    public int int_SpriteCover ;


    [Header("UI Visibility Bools")]
    public bool bool_game_mainmenu;
    public bool bool_game_lose;
    public bool bool_game_ach;
    public bool bool_game_leaderboards;
    public bool bool_game_tutorial;
    public bool bool_game_play;
    public bool bool_game_pause;
    public bool bool_shop;


    [Header("UI VAchievement Bools")]
    public bool[] bool_ach_array;
    public int int_ach_num;
 

    public GameObject con_IOS;


    [Header("Lang Bools")]
    public List<string> LanguageHolder;
    public List<string> EN;
    public List<string> PT;
    public List<string> NL;
    public bool isEN;
    public bool isPT;
    public bool isNL;

    [Header("Str Vars")]
    public Text str_ui_mainmenu_btnStart;
    public Text str_ui_lose_mainmenu;
    public Text str_ui_lose_tryagain;
    public Text str_ui_hud_score;
    public Text str_ui_lose_score;
    public Text str_ui_lose_highscore;
    public Text str_ui_lose_pluscoins;

    [Header("Game Variants")]
    public float float_tile_movespeed;
    public float default_speed;
    public float boss_default_speed;
    public float boss2_default_speed;
    public float boss3_default_speed;
    public float lang_default_speed;
    public float variant_speed_increase;
    public bool variant_increase_gamespeed;
    public bool variant_changesize;
    public bool variant_moveselector;
    public bool variant_tile_Yposition;
    public bool variant_tile_moveY;
    public bool variant_reverseTile;
    public bool var_stoppedReverse;
    public float previousSpeed = 0;
    public bool determineReverseDirection;
    public bool setupComplete;
    public int ads_Numplaytime;




    public Vector2 variant_storeinitialsize;
    public GameObject variant_Selector;
    public bool bool_canLose;
    public bool goRight;
    public Vector2 oriSize;
    public Vector2 oriPosition;

    [Header("Scripters")]
    public IOSPlatServices script_ios;
    public Ads script_ads;


    [Header("UI Cons")]
    public GameObject con_ui_mainmenu;
    public GameObject con_ui_lose;
    public GameObject con_ui_hud;
    public GameObject con_ui_clickarea;
    public GameObject con_credits;
    public Vector3 minimumDisplaySize = new Vector3(1024, 768, 0);
    /* public float pixelsWide;
    public float pixelsHigh;
    public float scaleX;
    public float scaleY;
    public float scale;*/



    //Game Phases Vars


    public bool bool_sound;
    public string appID;
    public string zoneID;
    public string appVersion;






    // Use this for initialization
    void Awake()
    {
       
        source = GetComponent<AudioSource>();
        if (!setupComplete)
        {
            
           
            int_SpriteCover = 2;
            int_SpriteSelector = 1;
            int_SpriteTile = 6;
        }
        else
        {
            
        }
       
    }


    // Use this for initialization
    void Start()
    {
       
        if (!setupComplete)
        {
            bool_game_tutorial = true;
            setupComplete = true;
        }else
        {
            
        }
        shop_changecover(int_SpriteCover);
        shop_changeSelector(int_SpriteSelector);
        shop_shopitemsnum = 100;
        int_ach_num = 30;
        boss_levels_num = 30;
        lang_num = 30;
        langs =new bool[lang_num];
        boss_levels = new bool[boss_levels_num];
        bool_ach_array = new bool[int_ach_num];
        shopItems = new bool[shop_shopitemsnum];
      
        Lang_TileCount = 21;
        determine_tile_width();
        ost_mainmenu.SetActive(true);
        setArrayStrings();
        script_ios = selfContainer.GetComponent<IOSPlatServices>();
        script_ads = selfContainer.GetComponent<Ads>();
        bool_game_mainmenu = true;
        screenPosition.y = Screen.height / 2;
        variant_speed_increase = -0.04f;
        float_tile_movespeed = -Screen.width *0.00008f;//-0.094f;
        default_speed = -Screen.width * 0.00007f;
        boss_default_speed = -Screen.width * 0.00009f;
        boss2_default_speed = -Screen.width * 0.00006f;
        boss3_default_speed = -Screen.width * 0.00008f;
        lang_default_speed = -Screen.width * 0.00006f;
        GameCamera = GetComponent<Camera>();
        array_tiles = new List<GameObject>();
        con_ui_mainmenu.SetActive(true);
        spawntiles(true,false, false,false);
       
        oriSize = array_tiles[0].GetComponent<SpriteRenderer>().transform.localScale;
        oriPosition = array_tiles[0].transform.localPosition;
        calculateSpriteSize();
        lose_pos = GameCamera.WorldToViewportPoint(variant_Selector.transform.position);
        mmenu_high_score.text = "Highscore" + " : " + int_highscore;
        pause_bg.SetActive(false);
        coinAnimator = pause_coin.GetComponent<Animator>();
        Load();
        //int_coins = 5000;
        mmenu_CurrentCoins.text = int_coins.ToString();
        hud_T_PlayerBar = new Vector3(1,1,1);
        hud_T_EnemyBar = new Vector3(1,1,1);

        //;
        /* int_SpriteCover = 2;
         int_SpriteSelector = 1;
         int_SpriteTile = 4;
         shop_changecover(int_SpriteCover);
         shop_changeSelector(int_SpriteSelector);
         shop_changeTiles(int_SpriteTile);*/




        //initializeAdColony();
      

        //;



    }

    public void hud_setScore()
    {
        //str_ui_mainmenu_btnStart.text = getLanguage(0);
        pause_coin.SetActive(true);
        hud_scoreText.SetActive(true);
        str_ui_hud_score.text = int_current_score.ToString();
    }

    //Ads Section

    #region 
        public void mmenu_credits()
    {
        con_ui_mainmenu.SetActive(false);
        bool_shop = true;
        con_credits.SetActive(true);
        
    }

    public void mmenu_creditsback()
    {
        
        con_credits.SetActive(false);
        bool_shop = false;
        con_ui_mainmenu.SetActive(true);
    }
    
    #endregion


    //Set UI Strings
    #region


    public void setQuestionStrings()
    {

    }
    //Lang
    //Get Lang
    public string getLanguage(int strNum)
    {
        // string outputStr;
        if (isEN == true)
        {
            LanguageHolder[strNum] = EN[strNum];
            //outputStr = LanguageHolder[strNum]; 
        }

        if (isPT == true)
        {
            LanguageHolder[strNum] = PT[strNum];
            // outputStr = LanguageHolder[strNum];
        }



        return LanguageHolder[strNum];
    }

    public void setENlan()
    {
        // Debug.Log("pressed");
        isEN = true;
        isPT = false;

        /*if (ui_opscreen == true)
        {
            setOPScreenStrings();
        }*/
    }

    public void setPTlan()
    {
        //Debug.Log("pressed");
        isPT = true;
        isEN = false;

        /*if (ui_opscreen == true)
        {
            setOPScreenStrings();
        }*/
    }

    public void setArrayStrings()
    {


        EN[0] = "Start";
        EN[1] = "Select your language";
        EN[2] = "Lets get set up!";
        EN[3] = "What is your name?";
        EN[4] = "Welcome ";
        EN[5] = "How many children do you have?";
        EN[6] = "What is the name of children number";
        EN[7] = "Great! You're ready to use Chisel!";
        EN[8] = "Enter your name here";
        EN[9] = "Enter the number here";
        EN[10] = "Enter the child's name here";
        EN[11] = "That is not a number. Please enter a number above 0.";
        EN[12] = "Great!";
        EN[13] = "How many points does it reward each children with?";
        EN[14] = "Enter the number here";
        EN[15] = "What do you want them to do?";
        EN[16] = "Enter task";
        EN[17] = "Who do you want to assign the task to?";
        EN[18] = "Please enter a cost for this task. It must be a number above 0.";
        EN[19] = "Create Task";
        EN[20] = "Create a new Task";
        EN[21] = "Create Reward";
        EN[22] = "Create a new Reward";
        EN[23] = "All Children";
        EN[24] = "Name of Child";
        EN[25] = "Points";
        EN[26] = "Level";
        EN[27] = "XP till next level";
        EN[28] = "Tasks";
        EN[29] = "Rewards";
        EN[30] = "Dinner Time";
        EN[31] = "Set your time";
        EN[32] = "Start";
        EN[33] = "Stop";
        EN[34] = "Done";
        EN[35] = "How many points would you like to give away?";
        EN[36] = "Next";
        EN[37] = "What do you want the prize to be?";
        EN[38] = "Enter prize name here";
        EN[39] = "How much do you want it to cost?";
        EN[40] = "Enter cost here";



        PT[0] = "Osso";
        PT[1] = "Cenoura";
        PT[2] = "Gato";
        PT[3] = "Queijo";
        PT[4] = "Cão";
        PT[5] = "Electricidade";
        PT[6] = "Raposa";
        PT[7] = "Lua";
        PT[8] = "Rato";
        PT[9] = "Sol";
        PT[10] = "Àgua";
        PT[11] = "Lobo";
        PT[12] = "Livro";
        PT[13] = "Casa";
        PT[14] = "Óculos";
        PT[15] = "Mala";
        PT[16] = "Carro";
        PT[17] = "Lápis";
        PT[18] = "Anjo";
        PT[19] = "Coração";
        PT[20] = "Fogo";
        PT[21] = "Nave espacial";
        PT[22] = "Criar uma nova Recompensa";
        PT[23] = "Todos/as os/as filhos/as";
        PT[24] = "Nome do/a filho/a";
        PT[25] = "Pontos";
        PT[26] = "Nível";
        PT[27] = "XP até o próximo nível";
        PT[28] = "Tarefas";
        PT[29] = "Recompensas";
        PT[30] = "Hora de jantar";
        PT[31] = "Escolha o tempo";
        PT[32] = "Começar";
        PT[33] = "Parar";
        PT[34] = "Terminar";
        PT[35] = "Quantos pontos quer dar de recompensa?";
        PT[36] = "Próximo";
        PT[37] = "O que quer que seja a recompensa?";
        PT[38] = "Insira o prémio aqui";
        PT[39] = "Quanto é que quer que custe?";
        PT[40] = "Insira o custo aqui";

        NL[0] = "Bot";
        NL[1] = "Wortel";
        NL[2] = "Kat";
        NL[3] = "Kaas";
        NL[4] = "Hond";
        NL[5] = "Elektriciteit";
        NL[6] = "Vos";
        NL[7] = "Maan";
        NL[8] = "Muis";
        NL[9] = "Zon";
        NL[10] = "Water";
        NL[11] = "Wolf";
        NL[12] = "Boek";
        NL[13] = "Huis";
        NL[14] = "Bril";
        NL[15] = "Koffer";
        NL[16] = "Auto";
        NL[17] = "Potlood";
        NL[18] = "Engel";
        NL[19] = "Hart";
        NL[20] = "Brand";
        NL[21] = "Ruimteschip";



    }
    #endregion

    // Update is called once per frame
    void Update()
    {

        
        Vector3 pos = GameCamera.WorldToViewportPoint(variant_Selector.transform.position);
        Vector3 left = GameCamera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));
        Vector3 right = GameCamera.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f));

        if (Input.GetKeyDown(KeyCode.Space))
       {
            //Application.CaptureScreenshot("Screenshot.jpg", 0);
            RemoveDuplicates();

}


        if (bool_game_pause)
        {

        }
        else if (bool_game_lose || bool_shop)
        {
            moveTiles();
        }
        else
        {
            if (variant_reverseTile)
            {
                if (var_stoppedReverse)
                {
                    ReverseTiles();
                }
                else
                {
                    moveTiles();
                }

            }
            else
            {
                moveTiles();
            }





            if (variant_moveselector)
            {

                if (determineReverseDirection)
                {
                    int direction = Random.Range(0, 2);

                    if (direction == 0)
                    {
                        goRight = true;
                    }
                    else
                    {
                        goRight = false;
                    }
                    determineReverseDirection = false;
                }

                // Debug.Log(GameCamera.ViewportToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)));
                if (goRight == false)
                {
                    if (0.7 < pos.x)
                    {


                        goRight = true;

                    }
                    variant_Selector.transform.position += new Vector3(0.02f, 0f, 0f);



                }
                else
                {
                    if (pos.x < 0.3)
                    {
                        goRight = false;

                    }

                    variant_Selector.transform.position -= new Vector3(0.04f, 0f, 0f);

                }


            }
            else
            {
                /*if(pos.x == 0.5)
                {

                }else
                {
                    Vector3.MoveTowards(pos, new Vector3(0.5f, pos.y, pos.z), 0);
                    // variant_Selector.transform.position.move
                }


                */
                if (pos.x < 0.5)
                {

                }
                else
                {
                    variant_Selector.transform.position -= new Vector3(0.01f, 0f, 0f);
                }


                if (pos.x > 0.5)
                {

                }
                else
                {
                    variant_Selector.transform.position += new Vector3(0.01f, 0f, 0f);
                }


            }


            if (!bool_Inmenu) { 

            if (Input.GetMouseButtonDown(0))
            { //clear the list and reset the hit vector myHitList.Clear(); firstHit = new Vector3();

                //this one was a mighty head scratcher, make sure you have all your colliders as 2d colliders
                RaycastHit2D[] hits;
                Vector3 mousePos = Input.mousePosition;

                if (bool_game_tutorial && !bool_bossmode && !lang_modeOn)
                {
                    if (int_current_score == 4)
                    {
                        variant_increase_gamespeed = true;
                        ActivateGameVariants(0);

                    }
                    else if (int_current_score == 9)
                    {
                        variant_changesize = true;
                        ActivateGameVariants(0);
                    }
                    else if (int_current_score == 14)
                    {
                        variant_changesize = false;
                       determineReverseDirection = true;
                        variant_moveselector = true;

                        ActivateGameVariants(0);
                    }
                    else if (int_current_score == 19)
                    {
                        variant_moveselector = false;
                        variant_tile_moveY = true;

                    }
                  
                    else if (int_current_score == 24)
                    {
                            variant_tile_moveY = false;
                            variant_reverseTile = false;
                        var_stoppedReverse = false;
                        bool_game_tutorial = false;
                    }

                }





                Vector3 screenPos = GameCamera.ScreenToWorldPoint(mousePos);
                Vector2 inf = new Vector2(Mathf.Infinity, Mathf.Infinity);
                //RaycastHit hit = Physics2D.Raycast(screenPos, Vector2.zero);
                hits = Physics2D.RaycastAll(screenPos, inf, Mathf.Infinity);

                if (hits.Length > 0)
                {
                    for (int i = 0; i < hits.Length; i++)
                    {
                            Debug.Log(hits[i].collider.tag);
                        //Debug.Log(hits[i].collider.name);
                        if (hits[i].collider.tag == "touchArea")
                        {
                                for (int f = 0; f < hits.Length; f++)
                                {
                                    if (hits[f].collider.tag == "tiles")
                                    {
                                        if (hits[f].transform.GetComponent<Tile_self_script>().bool_pressed && !bool_bossmode)
                                        {
                                            //Lose Scenario
                                            game_lose(false);

                                        }
                                        else if (hits[f].transform.GetComponent<Tile_self_script>().bool_pressed && bool_bossmode)
                                        {
                                            game_lose(true);
                                        }
                                        else if (bool_bossmode)
                                        {
                                            if (this.transform.gameObject.GetComponent<BossMode>().currentBoss == 1)
                                            {




                                                //Debug.Log("Stuff");
                                                int_current_score++;
                                                str_ui_hud_score.text = int_current_score.ToString();
                                                hits[f].transform.GetComponent<Tile_self_script>().bool_pressed = true;
                                                hud_T_EnemyBar.x = hud_T_EnemyBar.x - 0.01f;
                                                hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                //coinAnimator.SetBool("Clicked", true);
                                                //coinAnimator.Play("coinadded", -1, 0f);
                                                source.PlayOneShot(putDownFire, 0.7f);
                                                hits[f].transform.GetComponent<SpriteRenderer>().sprite = boss_firemodes[1];

                                                if (hud_T_EnemyBar.x < 0 && boss_levels[0])
                                                {
                                                    DestroyTiles(true);
                                                    boss_victory = true;
                                                    bool_game_play = false;
                                                    boss_levels[0] = true;
                                                    con_ui_hud.SetActive(false);
                                                    con_victory.SetActive(true);
                                                    hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                    hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                    hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                    hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                    ads_Numplaytime++;
                                                    if (ads_Numplaytime == 3)
                                                    {
                                                        ads_Numplaytime = 0;
                                                        script_ads.showInterstitial();

                                                    }
                                                }

                                                if (hud_T_EnemyBar.x < 0 && !boss_levels[0])
                                                {
                                                    DestroyTiles(true);

                                                    boss_victory = true;
                                                    bool_game_play = false;
                                                    boss_levels[0] = true;
                                                    con_ui_hud.SetActive(false);
                                                    con_victory.SetActive(true);
                                                    hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                    hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                    hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                    hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                    ads_Numplaytime++;
                                                    if (ads_Numplaytime == 3)
                                                    {
                                                        ads_Numplaytime = 0;
                                                        script_ads.showInterstitial();

                                                    }
                                                }

                                            }

                                            if (this.transform.gameObject.GetComponent<BossMode>().currentBoss == 2)
                                            {

                                                if (hits[f].transform.gameObject.GetComponent<Tile_self_script>().boss2_shieldDestroyed)
                                                {
                                                    //Debug.Log("Stuff");
                                                    int_current_score++;
                                                    str_ui_hud_score.text = int_current_score.ToString();
                                                    hits[f].transform.GetComponent<Tile_self_script>().bool_pressed = true;
                                                    hud_T_EnemyBar.x = hud_T_EnemyBar.x - 0.01f;
                                                    hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                    //coinAnimator.SetBool("Clicked", true);
                                                    //coinAnimator.Play("coinadded", -1, 0f);
                                                    source.PlayOneShot(putDownFire, 0.7f);
                                                    hits[f].transform.GetComponent<SpriteRenderer>().sprite = boss2_enemysprites[1];

                                                    if (hud_T_EnemyBar.x < 0 && boss_levels[1])
                                                    {
                                                        DestroyTiles(true);
                                                        boss_victory = true;
                                                        bool_game_play = false;
                                                        boss_levels[1] = true;
                                                        con_ui_hud.SetActive(false);
                                                        con_victory.SetActive(true);
                                                        hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                        hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                        hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                        hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                        /*ads_Numplaytime++;
                                                        if (ads_Numplaytime == 2)
                                                        {
                                                            ads_Numplaytime = 0;
                                                            script_ads.showInterstitial();

                                                        }*/
                                                    }

                                                    if (hud_T_EnemyBar.x < 0 && !boss_levels[1])
                                                    {
                                                        DestroyTiles(true);

                                                        boss_victory = true;
                                                        bool_game_play = false;
                                                        boss_levels[1] = true;
                                                        con_ui_hud.SetActive(false);
                                                        con_victory.SetActive(true);
                                                        hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                        hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                        hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                        hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                        /*ads_Numplaytime++;
                                                        if (ads_Numplaytime == 3)
                                                        {
                                                            ads_Numplaytime = 0;
                                                            script_ads.showInterstitial();

                                                        }*/
                                                    }
                                                }




                                               

                                            }

                                            if (this.transform.gameObject.GetComponent<BossMode>().currentBoss == 3)
                                            {
                                              
                                                    Debug.Log("Stuff");
                                                    int_current_score++;
                                                    str_ui_hud_score.text = int_current_score.ToString();
                                                    hits[f].transform.GetComponent<Tile_self_script>().bool_pressed = true;
                                                    hud_T_EnemyBar.x = hud_T_EnemyBar.x - 0.01f;
                                                    hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                    //coinAnimator.SetBool("Clicked", true);
                                                    //coinAnimator.Play("coinadded", -1, 0f);
                                                    source.PlayOneShot(putDownFire, 0.7f);
                                                    hits[f].transform.GetComponent<SpriteRenderer>().sprite = Boss3_sprites[0];

                                                    if (hud_T_EnemyBar.x < 0 && boss_levels[2])
                                                    {
                                                        DestroyTiles(true);
                                                        boss_victory = true;
                                                        bool_game_play = false;
                                                        boss_levels[2] = true;
                                                        con_ui_hud.SetActive(false);
                                                        con_victory.SetActive(true);
                                                        hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                        hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                        hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                        hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                        /*ads_Numplaytime++;
                                                        if (ads_Numplaytime == 2)
                                                        {
                                                            ads_Numplaytime = 0;
                                                            script_ads.showInterstitial();

                                                        }*/
                                                    }

                                                    if (hud_T_EnemyBar.x < 0 && !boss_levels[2])
                                                    {
                                                        DestroyTiles(true);

                                                        boss_victory = true;
                                                        bool_game_play = false;
                                                        boss_levels[1] = true;
                                                        con_ui_hud.SetActive(false);
                                                        con_victory.SetActive(true);
                                                        hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                        hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                        hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                                        hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                                      /*  ads_Numplaytime++;
                                                        if (ads_Numplaytime == 3)
                                                        {
                                                            ads_Numplaytime = 0;
                                                            script_ads.showInterstitial();

                                                        }*/
                                                    }
                                                
                                            }





                                            }
                                        else if (lang_modeOn)
                                        {

                                            lang_GiveWordOut(hits[f].transform.gameObject.GetComponent<Tile_self_script>().lang_ChosenTile);

                                            hud_setScore();

                                            int_current_score++;
                                            str_ui_hud_score.text = int_current_score.ToString();
                                            hits[f].transform.GetComponent<Tile_self_script>().bool_pressed = true;
                                            //coinAnimator.SetBool("Clicked", true);
                                            //coinAnimator.Play("coinadded", -1, 0f);
                                            source.PlayOneShot(coinSound, 0.4f);

                                            hits[f].transform.GetComponent<SpriteRenderer>().color = Color.blue;
                                        }
                                        else
                                        {
                                            hud_setScore();
                                            //Add score scenario
                                            int_current_score++;
                                            ost_mainmenu.SetActive(false);
                                            ost_game.SetActive(true);
                                            str_ui_hud_score.text = int_current_score.ToString();
                                            hits[f].transform.GetComponent<Tile_self_script>().bool_pressed = true;
                                            coinAnimator.SetBool("Clicked", true);
                                            coinAnimator.Play("coinadded", -1, 0f);
                                            source.PlayOneShot(coinSound, 0.4f);
                                            /*if (hits[f].transform.GetComponent<Tile_self_script>().bool_sizeDivided)
                                            {
                                                hits[f].transform.GetComponent<SpriteRenderer>().sprite = CrunchedTileSpriteTouched[int_SpriteTile];
                                            }else
                                            {*/
                                            hits[f].transform.GetComponent<SpriteRenderer>().sprite = TileSpriteTouched[int_SpriteTile];

                                            //\}
                                            //hits[f].transform.GetComponent<SpriteRenderer>().color = Color.blue;
                                            // hits[f].transform.GetComponent<Tile_self_script>().bool_firstTouched = true;

                                            if (bool_game_mainmenu)
                                            {
                                                bool_game_mainmenu = false;
                                                StartCoroutine(activateSelector());

                                                bool_game_play = true;
                                                con_ui_hud.SetActive(true);

                                                // this object was clicked - do something
                                                con_ui_mainmenu.SetActive(false);

                                            }



                                            //ACH 1 to 5
                                            #region
                                            //ACH 1
                                            if (Application.platform == RuntimePlatform.Android)
                                            {
                                                if (!bool_ach_array[1])
                                                {
                                                    Social.ReportProgress("CgkIr9at_PYOEAIQAg", 100.0f, (bool ssuccess) =>
                                                     {
                                                          // handle success or failure
                                                      });
                                                    bool_ach_array[1] = true;
                                                    int_coins = int_coins + 10;
                                                    Save();
                                                }
                                            }

                                            if (Application.platform == RuntimePlatform.IPhonePlayer)
                                            {
                                                if (!bool_ach_array[1])
                                                {
                                                    GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                                                    Social.localUser.Authenticate(success =>
                                                    {
                                                        if (success)
                                                        {
                                                            ReportAchievement(0);
                                                        }
                                                        else
                                                        {
                                                            Debug.Log("Failed to authenticate");
                                                        }
                                                    });
                                                    bool_ach_array[1] = true;
                                                    int_coins = int_coins + 10;
                                                    Save();
                                                }

                                            }


                                            //ACH2 Touch 10 Tiles
                                            if (int_current_score == 10)
                                            {
                                                if (Application.platform == RuntimePlatform.Android)
                                                {
                                                    if (!bool_ach_array[2])
                                                    {
                                                        Social.ReportProgress("CgkIr9at_PYOEAIQBA", 100.0f, (bool ssuccess) =>
                                                        {
                                                              // handle success or failure
                                                          });
                                                        bool_ach_array[2] = true;
                                                        int_coins = int_coins + 20;
                                                        Save();
                                                    }
                                                }

                                                if (Application.platform == RuntimePlatform.IPhonePlayer)
                                                {
                                                    if (!bool_ach_array[2])
                                                    {
                                                        GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                                                        Social.localUser.Authenticate(success =>
                                                        {
                                                            if (success)
                                                            {
                                                                ReportAchievement(1);
                                                            }
                                                            else
                                                            {
                                                                Debug.Log("Failed to authenticate");
                                                            }
                                                        });
                                                        bool_ach_array[2] = true;
                                                        int_coins = int_coins + 20;
                                                        Save();
                                                    }

                                                }
                                            }


                                            //ACH3 Touch 50 Tiles
                                            if (int_current_score == 50)
                                            {
                                                if (Application.platform == RuntimePlatform.Android)
                                                {
                                                    if (!bool_ach_array[3])
                                                    {
                                                        Social.ReportProgress("CgkIr9at_PYOEAIQBQ", 100.0f, (bool ssuccess) =>
                                                         {
                                                              // handle success or failure
                                                          });
                                                        bool_ach_array[3] = true;
                                                        shopItems[0] = true;
                                                        int_SpriteTile = 0;
                                                        shop_changeTiles(int_SpriteTile, false);
                                                        con_shop.GetComponent<ui_shop>().item_sale[0].SetActive(false);
                                                        con_shop.GetComponent<ui_shop>().item_purchased[0].SetActive(true);
                                                        int_coins = int_coins + 50;
                                                        Save();
                                                    }
                                                }

                                                if (Application.platform == RuntimePlatform.IPhonePlayer)
                                                {
                                                    if (!bool_ach_array[3])
                                                    {
                                                        GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                                                        Social.localUser.Authenticate(success =>
                                                        {
                                                            if (success)
                                                            {
                                                                ReportAchievement(2);
                                                            }
                                                            else
                                                            {
                                                                Debug.Log("Failed to authenticate");
                                                            }
                                                        });
                                                        bool_ach_array[3] = true;
                                                        shopItems[0] = true;
                                                        con_shop.GetComponent<ui_shop>().item_sale[0].SetActive(false);
                                                        con_shop.GetComponent<ui_shop>().item_purchased[0].SetActive(true);
                                                        int_SpriteTile = 0;
                                                        shop_changeTiles(int_SpriteTile, false);
                                                        int_coins = int_coins + 50;
                                                        Save();
                                                    }

                                                }

                                            }

                                            //ACH4 Touch 100 Tiles
                                            if (int_current_score == 100)
                                            {
                                                if (Application.platform == RuntimePlatform.Android)
                                                {
                                                    if (!bool_ach_array[4])
                                                    {
                                                        Social.ReportProgress("CgkIr9at_PYOEAIQBg", 100.0f, (bool ssuccess) =>
                                                        {
                                                              // handle success or failure
                                                          });
                                                        bool_ach_array[4] = true;
                                                        shopItems[8] = true;
                                                        int_SpriteSelector = 4;
                                                        shop_changeSelector(int_SpriteSelector);
                                                        con_shop.GetComponent<ui_shop>().item_sale[8].SetActive(false);
                                                        con_shop.GetComponent<ui_shop>().item_purchased[8].SetActive(true);
                                                        int_coins = int_coins + 100;
                                                        Save();
                                                    }
                                                }

                                                if (Application.platform == RuntimePlatform.IPhonePlayer)
                                                {
                                                    if (!bool_ach_array[4])
                                                    {
                                                        GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                                                        Social.localUser.Authenticate(success =>
                                                        {
                                                            if (success)
                                                            {
                                                                ReportAchievement(3);
                                                            }
                                                            else
                                                            {
                                                                Debug.Log("Failed to authenticate");
                                                            }
                                                        });
                                                        bool_ach_array[4] = true;

                                                        int_coins = int_coins + 100;
                                                        Save();
                                                    }

                                                }
                                                shopItems[8] = true;
                                                int_SpriteSelector = 4;
                                                shop_changeSelector(int_SpriteSelector);
                                                con_shop.GetComponent<ui_shop>().item_sale[8].SetActive(false);
                                                con_shop.GetComponent<ui_shop>().item_purchased[8].SetActive(true);
                                            }



                                            //ACH5 Touch 500 Tiles
                                            if (int_current_score == 500)
                                            {
                                                if (Application.platform == RuntimePlatform.Android)
                                                {
                                                    if (!bool_ach_array[5])
                                                    {
                                                        Social.ReportProgress("CgkIr9at_PYOEAIQBw", 100.0f, (bool ssuccess) =>
                                                         {
                                                              // handle success or failure
                                                          });
                                                        bool_ach_array[5] = true;
                                                        shopItems[12] = true;
                                                        int_SpriteCover = 1;
                                                        shop_changecover(int_SpriteCover);
                                                        con_shop.GetComponent<ui_shop>().item_sale[12].SetActive(false);
                                                        con_shop.GetComponent<ui_shop>().item_purchased[12].SetActive(true);
                                                        int_coins = int_coins + 500;
                                                        Save();
                                                    }
                                                }

                                                if (Application.platform == RuntimePlatform.IPhonePlayer)
                                                {
                                                    if (!bool_ach_array[5])
                                                    {
                                                        GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                                                        Social.localUser.Authenticate(success =>
                                                        {
                                                            if (success)
                                                            {
                                                                ReportAchievement(4);
                                                            }
                                                            else
                                                            {
                                                                Debug.Log("Failed to authenticate");
                                                            }
                                                        });
                                                        bool_ach_array[5] = true;
                                                        shopItems[12] = true;
                                                        int_SpriteCover = 1;
                                                        shop_changecover(int_SpriteCover);
                                                        con_shop.GetComponent<ui_shop>().item_sale[12].SetActive(false);
                                                        con_shop.GetComponent<ui_shop>().item_purchased[12].SetActive(true);
                                                        int_coins = int_coins + 500;
                                                        Save();
                                                    }

                                                }

                                            }
                                            #endregion

                                        }


                                    }
                                    if (hits[f].collider.tag == "shield")
                                    {
                                     hits[f].transform.gameObject.GetComponent<ShotsInside>().parent.transform.gameObject.GetComponent<ShotsInside>().Shots[0].GetComponent<Tile_self_script>().boss2_shieldDestroyed = true;
                                        Destroy(hits[f].transform.gameObject);
                                       
                                      hits[f].transform.gameObject.GetComponent<ShotsInside>().Shield.Clear();
                                       /* int_current_score++;
                                        str_ui_hud_score.text = int_current_score.ToString();
                                        hits[f].transform.GetComponent<Tile_self_script>().bool_pressed = true;
                                        hud_T_EnemyBar.x = hud_T_EnemyBar.x - 0.01f;
                                        hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                        //coinAnimator.SetBool("Clicked", true);
                                        //coinAnimator.Play("coinadded", -1, 0f);
                                        source.PlayOneShot(putDownFire, 0.7f);
                                        hits[f].transform.GetComponent<SpriteRenderer>().sprite = boss2_enemysprites[1];

                                        if (hud_T_EnemyBar.x < 0 && boss_levels[0])
                                        {
                                            DestroyTiles(true);
                                            boss_victory = true;
                                            bool_game_play = false;
                                            boss_levels[0] = true;
                                            con_ui_hud.SetActive(false);
                                            con_victory.SetActive(true);
                                            hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                            hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                            hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                            hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                            ads_Numplaytime++;
                                            if (ads_Numplaytime == 2)
                                            {
                                                ads_Numplaytime = 0;
                                                script_ads.showInterstitial();

                                            }
                                        }

                                        if (hud_T_EnemyBar.x < 0 && !boss_levels[0])
                                        {
                                            DestroyTiles(true);

                                            boss_victory = true;
                                            bool_game_play = false;
                                            boss_levels[0] = true;
                                            con_ui_hud.SetActive(false);
                                            con_victory.SetActive(true);
                                            hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                            hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                            hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
                                            hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
                                            ads_Numplaytime++;
                                            if (ads_Numplaytime == 2)
                                            {
                                                ads_Numplaytime = 0;
                                                script_ads.showInterstitial();

                                            }
                                        }
                                        */
                                    }
                                }
                        }
                    }
                }






            }
        }
        }
    }

    private void RemoveDuplicates()
    {
        Debug.Log("ds");
        int listCount = array_tiles.Count;

        for (int i = listCount-1; i >= 0; i--)
        {
                         
                    array_tiles.RemoveAt(i);
            return;
                }
            
        
        Debug.Log(array_tiles.Count);
    }

    public IEnumerator activateSelector()
    {
        yield return new WaitForSeconds(5f);
        bool_canLose = true;
    }

    public void ReverseTiles()
    {

        //Debug.Log("ds");
        for (int i = 0; i < array_tiles.Count; i++)
        {
            array_tiles[i].transform.position += new Vector3(0.05f, 0, 0);
        }
        StartCoroutine(RestartReverseTiles());
    }

    IEnumerator RestartReverseTiles()
    {
        yield return new WaitForSeconds(0.5f);
        var_stoppedReverse = false;
        if (bool_game_tutorial)
        {
            StartCoroutine(ReverseAgain());
        }
        else
        {
            variant_reverseTile = false;
        }
    }
    IEnumerator ReverseAgain()
    {
        yield return new WaitForSeconds(2f);
        var_stoppedReverse = true;
    }



    //MAIN MENU

   

    public void Btn_lose_mainmenu()
    {

        ost_lose.SetActive(false);
        ost_mainmenu.SetActive(true);
        mmenu_CurrentCoins.text = int_coins.ToString();
        float_tile_movespeed = default_speed;

        if (bool_bossmode && boss_victory)
        {
            this.transform.gameObject.GetComponent<BossMode>().currentBoss = 0;
            con_victory.SetActive(false);
            bool_game_lose = false;
            bool_bossmode = false;
            boss_victory = false;
            bool_game_mainmenu = true;
            shop_changeSelector(int_SpriteSelector);
            shop_changecover(int_SpriteCover);
            hud_T_PlayerBar.x = 1;
            con_ui_mainmenu.SetActive(true);
            hud_enemyPanel.SetActive(false);
            hud_PlayerPanel.SetActive(false);
            hud_enemyLifebar.SetActive(false);
            hud_player_bar.SetActive(false);
            spawntiles(true, false,false, false);
            int_current_score = 0;
            hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
        }

        if (bool_game_lose && !boss_victory)
        {
            
            bool_game_lose = false;
            con_ui_lose.SetActive(false);
            con_ui_mainmenu.SetActive(true);
            bool_game_mainmenu = true;
            //StartCoroutine(activateSelector());
            int_current_score = 0;
        }

        if (lang_modeOn)
        {
            lang_modeOn = false;
            lang_panel.SetActive(false);
        }

        if (bool_bossmode)
        {
            bool_bossmode = false;
            
            bool_game_mainmenu = true;
           
            int_current_score = 0;
            shop_changeSelector(int_SpriteSelector);
            shop_changecover(int_SpriteCover);
            spawntiles(true, false,false,false);

            hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
            hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
            hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
            hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
        }


    }

    public void lose_Restart()
    {
        ost_lose.SetActive(false);
        if (bool_bossmode)
        {
            if(this.transform.gameObject.GetComponent<BossMode>().currentBoss == 1){
                spawntiles(false, true, false,false);
            }
            else if (this.transform.gameObject.GetComponent<BossMode>().currentBoss == 2)
            {
                spawntiles(false, false, true,false);
            }else if(this.transform.gameObject.GetComponent<BossMode>().currentBoss == 3)
            {
                spawntiles(false, false, false, true);
            }

            ost_boss1.SetActive(true);
            hud_enemyPanel.SetActive(true);
            hud_PlayerPanel.SetActive(true);
            hud_enemyLifebar.SetActive(true);
            hud_player_bar.SetActive(true);
           

            hud_T_EnemyBar = new Vector3(1.0f, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
            hud_T_PlayerBar = new Vector3(1.0f, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
            hud_enemyLifebar.transform.localScale = new Vector3(hud_T_EnemyBar.x, hud_T_EnemyBar.y, hud_T_EnemyBar.z);
            hud_player_bar.transform.localScale = new Vector3(hud_T_PlayerBar.x, hud_T_PlayerBar.y, hud_T_PlayerBar.z);
        }
        else
        {
            StartCoroutine(activateSelector());
            ost_game.SetActive(true);

        }

        if (lang_modeOn)
        {
            lang_panel.SetActive(true);
            if (isPT)
            {
                isPT = false;
            }
        }

        int_current_score = 0;
        bool_game_lose = false;
        bool_game_mainmenu = false;
       
        
        mmenu_CurrentCoins.text = int_coins.ToString();
        con_ui_lose.SetActive(false);
        mmenu_CurrentCoins.text = int_coins.ToString();
        bool_game_play = true;
        con_ui_hud.SetActive(true);


        // this object was clicked - do something



    }

    public void shop_section()
    {
      
        con_ui_mainmenu.SetActive(false);
        shop_currentcoins.text = int_coins.ToString();
        con_shop.SetActive(true);
        shop_UpdateItemIcons();
        bool_shop = true;
    }

    public void shop_UpdateItemIcons()
    {
        var shopping = con_shop.GetComponent<ui_shop>();
        for (int i = 0; i < shop_shopitemsnum; i++)
        {
            if (shopItems[i])
            {
                shopping.item_sale[i].SetActive(false);
                shopping.item_purchased[i].SetActive(true);
            }
            else
            {

            }
        }
    }

    //PAUSE MENU
    public void PauseGame()
    {
        bool_game_pause = !bool_game_pause;
        if (bool_game_pause)
        {
            pause_pauandplay.GetComponent<Image>().sprite = pause_twosprites[1];
        }else
        {
            pause_pauandplay.GetComponent<Image>().sprite = pause_twosprites[0];
        }
       
        pause_bg.SetActive(bool_game_pause);
    }

    public void muteSound()
    {
        pause_mutesound = !pause_mutesound;
        if (pause_mutesound)
        {
            AudioListener.volume = 0;
            pause_mutebtn.GetComponent<Image>().sprite = pause_mutesprites[1];
        }else
        {
            AudioListener.volume = 1;
            pause_mutebtn.GetComponent<Image>().sprite = pause_mutesprites[0];
        }
    }

    //GAME FUNCTIONS
    #region

    public void ActivateGameVariants(float SpeedIncrement)
    {
      

        // THIS WILL BE THE PREVIOUS SPEED PLUS SPEED INCREMENT FROM WHERE FUNCTION IS CALLED SO THAT WHEN CHECKING IF DECREASING SPEED TO NORMAL OR NOT EVERYTHING WORKS

        if (bool_game_tutorial)
        {
            if (variant_increase_gamespeed)
            {

                variant_increase_gamespeed = false;
                float_tile_movespeed = float_tile_movespeed + variant_speed_increase;
            }
            else if (variant_changesize)
            {
                variant_increase_gamespeed = false;
                float_tile_movespeed = float_tile_movespeed - variant_speed_increase;
                //currentTile.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(scaleTile.x/3, scaleTile.y/3, 1);
            }
        }
        else
        {
            // REGULAR GAME
            if (variant_increase_gamespeed)
            {

                previousSpeed = float_tile_movespeed + SpeedIncrement;

                /* if (previousSpeed < float_tile_movespeed)
                    {*/
                float_tile_movespeed = float_tile_movespeed + SpeedIncrement;
                //Debug.Log("sadas");

                /* }
                    else
                    {
                    //  float_tile_movespeed = float_tile_movespeed + variant_speed_increase;

                    }*/
            }

            if (!variant_increase_gamespeed)
            {
                if (previousSpeed < float_tile_movespeed || previousSpeed == float_tile_movespeed)
                {
                    // float_tile_movespeed = float_tile_movespeed - variant_speed_increase;
                }
                else
                {

                }





            }


        }
    }
    //EACH SIZE SHOULD HAVE THEIR OWN SPRITE LIST
    // Here It will determine the Right sprite to use and the width of the sprite its using
    public void determine_tile_width()
    {
        #region




        // var vCollidersize = Tiles.GetComponent<BoxCollider2D>().size;
        /*   if (Screen.width > 2731)
            {
                //Debug.Log("sdfsd");
                size_tiles = new Vector2(2.4f, 10);
                Tiles.GetComponent<SpriteRenderer>().sprite = TileSpriteChanger[0];
                int_tile_spawnrate = 9;


                tiles_width = Tiles.GetComponent<SpriteRenderer>().sprite.rect.x + 2.6f;
                //Barrier position is equals to the left corner of the screen MINUS the width of the sprite chosen for the devices width 
                Barrier_position.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10)) - new Vector3(tiles_width, 0, 0) - new Vector3(tiles_width, 0, 0);



            }
            else if (Screen.width > 2559 && Screen.width < 2732)
            {
                //Debug.Log("sdfsd");
                size_tiles = new Vector2(2.559f, 10);
                Tiles.GetComponent<SpriteRenderer>().sprite = TileSpriteChanger[1];
                int_tile_spawnrate = 9;


                tiles_width = Tiles.GetComponent<SpriteRenderer>().sprite.rect.x + 2.8f;
                //Barrier position is equals to the left corner of the screen MINUS the width of the sprite chosen for the devices width 
                Barrier_position.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10)) - new Vector3(tiles_width, 0, 0) - new Vector3(tiles_width, 0, 0);



            }

            else if (Screen.width > 2207 && Screen.width < 2560)
            {
                //Debug.Log("sdfsd");
                size_tiles = new Vector2(2.207f, 10);
                Tiles.GetComponent<SpriteRenderer>().sprite = TileSpriteChanger[2];
                int_tile_spawnrate = 9;


                tiles_width = Tiles.GetComponent<SpriteRenderer>().sprite.rect.x + 2.8f;
                //Barrier position is equals to the left corner of the screen MINUS the width of the sprite chosen for the devices width 
                Barrier_position.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10)) - new Vector3(tiles_width, 0, 0) - new Vector3(tiles_width, 0, 0);



            }



            else*/
        if (Screen.width > 1270 && Screen.width < 1300)
        {
            //Debug.Log("sdfsd");
            // size_tiles = new Vector2(2.2f, 7.2f);
            // Tiles.GetComponent<SpriteRenderer>().sprite = TileSpriteChanger[1];
            // int_tile_spawnrate = 9;
            

            //tiles_width = Tiles.GetComponent<SpriteRenderer>().sprite.rect.x + 3.4f;
            //Barrier position is equals to the left corner of the screen MINUS the width of the sprite chosen for the devices width 
            //Barrier_position.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10)) - new Vector3(tiles_width*4, 0, 0) ;
        }
/*

            }
            else if(Screen.width == 1900)
            {
                //Debug.Log(Tiles.GetComponent<SpriteRenderer>().sprite.rect.x);
                size_tiles = new Vector2(2.7f,10.8f);

                Tiles.GetComponent<SpriteRenderer>().sprite = TileSpriteChanger[0];
                int_tile_spawnrate = 9;
                tiles_width = Tiles.GetComponent<SpriteRenderer>().sprite.rect.x + 2.8f;
                //Barrier position is equals to the left corner of the screen MINUS the width of the sprite chosen for the devices width 
                Barrier_position.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10)) - new Vector3(tiles_width, 0, 0) - new Vector3(tiles_width, 0, 0);
            }
            else if (Screen.width < 1100)
            {*/
        //Debug.Log(Tiles.GetComponent<SpriteRenderer>().sprite.rect.x);
        //size_tiles = new Vector2(1.76f, 7.68f);

        // Tiles.GetComponent<SpriteRenderer>().sprite = TileSpriteChanger[10];
        #endregion
        int_tile_spawnrate = 9;
        tiles_width = Tiles.GetComponent<SpriteRenderer>().sprite.rect.x + 2.8f;

        //Barrier position is equals to the left corner of the screen MINUS the width of the sprite chosen for the devices width 
        Barrier_position.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10)) - new Vector3(tiles_width, 0, 0) - new Vector3(tiles_width, 0, 0);
        // }

        // Instantiate(Barrier_Container, Barrier_position, Quaternion.identity);

    }

    public void calculateSpriteSize()
    {
        // Adjust the camera to show world position 'centeredAt' - (0,0,0) or other - with
        // the display being at least 480 units wide and 360 units high.
        Vector3 centeredAt = new Vector3(0, 0, 0);
        Vector3 minimumDisplaySize = new Vector3(1024, 768, 0);

        float pixelsWide = GetComponent<Camera>().pixelWidth;
        float pixelsHigh = GetComponent<Camera>().pixelHeight;

        // Calculate the per-axis scaling factor necessary to fill the view with
        // the desired minimum size (in arbitrary units).
        float scaleX = pixelsWide / minimumDisplaySize.x;
        float scaleY = pixelsHigh / minimumDisplaySize.y;

        // Select the smaller of the two scale factors to use.
        // The corresponding axis will have the exact size specified and the other 
        // will be *at least* the required size and probably larger.
        float scale = (scaleX < scaleY) ? scaleX : scaleY;

        Vector3 displaySize = new Vector3(pixelsWide / scale, pixelsHigh / scale, 0);

        // Use some magic code to get the required distance 'z' from the camera to the content to display
        // at the correct size.
        float z = displaySize.y /
                    (2 * Mathf.Tan((float)GetComponent<Camera>().fieldOfView / 2 * Mathf.Deg2Rad));

        // Set the camera back 'z' from the content.  This assumes that the camera
        // is already oriented towards the content.
        GetComponent<Camera>().transform.position = centeredAt + new Vector3(0, 0, -z);

        // The display is showing the region between coordinates 
        // "centeredAt - displaySize/2" and "centeredAt + displaySize/2".

        // After running this code with minimumDisplaySize 480x360, displaySize will
        // have the following values on different devices (and content will be full-screen
        // on all of them):
        //    iPad Air 2 - 480x360
        //    iPhone 1 - 540x360
        //    iPhone 5 - 639x360
        //    Nexus 6 - 640x360

        // As another example, after running this code with minimumDisplaySize 15x11
        // (tile dimensions for a tile-based game), displaySize will end up with the following 
        // actual tile dimensions on different devices (every device will have a display
        // 11 tiles high and 15+ tiles wide):
        //    iPad Air 2 - 14.667x11
        //    iPhone 1 - 16.5x11
        //    iPhone 5 - 19.525x11
        //    Nexus 6 - 19.556x11
    }

    public void spawntiles(bool normalmode, bool boss1, bool boss2, bool boss3)
    {
        if (normalmode)
        {

            for (int i = 0; i < int_tile_spawnrate; i++)
            {
                int f = i - 1;

                GameObject thisObject;
                // Transform tform_thisObject = thisObject.transform.x;
                if (i == 0)
                {


                    thisObject = Instantiate(Tiles) as GameObject;
                    array_tiles.Add(thisObject);
                   
                    thisObject.GetComponent<SpriteRenderer>().sprite = TileSpriteNoTouched[int_SpriteTile];
                    BoxCollider2D tobj = thisObject.GetComponent<BoxCollider2D>();
                    //tobj.size = new Vector2(size_tiles.x, size_tiles.y);
                    // thisObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(Screen.width / 480f, Screen.height / 320f, 1);


                    
                    thisObject.transform.parent = TileContainer.transform;
                    thisObject.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(0, screenPosition.y, 10));

                }
                if (i != 0)
                {
                    thisObject = Instantiate(Tiles) as GameObject;
                    array_tiles.Add(thisObject);
                    
                    thisObject.GetComponent<SpriteRenderer>().sprite = TileSpriteNoTouched[int_SpriteTile];
                    BoxCollider2D tobj = thisObject.GetComponent<BoxCollider2D>();
                    //tobj.size = new Vector2(size_tiles.x, size_tiles.y);
                    //thisObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(Screen.width / 1366f, Screen.height / 768f, 1);
                    
                    thisObject.transform.parent = TileContainer.transform;
                    thisObject.transform.position = array_tiles[f].transform.position + new Vector3(tiles_width, 0f, 0f); ;
                    // previous_tile_location = array_tiles[f].transform.position + array_tiles[f].GetComponent<Collider>().bounds.size;
                    // var vector_previous_tile_position =array_tiles[f].transform.position;
                    // vector_previous_tile_position.x = vector_previous_tile_position + Tiles.;
                }





            }
        }else if (boss1)
        {
            for (int i = 0; i < int_tile_spawnrate; i++)
            {
                int f = i - 1;

                GameObject thisObject;
                GameObject fire;
            
                // Transform tform_thisObject = thisObject.transform.x;
                if (i == 0)
                {
                    

                    thisObject = Instantiate(con_fire_container) as GameObject;
                    array_tiles.Add(thisObject);
                    Debug.Log(array_tiles.Count);
             
                    //tobj.size = new Vector2(size_tiles.x, size_tiles.y);
                    // thisObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(Screen.width / 480f, Screen.height / 320f, 1);



                    thisObject.transform.parent = TileContainer.transform;
                    thisObject.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(Screen.width, screenPosition.y, 10));



                    int RandPosition;
                    RandPosition = Random.Range(0, 7);

                    if (RandPosition == 0)
                    {
                        boss_spawnFire(0,thisObject, true, false, false);
                    }
                    else if (RandPosition == 1)
                    {
                        boss_spawnFire(0, thisObject, false, true, false);
                    }
                    else if (RandPosition == 2)
                    {
                        boss_spawnFire(0, thisObject, false, false, true);
                    }
                    else if (RandPosition == 3)
                    {
                        boss_spawnFire(0, thisObject, false, true, true);
                      
                    }
                    else if(RandPosition ==4)
                    {
                        boss_spawnFire(0, thisObject, true, true, false);
                    }else if (RandPosition == 5)
                    {
                        boss_spawnFire(0, thisObject, true, false, true);

                    }else
                    {
                        boss_spawnFire(0, thisObject, true, true, true);
                    }




                }
                if (i != 0)
                {
                    thisObject = Instantiate(con_fire_container) as GameObject;
                    array_tiles.Add(thisObject);
                    

                    //tobj.size = new Vector2(size_tiles.x, size_tiles.y);
                    //thisObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(Screen.width / 1366f, Screen.height / 768f, 1);

                    thisObject.transform.parent = TileContainer.transform;
                    thisObject.transform.position = array_tiles[f].transform.position + new Vector3(tiles_width, 0f, 0f); ;

                

                    int RandPosition;
                    RandPosition = Random.Range(0, 7);

                    if (RandPosition == 0)
                    {
                        boss_spawnFire(0, thisObject, true, false, false);
                    }
                    else if (RandPosition == 1)
                    {
                        boss_spawnFire(0, thisObject, false, true, false);
                    }
                    else if (RandPosition == 2)
                    {
                        boss_spawnFire(0, thisObject, false, false, true);
                    }
                    else if (RandPosition == 3)
                    {
                        boss_spawnFire(0, thisObject, false, true, true);

                    }
                    else if (RandPosition == 4)
                    {
                        boss_spawnFire(0, thisObject, true, true, false);
                    }
                    else if (RandPosition == 5)
                    {
                        boss_spawnFire(0, thisObject, true, false, true);

                    }
                    else
                    {
                        boss_spawnFire(0, thisObject, true, true, true);
                    }

                }





            }
        } else if (boss2)
        {
            for (int i = 0; i < int_tile_spawnrate; i++)
            {
                int f = i - 1;

                GameObject thisObject;
                GameObject fire;
                GameObject shieldContainer;

                // Transform tform_thisObject = thisObject.transform.x;
                if (i == 0)
                {


                    thisObject = Instantiate(boss2_container) as GameObject;
                    array_tiles.Add(thisObject);
                    Debug.Log(array_tiles.Count);

                   
                    

                    //tobj.size = new Vector2(size_tiles.x, size_tiles.y);
                    // thisObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(Screen.width / 480f, Screen.height / 320f, 1);



                    thisObject.transform.parent = TileContainer.transform;
                    thisObject.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(Screen.width, screenPosition.y, 10));

                    shieldContainer = Instantiate(con_shieldContainer) as GameObject;
                    thisObject.GetComponent<ShotsInside>().Shield.Add(shieldContainer);
                    shieldContainer.transform.parent = thisObject.transform;
                    shieldContainer.GetComponent<ShotsInside>().parent = thisObject;
                    shieldContainer.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(Screen.width, screenPosition.y, 10));


                    int RandPosition;
                    RandPosition = Random.Range(0, 3);

                    if (RandPosition == 0)
                    {
                        boss_spawnFire(1, thisObject, true, false, false);
                    }
                    else if (RandPosition == 1)
                    {
                        boss_spawnFire(1,thisObject, false, true, false);
                    }
                    else if (RandPosition == 2)
                    {
                        boss_spawnFire(1,thisObject, false, false, true);
                    }

                  


                }
                if (i != 0)
                {
                    thisObject = Instantiate(boss2_container) as GameObject;
                    array_tiles.Add(thisObject);


                    //tobj.size = new Vector2(size_tiles.x, size_tiles.y);
                    //thisObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(Screen.width / 1366f, Screen.height / 768f, 1);

                    thisObject.transform.parent = TileContainer.transform;
                    thisObject.transform.position = array_tiles[f].transform.position + new Vector3(tiles_width, 0f, 0f); ;

                    shieldContainer = Instantiate(con_shieldContainer) as GameObject;
                    thisObject.GetComponent<ShotsInside>().Shield.Add(shieldContainer);
                    shieldContainer.transform.parent = thisObject.transform;
                    shieldContainer.GetComponent<ShotsInside>().parent = thisObject;
                    shieldContainer.transform.position = array_tiles[f].transform.position + new Vector3(tiles_width, 0f, 0f); ;

                    int RandPosition;
                    RandPosition = Random.Range(0, 3);

                    if (RandPosition == 0)
                    {
                        boss_spawnFire(1,thisObject, true, false, false);
                    }
                    else if (RandPosition == 1)
                    {
                        boss_spawnFire(1, thisObject, false, true, false);
                    }
                    else if (RandPosition == 2)
                    {
                        boss_spawnFire(1, thisObject, false, false, true);
                    }

                  

                }





            }
        }else if (boss3)
        {
            GameObject thisObject;
            thisObject = Instantiate(boss3_container) as GameObject;
            array_tiles.Add(thisObject);
            thisObject.transform.parent = TileContainer.transform;
            thisObject.transform.position = GameCamera.ScreenToWorldPoint(new Vector3(Screen.width, screenPosition.y, 10));
                       
        }
    }

    public void boss_DetermineFireRate(int BossNum ,int RandPosition, GameObject parent)
    {
        if (RandPosition == 0)
        {
            boss_spawnFire(BossNum, parent, true, false, false);
        }
        else if (RandPosition == 1)
        {
            boss_spawnFire(BossNum, parent, false, true, false);
        }
        else if (RandPosition == 2)
        {
            boss_spawnFire(BossNum, parent, false, false, true);
        }
        else if (RandPosition == 3)
        {
            boss_spawnFire(BossNum, parent, false, true, true);

        }
        else if (RandPosition == 4)
        {
            boss_spawnFire(BossNum, parent, true, true, false);
        }
        else if (RandPosition == 5)
        {
            boss_spawnFire(BossNum, parent, true, false, true);

        }
        else
        {
            boss_spawnFire(BossNum, parent, true, true, true);
        }
    }

    public void boss_spawnFire(int BossNum, GameObject parentTile, bool up,bool mid, bool down)
    {
        GameObject fire;
        if(BossNum == 0)
        {
            if (up)
            {
                fire = Instantiate(con_boss1_fire1) as GameObject;
                fire.transform.parent = parentTile.transform;
                parentTile.GetComponent<ShotsInside>().Shots.Add(fire);
                fire.transform.position = new Vector3(parentTile.transform.position.x, 2.56f, parentTile.transform.position.z);
            }
            if (mid)
            {
                fire = Instantiate(con_boss1_fire1) as GameObject;
                fire.transform.parent = parentTile.transform;
                parentTile.GetComponent<ShotsInside>().Shots.Add(fire);
                fire.transform.position = new Vector3(parentTile.transform.position.x, 0, parentTile.transform.position.z);
            }
            if (down)
            {
                fire = Instantiate(con_boss1_fire1) as GameObject;
                fire.transform.parent = parentTile.transform;
                parentTile.GetComponent<ShotsInside>().Shots.Add(fire);
                fire.transform.position = new Vector3(parentTile.transform.position.x, -2.56f, parentTile.transform.position.z);
            }
        }else if(BossNum == 1)
        {
          
            if (up)
            {
                fire = Instantiate(boss2_enemy) as GameObject;
                fire.transform.parent = parentTile.transform;
                parentTile.GetComponent<ShotsInside>().Shots.Add(fire);
                fire.transform.position = new Vector3(parentTile.transform.position.x, 2.56f, parentTile.transform.position.z);
            }
            if (mid)
            {
                fire = Instantiate(boss2_enemy) as GameObject;
                fire.transform.parent = parentTile.transform;
                parentTile.GetComponent<ShotsInside>().Shots.Add(fire);
                fire.transform.position = new Vector3(parentTile.transform.position.x, 0, parentTile.transform.position.z);
            }
            if (down)
            {
                fire = Instantiate(boss2_enemy) as GameObject;
                fire.transform.parent = parentTile.transform;
                parentTile.GetComponent<ShotsInside>().Shots.Add(fire);
                fire.transform.position = new Vector3(parentTile.transform.position.x, -2.56f, parentTile.transform.position.z);
            }
          
        }
        
       
    }

    public void boss2_spawnShield(GameObject parentTile)
    {
        GameObject fire;
        fire = Instantiate(boss2_shield) as GameObject;
        fire.transform.parent = parentTile.transform;
        parentTile.GetComponent<ShotsInside>().Shield.Add(fire);
        fire.GetComponent<ShotsInside>().parent = parentTile;
        fire.transform.GetComponent<SpriteRenderer>().sortingOrder = 3;

        fire.transform.position = new Vector3(parentTile.transform.position.x, 0f, parentTile.transform.position.z);
    }

    public void DestroyTiles(bool bossmode)
    {
        if (bossmode)
        {
            for (int i = 0; i < int_tile_spawnrate; i++)
            {
                for (int f = 0; f < array_tiles[i].GetComponent<ShotsInside>().Shots.Count; f++)
                {
                    Destroy(array_tiles[i].GetComponent<ShotsInside>().Shots[f]);

                }
                array_tiles[i].GetComponent<ShotsInside>().Shots.Clear();
                Destroy(array_tiles[i].gameObject);

            }
            array_tiles.Clear();
        
        }
        else
        {
            for (int i = 0; i < int_tile_spawnrate; i++)
            {

                Destroy(array_tiles[i].gameObject);

            }
            array_tiles.Clear();
            Debug.Log(array_tiles.Count);
        }
       
        }

    public void moveTiles()
    {
        if (bool_bossmode && bool_game_lose)
        {

        }else
        {
            for (int i = 0; i < array_tiles.Count; i++)
            {
                array_tiles[i].transform.position += new Vector3(float_tile_movespeed, 0, 0);
            }
        }
        // Tiles.transform.position += new Vector3(-0.5f, 0, 0);
      
    }

    public void RealocateTile(GameObject Tiles, bool var_changesize)
    {

        if (var_changesize)
        {

            //other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, ymca);
            int lastIndex = array_tiles.Count - 2;
            var bottom = GameCamera.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
            BoxCollider2D managerBox = variant_Selector.GetComponent<BoxCollider2D>();


            array_tiles.Remove(Tiles);

            array_tiles.Add(Tiles);
            currentTile = Tiles;
            Tiles.transform.position = new Vector3(array_tiles[lastIndex].transform.position.x, 0f, array_tiles[lastIndex].transform.position.z) + new Vector3(tiles_width, Random.Range(Barrier_Container.GetComponent<Barrier>().minlocationTiles, managerBox.bounds.max.y - managerBox.bounds.max.y / 4), 0f);


            Tiles.transform.GetComponent<Tile_self_script>().bool_pressed = false;
        }
        else
        {
            int lastIndex = array_tiles.Count - 2;



            array_tiles.Remove(Tiles);

            array_tiles.Add(Tiles);
            currentTile = Tiles;
            //Tiles.transform.localScale = 
            Tiles.transform.position = new Vector3(array_tiles[lastIndex].transform.position.x, 0f, array_tiles[lastIndex].transform.position.z) + new Vector3(tiles_width, 0f, 0f);
            //Debug.Log(Barrier_Container.GetComponent<Barrier>().originalSize);
            //Tiles.GetComponent<SpriteRenderer>().transform.localScale =oriSize;
            if (bool_bossmode)
            {

            }else
            {
                Tiles.transform.GetComponent<Tile_self_script>().bool_pressed = false;
            }
         
        }
    }

    #endregion
    //SAVE LOAD SECTION

    #region
    public void Save()
    {

        SaveLoadManager.SavePlayer(this);
    }

    public void Load()
    {
        SaveLoadManager.LoadPlayer(this);

       

    }

    #endregion

  

    //SHOP SECTION
    #region
    public void shop_changecover(int chosenN)
    {
        if (Screen.width > 1270 && Screen.width < 1920)
        {
            
            con_Covers.GetComponent<Image>().sprite = Covers_Streched[chosenN];
        } else if(Screen.width > 1919)
        {
            
            con_Covers.GetComponent<Image>().sprite = Cover_1920[chosenN];
        }
        else 
        {
            con_Covers.GetComponent<Image>().sprite = Covers[chosenN];
        }
       
    }

    public void shop_changeSelector(int chosenN)
    {
        variant_Selector.GetComponent<SpriteRenderer>().sprite = Selectors[chosenN];
    }

    public void shop_changeTiles(int chosenN, bool LangMode)
    {
        if (!LangMode)
        {
            for (int i = 0; i < array_tiles.Count; i++)
            {
                array_tiles[i].GetComponent<SpriteRenderer>().sprite = TileSpriteNoTouched[chosenN];
            }
        }else
        {
            for (int i = 0; i < array_tiles.Count; i++)
            {
                int Rand = Random.Range(0, Lang_TileCount);
                array_tiles[i].GetComponent<SpriteRenderer>().sprite = Lang_Tiles[Rand];
                array_tiles[i].GetComponent<Tile_self_script>().lang_ChosenTile = Rand;
            }
        }
        
    }

    public void lang_changePersonalCover(GameObject tile)
    {
        
            
        

        int Rand = Random.Range(0, Lang_TileCount+1);
        tile.transform.GetComponent<SpriteRenderer>().color = Color.white;
        tile.GetComponent<SpriteRenderer>().sprite = Lang_Tiles[Rand];
        tile.GetComponent<Tile_self_script>().lang_ChosenTile = Rand;
    }

    public void lang_GiveWordOut(int Rand)
    {

        if (isPT)
        {
            LanguageHolder[Rand] = PT[Rand];
            Lang_Text.GetComponent<Text>().text = LanguageHolder[Rand];
        }

        if (isNL)
        {
            LanguageHolder[Rand] = NL[Rand];
            Lang_Text.GetComponent<Text>().text = LanguageHolder[Rand];
        }
            
        
    }

    


    #endregion


    //ACH SECTION
    #region
    public void ReportAchievement(int ach)
    {
        if (ach == 0)
        {
            Social.ReportProgress("ach1", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if(ach == 1)
        {
            Social.ReportProgress("ach2", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 2)
        {
            Social.ReportProgress("ach3", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 3)
        {
            Social.ReportProgress("ach4", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 4)
        {
            Social.ReportProgress("ach5", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 5)
        {
            Social.ReportProgress("ach6", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 6)
        {
            Social.ReportProgress("ach7", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 7)
        {
            Social.ReportProgress("ach8", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 8)
        {
            Social.ReportProgress("ach9", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach ==9)
        {
            Social.ReportProgress("ach10", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 10)
        {
            Social.ReportProgress("ach11", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 11)
        {
            Social.ReportProgress("ach12", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 12)
        {
            Social.ReportProgress("ach13", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        if (ach == 13)
        {
            Social.ReportProgress("ach14", 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

    }

    public void likeFacebook()
    {
        Application.OpenURL("https://www.facebook.com/Dont-Touch-Me-Twice-1748231942103967/");

        //ACH 7
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!bool_ach_array[7])
            {
                  Social.ReportProgress("CgkIr9at_PYOEAIQCA", 100.0f, (bool ssuccess) =>
                  {
                      // handle success or failure
                  });
                bool_ach_array[7] = true;
                int_coins = int_coins + 100;
                Save();
            }
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (!bool_ach_array[7])
            {
                GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                Social.localUser.Authenticate(success => {
                    if (success)
                    {
                        ReportAchievement(6);
                    }
                    else
                    {
                        Debug.Log("Failed to authenticate");
                    }
                });
                bool_ach_array[7] = true;
                int_coins = int_coins + 100;
                Save();
            }

        }

    }
    
    public void RateApp()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.mightysalmonstudioslimited.donttouchmetwice");
#elif UNITY_IPHONE
        Application.OpenURL("itms-apps://itunes.apple.com/app/dont-touch-me-twice!/id1182051555?mt=8");
#endif
   
        //ACH 8
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!bool_ach_array[8])
            {
                Social.ReportProgress("CgkIr9at_PYOEAIQCg", 100.0f, (bool ssuccess) =>
                  {
                      // handle success or failure
                  });
                bool_ach_array[8] = true;
                int_coins = int_coins + 150;
                Save();
            }
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (!bool_ach_array[8])
            {
                GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                Social.localUser.Authenticate(success => {
                    if (success)
                    {
                        ReportAchievement(7);
                    }
                    else
                    {
                        Debug.Log("Failed to authenticate");
                    }
                });
                bool_ach_array[8] = true;
                int_coins = int_coins + 150;
                Save();
            }

        }
    }

    public void ach14()
    {
        //ACH 14
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!bool_ach_array[14])
            {
                 Social.ReportProgress("CgkIr9at_PYOEAIQEA", 100.0f, (bool ssuccess) =>
                  {
                      // handle success or failure
                  });
                bool_ach_array[14] = true;
                int_coins = int_coins + 500;
                Save();
            }
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (!bool_ach_array[14])
            {
                GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                Social.localUser.Authenticate(success => {
                    if (success)
                    {
                        ReportAchievement(13);
                    }
                    else
                    {
                        Debug.Log("Failed to authenticate");
                    }
                });
                bool_ach_array[14] = true;
                int_coins = int_coins + 500;
                Save();
            }

        }
    }
    #endregion

    //LOSE SECTION
    #region

    public void game_lose(bool bossmode)
    {
        if (pause_mutesound)
        {

        }else
        {
            ost_lose.SetActive(true);
        }
      



        if (int_current_score > int_highscore)
        {
            int_highscore = int_current_score;
        }
        StopAllCoroutines();
        bool_game_play = false;
        variant_changesize = false;
        ost_game.SetActive(false);
        variant_moveselector = false;
        variant_tile_moveY = false;
        con_ui_hud.SetActive(false);
        variant_reverseTile = false;
      
        Barrier_Container.GetComponent<Barrier>().StartIncreasingSpeed = false;
        variant_Selector.transform.position = new Vector3(lose_pos.x, 0f,lose_pos.z);
        //pos.x = 0.5f;
        
        if(!bossmode || !lang_modeOn)
        {
            float_tile_movespeed = default_speed;
        }

        con_ui_hud.SetActive(false);
        con_ui_lose.SetActive(true);
        bool_game_lose = true;
        str_ui_lose_pluscoins.text = "+ " + "250";
        if (bossmode)
        {
           
            
            hud_T_PlayerBar.x = 1;
            str_ui_lose_score.text = "You defended yourself from " + int_current_score.ToString() + " Shots";
            ost_boss1.SetActive(false);
            if (this.transform.gameObject.GetComponent<BossMode>().currentBoss != 3)
            {
                for (int i = 0; i < array_tiles.Count; i++)
                {
                    for (int f = 0; f < array_tiles[i].GetComponent<ShotsInside>().Shots.Count; f++)
                    {
                        Destroy(array_tiles[i].GetComponent<ShotsInside>().Shots[f]);

                    }
                    array_tiles[i].GetComponent<ShotsInside>().Shots.Clear();

                    //  Debug.Log(Parent.hud_player_bar.transform.localScale);
                    Destroy(array_tiles[i].gameObject);




                }
            }else
            {
                for (int i = 0; i < array_tiles.Count; i++)
                {
                    Destroy(array_tiles[i].gameObject);
                }
            }
            array_tiles.Clear();
            hud_enemyPanel.SetActive(false);
            hud_PlayerPanel.SetActive(false);
            hud_enemyLifebar.SetActive(false);
            hud_player_bar.SetActive(false);

        }
        else
        {
            str_ui_lose_score.text = "You touched " + int_current_score.ToString() + " Tiles";
        }

        if (lang_modeOn)
        {
            float_tile_movespeed = lang_default_speed;
            lang_panel.SetActive(false);
        }
      
        str_ui_lose_highscore.text ="HIGHSCORE: " + int_highscore.ToString();
        int_coins = int_coins + int_current_score;
        int_alltimecoins = int_alltimecoins + int_coins;
        //variant_Selector.GetComponent<Collider2D>().enabled= false;
        bool_canLose = false;

        //Number of times to show ad
        /*ads_Numplaytime++;
        if(ads_Numplaytime == 3)
        {
            ads_Numplaytime = 0;
            script_ads.showInterstitial();

        }*/


        if (Application.platform == RuntimePlatform.Android)
        {

            Social.ReportScore(int_current_score, "CgkIr9at_PYOEAIQAw", (bool success) => {
                // handle success or failure
            });
        }
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            script_ios.PostScoreOnLeaderBoard(int_current_score);
        }

        Save();
        //ACH 9 - Collect 1000 coins!

        if (int_alltimecoins == 1000)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (!bool_ach_array[9])
                {
                     Social.ReportProgress("CgkIr9at_PYOEAIQCw", 100.0f, (bool ssuccess) =>
                      {
                          // handle success or failure
                      });
                    bool_ach_array[9] = true;
                    int_coins = int_coins + 500;
                    Save();
                }
            }

            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (!bool_ach_array[9])
                {
                    GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                    Social.localUser.Authenticate(success =>
                    {
                        if (success)
                        {
                            ReportAchievement(8);
                        }
                        else
                        {
                            Debug.Log("Failed to authenticate");
                        }
                    });
                    bool_ach_array[9] = true;
                    int_coins = int_coins + 500;
                    Save();
                }

            }
            //ACH10
        }else if(int_alltimecoins == 5000)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (!bool_ach_array[10])
                {
                    Social.ReportProgress("CgkIr9at_PYOEAIQDA", 100.0f, (bool ssuccess) =>
                      {
                          // handle success or failure
                      });
                    bool_ach_array[10] = true;
                    int_coins = int_coins + 1000;
                    Save();
                }
            }

            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (!bool_ach_array[10])
                {
                    GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                    Social.localUser.Authenticate(success =>
                    {
                        if (success)
                        {
                            ReportAchievement(9);
                        }
                        else
                        {
                            Debug.Log("Failed to authenticate");
                        }
                    });
                    bool_ach_array[10] = true;
                    int_coins = int_coins + 1000;
                    Save();
                }

            }
            //ACH 11
        }else if (int_alltimecoins == 10000)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (!bool_ach_array[11])
                {
                    Social.ReportProgress("CgkIr9at_PYOEAIQDQ", 100.0f, (bool ssuccess) =>
                      {
                          // handle success or failure
                      });
                    bool_ach_array[11] = true;
                    int_coins = int_coins + 2000;
                    Save();
                }
            }

            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (!bool_ach_array[11])
                {
                    GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
                    Social.localUser.Authenticate(success =>
                    {
                        if (success)
                        {
                            ReportAchievement(10);
                        }
                        else
                        {
                            Debug.Log("Failed to authenticate");
                        }
                    });
                    bool_ach_array[11] = true;
                    int_coins = int_coins + 2000;
                    Save();
                }

            }
        }
        // con_IOS.GetComponent<IOSPlatServices>().ReportScore(int_current_score, "scoredtmt");

    }


    public void Btn_getmoreSlots()
    {

        Debug.Log("Clicked");
        /* SlotNumber++;
            str_SlotNumber.text = SlotNumber.ToString();*/






    }






    #endregion
}