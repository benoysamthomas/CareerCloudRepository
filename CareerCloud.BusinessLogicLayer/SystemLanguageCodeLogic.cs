﻿using CareerCloud.Pocos;
using System;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CareerCloud.BusinessLogicLayer;

public class SystemLanguageCodeLogic
{
    protected IDataRepository<SystemLanguageCodePoco> _repository;
    public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) 
    {
        _repository = repository;
    }
    public  void Add(SystemLanguageCodePoco[] pocos)
    {
        Verify(pocos);
        _repository.Add(pocos);
    }

    public  void Update(SystemLanguageCodePoco[] pocos)
    {
        Verify(pocos);
        _repository.Update(pocos);
    }
    public SystemLanguageCodePoco Get(string languageid)

    {

        return _repository.GetSingle(l => l.LanguageID == languageid);

    }
    public List<SystemLanguageCodePoco> GetAll()

    {

        return _repository.GetAll().ToList();

    }
    public void Delete(SystemLanguageCodePoco[] pocos)

    {

        _repository.Remove(pocos);

    }
    protected void Verify(SystemLanguageCodePoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();
        foreach (var poco in pocos)
        {

            if (string.IsNullOrEmpty(poco.LanguageID))
            {
                exceptions.Add(new ValidationException(1000, $"LanguageID for SystemLanguageCode cannot be empty"));
            }

            if (string.IsNullOrEmpty(poco.Name))
            {
                exceptions.Add(new ValidationException(1001, $"Name for SystemLanguageCode cannot be empty"));
            }

            if (string.IsNullOrEmpty(poco.NativeName))
            {
                exceptions.Add(new ValidationException(1002, $"NativeName for SystemLanguageCode cannot be empty"));
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }
}







