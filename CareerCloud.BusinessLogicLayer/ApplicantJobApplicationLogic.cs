using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
{
    public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
    {
    }

    public override void Add(ApplicantJobApplicationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantJobApplicationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

    protected override void Verify(ApplicantJobApplicationPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
        DateTime today = DateTime.Today;
        foreach (var poco in pocos)
        {
            if (string.IsNullOrEmpty(poco.ApplicationDate.ToString()))
            {
                exceptions.Add(new ValidationException(110, $"ApplicationDate for ApplicantJobApplication {poco.Id} cannot be null"));
            }
            else if (poco.ApplicationDate > today)
            {
                exceptions.Add(new ValidationException(110, $"ApplicationDate for ApplicantJobApplication {poco.Id} must not be greater than today."));
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}