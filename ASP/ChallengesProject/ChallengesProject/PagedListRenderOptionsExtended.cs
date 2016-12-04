using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;

namespace ChallengesProject
{
    public class PagedListRenderOptionsExtended
    {
        public static PagedListRenderOptions EnableUnobtrusiveAjaxReplacing(PagedListRenderOptions options, AjaxOptions ajaxOptions)
        {
            options.FunctionToTransformEachPageLink = (liTagBuilder, aTagBuilder) =>
            {
                var liClass = liTagBuilder.Attributes.ContainsKey("class") ? liTagBuilder.Attributes["class"] ?? "" : "";
                if (ajaxOptions != null && !liClass.Contains("disabled") && !liClass.Contains("active"))
                {
                    //TODO: Try to set Url dynamically for each a tag
                    foreach (var ajaxOption in ajaxOptions.ToUnobtrusiveHtmlAttributes())
                        aTagBuilder.Attributes.Add(ajaxOption.Key, ajaxOption.Value.ToString());
                }

                liTagBuilder.InnerHtml = aTagBuilder.ToString();
                return liTagBuilder;
            };
            return options;
        }

        public static PagedListRenderOptions EnableUnobtrusiveAjaxReplacing(AjaxOptions ajaxOptions)
        {
            return EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions(), ajaxOptions);
        }
    }
}