using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAddonLibary
{
    public enum ErrorResponse
    {
        ThrowWithExeption,
        ContinueWithErrorMessage
    }

    public static class ConsoleInput
    {
        // Get Int value methods

        public static int GetIntValue()
        {
            return GetIntValue(() => ConsoleLogs.SystemLog("Please enter the int value:"), ErrorResponse.ContinueWithErrorMessage);
        }

        public static int GetIntValue(Action message)
        {
            return GetIntValue(message, ErrorResponse.ContinueWithErrorMessage);
        }

        public static int GetIntValue(ErrorResponse type)
        {
            return GetIntValue(() => ConsoleLogs.SystemLog("Please enter the int value:"), type);
        }

        public static int GetIntValue(Action message, ErrorResponse type)
        {
            message.Invoke();
            int inputValue = 0;
            bool convertationIsDone = false;
            while (!convertationIsDone)
            {
                try
                {
                    inputValue = Convert.ToInt32(Console.ReadLine());
                    convertationIsDone = true;
                }
                catch (Exception exception)
                {
                    if (type == ErrorResponse.ContinueWithErrorMessage)
                    {
                        ConsoleLogs.ErrorLog("Failed to convert string to int. Please try again");
                    }
                    else if (type == ErrorResponse.ThrowWithExeption)
                    {
                        ConsoleLogs.ErrorLog(exception.Message);
                        throw;
                    }
                }
            }
            return inputValue;
        }

        // Get Double value methods

        public static double GetDoubleValue()
        {
            return GetDoubleValue(() => ConsoleLogs.SystemLog("Please enter the double value: "), ErrorResponse.ContinueWithErrorMessage);
        }

        public static double GetDoubleValue(Action message)
        {
            return GetDoubleValue(message, ErrorResponse.ContinueWithErrorMessage);
        }

        public static double GetDoubleValue(ErrorResponse type)
        {
            return GetDoubleValue(() => ConsoleLogs.SystemLog("Please enter the double value: "), type);
        }

        public static double GetDoubleValue(Action message, ErrorResponse type)
        {
            ConsoleLogs.SystemLog(message);
            double doubleValue = 0;
            bool convertationIsDone = false;
            while (!convertationIsDone)
            {
                try
                {
                    string stringValue = Console.ReadLine();
                    if (!string.IsNullOrEmpty(stringValue))
                    {
                        stringValue = stringValue.Replace('.', ',');
                        doubleValue = Convert.ToDouble(stringValue);
                        convertationIsDone = true;
                    }
                }
                catch (Exception exeption)
                {
                    if (type == ErrorResponse.ContinueWithErrorMessage)
                    {
                        ConsoleLogs.ErrorLog("Failed to convert string to double. Please try again");
                    }
                    else if (type == ErrorResponse.ThrowWithExeption)
                    {
                        ConsoleLogs.ErrorLog(exeption.Message);
                        throw;
                    }
                }
            }
            return doubleValue;
        }

        // Get Boolean value methods

        public static bool GetBooleanValue()
        {
            return GetBooleanValue(() => ConsoleLogs.SystemLog("Please enter the boolean value: "), ErrorResponse.ContinueWithErrorMessage);
        }

        public static bool GetBooleanValue(Action message)
        {
            return GetBooleanValue(message, ErrorResponse.ContinueWithErrorMessage);
        }

        public static bool GetBooleanValue(ErrorResponse type)
        {
            return GetBooleanValue(() => ConsoleLogs.SystemLog("Please enter the boolean value: "), type);
        }

        public static bool GetBooleanValue(Action message, ErrorResponse type)
        {
            ConsoleLogs.SystemLog(message);
            bool booleanValue = false;
            bool convertationIsDone = false;
            while (!convertationIsDone)
            {
                try
                {
                    booleanValue = Convert.ToBoolean(Console.ReadLine());
                    convertationIsDone = true;
                }
                catch (Exception exeption)
                {
                    if (type == ErrorResponse.ContinueWithErrorMessage)
                    {
                        ConsoleLogs.ErrorLog("Failed to convert string to bool. Please try again");
                    }
                    else if (type == ErrorResponse.ThrowWithExeption)
                    {
                        ConsoleLogs.ErrorLog(exeption.Message);
                        throw;
                    }
                }
            }
            return booleanValue;
        }

        public static string GetStringValue()
        {
            return GetStringValue(() => ConsoleLogs.SystemLog("Please enter the text: "), ErrorResponse.ContinueWithErrorMessage);
        }

        public static string GetStringValue(Action message)
        {
            return GetStringValue(message, ErrorResponse.ContinueWithErrorMessage);
        }

        public static string GetStringValue(Action message, ErrorResponse type)
        {
            ConsoleLogs.SystemLog(message);
            string userMessage = null;
            bool convertationIsDone = false;

            while (!convertationIsDone)
            {
                try
                {
                    string stringValue = Console.ReadLine();
                    if (!string.IsNullOrEmpty(stringValue))
                    {
                        convertationIsDone = true;
                        userMessage = stringValue;
                    }
                    else
                    {
                        ConsoleLogs.ErrorLog("Your string is null. Please try again");
                    }
                }
                catch (Exception exeption)
                {
                    if (type == ErrorResponse.ContinueWithErrorMessage)
                    {
                        ConsoleLogs.ErrorLog("Failed to get string. Please try again");
                    }
                    else if (type == ErrorResponse.ThrowWithExeption)
                    {
                        ConsoleLogs.ErrorLog(exeption.Message);
                        throw;
                    }
                }
            }
            return userMessage;
        }

    }
}
