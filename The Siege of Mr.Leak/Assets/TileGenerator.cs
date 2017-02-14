using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {
    public GameObject tile;
    public int[] data;
    public GameObject[] tiles;
    GameObject player;
    int lastIndex;
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");

        data = new int[16000];
        tiles = new GameObject[16000];
        lastIndex = 0;
       // data = new int[20][8]();
		for(int i = 0; i < 200; i++)
        {//col

            for(int j = 0; j < 80; j++)
            {//row
                Vector3 pos = new Vector3(-10 + i*0.1f, -4 + 0.1f*j, 0);
                GameObject go = Instantiate(tile, pos,Quaternion.identity) as GameObject;
               // Debug.Log(i * 80 + j);
                data[i*80 + j] = 0;
                tiles[i*80+ j] = go;
            }
        }
	}



    // Update is called once per frame
    void FixedUpdate() {

        Vector3 pos = player.transform.position;
        int x = Mathf.FloorToInt((pos.x + 10) * 10 + 0.5f);//col
        int y = Mathf.FloorToInt((pos.y + 4) * 10 + 0.5f);//row
        Debug.Log(x + "," + y);
        int index = x * 80 + y;
        if (index > 0 && index < 16000)
        {
            tiles[x * 80 + y].GetComponent<SpriteRenderer>().color = Color.red;
            

            if (Mathf.Abs(lastIndex - index) > 0)
            {
                int lastcol = lastIndex / 80;
                int lastrow = lastIndex % 80;
                int currentcol = index / 80;
                int currentrow = index % 80;
                if(lastcol == currentcol)
                {
                    int thisrow = lastrow;
                    while (thisrow != currentrow)
                    {
                        thisrow = lastrow + (currentrow - lastrow) / Mathf.Abs(currentrow - lastrow);
                        tiles[x * 80 +lastrow].GetComponent<SpriteRenderer>().color = Color.red;
                    }

                }else if(lastrow == currentrow)
                {
                    int thiscol = lastcol;
                    while (thiscol != currentcol)
                    {
                        thiscol = lastcol + (currentcol - lastcol) / Mathf.Abs(currentcol - lastcol);
                        tiles[thiscol * 80 + y].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
                else
                {

                }

            }else
            {
                 tiles[x * 80 + y].GetComponent<SpriteRenderer>().color = Color.red;
            }
        
            lastIndex = index;
        }
        //tiles[]


	}
}
