using System.ComponentModel.DataAnnotations;

namespace GameStore;

public record UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] double Price,
    DateOnly ReleaseDate
);