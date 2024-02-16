using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
    #if !UNITY_EDITOR
    private void Awake() => Destroy(this);
    #endif

    [TextArea(15,20)]
    public string note = "";
}
