// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using WebExampleAppMvc.Data;
using WebExampleAppMvc.Models;

namespace WebExampleAppMvc.Controllers
{
    public class TestEmptyController : BaseController
    {
        #region Public and private fields and properties

        public JsonSettingsEntity JsonSettings { get; set; }
        private readonly MvcMovieContext _context;

        #endregion

        #region Constructor and destructor

        public TestEmptyController(ILogger<TestEmptyController> logger, IConfiguration configuration, MvcMovieContext context) : base(logger)
        {
            JsonSettings = new JsonSettingsEntity(configuration);
            _context = context;
        }

        #endregion

        #region Public and private methods

        [AllowAnonymous]
        [HttpGet()]
        [Route("api/testempty/")]
        public ContentResult Index()
        {
            return TaskHelper.RunTask(new Task<ContentResult>(() =>
            {
                string content = @$"
{nameof(JsonSettings)}: {JsonSettings}
{nameof(MvcMovieContext)}: {_context.Database}

Use this API:
- api/testempty/getmovie
- api/testempty/getmovie?id=1
- api/testempty/getmovie?id=1&format=json
- api/testempty/getmovie?id=1&format=xml
                    ".TrimStart('\r', ' ', '\n', '\t').TrimEnd('\r', ' ', '\n', '\t');
                return new ContentResult
                {
                    ContentType = "application/text",
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = content,
                };
            }));
        }

        [AllowAnonymous]
        [HttpGet()]
        [Route("api/testempty/getmovie")]
        public IActionResult GetMovie(int? id, string format)
        {
            return TaskHelper.RunTask(new Task<ContentResult>(() =>
            {
                string contentType = "application/text";
                string content = string.Empty;
                if (id == null)
                {
                    foreach (MovieEntity movieItem in _context.MovieEntity)
                    {
                        content += movieItem + Environment.NewLine;
                    }
                }
                MovieEntity movie = _context.MovieEntity.FirstOrDefaultAsync(x => x.Id == id).Result;
                content = (movie != null) ? movie.ToString() : new MovieEntity().ToString();
                if (!string.IsNullOrEmpty(format))
                {
                    switch (format.ToUpper())
                    {
                        case "XML":
                            contentType = "application/xml";
                            content = (movie != null) ? movie.SerializeObjectAsXml() : new MovieEntity().SerializeObjectAsXml();
                            break;
                        case "JSON":
                            contentType = "application/json";
                            content = (movie != null) ? movie.SerializeObjectAsJson() : new MovieEntity().SerializeObjectAsJson();
                            break;
                    }
                }
                return new ContentResult
                {
                    ContentType = contentType,
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = content,
                };
            }));
        }

        #endregion
    }
}
