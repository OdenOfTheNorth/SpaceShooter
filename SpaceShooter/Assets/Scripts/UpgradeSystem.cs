using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem upgradeSystemInstance { get; private set; }

    [Tooltip("the number of kills required to get the first upgrade")]
    [SerializeField] private int experienceToLevelup = 10;
    [Tooltip("how much the number of kill required to level up will increase per levelup")]
    [SerializeField] private int experienceRequirementIncreasePerLevel = 5;

    private int currentExperience = 0;
    private int currentUpgradePoints = 0;

    private void Awake()
    {
        upgradeSystemInstance = this;
    }

    public void GainExperience(int experienceToAdd)
    {
        currentExperience += experienceToAdd;
        while (currentExperience >= experienceToLevelup)
        {
            currentUpgradePoints += 1;
            currentExperience -= experienceToLevelup;
            experienceToLevelup += experienceRequirementIncreasePerLevel;
        }
    }

}
