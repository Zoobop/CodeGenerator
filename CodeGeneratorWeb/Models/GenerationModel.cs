using LanguageConvertor.Core;

namespace CodeGeneratorWeb.Models;

public record GenerationModel
{
    public ConvertibleLanguage Language { get; init; }
    public IEnumerable<string> FileData { get; init; }
}