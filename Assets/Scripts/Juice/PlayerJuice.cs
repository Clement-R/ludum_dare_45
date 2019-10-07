using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJuice : ActorJuice
{
    protected override void HitTaken()
    {
        base.HitTaken();
        
        Screenshake.Instance.Shake(0.15f);
    }
}
