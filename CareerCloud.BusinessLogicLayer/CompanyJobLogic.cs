using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
{

    public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository)
    {
    }
    public override void Add(CompanyJobPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

    protected override void Verify(CompanyJobPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
     
        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}




