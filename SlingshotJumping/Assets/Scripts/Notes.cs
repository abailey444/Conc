using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[AddComponentMenu("Miscellaneous/README")]
public class Notes : MonoBehaviour {
    [TextArea(15,1000)]
    public string note = "Enter a note here.";

    private void Awake() => Destroy(this);
}
#endif
