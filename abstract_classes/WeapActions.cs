using UnityEngine;
using System.Collections;

public class WeapActions : MonoBehaviour
{

    public virtual void AIm(bool isAim, bool iswalk) { }
    public virtual void Walk(bool Iswalking, bool aim) { }
    public virtual void GunClose() { }
    public virtual void Fire(bool Shots) { }
    public virtual void Reload(bool Rset) { }


}
