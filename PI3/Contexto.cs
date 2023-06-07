using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PI3.Entidades;


public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> opt) : base(opt)
    { }

    public DbSet<Usuario> USUARIO { get; set; }
    public DbSet<Pets> PETS { get; set; }


}
