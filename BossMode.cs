using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class BossMode : MonoBehaviour {

    public TileSpawner parent;
    public ui_shop shop;
    public int currentBoss;
  
 



    void Awake()
    {
       
    }

    // Use this for initialization
    void Start () {
        parent = this.GetComponent<TileSpawner>();
        shop = parent.con_shop.GetComponent<ui_shop>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btn_BossMode()
    {
        parent.shop_UpdateItemIcons();
        parent.con_ui_mainmenu.SetActive(false);
        parent.bool_Inmenu = true;
        parent.boss_coins.text = parent.int_coins.ToString();
        parent.con_Bossmode.SetActive(true);

    }

    public void boss_home_btn()
    {
        
        parent.bool_Inmenu = false;
        parent.con_Bossmode.SetActive(false);
        parent.con_ui_mainmenu.SetActive(true);
        parent.hud_enemyPanel.SetActive(false);
        parent.hud_PlayerPanel.SetActive(false);
        parent.hud_enemyLifebar.SetActive(false);
        parent.hud_player_bar.SetActive(false);
        parent.mmenu_CurrentCoins.text = parent.int_coins.ToString();

    }

    public void btn_Boss1()
    {
        parent.ost_mainmenu.SetActive(false);

        if (parent.shopItems[25])
            {

            parent.source.PlayOneShot(shop.sound_purchase, 1.0f);
            boss_code(true,false,false);
                parent.Save();


              
            }
            else
            {
                if (parent.int_coins < 500)
                {

                parent.source.PlayOneShot(shop.notenoughCoinsSound, 1.0f);
            }
            else
                {
                shop.item_sale[25].SetActive(false);
                parent.int_coins = parent.int_coins - 500;
                parent.shopItems[25] = true;
                parent.shopItems[24] = true;
                parent.shopItems[23] = true;
                parent.boss_coins.text = parent.int_coins.ToString();

                parent.source.PlayOneShot(shop.sound_purchase, 1.0f);
                shop.item_purchased[25].SetActive(true);
                parent.Save();
            }
              
            
        }

    }

    public void B28()
    {
        if (parent.shopItems[28])
        {
            boss_code(false,true,false);
            parent.Save();
       
            

            //mainscript.source.PlayOneShot(shop.sound_purchase, 1.0f);

            parent.Save();



        }
        else
        {
            //boss_code(false, true);
            shop.item_sale[28].SetActive(false);
            shop.item_purchased[28].SetActive(true);
           parent.shopItems[28] = true;
            parent.unlock_adrelative[1] = true;
         
            parent.script_ads.ShowRewardedVid();
            parent.Save();





        }
    }

    public void B29()
    {
        if (parent.shopItems[29])
        {
            boss_code(false, false, true);
            parent.Save();



            //mainscript.source.PlayOneShot(shop.sound_purchase, 1.0f);

            parent.Save();



        }
        else
        {
            //boss_code(false, true);
            shop.item_sale[29].SetActive(false);
            shop.item_purchased[29].SetActive(true);
            parent.shopItems[29] = true;
            parent.unlock_adrelative[2] = true;

            parent.script_ads.ShowRewardedVid();
            parent.Save();





        }
    }

    public void boss_code(bool boss1, bool boss2, bool boss3)
    {
        if (boss1)
        {
            currentBoss = 1;
            parent.float_tile_movespeed = parent.boss_default_speed;
            parent.con_Bossmode.SetActive(false);
            parent.bool_bossmode = true;
            parent.bool_Inmenu = false;
            parent.bool_game_play = true;
            parent.bool_game_tutorial = false;
            parent.DestroyTiles(false);
            parent.hud_coinicon.SetActive(false);
            parent.hud_text.SetActive(false);
            parent.con_ui_hud.SetActive(true);
            parent.hud_T_EnemyBar.x = 1;
            parent.hud_T_PlayerBar.x = 1;
            parent.hud_enemyPanel.SetActive(true);
            parent.spawntiles(false, true, false, false);
            parent.hud_PlayerPanel.SetActive(true);
            parent.hud_player_bar.SetActive(true);
            parent.hud_enemyLifebar.SetActive(true);
            parent.shop_changecover(7);
            parent.shop_changeSelector(7);
            if (parent.bool_game_mainmenu)
            {
                parent.bool_game_mainmenu = false;


                parent.bool_game_play = true;


                // this object was clicked - do something
                parent.con_ui_mainmenu.SetActive(false);

            }
        }
            if (boss2)
            {
            currentBoss = 2;
            parent.float_tile_movespeed = parent.boss2_default_speed;
            parent.con_Bossmode.SetActive(false);
            parent.bool_bossmode = true;
            parent.bool_Inmenu = false;
            parent.bool_game_play = true;
            parent.bool_game_tutorial = false;
            parent.DestroyTiles(false);
            parent.hud_coinicon.SetActive(false);
            parent.hud_text.SetActive(false);
            parent.con_ui_hud.SetActive(true);
            parent.hud_T_EnemyBar.x = 1;
            parent.hud_T_PlayerBar.x = 1;
            parent.hud_enemyPanel.SetActive(true);
            parent.spawntiles(false, false, true,false);
            parent.hud_PlayerPanel.SetActive(true);
            parent.hud_player_bar.SetActive(true);
            parent.hud_enemyLifebar.SetActive(true);
            parent.shop_changecover(8);
            parent.shop_changeSelector(8);
            if (parent.bool_game_mainmenu)
            {
                parent.bool_game_mainmenu = false;


                parent.bool_game_play = true;


                // this object was clicked - do something
                parent.con_ui_mainmenu.SetActive(false);

            }
        }

        if (boss3)
        {
            currentBoss = 3;
            parent.float_tile_movespeed = parent.boss3_default_speed;
            parent.con_Bossmode.SetActive(false);
            parent.bool_bossmode = true;
            parent.bool_Inmenu = false;
            parent.bool_game_play = true;
            parent.bool_game_tutorial = false;
            parent.DestroyTiles(false);
            parent.hud_coinicon.SetActive(false);
            parent.hud_text.SetActive(false);
            parent.con_ui_hud.SetActive(true);
            parent.hud_T_EnemyBar.x = 1;
            parent.hud_T_PlayerBar.x = 1;
            parent.hud_enemyPanel.SetActive(true);
            parent.spawntiles(false, false, false, true);
            parent.hud_PlayerPanel.SetActive(true);
            parent.hud_player_bar.SetActive(true);
            parent.hud_enemyLifebar.SetActive(true);
            parent.shop_changecover(9);
            parent.shop_changeSelector(9);
            if (parent.bool_game_mainmenu)
            {
                parent.bool_game_mainmenu = false;


                parent.bool_game_play = true;


                // this object was clicked - do something
                parent.con_ui_mainmenu.SetActive(false);

            }
        }



        if (parent.pause_mutesound)
        {

        }
        else
        {
            parent.ost_mainmenu.SetActive(false);
            parent.ost_boss1.SetActive(true);
        }
       
    }

}
