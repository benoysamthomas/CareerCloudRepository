using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
{

    public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
    {
    }
    public override void Add(CompanyProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

    protected override void Verify(CompanyProfilePoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
        string[] validExtensions = new string[] { ".ca", ".com", ".biz" };
        foreach (var poco in pocos)
        {

            if (string.IsNullOrEmpty(poco.CompanyWebsite))
            {
                exceptions.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfile {poco.Id} cannot be null"));
            }
            else if (!validExtensions.Any(extension => poco.CompanyWebsite.EndsWith(extension)))
            {
                exceptions.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfile {poco.Id}  must end with the following extensions – '.ca','.com', '.biz'"));
            }
            if (string.IsNullOrEmpty(poco.ContactPhone))
            {
                exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is required"));
            }
            else
            {
                string[] phoneComponents = poco.ContactPhone.Split('-');
                if (phoneComponents.Length != 3)
                {
                    exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is not in the required format."));
                }
                else
                {
                    if (phoneComponents[0].Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, $"ContactPhone for SecurityLogin {poco.Id} is not in the required format."));
                    }
                    else if (phoneComponents[1].Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is not in the required format."));
                    }
                    else if (phoneComponents[2].Length != 4)
                    {
                        exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.Id} is not in the required format."));
                    }
                }
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}





