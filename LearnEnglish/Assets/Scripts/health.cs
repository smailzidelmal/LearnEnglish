using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    public float palyerHealth = 75f;
    public float maxHealth = 100f;
    public Image healthBarImage;
    // Update is called once per frame
    void Update()
    {
        healthBarImage.fillAmount =healthBarImage.fillAmount;
    }
}
