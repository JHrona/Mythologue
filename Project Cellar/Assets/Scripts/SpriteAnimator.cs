using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField]private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    private float framerate = .1f;
    private SpriteRenderer spriteRenderer;
    
    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
    timer += Time.deltaTime;
    if(timer>= framerate)
    {
        timer -=framerate;
        currentFrame++;
    }
    

    }
}
