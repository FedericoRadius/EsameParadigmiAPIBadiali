﻿using FluentValidation;
using System.Text.RegularExpressions;

namespace EsameParadigmiAPIBadiali.Applicazione.Estensioni
{
    //TODO serve?
    public static class ValidationExtensions
    {
        public static void RegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regex, string validationMessage)
        {
            ruleBuilder.Custom((value, context) =>
            {
                var regEx = new Regex(regex);
                if (regEx.IsMatch(value.ToString()) == false)
                {
                    context.AddFailure(validationMessage);
                }
            });
        }
    }
}
