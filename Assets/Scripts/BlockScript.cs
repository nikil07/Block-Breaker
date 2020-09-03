using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockDestroyVFX;
    [SerializeField] Sprite[] hitSprites;

    LevelScript levelScript;
    GameStatus gameStatus;

    int timesHit = 0;
    int maxHits = 3;

    // Start is called before the first frame update
    void Start()
    {
        addBlock();
    }

    private void addBlock()
    {
        levelScript = FindObjectOfType<LevelScript>();
        gameStatus = FindObjectOfType<GameStatus>();
        if (!tag.Equals("Unbreakable"))
            levelScript.addBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag != "Unbreakable")
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                triggerDestroyVFX();
            }
            else {
                showNextHitSprite();
            }
        }
        else { 
            
        }
    }

    private void showNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit-1];
    }

    private void triggerDestroyVFX() {
        gameStatus.updateScore();
        levelScript.blockRemoved();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position); // Play near the camera so sound is louder
        Destroy(gameObject);
        GameObject destroyVFX = Instantiate(blockDestroyVFX, transform.position, transform.rotation);
        destroyVFX.SetActive(true);
    }
}
