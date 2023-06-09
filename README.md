# csharp-achieve

[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat&logo=git)](https://www.mit-license.org)
[![Visual Studio](https://img.shields.io/badge/VS-2022-brightgreen.svg?style=flat&logo=visualstudio)](https://visualstudio.microsoft.com/zh-hans/downloads/)
[![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.8-brightgreen.svg?style=flat&logo=.net)](https://dotnet.microsoft.com/zh-cn/download/dotnet-framework)
[![C#](https://img.shields.io/badge/C%23-7.3-brightgreen.svg?style=flat&logo=csharp)](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide)
[![.NET](https://img.shields.io/badge/.NET-7.0-brightgreen.svg?style=flat&logo=.net)](https://dotnet.microsoft.com/zh-cn/download/dotnet/7.0)
[![C#](https://img.shields.io/badge/C%23-11.0-brightgreen.svg?style=flat&logo=csharp)](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide)
[![Release](https://img.shields.io/badge/Release-0.8.0-blue.svg)](https://github.com/aaric/csharp-achieve/releases)

> C# Lang Learning.

## 1 Projects

|NO.|Project Name|SDK Version|Language Version|Remark|
|:---:|:---:|:---:|:---:|-----|
|1|`ConsoleLang`|`4.8`|`C# 7.3`|*C# Language Demo*|
|2|`DesktopWinForm`|`4.8`|`C# 7.3`|*C# WinForm Demo*|
|3|`DesktopWpfDotNetFx35`|`3.5`|`C# 6.0`|*C# WPF .NET Framework 3.5 Demo*|
|4|`DesktopWpfDotNetFx48`|`4.8`|`C# 7.3`|*C# WPF .NET Framework 4.8 Demo*|
|5|`DesktopWpfDotNet70`|`7.0`|`C# 11.0`|*C# WPF .NET 7.0 Demo*|

1. 语言基础（csharp）
2. 网络客户端（http/https/mqtt）
3. 解析文件（txt/xml/excel/json）
4. 定时调度（Quartz.NET）
5. 桌面开发技术（WinForm或WPF）
6. 制作安装包（可选）

## 2 NuGet (.NET_Framework v4.8)

### 2.1 Config

> `https://api.nuget.org/v3/index.json`

### 2.2 Packages

|NO.|SDK Version|Package Name|Package Version|Remark|
|:---:|:---:|:---:|:---:|-----|
|1|`4.8`|[`Newtonsoft.Json`](ConsoleLang/Lang/JsonPrinter.cs)|`13.0.3`||
|2|`4.8`|[`CommunityToolkit.Mvvm`](DesktopWpfDotNetFx48/MvvmWindow.xaml.cs)|`8.1.0`|*[`MvvmLight`](https://www.nuget.org/packages/MvvmLight) Deprecated*|
|3|`4.8`|[`BouncyCastle.Cryptography`](ConsoleLang/Lang/RsaPrinter.cs)|`2.1.1`||
|4|`7.0`|[`Microsoft.Data.Sqlite`](DesktopWpfDotNet70/SQLiteWindow.xaml.cs)|`7.0.5`||
|5|`7.0`|[`M2Mqtt`](DesktopWpfDotNet70/MqttWindow.xaml.cs)|`4.3.0`||
|6|`7.0`|[`Quartz`](DesktopWpfDotNet70/QuartzWindow.xaml.cs)|`3.6.2`||

## 3 WPF

### 3.1 Layout

- StackPanel
- WrapPanel
- DockPanel
- UniformGrid

### 3.2 Animation

- DoubleAnimation
- DoubleAnimationUsingPath
- DoubleAnimationUsingKeyFrames

## 4 Installer

> [Microsoft Visual Studio Installer Projects 2022](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2022InstallerProjects)  
> [C# 软件打包与制作安装向导](https://www.bilibili.com/video/BV1jA4y1S7kc)
