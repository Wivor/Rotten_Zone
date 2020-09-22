using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HpBar;

    public void Initialize(Rat rat)
    {
        if(rat.team == Team.A)
        {
            HpBar.color = Color.red;
        }
        else
        {
            HpBar.color = Color.blue;
        }
    }

    public void UpdateBar(int current, int max)
    {
        HpBar.fillAmount = (float)current / (float)max;
    }
}