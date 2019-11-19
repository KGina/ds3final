using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace AbantwanaWebMaster.Core.Extensions
{
    public static class CheckBoxListExtensions
    {
        /// <summary>
        /// Creates a checkbox list for flag enums.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <typeparam name="TValue">The model property type.</typeparam>
        /// <param name="html">The html helper.</param>
        /// <param name="expression">The model expression.</param>
        /// <param name="htmlAttributes">Optional html attributes.</param>
        /// <param name="sortAlphabetically">Indicates if the checkboxes should be sorted alfabetically.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListForEnum<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, bool sortAlphabetically = false)
        {
            var fieldName = ExpressionHelper.GetExpressionText(expression);
            var fullBindingName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(fieldName);
            var fieldId = TagBuilder.CreateSanitizedId(fullBindingName);

            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var value = metadata.Model;

            // Get all enum values
            IEnumerable<TValue> values = Enum.GetValues(typeof(TValue)).Cast<TValue>();

            // Sort them alphabetically by resource name or default enum name
            if (sortAlphabetically)
                values = values.OrderBy(i => i.ToString());

            // Create checkbox list
            var sb = new StringBuilder();
            foreach (var item in values)
            {
                TagBuilder builder = new TagBuilder("input");
                long targetValue = Convert.ToInt64(item);
                long flagValue = Convert.ToInt64(value);

                if ((targetValue & flagValue) == targetValue)
                    builder.MergeAttribute("checked", "checked");

                builder.MergeAttribute("type", "checkbox");
                builder.MergeAttribute("value", item.ToString());
                builder.MergeAttribute("name", fieldId);

                // Add optional html attributes
                if (htmlAttributes != null)
                    builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
                builder.InnerHtml = item.ToString();

                sb.Append(builder.ToString(TagRenderMode.Normal));

                // Seperate checkboxes by new line
                sb.Append("<br/>");
            }

            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString CheckBoxListFor<TModel, T>
   (this HtmlHelper<TModel> htmlHelper,
   Expression<Func<TModel, IEnumerable<T>>> selectedValuesExpression,
   Expression<Func<TModel, Dictionary<string, T>>> listOfOptionsExpression = null,
   string ulClass = null)
        {
            ModelMetadata metadataselectedValues = ModelMetadata.FromLambdaExpression(selectedValuesExpression, htmlHelper.ViewData);

            var unobtrusiveValidationAttributes = htmlHelper.GetUnobtrusiveValidationAttributes
(metadataselectedValues.PropertyName, metadataselectedValues);

            var html = new TagBuilder("ul");
            if (!String.IsNullOrEmpty(ulClass))
                html.MergeAttribute("class", ulClass);

            string innerhtml = "";
            var selectedValues = metadataselectedValues.Model as IEnumerable<T>;
            Dictionary<string, T> listOfOptions = null;
            if (typeof(T).BaseType != typeof(Enum) && listOfOptions == null)
            {
                throw new Exception("please provide list of possible checkboxes");
            }
            //check if is enum and we don't have any list
            else if (typeof(T).BaseType == typeof(Enum) && listOfOptions == null)
            {
                listOfOptions = new Dictionary<string, T>();
                listOfOptions = Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(currentItem => Enum.GetName(typeof(T), currentItem));
            }
            else
            {
                ModelMetadata metadatalistOfOptions = ModelMetadata.FromLambdaExpression(listOfOptionsExpression, htmlHelper.ViewData);
                listOfOptions = metadatalistOfOptions.Model as Dictionary<string, T>;
            }
            foreach (var item in listOfOptions)
            {

                bool ischecked = (selectedValues == null) ? false : selectedValues.Any(x => x.ToString() == item.Value.ToString());
                var itemId = metadataselectedValues.PropertyName + "_" + item.Value;
                var liBuilder = new TagBuilder("li");

                var inputBuilder = new TagBuilder("input");
                inputBuilder.MergeAttribute("type", "checkbox");
                inputBuilder.MergeAttribute("name", metadataselectedValues.PropertyName, true);
                inputBuilder.MergeAttribute("id", itemId, true);
                inputBuilder.MergeAttribute("value", item.Value.ToString(), true);
                inputBuilder.MergeAttributes(unobtrusiveValidationAttributes);
                if (ischecked)
                {
                    inputBuilder.MergeAttribute("checked", "'checked'");
                }

                liBuilder.InnerHtml = inputBuilder.ToString() + htmlHelper.Label(itemId, item.Key);
                innerhtml = innerhtml + liBuilder;

            }
            html.InnerHtml = innerhtml;
            return new MvcHtmlString(html.ToString());


        }
    }
}
