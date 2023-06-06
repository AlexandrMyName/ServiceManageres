using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    internal interface IUpgradable  
    {
        float Speed { get; set; }
        void Restore();
    }
}
