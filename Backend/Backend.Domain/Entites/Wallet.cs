using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Validation;

namespace Backend.Domain.Entites
{
    public sealed class Wallet
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public DateTime Created_at { get; private set; }
        public DateTime Updated_at { get; set; }

        public Wallet(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");
        }


    }
}