using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

public static class HtmlExtensions

{

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]

    public static MvcHtmlString LabelForRequired<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText = "")
    {
        return LabelHelper(html, ModelMetadata.FromLambdaExpression(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression), labelText);
    }
    public static MvcHtmlString LabelForRequired<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText = "", object htmlAttributes=null)
    {
        return LabelHelper(html, ModelMetadata.FromLambdaExpression(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression), labelText,htmlAttributes);
    }
    private static MvcHtmlString LabelHelper(HtmlHelper html,ModelMetadata metadata, string htmlFieldName, string labelText, object htmlAttributes = null)
    {
        if (string.IsNullOrEmpty(labelText))
        {
            labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
        }
        if (string.IsNullOrEmpty(labelText))
        {
            return MvcHtmlString.Empty;
        }
        bool isRequired = false;        
        if (metadata.ContainerType != null)
        {
            isRequired = metadata.ContainerType.GetProperty(metadata.PropertyName).GetCustomAttributes(typeof(RequiredAttribute), false).Length == 1;
        }
        TagBuilder tag = new TagBuilder("label");
        tag.Attributes.Add("for",TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
        if (isRequired)
            tag.Attributes.Add("class", "label-required");
        tag.SetInnerText(labelText);
        if (htmlAttributes != null)
        {
            RouteValueDictionary customAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (KeyValuePair<string, object> customAttribute in customAttributes)
            {
                tag.MergeAttribute(customAttribute.Key.ToString(), customAttribute.Value.ToString());
            }
        }
        var output = tag.ToString(TagRenderMode.Normal);        
        if (isRequired)
        {
            var asteriskTag = new TagBuilder("span");
            asteriskTag.Attributes.Add("class", "required");
            asteriskTag.SetInnerText("*");
            output += asteriskTag.ToString(TagRenderMode.Normal);
        }
        return MvcHtmlString.Create(output);
    }
}