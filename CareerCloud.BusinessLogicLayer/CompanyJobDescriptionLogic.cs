using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
{

    public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
    {
    }
    public override void Add(CompanyJobDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

    protected override void Verify(CompanyJobDescriptionPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
        foreach (var poco in pocos)
        {
            if (string.IsNullOrEmpty(poco.JobName))
            {
                exceptions.Add(new ValidationException(300, $"JobName for CompanyJobDescription {poco.Id} cannot be null"));
            }
         
            if (string.IsNullOrEmpty(poco.JobDescriptions))
            {
                exceptions.Add(new ValidationException(301, $"JobDescriptions for CompanyJobDescription {poco.Id} cannot be null"));
            }

        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}



