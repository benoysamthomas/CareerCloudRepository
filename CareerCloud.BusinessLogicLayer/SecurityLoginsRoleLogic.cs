using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
{

    public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository)
    {
    }
    public override void Add(SecurityLoginsRolePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(SecurityLoginsRolePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

    protected override void Verify(SecurityLoginsRolePoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}





