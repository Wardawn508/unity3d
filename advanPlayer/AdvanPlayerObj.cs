using UnityEngine;
using System.Collections;

public class AdvanPlayerObj : MonoBehaviour {
  
    [SerializeField]
    private CurrPlayer currplayerActor;
    public CurrPlayer MyPlayerstate 
    {
        get
        {
            return currplayerActor;
        }

        set 
        {
            currplayerActor = value;
            setup();
        }
    }

    [SerializeField]
    public Playerbase[] playerState  = new Playerbase[4] { new indieBehaviourScript(), new PlayerWalking(), new PlayerRunning(),new PlayerJumbing()};
    
    private void setup()
    {
    playerState[(int)currplayerActor].OnStart();
    }
  
    void Start()
    {
        //playerState = new Playerbase[3] { new indieBehaviourScript(), new PlayerWalking(), new PlayerRunning() };

        setup();

    }
	
	// Update is called once per frame
	void Update () {
        playerState[(int)currplayerActor].OnUpdate();
	
	}

    public void animset(animbase animset) 
    {
   
        for (int i = 0; i < playerState.Length; i++)
        {
            playerState[i].animset(animset);
        }
    }

    public void jumping( Vector3 mover) 
    {
        currplayerActor = CurrPlayer.isJumbing;
        playerState[(int)currplayerActor].moveDirection = mover;
    
    }
}
