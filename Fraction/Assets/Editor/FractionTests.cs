using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Assets.Scripts;

public class FractionTests
{

    [Test]
    public void FractionMultiplication_Test()
    {
        // ARRANGE
        var firstNumerator = 5;
        var secondNumerator = 2;
        var firstDenominator = 3;
        var secondDenominator = 7;
        var expectedFraction = "10/21";
        Fraction firstFraction, secondFraction;

        // ACT
        firstFraction = new Fraction(firstNumerator, firstDenominator);
        secondFraction = new Fraction(secondNumerator, secondDenominator);
        var result = firstFraction.times(secondFraction);

        // ASSERT
        Assert.That(result.ToString, Is.EqualTo(expectedFraction));
    }
    [Test]
    public void FractionDivision_Test()
    {
        // ARRANGE
        var firstNumerator = 5;
        var secondNumerator = 2;
        var firstDenominator = 3;
        var secondDenominator = 7;
        var expectedFraction = "35/6";
        Fraction firstFraction, secondFraction;

        // ACT
        firstFraction = new Fraction(firstNumerator, firstDenominator);
        secondFraction = new Fraction(secondNumerator, secondDenominator);
        var result = firstFraction.dividedBy(secondFraction);

        // ASSERT
        Assert.That(result.ToString, Is.EqualTo(expectedFraction));
    }
    [Test]
    public void FractionAddition_Test()
    {
        // ARRANGE
        var firstNumerator = 5;
        var secondNumerator = 2;
        var firstDenominator = 3;
        var secondDenominator = 7;
        var expectedFraction = "41/21";
        Fraction firstFraction, secondFraction;

        // ACT
        firstFraction = new Fraction(firstNumerator, firstDenominator);
        secondFraction = new Fraction(secondNumerator, secondDenominator);
        var result = firstFraction.plus(secondFraction);

        // ASSERT
        Assert.That(result.ToString, Is.EqualTo(expectedFraction));
    }
    [Test]
    public void FractionSubtraction_Test()
    {
        // ARRANGE
        var firstNumerator = 5;
        var secondNumerator = 2;
        var firstDenominator = 3;
        var secondDenominator = 7;
        var expectedFraction = "29/21";
        Fraction firstFraction, secondFraction;

        // ACT
        firstFraction = new Fraction(firstNumerator, firstDenominator);
        secondFraction = new Fraction(secondNumerator, secondDenominator);
        var result = firstFraction.minus(secondFraction);

        // ASSERT
        Assert.That(result.ToString, Is.EqualTo(expectedFraction));
    }
    [Test]
    public void FractionReduce_Test()
    {
        // ARRANGE
        var firstNumerator = 5;
        var secondNumerator = 5;
        var firstDenominator = 5;
        var secondDenominator = 5;
        var expectedFraction = "1/1";
        Fraction firstFraction, secondFraction;

        // ACT
        firstFraction = new Fraction(firstNumerator, firstDenominator);
        secondFraction = new Fraction(secondNumerator, secondDenominator);
        var result = firstFraction.times(secondFraction).reduced();

        // ASSERT
        Assert.That(result.ToString, Is.EqualTo(expectedFraction));
    }

}
