using System;
using System.Fabric;
using System.Fabric.Description;

namespace CloudFabric.Library.Common.Utilities
{
    public class ConfigUtil
    {
        ConfigurationPackage _package;
        public ConfigUtil(StatefulServiceContext context)
        {
            Setup(context);
        }
        public ConfigUtil(StatelessServiceContext context)
        {
            Setup(context);
        }
        public string GetParameterValueFromConfig(string section, string parameter)
        {
            return _package.Settings.Sections[section].Parameters[parameter].Value;
        }

        void Setup(ServiceContext context)
        {
            _package = context.CodePackageActivationContext.GetConfigurationPackageObject("Config");
            context.CodePackageActivationContext.ConfigurationPackageModifiedEvent += this.CodePackageActivationContext_ConfigurationPackageModifiedEvent;
            this.UpdateConfigSettings(context.CodePackageActivationContext.GetConfigurationPackageObject("Config").Settings);
        }

        private void CodePackageActivationContext_ConfigurationPackageModifiedEvent(object sender, PackageModifiedEventArgs<ConfigurationPackage> e)
        {
            this.UpdateConfigSettings(e.NewPackage.Settings);
        }

        public virtual void UpdateConfigSettings(ConfigurationSettings settings)
        {
        }
        public string GetValue(ConfigurationSettings settings, string section, string parameter)
        {
            try
            {
                return settings.Sections[section].Parameters[parameter].Value;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
