﻿namespace NZWalks.API.Models.Domain.DTO
{
    public class AddWalkRequestDto
    {
        public string Name { get; set; }
        public string RegionImageUrl { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
