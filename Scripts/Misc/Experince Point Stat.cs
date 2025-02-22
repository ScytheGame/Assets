using UnityEngine;

public class ExperincePointStat : MonoBehaviour
{
    public float Experince;
    [SerializeField] GameObject SmallExperincePoint;
    [SerializeField] GameObject SmallExperincePointWithStars;
    [SerializeField] GameObject MediumExperincePoint;
    [SerializeField] GameObject MediumExperincePointWithStars;
    [SerializeField] GameObject LargeExperincePoint;
    [SerializeField] GameObject LargeExperincePointWithStars;


    private void Start()
    {
        if (Experince < 25)
        {
            SmallExperincePoint.SetActive(true);
            SmallExperincePointWithStars.SetActive(false);
            MediumExperincePoint.SetActive(false);
            MediumExperincePointWithStars.SetActive(false);
            LargeExperincePoint.SetActive(false);
            LargeExperincePointWithStars.SetActive(false);
        }
        else if (Experince < 50)
        {
            SmallExperincePoint.SetActive(false);
            SmallExperincePointWithStars.SetActive(true);
            MediumExperincePoint.SetActive(false);
            MediumExperincePointWithStars.SetActive(false);
            LargeExperincePoint.SetActive(false);
            LargeExperincePointWithStars.SetActive(false);
        }
        else if (Experince < 75)
        {
            SmallExperincePoint.SetActive(false);
            SmallExperincePointWithStars.SetActive(false);
            MediumExperincePoint.SetActive(true);
            MediumExperincePointWithStars.SetActive(false);
            LargeExperincePoint.SetActive(false);
            LargeExperincePointWithStars.SetActive(false);
        }
        else if (Experince < 100)
        {
            SmallExperincePoint.SetActive(false);
            SmallExperincePointWithStars.SetActive(false);
            MediumExperincePoint.SetActive(false);
            MediumExperincePointWithStars.SetActive(true);
            LargeExperincePoint.SetActive(false);
            LargeExperincePointWithStars.SetActive(false);
        }
        else if (Experince < 125)
        {
            SmallExperincePoint.SetActive(false);
            SmallExperincePointWithStars.SetActive(false);
            MediumExperincePoint.SetActive(false);
            MediumExperincePointWithStars.SetActive(false);
            LargeExperincePoint.SetActive(true);
            LargeExperincePointWithStars.SetActive(false);
        }
        else
        {
            SmallExperincePoint.SetActive(false);
            SmallExperincePointWithStars.SetActive(false);
            MediumExperincePoint.SetActive(false);
            MediumExperincePointWithStars.SetActive(false);
            LargeExperincePoint.SetActive(true);
            LargeExperincePointWithStars.SetActive(true);
        }
    }
}
