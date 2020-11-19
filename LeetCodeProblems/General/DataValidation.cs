using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodeProblems
{

    //    Data Validation
    //Have the function DataValidation(strArr) read the input string and determine if it is in a valid format.

    //Acceptance Criteria
    //- Parameters should be handled in order from left to right
    //- Help has highest precedence
    //- Parameters are optional, however at least one parameter must be provided for a set of parameters to be considered valid
    //- Parameters are case-insensitive
    //- Additional whitespace should be ignored
    //- Your solution must not throw exceptions

    //Input Format
    //Parameter | Value
    //--count | an integer between 10 and 100 (inclusive)
    //--name | a string of length between 3 and 10 characters(inclusive)
    //--help |

    //Output Format
    //Value | Description
    //-1 | if invalid data or invalid parameters are given
    //0 | if all parameters are valid
    //1 | if help information was requested and all parameters are valid
    //Examples
    //Input: "--count g"
    //Output: -1
    //Input: "--name abc --help"
    //Output: 1
    //Browse Resources
    //Search for any help or documentation you might need for this problem.For example: array indexing, Ruby hash tables, etc.
    static class DataValidationClass
    {
        //private static readonly string[] validParameters = { "count", "name", "help" };

        public static string DataValidation(string str)
        {

            List<string> parameters = str.Split("--").Select(p => p.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            bool hasInvalidInput = false;

            if (parameters.Count == 0)
                return "-1";
                        
            foreach(string parameter in parameters)
            {
                string[] parameterNameAndValue = parameter.Split(' ');
                string parameterName = parameterNameAndValue[0];
                string parameterValue = parameterNameAndValue.Length > 1 ? parameterNameAndValue[1] : null;

                if (parameterName == "help")
                    return "1";

                if (!IsParameterNameAndValueValid(parameterName, parameterValue))
                    hasInvalidInput = true;
                
            }

            if (hasInvalidInput)
                return "-1";

            return "0";

        }

        private static bool IsParameterNameAndValueValid(string parameterName, string parameterValue)
        {
            switch (parameterName.ToLower())
            {
                case "name":
                    if (!NameIsValid(parameterValue))
                        return false;

                    break;
                case "count":
                    if (!CountIsValid(parameterValue))
                        return false;

                    break;
                default:
                    return false;
            }

            return true;

        }

        public static bool NameIsValid(string parameterValue)
        {
            if (parameterValue == null)
                return false;

            if (parameterValue.Length < 3 || parameterValue.Length > 10)
                return false;

            return true;
        }

        public static bool CountIsValid(string parameterValue)
        {
            int countValue = 0;

            if (Int32.TryParse(parameterValue, out countValue))
            {
                if (countValue < 10 || countValue > 100)
                    return false;
            }
            else
            {
                return false;
            }

            return true;
        }


    }
}
