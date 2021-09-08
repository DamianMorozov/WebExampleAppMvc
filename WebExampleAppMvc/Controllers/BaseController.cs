// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebExampleAppMvc.Common;

namespace WebExampleAppMvc.Controllers
{
    public class BaseController : Controller
    {
        #region Public and private fields and properties

        public TaskHelper TaskHelper = TaskHelper.Instance;
        public readonly ILogger<BaseController> Logger;

        #endregion

        #region Constructor and destructor

        public BaseController(ILogger<BaseController> logger)
        {
            Logger = logger;
        }

        #endregion

        #region Public and private methods


        #endregion
    }
}
