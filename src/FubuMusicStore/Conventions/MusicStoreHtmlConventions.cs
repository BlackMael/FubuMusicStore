using FubuFastPack.Domain;
using FubuMVC.Core.UI;
using FubuValidation;

namespace FubuMusicStore.Conventions
{
    public class MusicStoreHtmlConventions : HtmlConventionRegistry
    {
        public MusicStoreHtmlConventions()
        {
            validationAttributes();
        }
        // Declare policies for using validation attributes
        private void validationAttributes()
        {
            Editors.AddClassForAttribute<RequiredAttribute>("required");

            Labels.ModifyForAttribute<RequiredAttribute>(tag => tag.Add("span", span =>
            {
                span.Text("*");
                span.AddClass("req-indicator");
            }));

            Editors.ModifyForAttribute<MaximumStringLengthAttribute>((tag, att) =>
            {
                if (att.Length < DomainEntity.UnboundedStringLength)
                {
                    tag.Attr("maxlength", att.Length);
                }
            });

            Editors.If(x => x.Accessor.FieldName.ToLower().Contains("confirmpassword"))
                .Modify(tag => tag.Attr("data", "{equalTo:'#password', messages:{equalTo: 'Please enter the same password as above'}}"));

            Editors.ModifyForAttribute<GreaterOrEqualToZeroAttribute>(tag => tag.Attr("min", 0));
            Editors.ModifyForAttribute<GreaterThanZeroAttribute>(tag => tag.Attr("min", 1));
        }
    }
}