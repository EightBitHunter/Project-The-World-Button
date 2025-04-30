using UnityEngine;

public class ButtonAbilityController : MonoBehaviour
{
    public TogglePlatformGroup platformGroup1;
    public TogglePlatformGroup platformGroup2;

    private PlayerAbilities playerAbilities;

    void Start()
    {
        playerAbilities = FindFirstObjectByType<PlayerAbilities>();

        if (platformGroup1 != null && platformGroup2 != null)
        {
            platformGroup1.Toggle(true);
            platformGroup2.Toggle(false);
        }
    }

    void Update()
    {
        if (playerAbilities != null && playerAbilities.hasButtonAbility)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (platformGroup1 != null && platformGroup2 != null)
                {
                    bool group1IsActive = platformGroup1.IsActive();

                    platformGroup1.Toggle(!group1IsActive);
                    platformGroup2.Toggle(group1IsActive);
                }
            }
        }
    }
}



