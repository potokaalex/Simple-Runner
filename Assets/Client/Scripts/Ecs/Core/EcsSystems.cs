using System.Collections.Generic;

namespace Ecs.Core
{
    public class EcsSystems
    {
        public HashSet<IUpdateSystem> UpdateSystems = new();
		public HashSet<IFixedUpdateSystem> FixedUpdateSystems = new();
		public HashSet<ILateUpdateSystem> LateUpdateSystems = new();

		public EcsSystems Add(EcsSystems systems)
		{
			foreach(var system in systems.UpdateSystems)
				UpdateSystems.Add(system);

			foreach (var system in systems.FixedUpdateSystems)
				FixedUpdateSystems.Add(system);

			foreach (var system in systems.LateUpdateSystems)
				LateUpdateSystems.Add(system);

			return this;
		}

		public EcsSystems Add(ISystem system)
        {
            if (system is IUpdateSystem updateSystem)
                UpdateSystems.Add(updateSystem);

            if (system is IFixedUpdateSystem fixedUpdateSystem)
                FixedUpdateSystems.Add(fixedUpdateSystem);

			if (system is ILateUpdateSystem lateUpdateSystem)
				LateUpdateSystems.Add(lateUpdateSystem);

			return this;
        }
    }
}