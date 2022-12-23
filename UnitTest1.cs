using System;
using NUnit.Framework;

namespace stringcalculator;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BlankStringShouldReturn0()
    {
        var sut = new StringCalculator();

        int actual = sut.Add("");
        int expected = 0;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void NullStringShouldReturn0()
    {
        var sut = new StringCalculator();

        int actual = sut.Add(null);
        int expected = 0;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Single_Number_Should_Return_the_number()
    {
        var sut = new StringCalculator();

        int actual = sut.Add("5");
        int expected = 5;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void String_space_should_return_0()
    {
        var sut = new StringCalculator();

        int actual = sut.Add("                     ");
        int expected = 0;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Negative_number_should_return_itself()
    {
        var sut = new StringCalculator();

        int actual = sut.Add("-2");
        int expected = -2;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Garbage_characters_should_raise_exception()
    {
        var sut = new StringCalculator();
        Assert.Throws<ApplicationException>(() =>  sut.Add("asdfasdfsadf hello world "));
    }
    
    [Test]
    public void List_containing_1_and_2_should_return_3()
    {
        var sut = new StringCalculator();

        int actual = sut.Add("1,2");
        int expected = 3;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void List_containing_list_of_integers_should_return_their_sum()
    {
        var sut = new StringCalculator();

        int actual = sut.Add("5,5,1");
        int expected = 11;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void List_containing_list_of_integers_with_newline_delimiter_return_their_sum()
    {
        var sut = new StringCalculator();

        int actual = sut.Add($"5{Environment.NewLine}5{Environment.NewLine}1");
        int expected = 11;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void List_containing_list_of_integers_with_newline_and_comma_delimiters_return_their_sum()
    {
        var sut = new StringCalculator();

        int actual = sut.Add($"5{Environment.NewLine}5{Environment.NewLine}1,5");
        int expected = 16;
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void List_containing_list_of_integers_with_newline_delimiter_at_end_fails()
    {
        var sut = new StringCalculator();

        int actual = sut.Add($"5{Environment.NewLine}5{Environment.NewLine}1{Environment.NewLine}");
        int expected = 11;
        Assert.AreEqual(expected, actual);
    }
    

}