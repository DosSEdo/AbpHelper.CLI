using System;
using Volo.Abp.Application.Dtos;
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
    public class {{ DtoInfo.ReadTypeName }} : {{ EntityInfo.BaseType | string.replace "AggregateRoot" "Entity"}}Dto{{ if EntityInfo.PrimaryKey }}<{{ EntityInfo.PrimaryKey}}>{{ end }}
    {
        {{~ for prop in EntityInfo.Properties ~}}
        {{~ if prop | abp.is_ignore_property; continue; end ~}}
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