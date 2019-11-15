using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiStateBasedTesting.Tests
{
    public class UserManagementTestConventionsAttribute : AutoDataAttribute
    {
        public UserManagementTestConventionsAttribute() :
            base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
