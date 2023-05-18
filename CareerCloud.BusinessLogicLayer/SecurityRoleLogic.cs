using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class SecurityRoleLogic : BaseLogic<SecurityRolePoco>
{

    public SecurityRoleLogic(IDataRepository<SecurityRolePoco> repository) : base(repository)
    {
    }
    public override void Add(SecurityRolePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(SecurityRolePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

    protected override void Verify(SecurityRolePoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
        foreach (var poco in pocos)
        {
            if (string.IsNullOrEmpty(poco.Role))
            {
                exceptions.Add(new ValidationException(800, $"Role for SecurityRole {poco.Id} cannot be null"));
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}





