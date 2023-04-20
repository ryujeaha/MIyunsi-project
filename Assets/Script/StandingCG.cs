using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Standing
{
    [TextArea]
    public string Text;
    public Sprite CG;
}
public class StandingCG : MonoBehaviour
{
    
     
    [SerializeField] private SpriteRenderer sprite_StandingCG;

    private bool isDialogue = false;

    private int count = 0;
   
   
    [SerializeField] private Standing[] standing;

   

    void Start()
    {
        ShowCG();
        NextCG();
    }

    public void ShowCG()
    {
        sprite_StandingCG.gameObject.SetActive(true);
        count = 0;
        Onoff(true);
    }
    public void NextCG()
    {
        sprite_StandingCG.sprite = standing[count].CG;
        count++;
        
     
    }
 
    // Start is called before the first frame update
    public void Onoff(bool _fleg)
    {
        sprite_StandingCG.gameObject.SetActive(_fleg);
        isDialogue = _fleg;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDialogue)
        {
          
            
                if (count > standing.Length)
                    Onoff(false);
            
        }
    }
}
