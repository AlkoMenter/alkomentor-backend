﻿namespace Alkomentor.Domain;

public class Profile
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public double Weight { get; set; }

    public Gender Gender { get; set; }

    public Account? Account { get; set; }
}
