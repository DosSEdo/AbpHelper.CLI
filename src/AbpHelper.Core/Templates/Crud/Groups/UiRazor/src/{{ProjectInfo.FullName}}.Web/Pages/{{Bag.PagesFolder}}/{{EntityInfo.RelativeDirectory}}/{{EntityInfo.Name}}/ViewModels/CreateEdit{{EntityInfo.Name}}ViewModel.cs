{{- SKIP_GENERATE = Option.SeparateDto || Option.SkipViewModel -}}
using System;
{{~ if !Option.SkipLocalization }}
using System.ComponentModel.DataAnnotations;
{{ end ~}}
{{~ for prop in EntityInfo.Properties ~}}
    {{~ if prop | abp.is_ignore_property; continue; end ~}}
    {{~ if prop.Type | string.starts_with "IEnumerable<" ~}}
using System.Collections.Generic;
    {{~ end ~}}
    {{~ if !for.last ~}}

    {{~ end ~}}
{{~ end ~}}
{{~ if Bag.PagesFolder; pagesNamespace = Bag.PagesFolder + "."; end ~}}

namespace {{ ProjectInfo.FullName }}.Web.Pages.{{ pagesNamespace }}{{ EntityInfo.RelativeNamespace}}.{{ EntityInfo.Name }}.ViewModels
{
    public class CreateEdit{{ EntityInfo.Name }}ViewModel
    {
        {{~ for prop in EntityInfo.Properties ~}}
        {{~ if prop | abp.is_ignore_property; continue; end ~}}
        {{~ if !Option.SkipLocalization ~}}
        [Display(Name = "{{ EntityInfo.Name + prop.Name}}")]
        {{~ end ~}}
        {{~ if prop.Type | string.starts_with "IEnumerable<" ~}}
        public {{ prop.Type | string.replace ">" "ViewModel>"}} {{ prop.Name }}ViewModels { get; set; }
        {{~ else ~}}
        public {{ prop.Type }} {{ prop.Name }} { get; set; }
        {{~ end ~}}
        {{~ if !for.last ~}}

        {{~ end ~}}
        {{~ end ~}}
    }
}