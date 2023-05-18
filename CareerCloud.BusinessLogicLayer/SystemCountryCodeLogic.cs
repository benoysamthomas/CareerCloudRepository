using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class SystemCountryCodeLogic
{
    protected IDataRepository<SystemCountryCodePoco> _repository;
    public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) 
    {
        _repository = repository;
    }
    public  void Add(SystemCountryCodePoco[] pocos)
    {
        Verify(pocos);
        _repository.Add(pocos);
    }

    public void Update(SystemCountryCodePoco[] pocos)
    {
        Verify(pocos);
        _repository.Update(pocos);
    }
    public SystemCountryCodePoco Get(string code)

    {

        return _repository.GetSingle(c => c.Code == code);

    }
    public List<SystemCountryCodePoco> GetAll()

    {

        return _repository.GetAll().ToList();

    }
    public void Delete(SystemCountryCodePoco[] pocos)

    {

        _repository.Remove(pocos);

    }
    protected void Verify(SystemCountryCodePoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
        foreach (var poco in pocos)
        {

            if (string.IsNullOrEmpty(poco.Code))
            {
                exceptions.Add(new ValidationException(900, $"Code for SystemCountryCode cannot be null"));
            }

            if (string.IsNullOrEmpty(poco.Name))
            {
                exceptions.Add(new ValidationException(901, $"Name for SystemCountryCode cannot be null"));
            }
           
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}






