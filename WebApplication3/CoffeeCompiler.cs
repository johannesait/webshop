using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplication3
{
    public class CoffeeCompiler : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            var coffeeEngine = new CoffeeSharp.CoffeeScriptEngine();
            string compiledCoffeeScript = String.Empty;
            var currentDirectory = HttpContext.Current.Server.MapPath("~/");
            foreach (var file in response.Files)
            {
                var path = currentDirectory + file.VirtualFile.VirtualPath;

                using (var reader = new StreamReader(path))
                {

                    compiledCoffeeScript += coffeeEngine.Compile(reader.ReadToEnd());
                    reader.Close();
                }
            }

            response.Content = compiledCoffeeScript;
            response.ContentType = "text/javascript";
            response.Cacheability = HttpCacheability.Public;
        }
    }
}