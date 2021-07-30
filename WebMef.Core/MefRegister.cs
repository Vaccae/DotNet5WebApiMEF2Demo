using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Runtime.Loader;
using System.Linq;
using System.Composition.Convention;

namespace WebMef.Core
{
    public class MefRegister
    {
        [ImportMany]
        public static IEnumerable<IMsg> Msgs { get; set; }

        //定义组合容器
        private CompositionHost _container;


        public async Task<string> Start()
        {
            var assembiles = Directory.GetFiles(AppContext.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
            .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);

            var conventions = new ConventionBuilder();
            conventions.ForTypesDerivedFrom<IMsg>()
                .Export<IMsg>()
                .Shared();

            _container = new ContainerConfiguration().WithAssemblies(assembiles, conventions).CreateContainer();

            Msgs = _container.GetExports<IMsg>();

            return await Task.FromResult("MEF组件加载完成");
        }

        public void Stop()
        {
            Msgs = null;
            _container.Dispose();
        }
    }
}
