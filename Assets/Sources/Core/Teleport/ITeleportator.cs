using Sources.Core.Menu;

namespace Sources.Core.Teleport
{
    public interface ITeleportator
    {
        void Teleport(ITeleportTarget target);
    }
}