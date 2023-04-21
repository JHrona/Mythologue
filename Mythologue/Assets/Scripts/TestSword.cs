using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSword : MonoBehaviour
{
    //create me a sword
    public GameObject sword;


    // Start is called before the first frame update 
    void Start()
    {
        OnMouseDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //when the player presses the right mouse button (or whatever button you want to use)
    private void OnMouseDown()
    {
        //create a sword
        GameObject sword = Instantiate(this.sword, new Vector3(0, 0, 0), Quaternion.identity);
        //set the sword's parent to the player
        sword.transform.parent = this.transform;
        //set the sword's position to the player's position
        sword.transform.position = this.transform.position;
        //set the sword's rotation to the player's rotation
        sword.transform.rotation = this.transform.rotation;
    }
}
