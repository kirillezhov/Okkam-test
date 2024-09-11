using CarManager.Domain.DomainEvents;
using CarManager.Domain.ValueObjects;

namespace CarManager.Domain.Entities;

public partial class Car
{
    public CarCreated Create(string name, int seats, byte[] image, string? url)
    {
        var newId = Guid.NewGuid();
        var modelName = new ModelName(name);
        var seatsCount = new SeatsCount(seats);
        var carImage = new CarImage(image);
        var dealerUrl = string.IsNullOrWhiteSpace(url) ? null : new DealerUrl(url);

        return new CarCreated
        {
            DomainId = newId,
            ModelName = modelName,
            SeatsCount = seatsCount,
            Image = carImage,
            DealerUrl = dealerUrl
        };
    }

    private void Apply(CarCreated @event)
    {
        this.ModelName = @event.ModelName;
        this.SeatsCount = @event.SeatsCount;
        this.Image = @event.Image;
        this.Url = @event.DealerUrl;
    }
}