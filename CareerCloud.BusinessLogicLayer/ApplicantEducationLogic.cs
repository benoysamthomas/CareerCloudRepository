using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
{
    public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
    {
    }
    public override void Add(ApplicantEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

    protected override void Verify(ApplicantEducationPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
        DateTime today = DateTime.Today;
        foreach (var poco in pocos)
        {
            if (string.IsNullOrEmpty(poco.Major))
            {
                exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Id} cannot be null"));
            }
            else if (poco.Major.Length < 3)
            {
                exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Id} must be at least 3 characters."));
            }

           if (poco.StartDate > today)
            {
                exceptions.Add(new ValidationException(108, $"StartDate for ApplicantEducation {poco.Id} must not be greater than today"));

            }

            if (poco.CompletionDate < poco.StartDate)
            {
                exceptions.Add(new ValidationException(109, $"CompletionDate for ApplicantEducation {poco.Id} must not be earlier than StartDate"));

            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}