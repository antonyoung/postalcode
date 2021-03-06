[![Build Status](https://dev.azure.com/antonyoung/Validator/_apis/build/status/antonyoung.postalcode?branchName=master)](https://dev.azure.com/antonyoung/Validator/_build/latest?definitionId=3&branchName=master)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
## Postal code and IBAN validator and formatter (C#) .Net Standard

Validates and formats European postal codes, plus setup validating international bank account numbers (iban.)

### Intro

Started this little project in my spare time, for the reason that I noticed today (28 August 2019) at work that validation of Dutch postal codes is barely or none existent. 
The database contains postal codes as "1234", "1234aB", "1234-Ab", "1234abc", "1234-aBc", "xxxx" and so on, while only "[1-9]NNN AA" is valid. 
As always, how can I keep my life simple and it works, fast and reliable. While the solution is really simple as long you know your regular expressions.

Started as additional feature with an iban validator, as rules, as all European countries, except is Ierland correctly validated? Plus still have to think about how to implement formatters as postal codes, or as IBAN?

### Description

As a simple and fast European postal code and as a iban validator with simplistic formatters. 
Could be easily extended to add countries around the world or to have different types of formatting.

Technical: As validation regular expressions are used with group names. 
For formatting the postcode off the match groups in the regular expression are used. 
All countries with space or with hyphen or with prefix.
Are all validated correctly without, and will be automatically formatted in the correct way in case off with space, hyphen or prefix. 
With one exception Finland has two prefixes FI- / AX- without prefix FI- is choosen as default.
Default country as expected is for now The Netherlands.    

**Note:** - it does not validate, if it's an existing postal code!

Used the following website [publications.europa.eu](http://publications.europa.eu/code/en/en-390105.htm), as postal code rules and as guide lines in Europe. 
Source code works for all European countries as given on this website.
Not sure how valid the regular expressions are for the Alpha Numeric postal codes for the countires Ireland and UK?
I admit I just copied this from internet, I am not sure how this system works. 

Used the following website [en.wikipedia.org](https://en.wikipedia.org/wiki/International_Bank_Account_Number) as iban rules and as guide lines in Europe. 
 
### Prerequisites
```
* C# .NET Standard 2.1	  // => Validators
* C# .NET Core 3.1.0      // => Validators.Tests (xUnit) * With 333 tests => ~80 ms as test set.
```
### Code examples ( PostalcodeValidator )

* **Happy flow**
```csharp
bool isValid = new PostalcodeValidator()
   .TryValidate("1062GD", Countries.Netherlands, out string result); // => result = "1062 GD", isValid = true
```
* **Or as** 
```csharp
var test = new PostalcodeValidator(); 
test.TryValidate("1062GD", Countries.Netherlands, out string result);
test.IsValid;       // => true					
test.ErrorMessage   // => null
result              // => "1062 GD"
```
* **Unhappy flow ( has leading zero )**
```csharp
var test = new PostalcodeValidator(); 
test.TryValidate("0162GD", Countries.Netherlands, out string result);
test.IsValid;       // => false					
test.ErrorMessage   // => "Postal code \"0162GD\" is not valid. Use as example \"1234 AB\"."
result;             // => "0162GD"
```

### Code examples ( IbanValidator )

* **Happy flow**
```csharp
bool isValid = new IbanValidator()
   .TryValidate("NL71INGB1320949010", out string result); // => result = "NL71 INGB 1320 9490 10", isValid = true
```
* **Or as** 
```csharp
var test = new IbanValidator(); 
test.TryValidate("NL71INGB1320949010", out string result);
test.IsValid;			// => true					
test.ErrorMessage		// => null
test.AccountNumber		// => "1320949010"
test.Country			// => Countries.Netherlands
test.CheckDigits		// => 71
Test.NationalBankCode	        // => "INGB"
test.NationalBranchCode	        // => null
test.NationalCheckDigit	        // => null
result:                         // => "NL71 INGB 1320 9490 10"
```

## Authors

* **Anton Young** - *Initial work*

## License

This project is licensed for now under the GNU General Public License (GPL) License Lv3 - see the [LICENSE.md](LICENSE.md) file for details

### Acknowledgments
See also issues: [is:issue is:open check in:title](https://github.com/antonyoung/postalcode/issues?utf8=%E2%9C%93&q=is%3Aissue+is%3Aopen+check+in%3Atitle)

### Additional features
See also issues: [is:issue is:open feature in:title](https://github.com/antonyoung/postalcode/issues?utf8=%E2%9C%93&q=is%3Aissue+is%3Aopen+feature+in%3Atitle+)
