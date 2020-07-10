using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

   //Configuration parameters
    [SerializeField] int breakableBlocks;

    //Cached Reference
    ChangeLevel changelevel;

    private void Start()
    {
        changelevel = FindObjectOfType<ChangeLevel>();  
    }

    public void countBlocks()
    {
        breakableBlocks++;
    }

    public void destroyedBlocks()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            changelevel.LoadNextLevel();
        }
    }



}
