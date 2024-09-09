using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

namespace CarManager.Domain.ValueObjects;

public record CarImage
{
    public byte[] Value { get; }
    
    public CarImage(byte[] value)
    {
        Validate(value);
        Value = value;
    }

    protected static void Validate(byte[] input)
    {
        IImageFormat? format = Image.DetectFormat(input);

        if (format is null)
        {
            throw new ArgumentException("Invalid image format.");
        }

        if (format is not (JpegFormat or PngFormat))
        {
            throw new ArgumentException("Image format must be JPEG or PNG.");
        }
    }
}