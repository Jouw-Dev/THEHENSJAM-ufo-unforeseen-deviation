using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image fillImage;

    private void Start()
    {
        if(fillImage == null) fillImage = GetComponent<Image>();

        UpdateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar() 
    {
        if(playerHealth == null || fillImage == null) return;

        fillImage.fillAmount = playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }

}
