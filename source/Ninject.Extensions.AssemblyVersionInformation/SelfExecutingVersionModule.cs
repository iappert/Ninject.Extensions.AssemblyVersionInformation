//-------------------------------------------------------------------------------
// <copyright file="SelfExecutingVersionModule.cs" company="Ninject">
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

namespace Ninject.Extensions.AssemblyVersionInformation
{
    using System.Diagnostics;
    using System.Reflection;
    using JetBrains.Annotations;
    using Ninject.Activation;
    using Ninject.Modules;

    [UsedImplicitly]
    public class SelfExecutingVersionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<EntryAssemblyVersion>().ToProvider<IProvider<EntryAssemblyVersion>>().InSingletonScope();
            this.Bind<IProvider<EntryAssemblyVersion>>().To<EntryAssemblyVersionProvider>();
        }

        [UsedImplicitly]
        private class EntryAssemblyVersionProvider : Provider<EntryAssemblyVersion>
        {
            protected override EntryAssemblyVersion CreateInstance(IContext context)
            {
                var assembly = Assembly.GetEntryAssembly();
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

                return new EntryAssemblyVersion(fileVersionInfo.ProductVersion);
            }
        }
    }
}