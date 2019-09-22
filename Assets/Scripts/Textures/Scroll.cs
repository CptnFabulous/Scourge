using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //scroll speed of textures
    [Header("ScrollSpeed")]
    [Range(0, 10)]
    public float albedoSpeedX = .1f;
    [Range(0, 10)]
    public float albedoSpeedY = .1f;
    [Range(0, 10)]
    public float heightSpeedX = .1f;
    [Range(0, 10)]
    public float heightSpeedY = .1f;
    [Range(0,10)]
    [Header("Adjustments")]
    public float parallaxStrength;
   
    private void Start()
    {
      
        
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //change the offset var based on time and speed
        float albedoOffsetX = Time.time * albedoSpeedX;
        float albedoOffsetY = Time.time * albedoSpeedY;
        float heightOffsetX = Time.time * heightSpeedX;
        float heightOffsetY = Time.time * heightSpeedY;
        //apply the new offsets to the textures 
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(albedoOffsetX, albedoOffsetY));
        GetComponent<Renderer>().material.SetTextureOffset("_ParallaxMap", new Vector2(heightOffsetX, heightOffsetY));
        GetComponent<Renderer>().material.SetFloat("_Parallax", parallaxStrength);
        //_ParallaxMap may not be easy to see as the standard shader script sets it super low.
    }
}
