using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Mjolnir.CRM.Core.EntityManagers;
using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.Tests
{
    [TestClass]
    public class CrmSettingManagerTests : CrmUnitTestBase
    {
        public const string CRM_SETTING_KEY = "CRM Setting Key";

        [TestMethod]
        public void should_create_new_crmsetting()
        {
            var crmSettingManager = new CrmSettingManager(CrmContext);

            var crmSetting = new CrmSettingEntity();
            crmSetting.BoolSetting = true;
            crmSetting.DateTimeSetting = DateTime.Now;
            crmSetting.DecimalSetting = 100;
            crmSetting.IntSetting = 100;
            crmSetting.MoneySetting = new Money(100);
            crmSetting.SettingKey = CRM_SETTING_KEY;
            crmSetting.StringSetting = "string setting";
            //crmSetting.SystemUserSettingEntityReference = new EntityReference()
            //crmSetting.BusinessUnitSetting = new EntityReference()

            crmSetting.Id = crmSettingManager.Create(crmSetting);

            Assert.AreNotEqual(Guid.Empty, crmSetting.Id);
        }

        [TestMethod]
        public void should_delete_crmsetting()
        {
            var crmSettingManager = new CrmSettingManager(CrmContext);

            var crmSetting = crmSettingManager.GetCrmSettingByKey(CRM_SETTING_KEY);

            crmSettingManager.DeleteById(crmSetting.Id);

            var crmSetting_After_Delete = crmSettingManager.GetCrmSettingByKey(CRM_SETTING_KEY);

            Assert.AreNotEqual(null, crmSetting_After_Delete);
        }

        
    }
}
