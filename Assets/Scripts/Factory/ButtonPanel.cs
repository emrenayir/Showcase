using UnityEngine;

namespace Factory
{
    public class ButtonPanel : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab;
        
        private void OnEnable()
        {
            var names = AbilityFactory.GetAbilityNames();

            foreach (var message in names)
            {
                var button = Instantiate(buttonPrefab, transform, true);
                button.name = message;
                button.GetComponent<ButtonAbility>().SetAbilityName(message);
            }
        }
    }
}
