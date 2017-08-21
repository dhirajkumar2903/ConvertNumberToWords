using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AKQA.Common;
using System.Configuration;
using System.Text;

namespace AKQA.Service.Repository
{
    public class GetConvertedNumber : IGetWords
    {
        string[] _finalRange = ConfigurationManager.AppSettings[Constants.FinalRange].Split(',');
        string[] _tenSpacer = ConfigurationManager.AppSettings[Constants.TenSpacer].Split(',');
        string[] _elevenToNineteen = ConfigurationManager.AppSettings[Constants.ElevenToNineteen].Split(',');
        string[] _digits = ConfigurationManager.AppSettings[Constants.Digits].Split(',');
        public Response GetResponses(string name, string number)
        {
            string[] _splittedNumber = number.Split('.');
            Int32 _supportedRange = _finalRange.Count() * 3;
            if (_splittedNumber[0].Count() > _supportedRange || (_splittedNumber.Count() > 1 && _splittedNumber[1].Count() > _supportedRange))
            {
                throw new Exception("Pleaes enter smaller number");
            }
            StringBuilder sbConvertedWords = new StringBuilder();
            sbConvertedWords = sbConvertedWords.Append(ConvertWord(_splittedNumber[0])).Append("dollar");
            if (_splittedNumber.Count() > 1)
                sbConvertedWords = sbConvertedWords.Append(" and ").Append(ConvertWord(_splittedNumber[1])).Append(" cents");
            Response _response = new Response();
            _response.Name = name;
            _response.ConvertedNumber = sbConvertedWords.ToString();
            return _response;
        }

        private StringBuilder ConvertWord(string _number)
        {
            StringBuilder sbConvertedWords = new StringBuilder();
            Int32 _numericValue = Convert.ToInt32(_number);
            _number = _numericValue.ToString();
            if(_numericValue<=0)
            {
                return sbConvertedWords.Append(_digits[0]);
            }
            if (_number.Count() >= 3)
            {

                for (int i = 0; i <= _number.Count() / 3; i++)
                {
                    if (_numericValue < 100)
                    {
                        sbConvertedWords = GetFirstTwoDigits(_numericValue,i).Append(_finalRange[i]).Append(" ").Append(sbConvertedWords);
                    }
                    else
                    {
                        sbConvertedWords = GetPartialNumber(_numericValue % 1000, i).Append(sbConvertedWords);
                        _numericValue = _numericValue / 1000;
                    }
                    if (_numericValue <= 0)
                        break;
                }
            }
            else
            {
                sbConvertedWords = GetFirstTwoDigits(_numericValue,0);
            }

            return sbConvertedWords;
        }
        private StringBuilder GetPartialNumber(Int32 _numericNumber, int range)
        {
            StringBuilder sbPartialNumber = new StringBuilder();
            if (_numericNumber > 0)
            {
                StringBuilder sbLastTwodigits = new StringBuilder();
                if (_numericNumber.ToString().Count() >= 2)
                {
                    Int32 _firstTwoDigits = _numericNumber % 100;
                    sbLastTwodigits = GetFirstTwoDigits(_firstTwoDigits, range);
                    _numericNumber = _numericNumber / 100;
                }
                sbPartialNumber = sbPartialNumber.Append(_digits[_numericNumber]).Append(" ").Append(_finalRange[0]).Append(" ").Append(sbLastTwodigits);
                if (range > 0)
                {
                    sbPartialNumber.Append(_finalRange[range]).Append(" ").Append("and ");
                }
            }
            return sbPartialNumber;
        }

        private StringBuilder GetFirstTwoDigits(Int32 _firstTwoDigits, int range)
        {
            StringBuilder firstTwoDigits = new StringBuilder();
            if (_firstTwoDigits > 0)
            {
                if (_firstTwoDigits > 10 && _firstTwoDigits < 21)
                {
                    firstTwoDigits = firstTwoDigits.Append(_elevenToNineteen[(_firstTwoDigits % 10) - 1]).Append(" ");
                }
                else if (_firstTwoDigits <= 10 && range <= 0)
                {
                    firstTwoDigits = firstTwoDigits.Append(_digits[_firstTwoDigits]).Append(" ");
                }
                else if (_firstTwoDigits > 20)
                {
                    firstTwoDigits = firstTwoDigits.Append(_tenSpacer[(_firstTwoDigits / 10) - 2]).Append(" ");
                    if (_firstTwoDigits % 10 > 0)
                        firstTwoDigits = firstTwoDigits.Append(_digits[_firstTwoDigits % 10]).Append(" ");
                }
            }
            return firstTwoDigits;
        }
    }
}