using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ToggleEditorSync : MonoBehaviour
{
    public Image On;
    public Image Off;
    public Toggle toggle;

    private void LateUpdate()
    {
        if (On != null && Off != null && toggle != null)
        {
            if (toggle.isOn)
            {
                if (On.enabled != true) On.enabled = true;
                if (Off.enabled != false) Off.enabled = false;
            }
            else
            {
                if (On.enabled != false) On.enabled = false;
                if (Off.enabled != true) Off.enabled = true;
            }
        }
    }
}
