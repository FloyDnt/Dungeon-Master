using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiPanel : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Dray dray;
    public Sprite healthEmpty;
    public Sprite healthHalf;
    public Sprite healthFull;

    Text keyCountText;
    List<Image> healthImages;

    private void Start()
    {
        Transform trans = transform.Find("Key Count");
        keyCountText = trans.GetComponent<Text>();

        Transform healPanel = transform.Find("Health Panel");
        healthImages = new List<Image>();
        if (healPanel != null)
        {
            for (int i = 0; i < 20; i++)
            {
                trans = healPanel.Find("H_" + i);
                if (trans == null) break;
                healthImages.Add(trans.GetComponent<Image>());
            }
        }
    }

    private void Update()
    {
        keyCountText.text = dray.numKeys.ToString();

        int health = dray.health;
        for (int i = 0; i < healthImages.Count; i++)
        {
            if (health > 1)
            {
                healthImages[i].sprite = healthFull;
            }
            else if (health == 1)
            {
                healthImages[i].sprite = healthHalf;
            }
            else
            {
                healthImages[i].sprite = healthEmpty;
            }
            health -= 2;
        }
    }
}
