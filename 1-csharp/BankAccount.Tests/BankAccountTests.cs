using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;

namespace BankAccount.Tests
{
    public class BankAccountTests
    {
        // C# has syntax for "attributes"
        // any class deriving from System.Attribute can be put in brackets before classes, interfaces, properties, fields, methods, method parameters, etc.
        // by themselves then don't do anything - but some code looks for those attributes using "reflection" and does something on that basis.

        //tests classes and methods should be very descriptive in what is being tested.
        //if we sort an empty list, it should still be empty
        [Fact]
        //classes should be detailed and preferrably give desired result
        public void EmptyListShouldSortToEmpty()
        {
            // arrange
            //    any necessary setup before the "act". Everything in this section is assumed to work correctly. (if possible/relevant, it should itself get other unit tests.)

            //--var sorter = new ProductSorter(); //These wont run, just following along.
            //--var emptyList = new List<Product>();

            // act 
            //    the specific thing (usually 1 method call) that this method is responsible for testing
            //--sorter.Sort(emptyList)

            // assert
            //      run checks as much as possible to verify the correct behavior.
            // in xUnit, user Asset static class.
            //--Assert.Empty(emptyList);

            // in case of an unhandled exception, the test is considered failed. 
        }
    }
}
