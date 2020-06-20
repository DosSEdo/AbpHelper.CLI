{{- SKIP_GENERATE = !Option.SeparateDto || Option.SkipViewModel -}}
using System;
{{~ if !Option.SkipLocalization }}
using System.ComponentModel.DataAnnotations;
{{ end ~}}
{{~ if Bag.PagesFolder; pagesNamespace = Bag.PagesFolder + "."; end ~}}

namespace {{ ProjectInfo.FullName }}.Web.Pages.{{ pagesNamespace }}{{ EntityInfo.RelativeNamespace}}.{{ EntityInfo.Name }}.ViewModels
{
    public class Create{{ EntityInfo.Name }}ViewModel
    {
        {{~ for prop in EntityInfo.Properties ~}}
        {{~ if prop | abp.is_ignore_property; continue; end ~}}
        {{~ if !Option.SkipLocalization ~}}
        [Display(Name = "{{ EntityInfo.Name + prop.Name}}")]
        {{~ end ~}}
        {{~ if string.ends_with prop.Type ">" ~}} 
        public {{
        stNameRgex = prop.Name | regex.replace "s" "." "$"
        stStart = "<" | string.append stNameRgex
        stViewModels = stStart | string.append "ViewModels."
        stCreate = stViewModels | string.append "Create"
        stNameVMAdded = prop.Name | regex.replace "s" "ViewModel" "$"
        stArrangeName = stCreate | string.append stNameVMAdded
        stAppendAtEnd = stArrangeName | string.append ">"
        stRegexFind = prop.Name | regex.replace "s" ">" "$"

        stFind = "<" | string.append stRegexFind


        prop.Type | string.replace stFind stAppendAtEnd

        }} Create{{ prop.Name }}ViewModel { get; set; }
        {{~ else ~}}
        public {{ prop.Type}} {{ prop.Name }} { get; set; }
        {{~end ~}}
        {{~ if !for.last ~}}

        {{~ end ~}}
        {{~ end ~}}
    }
}