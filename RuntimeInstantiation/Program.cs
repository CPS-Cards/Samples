using System;

namespace RuntimeInstantiation
{
    class Program
    {
        static void Main(string[] args)
        {
            var progressionMessage = "Press any key to proceed";

            var instantiationNamespace = typeof(ToBeInstantiated).Namespace;

            var regularInstantiationTypeName = nameof(ToBeInstantiated);
            var helloFreshInstantiationTypeName = nameof(ProcessHelloFresh);
            var merrickInstantiationTypeName = nameof(ProcessMerrick);

            Console.WriteLine("I am classless.");

            // classless method call, no instantiation necessary.
            Console.WriteLine(ToBeInstantiated.GetStaticMessage());
            Console.WriteLine(progressionMessage);
            Console.ReadLine();

            // concrete instantiation, directly newing up class
            var instantiated = new ToBeInstantiated();
            Console.WriteLine(instantiated.GetConcreteInstantiationMessage());
            Console.WriteLine(progressionMessage);
            Console.ReadLine();

            // contractual instantiation. Can be interface, inherited base class, etc. Usually injected through parent method or class.
            IManageInstantiationMethods instantiationMethodsManager = new ToBeInstantiated();
            Console.WriteLine(instantiationMethodsManager.GetRegularInstantiationMessage());
            Console.WriteLine(progressionMessage);
            Console.ReadLine();

            // dynamic instantiation of a concrete class.
            // Note that GetType() and the Activator will resolve from a string -- this can be from a DB field, config file, etc.
            var activatedConcreteType = Activator.CreateInstance(Type.GetType($"{instantiationNamespace}.{regularInstantiationTypeName}", true, false)) as ToBeInstantiated;
            Console.WriteLine(activatedConcreteType.GetConcreteInstantiationMessage());
            Console.WriteLine(progressionMessage);
            Console.ReadLine();

            // dynamic instantiations via interface.
            IManageInstantiationMethods activatedTypeThroughInterface = Activator.CreateInstance(Type.GetType($"{instantiationNamespace}.{regularInstantiationTypeName}", true, false)) as IManageInstantiationMethods;
            Console.WriteLine(activatedTypeThroughInterface.GetDynamicInstantiationMessage());
            Console.WriteLine(progressionMessage);
            Console.ReadLine();

            // At this point we can process arbitrarily and it's completely up to the caller to supply a valid processor name.

            // "Hello Fresh processor"
            activatedTypeThroughInterface = Activator.CreateInstance(Type.GetType($"{instantiationNamespace}.{helloFreshInstantiationTypeName}", true, false)) as IManageInstantiationMethods;
            Console.WriteLine(activatedTypeThroughInterface.GetDynamicInstantiationMessage());
            Console.WriteLine(progressionMessage);
            Console.ReadLine();

            // "Merrick processor"
            activatedTypeThroughInterface = Activator.CreateInstance(Type.GetType($"{instantiationNamespace}.{merrickInstantiationTypeName}", true, false)) as IManageInstantiationMethods;
            Console.WriteLine(activatedTypeThroughInterface.GetDynamicInstantiationMessage());
            Console.WriteLine(progressionMessage);
            Console.ReadLine();

            // If we need to select from a group of related processors or chain together multiple processors or choose based on file contents,
            // you can use a bus to select/retrieve the appropriate handler(s).
            // For an example of this in action, follow the _machineFileGenerationBus field in HOWIE/Verto's Automation solution which features a constructor-injected bus to the automation execution engine.

        }
    }
}
