// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.Extensions.Configuration;

namespace WebExampleAppMvc.Models
{
    /// <summary>
    /// appsettings.json
    /// </summary>
    public class JsonSettingsEntity
    {
        public IConfiguration Configuration { get; }
        public string MvcMovieContext
        {
            get => Configuration["ConnectionStrings:MvcMovieContext"];
            set => Configuration["ConnectionStrings:MvcMovieContext"] = value;
        }
        public JsonSettingsEntity(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override string ToString() => $"{nameof(MvcMovieContext)}: {MvcMovieContext}. ";
    }
}
