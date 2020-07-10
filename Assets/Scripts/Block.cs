using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //configuration parameters
    [SerializeField] AudioClip ontheBreak;
    [SerializeField] GameObject blockSparkleVFX;
    
    [SerializeField] Sprite[] hitSprites;

    //Cached Reference
    Level level;

    //state variables
    [SerializeField]int timesHit;


    private void Start()
    {
        CountBlocks();

    }

    private void CountBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.countBlocks();
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();

        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlocks();
        }
        else
        {
            ShowHitSprites();
        }
    }

    private void ShowHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is Missing From Array" + gameObject.name);
        }
    }

    private void DestroyBlocks()
    {
        BlocksSFX();
        Destroy(gameObject);
        level.destroyedBlocks();
        SparkleVFX();

    }

    private void BlocksSFX()
    {
        FindObjectOfType<GameStatus>().AddtoScore();
        AudioSource.PlayClipAtPoint(ontheBreak, Camera.main.transform.position);
    }

    private void SparkleVFX()
    {

        GameObject sparkle = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 1f);
    }

}
