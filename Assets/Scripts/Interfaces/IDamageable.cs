using System.Numerics;
using Vector3 = UnityEngine.Vector3;

namespace Interfaces
{
    public interface IDamageable
    {
        Vector3 Position { get; }
        void Damage(float damage);
    }
}
