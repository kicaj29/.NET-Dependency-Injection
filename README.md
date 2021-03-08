# Unity
Unity for .NET Framework: https://www.nuget.org/packages/Unity/   
Unity for .NET Standard: https://www.nuget.org/packages/Unity.NetCore/

https://docs.microsoft.com/en-us/previous-versions/msp-n-p/dn507462(v=pandp.30)   
https://www.c-sharpcorner.com/UploadFile/dhananjaycoder/unity-framework/   
http://www.tutorialsteacher.com/ioc/lifetime-manager-in-unity-container   

## Lifetime Managers
* *TransientLifetimeManager*   
Creates a new object of requested type every time you call Resolve or ResolveAll method.
* *ContainerControlledLifetimeManager*   
Creates a singleton object first time you call Resolve or ResolveAll method and then returns the same object on subsequent Resolve or ResolveAll call.
* *HierarchicalLifetimeManager*   
Same as ContainerControlledLifetimeManager, the only difference is that child container can create its own singleton object. Parent and child container do not share singleton object.


# StructureMap.NET5   

[example](./StructureMap.NET5)   

https://stackoverflow.com/questions/66528541/structuremap-does-not-see-types-in-asp-net-core-net5?answertab=oldest#tab-top


