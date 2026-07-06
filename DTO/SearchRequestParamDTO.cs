using System.Text.Json.Serialization;

public class SearchRequestParamDTO
{
    public ShikimoriSearchRequestParamDTO searchShikimori {get; set;}
    public KodikSearchRequestParamDTO searchKodik {get; set;}
}