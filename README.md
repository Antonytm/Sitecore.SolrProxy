# Sitecore.CSSGridLayout

[![Build status](https://ci.appveyor.com/api/projects/status/2fiwv4i4e68bcb3q?svg=true)](https://ci.appveyor.com/project/Antonytm/sitecore-cssgridlayout)

[![](https://sonarcloud.io/api/project_badges/quality_gate?project=Sitecore.CSSGridLayout)](https://sonarcloud.io/dashboard/index/Sitecore.CSSGridLayout)

[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.CSSGridLayout&metric=coverage)](https://sonarcloud.io/component_measures?id=Sitecore.CSSGridLayout&metric=coverage)
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.CSSGridLayout&metric=code_smells)](https://sonarcloud.io/component_measures?id=Sitecore.CSSGridLayout&metric=code_smells) 
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.CSSGridLayout&metric=bugs)](https://sonarcloud.io/component_measures?id=Sitecore.CSSGridLayout&metric=bugs)
[![](https://sonarcloud.io/api/project_badges/measure?project=Sitecore.CSSGridLayout&metric=vulnerabilities)](https://sonarcloud.io/project/issues?id=Sitecore.CSSGridLayout&resolved=false&types=VULNERABILITY)

## Abstract:
CSS Grid Layout for Sitecore project. It allows you to get flexible grid for your Sitecore project. You can design grid that you want in the Experience Editor.

## Requirements:
Sitecore 8+ with [Dynamic Placeholders](https://www.nuget.org/packages/DynamicPlaceholders/) [Dynamic Placeholders MVC](https://www.nuget.org/packages/DynamicPlaceholders.Mvc/) Nuget packages.
Project is build following Helix principles, but you can use it in any Sitecore project.

## Browsers support
CSS Grid Layout [is supported](https://caniuse.com/#feat=css-grid) by modern browsers.

## How to use
1. Download Sitecore update package from [AppVeyor](https://ci.appveyor.com/project/Antonytm/sitecore-cssgridlayout)
2. Install it using update installation wizard /sitecore/admin/UpdateInstallationWizard.aspx
3. You will be able to insert "Container" component /sitecore/layout/Renderings/CSSGrid/Container. Amount of columns and rows is configurable using rendering parameters.
4. Inside placeholder under "Container" component you will be able to insert any amount of "Item" components /sitecore/layout/Renderings/CSSGrid/Item. Location(row/column) and size(rows/columns) is configurable using rendering parameters
(If this will be used sometime in production, I expect that all UI components will be compatible with Grid CSS. You will be able to place them inside container)
5. If you have any difficutlties, refer to [example](https://github.com/Antonytm/Sitecore.CSSGridLayout/tree/master/src/Project/Example/code) how to use it.
