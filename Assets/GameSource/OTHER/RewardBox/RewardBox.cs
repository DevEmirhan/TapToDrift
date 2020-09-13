using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RewardBox : MonoBehaviour
{
    public Image boxImg;
    public TextMeshProUGUI percentageTxt;
    public int stepsToFullFill;
    public GameObject getRewardButton;
    private void Start()
    {
        ValueUp();
    }
    [NaughtyAttributes.Button("Fill")]
    public void ValueUp()
    {
        float boxVal = SaveManager.GetSaveDataFloat("rewardBox");
        if (boxVal == -1)
        {
            SaveManager.Save("rewardBox", 0f);
            boxVal = 0;
        }
        boxImg.fillAmount = boxVal / 100;
        percentageTxt.text = "%" + boxVal;
        float fillAmount = 100 / stepsToFullFill;
        float fillTo = (boxVal + fillAmount) / 100;
        fillTo = Mathf.Clamp01(fillTo);
        boxImg.DOFillAmount(fillTo, 0.8f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (fillTo == 1)
            {
                getRewardButton.SetActive(true);
                fillTo = 0;
            }
            SaveManager.Save("rewardBox", fillTo * 100);
        });
    }
    private void Update()
    {
        percentageTxt.text = "%" + (boxImg.fillAmount*100).ToString("F0");
    }
    public void CollectButtonDo()
    {

    }
}
