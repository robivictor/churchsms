﻿using System.Text;
using System.Web.Mvc;

namespace ChurchSMS_offline.JsonNet
{
    public abstract class BaseController:Controller
    {
        protected override JsonResult Json(object data, string contentType,
        Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}