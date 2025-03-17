using NUnit.Framework;
using Radishmouse;
using Sirenix.Utilities;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] SkillPrefabController SkillPrefabController;
    [SerializeField] GameObject PreviousSkillObject;


    [SerializeField] UILineRenderer UILineRenderer;
    [SerializeField] RectTransform PreviousSkillTransform;
    [SerializeField] RectTransform SkillTransform;
    [SerializeField] Vector2 PreviousSkillPosition;
    [SerializeField] Vector2 SkillPosition;
    [SerializeField] Vector2 Point1 = new Vector2(30, 0);
    [SerializeField] Vector2 Point2 = new Vector2(30, 0);
    [SerializeField] Vector2 Point3 = new Vector2(30, 0);
    [SerializeField] Vector2 Point4 = new Vector2(30, 0);

    private void OnEnable()
    {
        if (SkillPrefabController.PreviousSkill != null)
        {
            PreviousSkillObject = SkillPrefabController.PreviousSkill.gameObject;
            PreviousSkillTransform = PreviousSkillObject.GetComponent<RectTransform>();
            PreviousSkillPosition = PreviousSkillTransform.anchoredPosition;

            SkillTransform = this.GetComponent<RectTransform>();
            SkillPosition = SkillTransform.anchoredPosition;

            if (PreviousSkillPosition.y <= SkillPosition.y)
            {
                Point1 = new Vector2(30, 0);
                Point2 = new Vector2(30, (PreviousSkillTransform.anchoredPosition.y + 60 - SkillTransform.anchoredPosition.y) / 2);

                if (PreviousSkillTransform.anchoredPosition.x >= SkillTransform.anchoredPosition.x) // if skill is on the left
                    Point3 = new Vector2((PreviousSkillTransform.anchoredPosition.x + 30 - SkillTransform.anchoredPosition.x), (PreviousSkillTransform.anchoredPosition.y + 60 - SkillTransform.anchoredPosition.y) / 2);

                else if (PreviousSkillTransform.anchoredPosition.x <= SkillTransform.anchoredPosition.x) // if skill is on the right
                    Point3 = new Vector2((PreviousSkillTransform.anchoredPosition.x + 30 - SkillTransform.anchoredPosition.x), (PreviousSkillTransform.anchoredPosition.y + 60 - SkillTransform.anchoredPosition.y) / 2);

                Point4 = new Vector2(Point3.x, Point3.y * 2);
            }
            else if (PreviousSkillPosition.y >= SkillPosition.y)
            {
                Point1 = new Vector2(30, 0);
                Point2 = new Vector2(30, (PreviousSkillTransform.anchoredPosition.y - SkillTransform.anchoredPosition.y) / 2);

                if (PreviousSkillTransform.anchoredPosition.x >= SkillTransform.anchoredPosition.x) // if skill is on the left
                    Point3 = new Vector2((PreviousSkillTransform.anchoredPosition.x + 30 - SkillTransform.anchoredPosition.x), (PreviousSkillTransform.anchoredPosition.y - SkillTransform.anchoredPosition.y) / 2);

                else if (PreviousSkillTransform.anchoredPosition.x <= SkillTransform.anchoredPosition.x) // if skill is on the right
                    Point3 = new Vector2((PreviousSkillTransform.anchoredPosition.x + 30 - SkillTransform.anchoredPosition.x), (PreviousSkillTransform.anchoredPosition.y - SkillTransform.anchoredPosition.y) / 2);

                Point4 = new Vector2(Point3.x, Point3.y * 2);
            }

            UILineRenderer.points[0] = Point1;
            UILineRenderer.points[1] = Point2;
            UILineRenderer.points[2] = Point3;
            UILineRenderer.points[3] = Point4;

        }
    }

}
