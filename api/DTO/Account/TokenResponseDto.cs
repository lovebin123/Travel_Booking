#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Account
{
    public record TokenResponseDto(
      string? AccessToken,
      string? RefreshToken
    );
}
