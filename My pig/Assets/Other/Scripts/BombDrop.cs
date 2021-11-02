﻿using UnityEngine;
using System.Collections;

public class BombDrop : MonoBehaviour 
{
	public AudioClip bombSound;
    public GameObject bombPrefab;

	// NEED TO ADD
	public static Vector2 roundedPos;
	public static Vector2 rangeUp;
	public static Vector2 rangeRight;
	public static Vector2 rangeDown;
	public static Vector2 rangeLeft;
	bool bmb = false;

	void Update () 
	{
	    if (Input.GetKeyDown(KeyCode.Space)&& bmb == false) 
		{
			bmb = true;
			Vector2 pos = transform.position;
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);
			
			// NEED TO ADD
		 	roundedPos = new Vector2 (pos.x,pos.y);
			rangeUp = new Vector2(pos.x,pos.y +1); // Explosion covers 1 unit up
			rangeRight = new Vector2(pos.x +1,pos.y); // Explosion covers 1 unit right
			rangeDown = new Vector2(pos.x,pos.y -1); // Explosion covers 1 unit down
			rangeLeft = new Vector2(pos.x-1,pos.y); // Explosion covers 1 unit left

            Instantiate(bombPrefab, pos, Quaternion.identity);
			Invoke ("BombSound", 3f);
		
        }
	}
	void OnGUI()
    {
		if (GUI.Button(new Rect(35, 185, 160, 40), "bomb"))
		{
			bmb = true;
			Vector2 pos = transform.position;
			pos.x = Mathf.Round(pos.x);
			pos.y = Mathf.Round(pos.y);

			// NEED TO ADD
			roundedPos = new Vector2(pos.x, pos.y);
			rangeUp = new Vector2(pos.x, pos.y + 1); // Explosion covers 1 unit up
			rangeRight = new Vector2(pos.x + 1, pos.y); // Explosion covers 1 unit right
			rangeDown = new Vector2(pos.x, pos.y - 1); // Explosion covers 1 unit down
			rangeLeft = new Vector2(pos.x - 1, pos.y); // Explosion covers 1 unit left

			Instantiate(bombPrefab, pos, Quaternion.identity);
			Invoke("BombSound", 3f);
		}
	}
	void BombSound()	
	{
		bmb = false;
		GetComponent<AudioSource>().PlayOneShot (bombSound);
	}
}
