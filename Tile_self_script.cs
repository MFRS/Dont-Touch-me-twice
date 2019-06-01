using UnityEngine;
using System.Collections;


public class Tile_self_script : MonoBehaviour
{

    public bool bool_pressed;
    public bool bool_ontrigger;
    public GameObject GameContainer;
    public bool bool_sizeDivided;
    //USED FOR CASES WHEN YOU PRESS A TILE WHEN ANOTHER IS JUST ABOUT TO LEAVE THE SELECTOR AND GIVES YOU INSTANT GG;
    public bool bool_firstTouched;
    public bool moveY;
    public bool upD;
    public int cibai;
    public int lang_ChosenTile;
    public bool boss2_shieldDestroyed;

    public TileSpawner mainscript;


    // Use this for initialization
    void Start()
    {
        //mainscript = GameContainer.GetComponent<TileSpawner>();
       
       
        
        //Debug.Log(this.upD);
       
       
    }

    


    public void decideDirection()
    {
       this.cibai = Random.Range(0, 2);
        
        if (this.cibai == 0)
        {
            this.upD = true;
        }
        else
        {
            this.upD = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
      
            if (this.moveY)
            {
            if (this.upD == false)
            {
                if (2.8 < this.transform.position.y)
                {
                    this.upD = true;
                    
                }

                this.transform.position += new Vector3(0, 0.03f, 0);
            }else
            {
                if (this.transform.position.y < -4.7)
                {
                    this.upD = false;

                }
                this.transform.position += new Vector3(0, -0.03f, 0);
                //  Debug.Log(this.transform.position.y);
            }


        }
        else
        {
            
              
            
        }
    }

    public void DestroyMyself(TileSpawner parent)
    {
       
    }

   /* void OnMouseDown()
    {
        if (this.bool_ontrigger == true)
        {
            this.bool_pressed = true;
            //Physics2D.GetRayIntersectionAll((Ray ray, float distance = Mathf.Infinity, int layerMask = DefaultRaycastLayers);
            Debug.Log("fdfdf");
        }

        if (this.bool_ontrigger == true && this.bool_pressed == true)
        {
            {
                this.bool_pressed = true;
            }
        }

      
    }*/




}
