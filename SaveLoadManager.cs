using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveLoadManager: MonoBehaviour {

   

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void SavePlayer(TileSpawner player) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create)  ;

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();

    }

    public static void LoadPlayer(TileSpawner main)
    {
        if (File.Exists(Application.persistentDataPath + "/player.sav"))
        {
           
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

         
            main.int_coins = data.int_coins;
            main.int_alltimecoins = data.int_alltimecoins;
            main.int_highscore = data.highscore;
            main.int_SpriteCover = data.int_SpriteCover;
            main.int_SpriteSelector = data.int_SpriteSelector;
            main.int_SpriteTile = data.int_SpriteTile;
            main.shop_changeSelector(data.int_SpriteSelector);
            main.shop_changeTiles(data.int_SpriteTile, false);
            main.shop_changecover(data.int_SpriteCover);
            main.int_ach_num = data.int_achNum;
            main.ads_Numplaytime = data.ads_playtimes;

            for (int i = 0; i < data.boss_levels_int; i++)
            {
                main.boss_levels[i] = data.boss_levels[i];

            }

            for (int i = 0; i < data.int_achNum; i++)
            {
                main.bool_ach_array[i] = data.ach_array[i];

            }

            for (int i = 0; i < data.shopItemsNum; i++)
            {
                main.shopItems[i] = data.shopItems[i];
              
            }

            for (int i = 0; i < data.lang_num; i++)
            {
                main.langs[i] = data.langs[i];

            }


            stream.Close();
            
            
        }else
        {
            Debug.LogError("File does not exist.");
            //return new int[1];
        }
    }

}

[Serializable]
public class PlayerData
{
    
    public int int_coins;
    public int int_alltimecoins;
    public int highscore;
    public bool[] shopItems;
    public int shopItemsNum;
    public int int_SpriteSelector;
    public int int_SpriteCover;
    public int int_SpriteTile;
    public int int_achNum;
    public bool[] ach_array;
    public int ads_playtimes;
    public bool[] boss_levels;
    public int boss_levels_int;
    public int lang_num;
    public bool[] langs;
    
    






    public PlayerData(TileSpawner player )
    {
        //Here you add the vars to save
       
        int_coins = player.int_coins;
        int_alltimecoins = player.int_alltimecoins;
        highscore = player.int_highscore;
        shopItemsNum = player.shopItems.Length;
        shopItems = new bool[shopItemsNum];
        int_SpriteSelector = player.int_SpriteSelector;
        int_SpriteCover = player.int_SpriteCover;
        int_SpriteTile = player.int_SpriteTile;
        int_achNum = player.bool_ach_array.Length;
        ach_array = new bool[int_achNum];
        ads_playtimes = player.ads_Numplaytime;
        boss_levels_int = player.boss_levels_num;
        boss_levels = new bool[boss_levels_int];
        lang_num = player.lang_num;
        langs = new bool[lang_num];


        for (int i = 0; i < lang_num; i++)
        {
            langs[i] = player.langs[i];
        }

        for (int i = 0; i < boss_levels_int; i++)
        {
            boss_levels[i] = player.boss_levels[i];
        }


        for (int i = 0; i <shopItemsNum; i++)
        {
            shopItems[i] = player.shopItems[i];
           

        }

        for (int i = 0; i < int_achNum; i++)
        {
            ach_array[i] = player.bool_ach_array[i];


        }


        //Children = player.Children;
    }
}