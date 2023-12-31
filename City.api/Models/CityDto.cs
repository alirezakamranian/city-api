﻿namespace City.api.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumberOfPointsOfIntrest { get { return PointsOfIntrest.Count; } }

        public ICollection<PointsOfIntrestDto> PointsOfIntrest { get; set; } =new List<PointsOfIntrestDto>();
    }
}
