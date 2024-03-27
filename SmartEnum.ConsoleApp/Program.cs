using SmartEnum.ConsoleApp.Enums;


CreditCard creditCardValue = CreditCard.Platinum;

var discound = creditCardValue switch
{
    CreditCard.Standard => 0.01,
    CreditCard.Platinum => 0.10,
    CreditCard.Premium => 0.20,
    CreditCard.Gold => 0.30,
    _ => throw new NotImplementedException()
};

CreditCard2 creditCardValue2 = CreditCard2.FromValue(2);
var discound2 = creditCardValue2.GetDiscountRate();

Console.WriteLine($"Credit card type: {creditCardValue2} discound: {discound2}");


var creditCard3 = CreditCard3.FromValue("Cuma 1");

Console.WriteLine(creditCard3.Name);