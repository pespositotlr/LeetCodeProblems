using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;


// You are a developer at a software house and you need to wrte a simple parser of a configuration file. A sample configuration looks as follows:

//<div id = "standard_task_description" class="protected" style="height: 100%; overflow: auto;" tabindex="0"><div class="task-description__TaskContentWrapper-sc-380ibo-1 xtrBv task-description-content"><p>You are a developer at a software house and you need to wrte a simple parser of a configuration file.A sample configuration looks as follows:</p>
//<pre><code>UserName: admin;
//Password: super password;

//TimeToLive: 4;
//IsEnabled: true;
//</code></pre>
//<p>You can assume that:</p>
//<ul>
//<li>A configuration file will always have a format as above i.e.each non empty line will contain a key name, then a colon and then a value.</li>
//<li>Key names are case sensitive.</li>
//<li>A key value can be a bool (<code>true</code>, <code>false</code>), an integer(e.g. 1, -2, 44)  or a string.</li>
//<li>All values that are not bools or integers should be treated as strings.</li>
//<li>Integer values can be safely stored in a variable of type int.</li>
//<li>Integer values will be written as a series of digits and only digits + minus sign at the beginning for the negative numbers.</li>
//<li>A configuration file can contain empty lines.</li>
//<li>Neither a key name nor a value will contain a colon.</li>
//<li>Each line in a configuration file except empty lines has a semicolon at the end.</li>
//</ul>
//<p>Additional requirements:</p>
//<ul>
//<li>The parsing method should have the following signature <code>public dynamic Parse(string configuration);</code></li>
//<li>Every key name found in a configuration file should be exposed as a property of an object returned from a parser e.g. <code>var r = parser.Parse(s); Console.WriteLine(r.TimeToLive);</code>. These properties should be of an appropriate type i.e. bool, int or string.</li>
//<li>A parsing methods should throw an exception<code>ArgumentException</code> if a provided string is null or empty.</li>
//<li>The parser should trimmed all key names and all string values.</li>
//<li>If someone tries to read a property (a key) which was not found in a configuration file then an exception should be thrown (in the following way<code>throw new UnknownKeyException();</code>)</li>
//<li>If a key name is null or empty then an exception should be thrown(in the following way<code>throw new EmptyKeyException();</code>)</li>
//<li>If a key found in a configuration file cannot be used as a property in C# then an exception should be thrown (in the following way <code>throw new InvalidKeyException();</code>). You can assume that a key name is correct if and only if it consists of letters (a-z and A-Z), digits (0-9) and does not start with a digit.</li>
//<li> You should throw an exception(in the following way<code>throw new DuplicatedKeyException()</code>) if a duplicated key name is found in a configuration file.</li>
//</ul></div></div>

/*
Reuse the following exceptions:

- UnknownKeyException
- EmptyKeyException
- InvalidKeyException
- DuplicatedKeyException
*/
namespace DynamicObjectParser.Tests
{
    public class Parser : IParser
    {
        /*
        Here is an example input configuration to parse:

        UserName:admin;
        Password:""super%^&*333password;
        DNSName:SomeName;

        TimeToLive:4;
        ClusterSize:2;
        PortNumber:2222;

        IsEnabled:true;
        EnsureTransaction:false;
        PersistentStorage:false;
        */
        public dynamic Parse(string configuration)
        {
            //Split by lines
            var configurationArray = configuration.Split(new string[] { "\n" }, StringSplitOptions.None);

            ParsedObject outputObject = new ParsedObject();

            for (int i=0; i < configurationArray.Length; i++)
            {
                //Allow blank lines
                if (configurationArray[i].Length == 0)
                    continue;

                //Throw errors for malformed keys
                if (configurationArray[i].IndexOf(":") == -1)
                {
                    throw new InvalidKeyException();
                }

                string key = configurationArray[i].Substring(0, configurationArray[i].IndexOf(":"));

                if (key.Length == 0)
                {
                    throw new EmptyKeyException();
                }

                if (!outputObject.IsValidKey(key))
                {
                    throw new InvalidKeyException();
                } else
                {
                    string value = configurationArray[i].Substring(configurationArray[i].IndexOf(":") + 1).TrimStart().TrimEnd().TrimEnd(';');

                    if (value.Length == 0)
                        throw new ArgumentException();

                    //outputObject.SetProperty(key, value);
                    outputObject.SetPropertyDictionary(key, value);
                }
            }

            //I originally wrote this assuming only the example properties were possible, but based on the tests and one line it meant the dynamic object should allow "any" properties
            //So I probably failed based on not getting that part.
            //return outputObject;

            return outputObject.GetObjectFromDictionary();
        }
    }

