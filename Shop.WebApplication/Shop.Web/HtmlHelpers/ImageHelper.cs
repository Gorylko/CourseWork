using System;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Shop.Business.Services;
using Shop.Shared.Entities.Images;

namespace Shop.Web.HtmlHelpers
{
    public static class ImageHelper
    {
        private static ImageService _imageService = new ImageService();
        public static IHtmlString RenderImage(this HtmlHelper helper, Image image, string cssClass, object htmlAttributes = null)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", cssClass);
            builder.MergeAttributes(ObjectToHtmlAttributes(htmlAttributes));

            var imageString = image != null ? Convert.ToBase64String(image.Data) : "";
            var img = string.Format("data:image/" + image.Extension + ";base64," + imageString);
            builder.MergeAttribute("src", img);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        private static RouteValueDictionary ObjectToHtmlAttributes(object htmlAttributes)
        {
            RouteValueDictionary result = new RouteValueDictionary();
            if (htmlAttributes != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes))
                {
                    result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
                }
            }
            return result;
        }
    }
}