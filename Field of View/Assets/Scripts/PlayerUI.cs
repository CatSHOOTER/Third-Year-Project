using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform HealthLevel;

    //public Text bouncyCounttx;
    //public Text stickyCounttx;




    //tally of dogs removed
    //minimap linked
    //ammo and current weapon

    void SetHealthLevel(float amount)
    {
        HealthLevel.localScale = new Vector3(1f, amount, 1f);
    }
    void SetText()
    {

    }
	
}
