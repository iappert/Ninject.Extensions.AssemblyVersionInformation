//-------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Ninject">
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

namespace ConsoleTestClient
{
    using System;
    using Ninject;
    using Ninject.Extensions.AssemblyVersionInformation;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel(new NinjectSettings() { LoadExtensions = false });

            kernel.Load<SelfExecutingVersionModule>();
            var entryAssemblyVersion = kernel.Get<EntryAssemblyVersion>();

            Console.WriteLine("Expected entry assembly version to be equal to `2.1.0.0`.");
            Console.WriteLine("Found entry assembly version is equal to `" + entryAssemblyVersion.ProductVersion + "`.");
            Console.ReadKey();
        }
    }
}
