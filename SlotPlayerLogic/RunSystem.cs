using System;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class RunSystem {

    [SerializeField]
    float decayrate = .01f;
    [SerializeField]
    float timestep = 3f;
    [SerializeField]
    bool Isrun = false;
    [SerializeField]
    float _timestep = 4f;
	// Update is called once per frame
    public void Update()
    {
        

        if (_timestep > 0 && Isrun == true)
        {
            _timestep -= decayrate;
            
           
        }
        if (Isrun == false && _timestep < timestep) 
        {
            _timestep += decayrate / 2;

        }
        
        if (_timestep < 0) 
        {
            Isrun = false;
        }

	
	}

    public void setrun(bool r)
    {
        Isrun = r;
    
    
    }

    public bool IsRunning() 
    {
        if (_timestep > 0 && Isrun == true)
        {

            return true;

        }


       return false;
        
    }
}
