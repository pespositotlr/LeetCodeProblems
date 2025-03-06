#pragma warning disable
using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using System.Threading;



/*
Virtual Credit Card Number Validation rules

Similar to credit card numbers, the digits in virtual card numbers and associated transaction numbers may seem random, but they actually carry meaning.
When a Capital One Virtual Credit Card is used, the data must be validated against certain business rules to arrive at a spend decision.  
These rules are applied to specific digits in the VCN and transaction id. 
Each transaction made with a VCN is assigned a unique eight (8) digit transaction id.

Basic rules for transaction id validation:

| Digit position (0-7)  | Purpose                         | Associated Rule                 |
|-----------------------|---------------------------------|---------------------------------|
| 7                     | Online Transaction Indicator    | 1 = true             0 = false  |
| 6                     | Authorization/Charge* Indicator | 0 = Authorization    1 = Charge |

* Authorization is a hold on funds (e.g. when checking into a hotel) vs. the charge of the bill owed/balance due (e.g. when checking out).

Basic rules for VCN validation:

| Digit position (0-15) | Purpose                    | Associated Rule            |
|-----------------------|----------------------------|----------------------------|
| 15                    | Merchant-Bound** Indicator | 1 = true    0 = false      |
| 14                    | Card Type                  | 0 = Visa    1 = Mastercard |
| 13                    | Multi-use** indicator      | 1 = true    0 = false      |

** Merchant-bound VCNs may only be used at a specified merchant.  Multi-use VCNs may be used for online or offline (card-not-present) transactions.

Visa transactions are valid when the VCN is merchant-bound and cannot be multi-use. 
The VCN can still be valid if the transaction is online and the amount is less than $100 as long as the transaction is not an authorization.

//Visa: merchant-bound == 1 && multi-use == 0 || online = 1 && value < 100 && ischarge (not authorize)

Mastercard transactions are valid when the amount is less than $100, the purchase is done online or in person, and the VCN is not merchant-bound.   
The VCN can still be valid if it is merchant-bound and the amount is more than $100.

//Mastercard: amount < 100 && merchant-bount = 0 || merchant-bound && amount > 100

Test Cases

Here are some of the test cases. Based on the rules, what is the expected response?

| vcnNumber        | transactionId	| transactionAmount  | Expected Response |
|------------------|----------------|--------------------|-------------------|
| 1234567891012|001 |    123451|01    |      $50           |         True      | Not multi-use, Visa, Merchant Bound    | Authorization, Online Transaction True
| 1234567891012|011 |    123451|10    |     $150           |         True         | Not Multi-use, Mastercard, Merchant-bound | Charge, Offline
| 1234567891012|110 |    123451|01    |      $50           |         True         | Multi-use, Master, Merchant-Bound False | Auth, Online
| 1234567891012|100 |    123451|11    |      $50           |         True         | Multi-use, Visa, Merchant-Bound False | Charge, Online
| 1234567891012|100 |    123451|01    |      $50           |         False         | Multi-use, Visa, Merchant-Bound False | Auth, Online


Extra section discussed at the end
All Visa Card Numbers start with a 4.  New Cards have 16 digits.  Old Cards have 13.

Mastercard Numbers either start with the numbers 51 through 55 or with the numbers 2221 through 2720.  All have 16 digits.

//If digit-count = 13
    return Visa
    
//Convert to string, and then check first 2 digits (5) then check second one for 1-5
//If first digit is (2) check next digits for Substring(1,3) convert to int is >= 221, <=720

I didn't mention this in the interview but probably the best/most obvious way is to convert to string and then do stringNumber[13] and so on to get that char.

*/

public class VcnTransactionValidator
{
    public static bool IsValidVcnTransaction(long vcnNumber, int transactionId, int transactionAmount)
    {
        string vcnNumberString = vcnNumber.ToString();
        string transactionIdString = vcnNumber.ToString();
        bool isMerchantBoundBool = Convert.ToBoolean(vcnNumberString[13]); //Alternative
        long cardTypeVersin2 = (long)vcnNumberString[14];

        long isMerchantBound = vcnNumber % 2;
        long cardType = (long)(Math.Floor(Convert.ToDouble(vcnNumber) / 10) % 2);
        long isMultiUse = (long)(Math.Floor(Convert.ToDouble(vcnNumber) / 100) % 2);
        long isMultiUse2 = (long)((Convert.ToDouble(vcnNumber) / 100) % 2);

        long isOnlineTransaction = transactionId % 2;
        long isAuth = (long)(Math.Floor(Convert.ToDouble(transactionId) / 10) % 2); //The trick with this one is 0 is true

        // Visa
        if (cardType == 0)
        {
            return (isMerchantBound == 1 && isMultiUse == 0) || (isOnlineTransaction == 1 && transactionAmount < 100 && isAuth == 1);
        }
        // Mastercard
        else if (cardType == 1)
        {
            return (transactionAmount > 100 && isMerchantBound == 1) || (transactionAmount < 100 && isMerchantBound == 0);
        }
        return false;
    }
}
