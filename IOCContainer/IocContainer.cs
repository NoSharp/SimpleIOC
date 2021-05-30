using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IOCContainer{

    /// <summary>
    /// A simple IoC container that allows for constructor dependency Injection.
    /// </summary>
    public class IocContainer
    {

        private readonly Dictionary<Type, object> _singletons;

        private static IocContainer _containerInstance;

        public static IocContainer Instance
        {
            get { return _containerInstance ??= new IocContainer(); }
        }

        public IocContainer()
        {
            _singletons = new Dictionary<Type, object>();
        }

        private ConstructorInfo ResolveConstructor(Type type)
        {
            try
            {
                return type.GetConstructors().FirstOrDefault();
            }
            catch (MissingMethodException _)
            {
                Console.WriteLine("No construcotr!");
                return null;
            }
        }

        private T SafelyInstantiateObject<T>(params object[] args)
        {
            if (args.Length == 0)
            {
                return (T) Activator.CreateInstance(typeof(T), null);
            }
            
            return (T) Activator.CreateInstance(typeof(T), args.ToArray());
            
        }

        private T ConstructObject<T>(params object[] extraArguments)
        {
            var type = typeof(T);
            var arguments = new List<object>();
            var constructor = ResolveConstructor(type);
            
            if (constructor == null)
            {
                
                return SafelyInstantiateObject<T>(arguments.ToArray());
            }

            uint currentExtraIndex = 0;
            var parameterInfos = constructor.GetParameters();
            for (int paramIdx = 0; paramIdx < parameterInfos.Length; paramIdx++)
            {
                var paramInfo = parameterInfos[paramIdx];
                var paramType = paramInfo.ParameterType;
                
                if (_singletons.ContainsKey(paramType))
                {
                    arguments.Add(this._singletons[paramType]);
                }
                else
                {
                    arguments.Add(extraArguments[currentExtraIndex]);
                    currentExtraIndex++;
                }

            }
            
            return SafelyInstantiateObject<T>(arguments.ToArray());
        }

        public void Set<T, TV>(params object[] args) where TV : T
        {
            Type type = typeof(T);
            
            if (_singletons.ContainsKey(type))
            {
                throw new Exception("Duplicate singleton found in IOCContainer.");
            }

            _singletons.Add(type, ConstructObject<TV>(args));
        }

        public T Get<T>()
        {
            return (T)_singletons[typeof(T)];
        }

    }
}