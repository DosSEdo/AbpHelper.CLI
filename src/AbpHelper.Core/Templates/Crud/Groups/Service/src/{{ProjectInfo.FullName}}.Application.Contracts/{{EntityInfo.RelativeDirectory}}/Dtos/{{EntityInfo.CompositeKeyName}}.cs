{{- SKIP_GENERATE = EntityInfo.CompositeKeyName == null -}}
using System;
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
    public class {{ EntityInfo.CompositeKeyName }}
    {
        {{~ for prop in EntityInfo.CompositeKeys ~}}
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