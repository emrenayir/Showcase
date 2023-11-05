using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Factory
{
    public abstract class Ability
    {
        public abstract string Name { get; }
        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override string Name => "fire";

        public override void Process()
        {
            Debug.Log("Fire");
        }
    }

    public class SelfHealAbility : Ability
    {
        public override string Name => "heal";
        
        public override void Process()
        {
            Debug.Log("Healed");
        }
    }

    public static class AbilityFactory
    {
        private static Dictionary<string, Type> _abilitiesByName;
        private static bool IsInitialized => _abilitiesByName != null;

        private static void InitializeFactory()
        {
            if (IsInitialized) return;
            var abilitiesByTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes().Where(myType => myType.IsClass
                && !myType.IsAbstract && myType.IsSubclassOf(typeof(Ability)));

            _abilitiesByName = new Dictionary<string, Type>();

            foreach (var type in abilitiesByTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Ability;
                _abilitiesByName.Add(tempEffect.Name,type);
            }
            
        }
        

        public static Ability GetAbility(string abilityType)
        {
            InitializeFactory();
            if (_abilitiesByName.TryGetValue(abilityType, out var type))
            {
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            }
            return null;
        }

        internal static IEnumerable<string> GetAbilityNames()
        {
            InitializeFactory();
            return _abilitiesByName.Keys;
        }
    }
    
}