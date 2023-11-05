using UnityEngine;
using UnityEngine.UI;

namespace Factory
{
    public class ButtonAbility : MonoBehaviour
    {
        private Ability _ability;
        private Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
        }
    
        public void SetAbilityName(string abilityName)
        {
            _ability = AbilityFactory.GetAbility(abilityName);
            _button.onClick.AddListener(CustomButton_onClick);
        }

        private void CustomButton_onClick()
        {
            _ability.Process();
        }
    }
}
