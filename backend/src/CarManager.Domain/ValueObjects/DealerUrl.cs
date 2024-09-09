using System.Text.RegularExpressions;

namespace CarManager.Domain.ValueObjects;

public record DealerUrl : SingleValueObject<string?>
{
    public DealerUrl(string? value)
    {
        Validate(value);
        Value = value;
    }

    protected static void Validate(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }
        
        var regex = new Regex(@"^https?:\/\/+([a-zA-Z0-9]+\.)?([a-zA-Z]{2,}\.ru)(\/+[^\r\n]*)?$", RegexOptions.Compiled);

        if (!regex.IsMatch(value))
        {
            throw new ArgumentException($"Dealer URL must be in the '.ru' domain. Passed value: {value}");
        }
    }
}