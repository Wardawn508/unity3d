using UnityEngine;
using System.Collections;

public abstract class RigbodyBasic : MonoBehaviour
{
    public Rigidbody rigBody;

	// Use this for initialization
	public virtual void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void FixedUpdate () {
        Debug.Log(" fixedered");
	}

    public virtual void Update() { }

    public virtual bool GroundChecK()
    {
        return false;
    }


    public virtual void Horizontal(float _horizontal)
    {
    }
    public virtual void Vertical(float _Vertical)
    {
    }


}
