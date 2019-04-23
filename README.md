# Sitecore.SolrProxy

[![Build status](https://ci.appveyor.com/api/projects/status/jsjfx04v9u929os2?svg=true)](https://ci.appveyor.com/project/Antonytm/sitecore-solrproxy)

[![](https://sonarcloud.io/api/project_badges/quality_gate?project=Sitecore.SolrProxy)](https://sonarcloud.io/dashboard/index/Sitecore.SolrProxy)

[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.SolrProxy&metric=coverage)](https://sonarcloud.io/component_measures?id=Sitecore.SolrProxy&metric=coverage)
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.SolrProxy&metric=code_smells)](https://sonarcloud.io/component_measures?id=Sitecore.SolrProxy&metric=code_smells) 
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.SolrProxy&metric=bugs)](https://sonarcloud.io/component_measures?id=Sitecore.SolrProxy&metric=bugs)
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.SolrProxy&metric=vulnerabilities)](https://sonarcloud.io/project/issues?id=Sitecore.SolrProxy&resolved=false&types=VULNERABILITY)

## Abstract:


## Requirements:
Sitecore 8+
Project is build following Helix principles, but you can use it in any Sitecore project.

## How to use
1. Download Sitecore update package from [AppVeyor](https://ci.appveyor.com/project/Antonytm/sitecore-solrproxy)
2. Install it using update installation wizard /sitecore/admin/UpdateInstallationWizard.aspx
3. Open url of Solr proxy https://yourwebsite/solr

### Optional steps
By default module injects to HttpRequestBegin pipeline. But you can reconfigure it by registering http handler.

4. Open *Web.config* file and add handler *configuration>system.webServer>modules*
        `<add verb="*" path="solr/*" type="Foundation.SorlProxy.SolrHandler, Foundation.SorlProxy" name ="SolrHandler" />`
5. Add *"/solr"* to IgnoreUrlPrefixes Sitecore setting (*Sitecore.config Sitecore>Settings>Setting[name="IgnoreUrlPrefixes"]*)
