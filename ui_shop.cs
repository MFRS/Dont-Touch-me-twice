using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ui_shop : MonoBehaviour {

    
    public GameObject Parent;
    public GameObject CoinsAnimator;
    public AudioClip notenoughCoinsSound;
    public AudioClip sound_purchase;
    private AudioSource source;
    private Animator notcoinsanim;
    public TileSpawner aq;


    [Header("Buttons")]
    public GameObject btn_foxwolf;
    public GameObject sale_1;
    public GameObject purchase_1;
    public GameObject btn_pastrycover;
    public List<GameObject> item_sale;
    public List<GameObject> item_purchased;
   
    //public int int_alltimecoins;
    //public int int_coins;
    // Use this for initialization

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start () {
         aq = Parent.GetComponent<TileSpawner>();
        notcoinsanim = CoinsAnimator.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    #region

    public void shop_T5()
    {
        aq.int_SpriteTile = 2;
        aq.shop_changeTiles(aq.int_SpriteTile, false);
        
        source.PlayOneShot(sound_purchase, 0.5f);
        aq.Save();
    }

    public void shop_S6()
    {
        aq.int_SpriteSelector = 1;
        aq.shop_changeSelector(aq.int_SpriteSelector);
        source.PlayOneShot(sound_purchase, 0.5f);
        aq.Save();
    }

    public void shop_C15()
    {
        aq.int_SpriteCover = 2;
        aq.shop_changecover(aq.int_SpriteCover);
        source.PlayOneShot(sound_purchase, 0.5f);
        aq.Save();
    }




    public void shop_T0()
    {
      
            if (aq.shopItems[0])
            {
            aq.int_SpriteTile = 0;
            aq.shop_changeTiles(aq.int_SpriteTile, false);
                source.PlayOneShot(sound_purchase, 1.0f);
            aq.Save();
        }
            else
            {
               /* btn_T0_sale.SetActive(false);
                aq.int_coins = aq.int_coins - 50;
                aq.shopItems[0] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                btn_T0_purchase.SetActive(true);
                aq.int_SpriteTile = 0;
                aq.shop_changeTiles(0);
            source.PlayOneShot(sound_purchase, 1.0f);*/
            
            }
        
    }

    public void shop_S8()
    {

        if (aq.shopItems[8])
        {
            aq.int_SpriteSelector = 4;
            aq.shop_changeSelector(aq.int_SpriteSelector);
            source.PlayOneShot(sound_purchase, 1.0f);
            aq.Save();
        }
        else
        {
            /* btn_T0_sale.SetActive(false);
             aq.int_coins = aq.int_coins - 50;
             aq.shopItems[0] = true;
             aq.shop_currentcoins.text = aq.int_coins.ToString();
             btn_T0_purchase.SetActive(true);
             aq.int_SpriteTile = 0;
             aq.shop_changeTiles(0);
         source.PlayOneShot(sound_purchase, 1.0f);*/

        }

    }

    public void shop_C12()
    {

        if (aq.shopItems[12])
        {
            aq.int_SpriteCover = 4;
            aq.shop_changecover(aq.int_SpriteCover);
            source.PlayOneShot(sound_purchase, 1.0f);
            aq.Save();
        }
        else
        {
            /* btn_T0_sale.SetActive(false);
             aq.int_coins = aq.int_coins - 50;
             aq.shopItems[0] = true;
             aq.shop_currentcoins.text = aq.int_coins.ToString();
             btn_T0_purchase.SetActive(true);
             aq.int_SpriteTile = 0;
             aq.shop_changeTiles(0);
         source.PlayOneShot(sound_purchase, 1.0f);*/

        }

    }

    public void shop_btnFoxWolf()
    {
      
            if (aq.shopItems[1]) {
                aq.int_SpriteTile = 4;
                aq.shop_changeTiles(aq.int_SpriteTile, false);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
            if (Parent.GetComponent<TileSpawner>().int_coins < 200)
            {
                notcoinsanim.SetBool("notCoins", true);
                notcoinsanim.Play("notenoughcoins", -1, 0f);
                source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[1].SetActive(false);
                aq.int_coins = aq.int_coins - 200;
                aq.shopItems[1] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[1].SetActive(true);
                aq.int_SpriteTile = 4;
                aq.shop_changeTiles(aq.int_SpriteTile, false);

                aq.Save();
            }
           
            }
           

        
    }

    public void btn_C14()
    {
      
       
            if (aq.shopItems[14])
            {
                aq.int_SpriteCover = 3;
                aq.shop_changecover(aq.int_SpriteCover);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
            if (Parent.GetComponent<TileSpawner>().int_coins < 150)
            {
                notcoinsanim.SetBool("notCoins", true);
                notcoinsanim.Play("notenoughcoins", -1, 0f);
                source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[14].SetActive(false);
                aq.int_coins = aq.int_coins - 150;
                aq.shopItems[14] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[14].SetActive(true);
                aq.int_SpriteCover = 3;
                aq.shop_changecover(aq.int_SpriteCover);

                aq.Save();
            }
           
            


        }
    }

    public void btn_S9()
    {
        
       
            if (aq.shopItems[9])
            {
                aq.int_SpriteSelector = 0;
                aq.shop_changeSelector(aq.int_SpriteSelector);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
            if (Parent.GetComponent<TileSpawner>().int_coins < 50)
            {
                notcoinsanim.SetBool("notCoins", true);
                notcoinsanim.Play("notenoughcoins", -1, 0f);
                source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[9].SetActive(false);
                aq.int_coins = aq.int_coins - 50;
                aq.shopItems[9] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[9].SetActive(true);
                aq.int_SpriteSelector = 0;
                aq.shop_changeSelector(aq.int_SpriteSelector);

                aq.Save();
            }
           
            }


        
    }

    public void btn_T2()
    {
       
       
            if (aq.shopItems[2])
            {
                aq.int_SpriteTile = 5;
                aq.shop_changeTiles(aq.int_SpriteTile, false);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
            if (Parent.GetComponent<TileSpawner>().int_coins < 300)
            {
                notcoinsanim.SetBool("notCoins", true);
                notcoinsanim.Play("notenoughcoins", -1, 0f);
                source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[2].SetActive(false);
                aq.int_coins = aq.int_coins - 300;
                aq.shopItems[2] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                item_purchased[2].SetActive(true);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.int_SpriteTile = 5;
                aq.shop_changeTiles(aq.int_SpriteTile, false);

                aq.Save();
            }
           
            


        }
    }

    public void btn_C13()
    {
       
        
            if (aq.shopItems[13])
            {
                aq.int_SpriteCover = 1;
                aq.shop_changecover(aq.int_SpriteCover);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
            if (Parent.GetComponent<TileSpawner>().int_coins < 400)
            {
                notcoinsanim.SetBool("notCoins", true);
                notcoinsanim.Play("notenoughcoins", -1, 0f);
                source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[13].SetActive(false);
                aq.int_coins = aq.int_coins - 400;
                aq.shopItems[13] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[13].SetActive(true);
                aq.int_SpriteCover = 1;
                aq.shop_changecover(aq.int_SpriteCover);

                aq.Save();
            }
            
            


        }
    }

    public void btn_S7()
    {
       
        
            if (aq.shopItems[7])
            {
                aq.int_SpriteSelector = 2;
                aq.shop_changeSelector(aq.int_SpriteSelector);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
            if (Parent.GetComponent<TileSpawner>().int_coins < 550)
            {
                notcoinsanim.SetBool("notCoins", true);
                notcoinsanim.Play("notenoughcoins", -1, 0f);
                source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[7].SetActive(false);
                aq.int_coins = aq.int_coins - 550;
                aq.shopItems[7] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                item_purchased[7].SetActive(true);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.int_SpriteSelector = 2;
                aq.shop_changeSelector(aq.int_SpriteSelector);

                aq.Save();
            }
           
            


        }
    }

    public void btn_T3()
    {
      
        
            if (aq.shopItems[3])
            {
                aq.int_SpriteTile = 1;
                aq.shop_changeTiles(aq.int_SpriteTile, false);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
            if (Parent.GetComponent<TileSpawner>().int_coins < 650)
            {
                notcoinsanim.SetBool("notCoins", true);
                notcoinsanim.Play("notenoughcoins", -1, 0f);
                source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[3].SetActive(false);
                aq.int_coins = aq.int_coins - 650;
                aq.shopItems[3] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[3].SetActive(true);
                aq.int_SpriteTile = 1;
                aq.shop_changeTiles(aq.int_SpriteTile, false);

                aq.Save();
            }
           
            


        }
    }

    public void btn_C11()
    {
     
        
            if (aq.shopItems[11])
            {
                aq.int_SpriteCover = 0;
                aq.shop_changecover(aq.int_SpriteCover);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                if (Parent.GetComponent<TileSpawner>().int_coins < 800)
                {
                    notcoinsanim.SetBool("notCoins", true);
                    notcoinsanim.Play("notenoughcoins", -1, 0f);
                    source.PlayOneShot(notenoughCoinsSound, 1.0f);
                }else
                {
                    item_sale[11].SetActive(false);
                    aq.int_coins = aq.int_coins - 800;
                    aq.shopItems[11] = true;
                    aq.shop_currentcoins.text = aq.int_coins.ToString();
                    item_purchased[11].SetActive(true);
                    source.PlayOneShot(sound_purchase, 1.0f);
                    aq.int_SpriteCover = 0;
                    aq.shop_changecover(aq.int_SpriteCover);

                    aq.Save();
                }
              
            


        }
    }

    public void btn_S10()
    {
     
       
            if (aq.shopItems[10])
            {
                aq.int_SpriteSelector = 3;
                aq.shop_changeSelector(aq.int_SpriteSelector);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
            if (Parent.GetComponent<TileSpawner>().int_coins < 850)
            {
                notcoinsanim.SetBool("notCoins", true);
                notcoinsanim.Play("notenoughcoins", -1, 0f);
                source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[10].SetActive(false);
                aq.int_coins = aq.int_coins - 850;
                aq.shopItems[10] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                item_purchased[10].SetActive(true);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.int_SpriteSelector = 3;
                aq.shop_changeSelector(aq.int_SpriteSelector);

                aq.Save();
            }
           
            


        }
    }

    public void btn_T4()
    {
      
        
            if (aq.shopItems[4])
            {
                aq.int_SpriteTile = 3;
                aq.shop_changeTiles(aq.int_SpriteTile, false);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                if (Parent.GetComponent<TileSpawner>().int_coins < 900)
                {
                    notcoinsanim.SetBool("notCoins", true);
                    notcoinsanim.Play("notenoughcoins", -1, 0f);
                    source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[4].SetActive(false);
                aq.int_coins = aq.int_coins - 900;
                aq.shopItems[4] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                item_purchased[4].SetActive(true);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.int_SpriteTile = 3;
                aq.shop_changeTiles(aq.int_SpriteTile, false);

                aq.Save();
            }
               
            


        }
    }

    public void btn_T16()
    {
       
            
                aq.int_SpriteTile = 6;
                aq.shop_changeTiles(aq.int_SpriteTile, false);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            
           


        }

    public void btn_T17()
    {
       
       
            if (aq.shopItems[17])
            {
                aq.int_SpriteTile = 8;
                aq.shop_changeTiles(aq.int_SpriteTile, false);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                if (Parent.GetComponent<TileSpawner>().int_coins < 170)
                {
                    notcoinsanim.SetBool("notCoins", true);
                    notcoinsanim.Play("notenoughcoins", -1, 0f);
                    source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[17].SetActive(false);
                aq.int_coins = aq.int_coins - 170;
                aq.shopItems[17] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[17].SetActive(true);
                aq.int_SpriteTile = 7;
                aq.shop_changeTiles(aq.int_SpriteTile, false);

                aq.Save();
            }
                
            


        }
    }

    public void btn_T18()
    {
       
       
            if (aq.shopItems[18])
            {
                aq.int_SpriteTile = 7;
                aq.shop_changeTiles(aq.int_SpriteTile, false);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                if (Parent.GetComponent<TileSpawner>().int_coins < 500)
                {
                    notcoinsanim.SetBool("notCoins", true);
                    notcoinsanim.Play("notenoughcoins", -1, 0f);
                    source.PlayOneShot(notenoughCoinsSound, 1.0f);
                }else
                {
                    item_sale[18].SetActive(false);
                    aq.int_coins = aq.int_coins - 500;
                    aq.shopItems[18] = true;
                    aq.shop_currentcoins.text = aq.int_coins.ToString();
                    source.PlayOneShot(sound_purchase, 1.0f);
                    item_purchased[18].SetActive(true);
                    aq.int_SpriteTile = 8;
                    aq.shop_changeTiles(aq.int_SpriteTile, false);

                    aq.Save();
                }
               
            


        }
    }

    public void btn_S19()
    {
      
      
            if (aq.shopItems[19])
            {
                aq.int_SpriteSelector = 5;
                aq.shop_changeSelector(aq.int_SpriteSelector);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                if (Parent.GetComponent<TileSpawner>().int_coins < 350)
                {
                    notcoinsanim.SetBool("notCoins", true);
                    notcoinsanim.Play("notenoughcoins", -1, 0f);
                    source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[19].SetActive(false);
                aq.int_coins = aq.int_coins - 350;
                aq.shopItems[19] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[19].SetActive(true);
                aq.int_SpriteSelector = 5;
                aq.shop_changeSelector(aq.int_SpriteSelector);

                aq.Save();
            }
               
            


        }
    }

    public void btn_S20()
    {
        
            if (aq.shopItems[20])
            {
                aq.int_SpriteSelector = 6;
                aq.shop_changeSelector(aq.int_SpriteSelector);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                if (Parent.GetComponent<TileSpawner>().int_coins < 100)
                {
                    notcoinsanim.SetBool("notCoins", true);
                    notcoinsanim.Play("notenoughcoins", -1, 0f);
                    source.PlayOneShot(notenoughCoinsSound, 1.0f);
                }else
                {
                    item_sale[20].SetActive(false);
                    aq.int_coins = aq.int_coins - 100;
                    aq.shopItems[20] = true;
                    aq.shop_currentcoins.text = aq.int_coins.ToString();
                    source.PlayOneShot(sound_purchase, 1.0f);
                    item_purchased[20].SetActive(true);
                    aq.int_SpriteSelector = 6;
                    aq.shop_changeSelector(aq.int_SpriteSelector);

                    aq.Save();
                }
               
            


        }
    }

    public void btn_C21()
    {
        
        
            if (aq.shopItems[21])
            {
                aq.int_SpriteCover = 5;
                aq.shop_changecover(aq.int_SpriteCover);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                if (Parent.GetComponent<TileSpawner>().int_coins < 700)
                {
                    notcoinsanim.SetBool("notCoins", true);
                    notcoinsanim.Play("notenoughcoins", -1, 0f);
                    source.PlayOneShot(notenoughCoinsSound, 1.0f);
                }else
                {
                    item_sale[21].SetActive(false);
                    aq.int_coins = aq.int_coins - 700;
                    aq.shopItems[21] = true;
                    aq.shop_currentcoins.text = aq.int_coins.ToString();
                    source.PlayOneShot(sound_purchase, 1.0f);
                    item_purchased[21].SetActive(true);
                    aq.int_SpriteCover = 5;
                    aq.shop_changecover(aq.int_SpriteCover);

                    aq.Save();
                }
               
            


        }
    }

    public void btn_C22()
    {
      
        
            if (aq.shopItems[22])
            {
                aq.int_SpriteCover = 6;
                aq.shop_changecover(aq.int_SpriteCover);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                if (Parent.GetComponent<TileSpawner>().int_coins < 1000)
                {
                    notcoinsanim.SetBool("notCoins", true);
                    notcoinsanim.Play("notenoughcoins", -1, 0f);
                    source.PlayOneShot(notenoughCoinsSound, 1.0f);
            }else
            {
                item_sale[22].SetActive(false);
                aq.int_coins = aq.int_coins - 1000;
                aq.shopItems[22] = true;
                aq.shop_currentcoins.text = aq.int_coins.ToString();
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[22].SetActive(true);
                aq.int_SpriteCover = 6;
                aq.shop_changecover(aq.int_SpriteCover);

                aq.Save();
            }
               
            


        }
    }

    public void btn_C23()
    {
        
            if (aq.shopItems[23])
            {
                aq.int_SpriteCover = 7;
                aq.shop_changecover(aq.int_SpriteCover);
                source.PlayOneShot(sound_purchase, 1.0f);
                aq.Save();
            }
            else
            {
                item_sale[23].SetActive(false);
              
                aq.shopItems[23] = true;
               
                source.PlayOneShot(sound_purchase, 1.0f);
                item_purchased[23].SetActive(true);
                aq.int_SpriteCover = 7;
                aq.shop_changecover(aq.int_SpriteCover);

                aq.Save();
            }


        
    }

    public void btn_S24()
    {

        if (aq.shopItems[24])
        {
            aq.int_SpriteSelector = 7;
            aq.shop_changeSelector(aq.int_SpriteSelector);
            source.PlayOneShot(sound_purchase, 1.0f);
            aq.Save();
        }
        else
        {
            item_sale[24].SetActive(false);

            aq.shopItems[24] = true;

            source.PlayOneShot(sound_purchase, 1.0f);
            item_purchased[24].SetActive(true);
            aq.int_SpriteSelector = 7;
            aq.shop_changeSelector(aq.int_SpriteSelector);

            aq.Save();
        }



    }

    public void shop_backbtn()
    {
        aq.bool_shop = false;
        aq.con_shop.SetActive(false);
        aq.con_ui_mainmenu.SetActive(true);
        aq.mmenu_CurrentCoins.text = aq.int_coins.ToString();
    }

    


    #endregion

}
