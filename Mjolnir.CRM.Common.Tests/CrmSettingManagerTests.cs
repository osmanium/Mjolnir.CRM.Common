using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Mjolnir.CRM.Common.EntityManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.Tests
{
    [TestClass]
    public class CrmSettingManagerTests : CrmUnitTestBase
    {
        [TestMethod]
        public void should_create_new_crmsetting()
        {
            var crmSettingManager = new CrmSettingEntityManager(CrmContext);

            var crmSetting = new CrmSettingEntity();
            crmSetting.BoolSetting = true;
            crmSetting.DateTimeSetting = DateTime.Now;
            crmSetting.DecimalSetting = 100;
            crmSetting.IntSetting = 100;
            crmSetting.MoneySetting = new Money(100);
            crmSetting.SettingKey = "setting key";
            crmSetting.StringSetting = "string setting";
            //crmSetting.SystemUserSettingEntityReference = new EntityReference()

            crmSetting.Id = crmSettingManager.Create(crmSetting);

            Assert.AreNotEqual(Guid.Empty, crmSetting.Id);

            crmSettingManager.Delete(crmSetting.Id);
        }
    }
}
