using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class ApplicantWorkHistoryLogic : BaseLogic<ApplicantWorkHistoryPoco>
{

    public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : base(repository)
    {
    }
    public override void Add(ApplicantWorkHistoryPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantWorkHistoryPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

    protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
        DateTime today = DateTime.Today;
        foreach (var poco in pocos)
        {
            if (poco.CompanyName.Length <= 2)
            {
                exceptions.Add(new ValidationException(105, $"CompanyName for ApplicantWorkHistory {poco.Id} must be greater than 2 characters."));
            }

        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}

