# Sitecore.SolrProxy

[![Build status](https://ci.appveyor.com/api/projects/status/jsjfx04v9u929os2?svg=true)](https://ci.appveyor.com/project/Antonytm/sitecore-solrproxy)

[![](https://sonarcloud.io/api/project_badges/quality_gate?project=Sitecore.SolrProxy)](https://sonarcloud.io/dashboard/index/Sitecore.SolrProxy)

[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.SolrProxy&metric=coverage)](https://sonarcloud.io/component_measures?id=Sitecore.SolrProxy&metric=coverage)
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.SolrProxy&metric=code_smells)](https://sonarcloud.io/component_measures?id=Sitecore.SolrProxy&metric=code_smells) 
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.SolrProxy&metric=bugs)](https://sonarcloud.io/component_measures?id=Sitecore.SolrProxy&metric=bugs)
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.SolrProxy&metric=vulnerabilities)](https://sonarcloud.io/project/issues?id=Sitecore.SolrProxy&resolved=false&types=VULNERABILITY)

## Abstract:

Tool for easy access to Solr admin console if you have access only to Sitecore CM.

## Requirements:
Sitecore 8+
Project is build following Helix principles, but you can use it in any Sitecore project.

## Pick version for your Sitecore

Pick latest 1.xxx version if you use Sitecore 8+. Pick latest 2.xxx version if you use Sitecore 9+ or Sitecore 10+.

## How to use
1. Download latest Sitecore update package from [AppVeyor](https://ci.appveyor.com/project/Antonytm/sitecore-solrproxy) or from [Github releases](https://github.com/Antonytm/Sitecore.SolrProxy/releases)
2. Install it using update installation wizard /sitecore/admin/UpdateInstallationWizard.aspx
3. Open url of Solr proxy https://yourwebsite/sitecore/shell/solr/ (https://yourwebsite/solr/ if you use version for Sitecore 8+)

### Optional steps
By default module injects to HttpRequestBegin pipeline. But you can reconfigure it by registering http handler.

4. Open *Web.config* file and add handler *configuration>system.webServer>modules*
        `<add verb="*" path="solr/*" type="Foundation.SorlProxy.SolrHandler, Foundation.SorlProxy" name ="SolrHandler" />`
5. Add *"/solr"* to IgnoreUrlPrefixes Sitecore setting (*Sitecore.config Sitecore>Settings>Setting[name="IgnoreUrlPrefixes"]*)
6. Disable *Foundation.Solr.Proxy.config* configuration file


## Possible issues

1. If nothing happened after installation of package(/sitecore/shell/solr/ url doesn't work), check that *App_Config\Include\Foundation\Foundation.Solr.Proxy.config* configuration is enabled
2. If you get "Too many redirects" then you have conflict with Solr console that requires trailing slash and your rewrite rules that force no trailing slash. Add rule that disable redirects for Solr console:

```
<rule name="Dont redirect Solr" stopProcessing="true">
  <match url="^solr(.*)" />
  <action type="None" />
</rule>
```
