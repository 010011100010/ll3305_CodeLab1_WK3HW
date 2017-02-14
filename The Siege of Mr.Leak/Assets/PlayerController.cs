using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10f;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //Vector3 translate = new Vector3(x, y, 0);
        //transform.Translate(translate * speed * Time.deltaTime);
        //if(Input.GetKeyDown(KeyCode.))

        if (Input.GetKey(upKey))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(downKey))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if(Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }


}
