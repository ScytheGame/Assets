using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

public class AllSkills : MonoBehaviour
{
    [SerializeField] StatsController StatsController;
    [SerializeField] SkillsController SkillsController;
    [SerializeField] float BiasFactor;
    [SerializeField] float MaxValue;
    [SerializeField] List<SkillData> SkillsList = new List<SkillData>();

    void Start()
    {
        SkillData[] TempSkillsList = Resources.LoadAll<SkillData>("Scriptable Objects/Skills");
        SkillsList = TempSkillsList.ToList();

        SkillsController.SkillsList = SkillsList;


        SkillTreeData SkillData = SkillTreeData.Load();
        BiasFactor = SkillData.SkillChanceBias;
        MaxValue = SkillData.SkillValueBoost;
    }
    public void RemoveSkil(SkillData SkillData)
    {
        foreach (SkillData Item in SkillsList)
        {
            if (Item == SkillData)
            {
                SkillsList.Remove(Item);
            }
        }
    }
    public void UpdateSkills()
    {
        foreach (SkillData SkillData in SkillsList)
        {
            if (!SkillData.UseRandomValues)
                SkillData.SkillValueUpdate(ValueUpdate());
        }
    }

    public float ValueUpdate()
    {
        List<float> Values = GeneratedValues();

        if (Values.Count == 0) 
            return 0;

        float TotalWeight = 0f;

        List<float> CumulativeWeights = new List<float>();

        for (int i = 0; i < Values.Count; i++)
        {
            TotalWeight += Mathf.Pow(i + 1, BiasFactor);
            CumulativeWeights.Add(TotalWeight);
        }

        for (int i = 0; i < Values.Count; i++)
        {
            CumulativeWeights[i] /= TotalWeight;
        }

        float RandomValue = Random.Range(0f, 1f);

        for (int i = 0; i < Values.Count; i ++)
        {
            if (RandomValue <= CumulativeWeights[i])
            {
                return Values[i];
            }
        }

        return Values[0];

    }

    List<float> GeneratedValues()
    {
        List<float> Values = new List<float>();

        for (float i = MaxValue; i >= 0.05f; i -= 0.05f)
        {
            float roundedValue = Mathf.Round(i * 100f) / 100f;
            //Debug.Log(" Available skill percent: " + roundedValue);
            Values.Add(roundedValue);
        }
        return Values;
    }
}
