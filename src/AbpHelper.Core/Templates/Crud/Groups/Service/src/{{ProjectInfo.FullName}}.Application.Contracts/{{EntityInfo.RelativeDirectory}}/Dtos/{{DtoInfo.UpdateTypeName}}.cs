{{- SKIP_GENERATE = DtoInfo.CreateTypeName == DtoInfo.UpdateTypeName -}}
using System;
using System.ComponentModel;
{{~ for prop in EntityInfo.Properties ~}}
    {{~ if prop | abp.is_ignore_property; continue; end ~}}
    {{~ if prop.Type | string.starts_with "IEnumerable<" ~}}
using System.Collections.Generic;
    {{~ end ~}}
    {{~ if !for.last ~}}

    {{~ end ~}}
{{~ end ~}}

namespace {{ EntityInfo.Namespace }}.Dtos
{
    [Serializable]
    public class {{ DtoInfo.UpdateTypeName }}
    {
        {{~ for prop in EntityInfo.Properties ~}}
        {{~ if prop | abp.is_ignore_property; continue; end ~}}
        {{~ if !Option.SkipLocalization && Option.SkipViewModel ~}}
        [DisplayName("{{ EntityInfo.Name + prop.Name}}")]
        {{~ end ~}}
        {{~ if prop.Type | string.starts_with "IEnumerable<" ~}}
        public {{ prop.Type | string.replace ">" "Dto>"}} {{ prop.Name }}Dto { get; set; }
        {{~ else ~}}
        public {{ prop.Type }} {{ prop.Name }} { get; set; }
        {{~ end ~}}
        {{~ if !for.last ~}}

        {{~ end ~}}
        {{~ end ~}}
    }
}