﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Write;

public abstract class Entity
{
    public Entity(Guid id)
    {
        Id = id;
    }
    public Entity()
    { }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
}