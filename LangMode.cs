using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LangMode : MonoBehaviour {


    public TileSpawner mainscript;
    public ui_shop shop;
    public Animator anim_L27;
    public GameObject anim_lock;

	// Use this for initialization
	void Start () {
        mainscript = this.GetComponent<TileSpawner>();
        shop = mainscript.con_shop.GetComponent<ui_shop>();
        anim_L27 = anim_lock.GetComponent<Animator>();
    }

    public void mmenu_LangMode()
    {
        mainscript.shop_UpdateItemIcons();
        mainscript.con_ui_mainmenu.SetActive(false);
        mainscript.bool_Inmenu = true;
        mainscript.language_Coins.text = mainscript.int_coins.ToString();
        mainscript.con_lang.SetActive(true);
        anim_L27.Play("lockanim", -1, 0f);
    }

    public void lang_homebtn()
    {
        mainscript.bool_Inmenu = false;
        mainscript.con_lang.SetActive(false);
        mainscript.con_ui_mainmenu.SetActive(true);
        mainscript.hud_enemyPanel.SetActive(false);
        mainscript.hud_PlayerPanel.SetActive(false);
        mainscript.hud_enemyLifebar.SetActive(false);
        mainscript.hud_player_bar.SetActive(false);
        mainscript.mmenu_CurrentCoins.text = mainscript.int_coins.ToString();
    }

    public void L26()
    {
        if (mainscript.shopItems[26])
        {
            if (mainscript.bool_game_mainmenu)
            {
                lang_defaultcode();
                mainscript.isPT = true;             
            }

            mainscript.source.PlayOneShot(shop.sound_purchase, 1.0f);
            
            mainscript.Save();



        }
        else
        {
            if (mainscript.int_coins < 300)
            {

                mainscript.source.PlayOneShot(shop.notenoughCoinsSound, 1.0f);
            }
            else
            {
                shop.item_sale[26].SetActive(false);
                mainscript.int_coins = mainscript.int_coins - 300;
                mainscript.language_Coins.text = mainscript.int_coins.ToString();
                mainscript.source.PlayOneShot(shop.sound_purchase, 1.0f);
                shop.item_purchased[26].SetActive(true);
                mainscript.shopItems[26] = true;
                mainscript.langs[0] = true;
                //mainscript.lang_modeOn = true;
               
                mainscript.Save();
            }


        }
    }

    public void L27()
    {
        if (mainscript.shopItems[27])
        {
            if (mainscript.bool_game_mainmenu)
            {
                lang_defaultcode();
                mainscript.isNL = true;
            }

            //mainscript.source.PlayOneShot(shop.sound_purchase, 1.0f);

            mainscript.Save();



        }
        else
        {
            shop.item_sale[27].SetActive(false);
            shop.item_purchased[27].SetActive(true);
            mainscript.shopItems[27] = true;
            mainscript.unlock_adrelative[0] = true;
            mainscript.langs[1] = true;
            mainscript.script_ads.ShowRewardedVid();
            mainscript.Save();





        }
    }

    public void lang_defaultcode()
    {
        mainscript.float_tile_movespeed = mainscript.lang_default_speed;
        mainscript.bool_game_mainmenu = false;
        StartCoroutine(mainscript.activateSelector());
        mainscript.ost_mainmenu.SetActive(false);
        mainscript.ost_game.SetActive(true);
        mainscript.bool_Inmenu = false;
        mainscript.bool_game_play = true;
        mainscript.lang_modeOn = true;
        mainscript.lang_panel.SetActive(true);
        mainscript.con_ui_hud.SetActive(true);
       
        // this object was clicked - do something
        mainscript.con_lang.SetActive(false);
        mainscript.shop_changeTiles(0, true);
        mainscript.Lang_Text.SetActive(true);
    }


    // Update is called once per frame
    void Update () {
	
	}
}
