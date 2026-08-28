using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Dtos
{
    public record GameDto(
        int Id,
        string Name,
        string Genre,
        double Price,
        DateOnly ReleaseDate
    );
}