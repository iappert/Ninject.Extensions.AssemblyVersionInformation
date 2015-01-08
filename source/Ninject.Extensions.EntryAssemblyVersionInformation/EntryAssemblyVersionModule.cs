//-------------------------------------------------------------------------------
// <copyright file="EntryAssemblyVersionModule.cs" company="Ninject">
//   Copyright (c) 2008-2015
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Ninject.Extensions.EntryAssemblyVersionInformation
{
    using JetBrains.Annotations;
    using Ninject.Activation;
    using Ninject.Extensions.AssemblyVersionInformation;
    using Ninject.Extensions.AssemblyVersionInformation.EntryAssembly;
    using Ninject.Modules;

    [UsedImplicitly]
    public class EntryAssemblyVersionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<VersionInformation>().ToProvider<IProvider<VersionInformation>>().InSingletonScope();
            this.Bind<IProvider<VersionInformation>>().To<EntryAssemblyVersionProvider>().InTransientScope();
        }
    }
}