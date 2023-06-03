using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
    public class DontDestroyerObject : MonoBehaviour { void Awake() => DontDestroyOnLoad(this.gameObject); }
}
