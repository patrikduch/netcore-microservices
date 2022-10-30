using NetMicroservices.SqlWrapper.Nuget;

namespace User.Domain.Entities;

public class UserEntity : EntityBase
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }
}
