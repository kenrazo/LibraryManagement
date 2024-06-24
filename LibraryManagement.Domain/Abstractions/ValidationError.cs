namespace LibraryManagement.Domain.Abstractions
{
    public sealed record ValidationError(string PropertyName, string ErrorMessage);
}
