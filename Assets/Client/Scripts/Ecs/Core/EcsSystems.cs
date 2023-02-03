using System.Collections.Generic;

namespace Ecs
{
    public class EcsSystems
    {
		//public List<IInitializationSystem> InitializationSystems = new();
		public List<IFixedUpdateSystem> FixedUpdateSystems = new();
		public List<IUpdateSystem> UpdateSystems = new();
		public List<ILateUpdateSystem> LateUpdateSystems = new();

		public EcsSystems Add(EcsSystems systems)
		{
			/*
			foreach (var system in systems.InitializationSystems)
				InitializationSystems.Add(system);
			*/
			foreach (var system in systems.FixedUpdateSystems)
				FixedUpdateSystems.Add(system);

			foreach (var system in systems.UpdateSystems)
				UpdateSystems.Add(system);

			foreach (var system in systems.LateUpdateSystems)
				LateUpdateSystems.Add(system);

			return this;
		}

		public EcsSystems Add(ISystem system)
        {
			/*
			if (system is IInitializationSystem initializationSystem)
				InitializationSystems.Add(initializationSystem);
			*/
			if (system is IFixedUpdateSystem fixedUpdateSystem)
                FixedUpdateSystems.Add(fixedUpdateSystem);

			if (system is IUpdateSystem updateSystem)
				UpdateSystems.Add(updateSystem);

			if (system is ILateUpdateSystem lateUpdateSystem)
				LateUpdateSystems.Add(lateUpdateSystem);

			return this;
        }
    }
}