    public static class AlphaNumericChecker
    {
        public static bool IsAlphaNum(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (!(char.IsLetter(str[i])) && (!(char.IsNumber(str[i]))))
                    return false;
            }

            return true;
        }

    }


    [Serializable]
    internal class UnknownKeyException : Exception
    {
        public UnknownKeyException()
        {
        }

        public UnknownKeyException(string message) : base(message)
        {
        }

        public UnknownKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class EmptyKeyException : Exception
    {
        public EmptyKeyException()
        {
        }

        public EmptyKeyException(string message) : base(message)
        {
        }

        public EmptyKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class DuplicatedKeyException : Exception
    {
        public DuplicatedKeyException()
        {
        }

        public DuplicatedKeyException(string message) : base(message)
        {
        }

        public DuplicatedKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatedKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class ParsedObject
    {
        public Dictionary<string, string> ParsedKeysAndValues = new Dictionary<string, string>();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DNSName { get; set; }
        public int? TimeToLive { get; set; }
        public int? ClusterSize { get; set; }
        public int? PortNumber { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? EnsureTransaction { get; set; }
        public bool? PersistentStorage { get; set; }

        /// <summary>
        /// Only properties of this type are considered valid properties
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsValidKey(string key)
        {
            var isAlphaNum = AlphaNumericChecker.IsAlphaNum(key);
            var verZero = key[0];
            var isFirstLetter = char.IsLetter(key[0]);
            var isPropertyNull = this.GetType().GetProperty(key).GetValue(this);
            if (isAlphaNum && isFirstLetter && isPropertyNull == null)
                return true;

            return false;
        }
        public void SetProperty(string key, string value)
        {
            var type = this.GetType();
            var property = type.GetProperty(key);
            if (property.GetValue(this) != null)
            {
                throw new DuplicatedKeyException();
            }
            if (property.PropertyType == typeof(Nullable<Int32>))
            {
                int num = 0;
                if (!int.TryParse(value, out num))
                    throw new InvalidOperationException("Value is not a number.");
                property.SetValue(this, num, null);
                return;
            } else if(property.PropertyType == typeof(Nullable<bool>))
            {
                bool boolValue = false;
                if (!bool.TryParse(value, out boolValue))
                    throw new InvalidOperationException("Bool is not true or false.");
                property.SetValue(this, boolValue, null);
                return;
            }

            property.SetValue(this, value, null);
        }

        public void SetPropertyDictionary(string key, string value)
        {
            if (ParsedKeysAndValues.ContainsKey(key))
                throw new DuplicatedKeyException();

            ParsedKeysAndValues.Add(key, value);
        }

        public dynamic GetObjectFromDictionary()
        {
            var eo = new ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;

            foreach (var kvp in ParsedKeysAndValues)
            {
                object outputValue = new object();

                var num = 0;
                var boolVal = false;
                if (int.TryParse(kvp.Value, out num))
                {
                    outputValue = num;
                } else if(bool.TryParse(kvp.Value, out boolVal))
                {
                    outputValue = boolVal;
                } else
                {
                    outputValue = kvp.Value;
                }

                eoColl.Add(new KeyValuePair<string, object>(kvp.Key, outputValue));
            }

            dynamic eoDynamic = eo;
            return eoDynamic;
        }

    }

    public interface IParser
    {
    }
}

