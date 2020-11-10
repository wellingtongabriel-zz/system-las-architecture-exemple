using Sistema.Las.Domain.Interfaces;
using System;

namespace Sistema.Las.Domain.Entidades
{
    public abstract class EntidadeBase : IEntidadeBase
    {
        public Guid Id { get; private set; }

        public EntidadeBase AlteraId(Guid id)
        {
            Id = id;
            return this;
        } 
    }
}
