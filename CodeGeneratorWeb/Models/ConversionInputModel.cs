namespace CodeGeneratorWeb.Models;

using LanguageConvertor.Core;

public record ConversionInputModel
{
    public FileInfo File { get; init; }
    public ConvertibleLanguage Language { get; init; }
}