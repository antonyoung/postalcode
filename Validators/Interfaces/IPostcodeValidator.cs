﻿using Validators.Formatters;
using Validators.Enums;

namespace Validators.Interfaces
{
      
    /// <summary>
    ///     interface to be used for postal code business logic according to each country in Europe
    /// </summary>
    public interface IPostcodeValidator // : IPostcodeModel
    {

        /// <summary>
        ///     used as example postalcode of the set country. 
        /// </summary>
        string Example { get; }


        /// <summary>
        ///     used as message to the caller in case <seealso cref="IsValid"/> is false, else is string.Empty.
        /// </summary>
        string ErrorMessage { get; }


        /// <summary>
        ///     validates current input as postal code according to the set country.
        /// </summary>
        bool IsValid { get; }


        bool TryValidate(string value, out string result);


        bool TryValidate(string value, Countries country, out string result);


        bool TryValidate(string value, Countries country, PostcodeFormatters formatter, out string result);

    }
}