using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform HealthLevel;

    //tally of dogs removed
    //minimap linked
    //ammo and current weapon

    void SetHealthLevel(float amount)
    {
        HealthLevel.localScale = new Vector3(amount, 1f, 1f);
    }
	
}
